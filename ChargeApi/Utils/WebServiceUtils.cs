using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ChargeApi.Tools
{

    public class WebServiceUtils
    {
        public string SoapMethod(string nameSpace, string uri, string method, Hashtable iparams, bool hasSOAPAction = true)
        {
            HttpWebResponse res = null;
            string result = "";
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(uri);
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentType = "text/xml; charset=utf-8";
                if (hasSOAPAction)
                    httpWebRequest.Headers.Add("SOAPAction", "\"" + nameSpace + (nameSpace.EndsWith("/") ? "" : "/") + method + "\"");
                httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
                httpWebRequest.Timeout = 30000;

                byte[] sendData = EncodeParaToSoap(method, nameSpace, iparams);

                httpWebRequest.ContentLength = sendData.Length;
                Stream sw = httpWebRequest.GetRequestStream();
                sw.Write(sendData, 0, sendData.Length);
                sw.Close();
                res = (HttpWebResponse)httpWebRequest.GetResponse();
                StreamReader sr = new StreamReader(res.GetResponseStream() ?? throw new InvalidOperationException(), Encoding.UTF8);
                String retXml = sr.ReadToEnd();
                sr.Close();
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(retXml);
                XmlNamespaceManager mgr = new XmlNamespaceManager(doc.NameTable);
                mgr.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
                result = doc.SelectSingleNode("//soap:Body/*/*", mgr).InnerXml;
            }

            catch (WebException ex)
            {
                res = (HttpWebResponse)ex.Response;
                StreamReader sr = new StreamReader(res.GetResponseStream() ?? throw new InvalidOperationException(), Encoding.UTF8);
                result = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                result = "发送异常" + ex.Message;
            }
            return result;
        }

        public byte[] EncodeParaToSoap(string method, string nameSpace, Hashtable hparams)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"" +
                " xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" " +
                "xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"></soap:Envelope>");

            XmlDeclaration decl = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.InsertBefore(decl, doc.DocumentElement);

            XmlElement soapBody = doc.CreateElement("soap", "Body", "http://schemas.xmlsoap.org/soap/envelope/");
            XmlElement soapMethod = doc.CreateElement(method);
            soapMethod.SetAttribute("xmlns", nameSpace);
            if (hparams != null)
            {
                foreach (string k in hparams.Keys)
                {
                    XmlElement soapPar = doc.CreateElement(k);
                    soapPar.InnerXml = ObjectToSoapXml(hparams[k]);
                    soapMethod.AppendChild(soapPar);
                }
            }
            soapBody.AppendChild(soapMethod);
            doc.DocumentElement.AppendChild(soapBody);
            return Encoding.UTF8.GetBytes(doc.OuterXml);
        }

        private static string ObjectToSoapXml(object o)
        {
            XmlSerializer mySerializer = new XmlSerializer(o.GetType());
            MemoryStream ms = new MemoryStream();
            mySerializer.Serialize(ms, o);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Encoding.UTF8.GetString(ms.ToArray()));
            if (doc.DocumentElement != null)
            {
                return doc.DocumentElement.InnerXml;
            }
            else
            {
                return o.ToString();
            }
        }
    }
}
