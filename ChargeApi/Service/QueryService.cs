using ChargeApi.Entities;
using ChargeApi.IService;
using ChargeApi.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace ChargeApi.Service
{
    public class QueryService : IQueryService
    {
        public Task<Tuple<bool, X18J52,string>> Query18J52(X18J52 x18J52)
        {
           return Task.Run(() =>
            {
                bool succ = false;
                X18J52 resp_18J52 = null;
                string msg = "查询失败!";
                try
                {
                    //Hashtable hashtable = new Hashtable();
                    //string queryxml = $"<?xml version=\"1.0\" encoding=\"GBK\"?><root><QueryCondition><hphm>{x18J52?.hphm}</hphm>" +
                    //    $"<hpzl>{x18J52?.hpzl}</hpzl><clsbdh>{x18J52?.clsbdh}</clsbdh><dly>{x18J52?.dly}</dly><dlysfzh></dlysfzh></QueryCondition></root>";
                    //hashtable.Add("xtlb", "18");
                    //hashtable.Add("jkxlh", "");
                    //hashtable.Add("jkid", "18J52");
                    //hashtable.Add("xmlDoc", queryxml);
                    //WebServiceUtils webServiceTools = new WebServiceUtils();
                    //var respXml = HttpUtility.HtmlDecode(webServiceTools.SoapMethod(AppHelper.AppSetting.Namespace, AppHelper.AppSetting.WebServiceUrl, "queryObjectOut", hashtable));
                    var respXml = "<?xml version=\"1.0\" encoding=\"utf - 8\"?><root><head><code>1</code><message>获取机动车上线登录信息成功</message><rownum>1</rownum></head><body><vehispara><jylsh>110002190227002940101</jylsh><jcxdh>1</jcxdh><xh>11010013239237</xh><hpzl>02</hpzl><hphm>京PWG759</hphm>" +
                        "<clsbdh>LS4ASB3RXDA636379</clsbdh><fdjh>D30J018164</fdjh><csys>B</csys><syxz>A</syxz><rlzl>A</rlzl><gl>72.0</gl><zs>2</zs><zj>2605</zj><qlj>1425</qlj><hlj>1435</hlj><zzl>1880</zzl><zbzl>1175</zbzl><ccrq>2013-02-25 00:00:00.000</ccrq><qdxs>1</qdxs><zczs>1</zczs>" +
                        "<zczw>2</zczw><zzs>2</zzs><zzly>0</zzly><qzdz>03</qzdz><ygddtz>0</ygddtz><zxzxjxs>0</zxzxjxs><lcbds>177267</lcbds><jyxm>F1,H1,H4,B1,B2,B0,DC,C1</jyxm><jylb>01</jylb><bhgx/><jycs>1</jycs><clpp1>长安牌</clpp1><clxh>SC6418HVB5</clxh><syr>曹洪喜</syr>" +
                        "<cllx>K39</cllx><cwkc>4110</cwkc><cwkk>1690</cwkk><cwkg>1930</cwkg><clyt>P1</clyt><ytsx>9</ytsx><clsslb>01</clsslb><wjbhgx/><wjjywhx/><dpbhgx/><dpjywhx/><dtdpbhgx/><dtdpjywhx/><wjpd>1</wjpd><dppd>0</dppd><dtdppd>0</dtdppd><wjy>李冬</wjy>" +
                        "<dpjyy/><dtdpjyy/><zkrs>5</zkrs><ccdjrq>2013-03-15 00:00:00.000</ccdjrq><Hdzzl>0</Hdzzl><pdyj>2</pdyj><xbwjbhgx/><xbdpbhgx/><xbdtdpbhgx/><qzs>1</qzs><ywcjyxm>F1</ywcjyxm><rgwjxm>OOOOO---O------OOOOOOOO------------------</rgwjxm><rgdtdpxm>OOOO</rgdtdpxm>" +
                        "</vehispara></body></root>";
                    var code = Utils.RegexUtils.MatchField(respXml, "code", false);
                    if ("1" == code)
                    {
                        resp_18J52 = Utils.RegexUtils.XmlToModelByName<X18J52>(respXml);
                        msg = Utils.RegexUtils.MatchField(respXml, "message", false);
                        succ = true;
                    }
                    else if (string.IsNullOrEmpty(code))
                    {
                        msg += respXml;
                    }
                    else
                    {
                        msg += Utils.RegexUtils.MatchField(respXml, "message", false);
                    }

                }
                catch (WebException wex)
                {
                    succ = false;
                    msg = wex.Message;
                }
                catch (Exception ex)
                {
                    succ = false;
                    msg = ex.Message;
                }
                return new Tuple<bool, X18J52, string>(succ, resp_18J52, msg);
            });
        }
    }
}
