using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TsinghuaPerformanceAPI
{

    class ShowList
    {
        public
            static int page = 1;
        public static List<PerformanceData> GetListShow()
        {
            //这里只有第一页
            string html = ("http://www.hall.tsinghua.edu.cn/columnEx/pwzx_hdap/yc-dy-px-zl-jz/"+ page.ToString());
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);
            var htmlNodes = htmlDoc.DocumentNode.SelectNodes("/html/body/div[2]/div/div[2]/div/div");//timelist
            var InnerTest = htmlNodes[0].InnerHtml;
            Regex.Replace(InnerTest, "::after", "");//Remove after using System.Text.RegularExpressions;
            var doc = new HtmlDocument();
            doc.LoadHtml(InnerTest);
            var ListNodes = doc.DocumentNode.SelectNodes("/div");
            //ParseDataHere
            //int j = ListNodes.Count;

            var Data = new List<PerformanceData>();
            for (int i = 1; i < ListNodes.Count; i++)
            {
                string PerDay = ListNodes[i].ChildNodes[1].ChildNodes[3].ChildNodes[1].ChildNodes[0].InnerText; //演出的日
                string PerDate = ListNodes[i].ChildNodes[1].ChildNodes[3].ChildNodes[1].ChildNodes[1].InnerText; //演出的年/月
                string PerHour = ListNodes[i].ChildNodes[1].ChildNodes[3].ChildNodes[1].ChildNodes[3].InnerText;//演出在几点
                PerHour = PerHour.Replace(" ","");
                string PerTime = PerDate + "-"+ PerDay + "    "+ PerHour;
                PerTime = PerTime.Replace("\r", "");
                PerTime = PerTime.Replace("\n", "");
                PerTime = PerTime.Replace("\t", "");
                string PerName = ListNodes[i].ChildNodes[1].ChildNodes[5].ChildNodes[1].InnerText;
                string PerAddress = ListNodes[i].ChildNodes[1].ChildNodes[5].ChildNodes[5].InnerText;
                string PerState = ListNodes[i].ChildNodes[1].ChildNodes[5].ChildNodes[7].InnerText;
                PerState = PerState.Replace("\r","");
                PerState = PerState.Replace("\n", "");
                PerState = PerState.Replace("\t", "");
                Data.Add(new PerformanceData
                {
                    PerformanceTime = PerTime,
                    PerformanceName = PerName,
                    PerformanceAddress = PerAddress,
                    PerformanceState = PerState
                }
                );
                int j = ListNodes.Count;
            }
            return Data;
        }
    }

    public class PerformanceData
    {
        public string PerformanceName;
        public string PerformanceTime;
        public string PerformanceAddress;
        public string PerformanceState;
        //int page;
    }


}
