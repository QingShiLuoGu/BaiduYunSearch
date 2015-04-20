using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace fileSearch
{
    class htmlBasicFunction
    {
        int Timeout = 2000;//设置连接超时
        
   
        public string GetTextMid(string t, string k, string j)//截取指定文本，和易语言的取文本中间差不多
        {
            try//异常捕捉
            {
                int kn = t.IndexOf(k) + k.Length;
                int jn = t.IndexOf(j, kn);

                return t.Substring(kn, jn - kn);
            }
            catch (Exception e)//如果发现未知的错误，比如上面的代码出错了，就执行下面这句代码
            {

                return e.Message;
                //   return "截取指定文本发现异常错误！";//返回错误
                // Console. e.Message;
            }


        }


        /*
         该方法用于将谷歌搜索的结果页分片，每一片包含单项结果的详细信息，如文件名，文件大小等,返回它们
         */
        public string[][] fileDeteil(string html,int jing)
        {
            String[] Data = Regex.Split(html, "<h2 class=\"r\">", RegexOptions.IgnoreCase);
            int len = Data.Length;
            string[][] result = new string[len-1][];
           // string qian;
            int j = 0;


            for (int i = 0; i < Data.Length; i++)
            {
                if (i > 0)
                {
                    string[] ul = new string[3];
                    string text = Data[i];
                    ul[2] = GetTextMid(text, "class=\"l\" href=\"", "\" onmousedown=");
                    ul[2] = cutUrl(ul[2]);
                    //qian = ul[2] + "\">";
                    ul[0] = GetTextMid(text, "target=\"_blank\">", "</a></h2>");
                    //ul[0] = GetTextMid(text, qian, "</a>");
                    if ((ul[0].IndexOf("百度云") == 0  || ul[0].Contains("的分享")) && jing == 1)
                        continue;
                    ul[0] = cutString1(ul[0]);
                    ul[0] = cutString2(ul[0]);
                    ul[1] = getFileDaxiao(text);
                    result[j++] = ul;
                }

            }
            //MessageBox.Show(result[5][1], "提示！", MessageBoxButtons.OK);

            return result;
        }

        /*
            该函数用于去除文件名中的无关文字。
         */
        public string cutString1(string str)
        {
            int pos;
            //string ans;

            try
            {
                if (str.Substring(0, 5) != "百度云网盘")
                {
                    if (str.Substring(str.Length-1,1) == "等")
                    {
                        return str.Substring(0,str.Length-2);
                    }
                    else
                    {
                        pos = str.IndexOf("_免");
                        if (pos != -1)
                            str = str.Substring(0, pos);
                        return str;
                    }
                  
                }
                else
                {
                    int p = str.IndexOf("-");
                    int pp = str.IndexOf("的分享");
                   // Console.WriteLine("!!!!!!!!!!!!!!!!!!" + p + "  " + pp + "  " + (pp+3-p));
                    if (pp != -1)
                    {
                        string s = str.Substring(p + 1, pp + 2 - p);
                        return s;
                    }

                    return str;

                }
            }
           catch(Exception e)
           {
               return "字符串处理错误： "+e.Message;
           }

         //   Console.WriteLine("百度云".Substring(0,1));

          //  return str;
            
        }

        /*
            该方法用于去除文件名中的“<b>关键字</b>”中的非中文符号。
         *  有的字符串中不知包含一套此符号，故循环操作。
         */
        public string cutString2(string str)
        {
            int s, e,len;

            while (str.IndexOf("<b>") != -1)
            { 
                try
                {
                    len = str.Length;
                    s = str.IndexOf("<b>");
                    e = str.IndexOf("</b>");

                    str = str.Substring(0, s) + str.Substring(s+3,e-s-3) + str.Substring(e + 4, len - e - 4);

                }
                catch (Exception ex)
                {
                    return "字符串切割异常  "+ex.Message;
                }
            }
          

            return str;
            
        }

        public string getFileDaxiao(string text)
        {
            int flag1 = text.IndexOf("下载(");
            int flag2 = text.IndexOf("文件大小");


            try
            {
                if (flag2 != -1)
                {
                    return GetTextMid(text, "文件大小:", " ");
                }
                if (flag1 != -1)
                {
                    return GetTextMid(text, "下载(", ")");
                }
                return "--";

            }
            catch (Exception e)
            {
                return "文件大小获取异常： " + e.Message;
            }
           
            
        }


        public string getHtml(string url)//用程序模拟浏览器，将减少被发现为爬虫的几率，此为geihtml函数的升级版
        {

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            //req.Timeout = Timeout;
            req.Method = "GET";
            req.Accept = "text/html";
            req.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/4.0)";
            string html = null;
            try
            {

                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                using (StreamReader reader = new StreamReader(res.GetResponseStream()))
                {
                    html = reader.ReadToEnd();
                 
                }
                req.Abort();
               
            }
            catch (WebException we)
            {
                Console.WriteLine(we.Message);
            }
            return html;

        }

        public string ifCSharp(string txt)//假如关键字含有“#”字样，直接提交将不被识别，故需要转换“#”为“%23”
        {
            while (txt.IndexOf("#") != -1)
            {
                txt = txt.Substring(0, txt.IndexOf("#")) + "%23" +  txt.Substring(txt.IndexOf("#") + 1, txt.Length - 1 - txt.IndexOf("#"));
            }
            while (txt.IndexOf("+") != -1)
                txt = txt.Replace("+", "%2b");

            return txt;
            
        }

        public string  getNumOfResult(string html)//用于获取搜索结果个数
        {
            string res = GetTextMid(html, "约", "条");

            return res;
        }

        public string cutUrl(string url)
        {
            while (url.IndexOf("amp;") != -1)
            {
                url = url.Substring(0, url.IndexOf("amp;")) + '&'+ url.Substring(url.IndexOf("amp;") + 4, url.Length - 4 - url.IndexOf("amp;"));
            }

            return url;
        }

        public string tongZhi(string html)
        {
            string tz = GetTextMid(html, "【通知】", "【/通知】");
            if (tz != null)
                return tz;
            return "error";
        }

        public string IP(string html)
        {
            string tz = GetTextMid(html, "【IP】", "【/IP】");
            if (tz != null)
                return tz;
            return "error";
        }

        public string shengJi(string html)
        {
            string tz = GetTextMid(html, "【升级】", "【/升级】");
            if (tz != null)
                return tz;
            return "error";
        }


        public bool isTrue(string tz)
        {
            string T = GetTextMid(tz, "【T】", "【/T】");
            if (T.Trim() == "1")
                return true;
            return false;
        }

        public string  theValue(string tz)
        {
            string T = GetTextMid(tz, "【V】", "【/V】");
            if (T.Trim() != null)
                return T.Trim();
            return "error";
        }
        public string theTT(string tz,string sh)
        {
            string T = GetTextMid(tz, "【"+sh +"】", "【/"+sh+"】");
            if (T.Trim() != null)
                return T.Trim();
            return "error";
        }
        public  int ping()
        {
            Ping p = new Ping();
            PingReply pr;

            pr = p.Send("202.108.22.5");//百度的IP
            if (pr.Status != IPStatus.Success)//如果连接不成功
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        string getNum(string s)
        {
            return s.Substring(s.LastIndexOf('\\') + 1, s.Length - s.LastIndexOf('\\') - 1);
        }
       

    }
}
