using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace fileSearch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;//允许在多线程中更改UI
            label2.Text = "";

        }

        //int mod = 0;
        Boolean ting = false;
        string version = "1.3";
        string IPnew;
        int IPT = 0;
        string history = "";
        //textBox中的文字是否被全部选中
        int  numOftextBoxClicked= 0;
        int numOfHtmlPage = 0;
        int num = 0;
        int pagePercent = 1;
        Boolean oldThreadIsRunning = false;
        int pageNumOfEachThread = 2;//每个线程读取页面数
        Boolean IPisBad = false;

        public void threadLoadNextPage()
        {

            //if (oldThreadIsRunning)
            //{
            //    MessageBox.Show("请等待搜索完成！", "提示！", MessageBoxButtons.OK);
            //    return;
            //}
            buttonNextPage.Visible = false;//显示该按钮
            oldThreadIsRunning = true;
            string url;
            if (IPT == 1)
            {
                url = "http://" + IPnew;
            }
            else
            {
                url = "http://209.85.228.22";
            }

            while ((numOfHtmlPage < pageNumOfEachThread * pagePercent) && (pagePercent <= 17))
            {             
                try
                {

                    if (ting)
                    {
                        ting = false;
                        break;

                    }


                    htmlBasicFunction hhh = new htmlBasicFunction();
                    string str = textBox1.Text;
                    str = hhh.ifCSharp(str);


                    url = url + "/custom?q=" + str + "&newwindow=1&sitesearch=pan.baidu.com&hl=zh-CN&prmd=ivns&ei=XS22VJ7EJoingwSq8ICYBQ&start=" + numOfHtmlPage++ * 10 + "&sa=N";
                    string html = hhh.getHtml(url);
                    label2.Text = "";
                    IPisBad = true;//IP未被封


                    string[][] res = null;
                    res = hhh.fileDeteil(html, 0);


                    for (int k = 0; k < res.Length; k++)
                    {
                        //从新建的tabpage中取出listview控件并操作它，使显示搜索结果
                        //ListView listview = tabControl1.TabPages[tabControl1.TabCount - 1].Controls[0] as ListView;
                        ListView listview = tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0] as ListView;
                        res[k][0] = (num+1) + " " + res[k][0];
                        listview.Items.AddRange(new ListViewItem[] { new ListViewItem(res[k]) });
                        num++;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("你的IP被服务器禁止了，稍等一两小时后恢复正常", "提示！", MessageBoxButtons.OK);
                    break;
                }

            }


            if (pagePercent <= 16)
            {
                pagePercent++;
            }
            else
            {
                MessageBox.Show("这是最后一页了", "提示！", MessageBoxButtons.OK);
            }

            label2.Text = "搜索到"+num+"个资源";
            buttonNextPage.Visible = true;//显示该按钮
            oldThreadIsRunning = false;

        }


        public void check()
        {
            htmlBasicFunction hhh = new htmlBasicFunction();
            string html = hhh.getHtml("http://qingshiluogu.lingd.cc/article-6388958-1.html");
            string tz = hhh.tongZhi(html);
            string ip = hhh.IP(html);
            string sj = hhh.shengJi(html);
            string mail = hhh.theTT(html, "mail");

            bool tzT = hhh.isTrue(tz);
            bool ipT = hhh.isTrue(ip);
            bool sjT = hhh.isTrue(sj);
            string tzV = hhh.theValue(tz);
            string ipV = hhh.theValue(ip);
            string sjV = hhh.theValue(sj);
            bool mailT = hhh.isTrue(mail);
            sjV = hhh.GetTextMid(sjV, ">", "</a>").Trim();
            string ver = hhh.theTT(sj, "version");
            int daxiao = string.Compare(ver, version);
            string sjXiangqing = hhh.theTT(sj, "详情");


           // MessageBox.Show(sj, "通知！", MessageBoxButtons.OK);
            try
            {
                if (hhh.ping() == 0)
                {
                    MessageBox.Show("您的网络没有连接好或者网络较慢", "出错", MessageBoxButtons.OK);
                    return;                    
                } 

            }
            catch
            {
                MessageBox.Show("您的网络没有连接好或者网络较慢", "出错", MessageBoxButtons.OK);
                return;
                }
         
            try
            {
                if (tzT == true && tzV != "error")
                {
                    MessageBox.Show(tzV, "通知！", MessageBoxButtons.OK);
                }
                if (sjT == true && (daxiao > 0 || ver == "all") && sjV != "error")
                {
                    MessageBox.Show("最新版本为" + ver + ",您的版本需要升级了！O(∩_∩)O~\r\n\r\n" + sjXiangqing, "通知！", MessageBoxButtons.OK);
                    Process.Start(sjV);

                }
                if (ipT == true)
                {
                    IPnew = ipV;
                    IPT = 1;
                }
            }
            catch
            {
                MessageBox.Show("读取通知及升级信息失败，请联系我并报告此异常状况 O(∩_∩)O", "出错", MessageBoxButtons.OK);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                buttonNextPage.Visible = false;
                htmlBasicFunction hhh = new htmlBasicFunction();
                this.Text += version;               
                new Thread(check).Start();
                //给右键菜单添加处理程序
                contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(myContextMenuStripItem_Click);
            }
            catch (Exception ed)
            {
                MessageBox.Show("Form1_Load 出错，请联系我报告这个问题", "出错", MessageBoxButtons.OK);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            pagePercent = 1;//重置页面记录
            num = 0;
            numOfHtmlPage = 0;//设置页面为0
            //点击搜索按钮后，设置文本框的点击次数为零
            numOftextBoxClicked = 0;

            if (oldThreadIsRunning)
            {
                MessageBox.Show("请等待搜索完成！", "提示！", MessageBoxButtons.OK);
                return;
            }
           
            string str = textBox1.Text.Trim();
            if (str == "")
            {
                MessageBox.Show("关键字不能为空", "提示！", MessageBoxButtons.OK);
                textBox1.Text = "";
            }

            else
            {
                try
                {
                    buttonNextPage.Visible = true;//显示该按钮
                    history += str + ";";
                    //MessageBox.Show(history, "提示！", MessageBoxButtons.OK);
                       
                    label2.Text = "基于谷歌搜索，如搜索无结果，稍等几小时后会恢复正常";
    
                    TabPage tabPage = new TabPage();
                    tabPage.Width = 639;
                    tabPage.Height = 381;
                    tabPage.Text = textBox1.Text.Trim();
                    //tabPage.MouseDoubleClick += new MouseEventHandler(myTabPage_DoubleClick);
                    tabControl1.TabPages.Add(tabPage);
                    ListView listview = new ListView();
                        
                    //为其设置右键菜单
                    listview.ContextMenuStrip = contextMenuStrip1;
                    listview.Width = 639;
                    listview.Height = 381;
                    listview.View = View.Details;
                    listview.Columns.Add("文件名", 500, HorizontalAlignment.Left); //一步添加
                    listview.Columns.Add("文件大小", 110, HorizontalAlignment.Center); //一步添加
                    listview.Columns.Add("url", 0, HorizontalAlignment.Left); //一步添加
                    listview.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    //给新建的listview动态添加双击事件
                    listview.DoubleClick += new EventHandler(this.newListView_DoubleClick);
                    tabPage.Controls.Add(listview); 
                    tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabPage);               
                    new Thread(threadLoadNextPage).Start();
                }
                catch (System.Exception ex)
                {
                    System.Environment.Exit(System.Environment.ExitCode);
                }
            }

        }

        private void newListView_DoubleClick(object sender, EventArgs e)
        {
            //设置文本框被点击次数为零
            numOftextBoxClicked = 0;
            ListView listview = (ListView)sender;
            Process.Start(listview.SelectedItems[0].SubItems[2].Text);
            
        }


        //为listview的item添加右键菜单选择
        private void myContextMenuStripItem_Click(object sender,ToolStripItemClickedEventArgs e)
        {
            if (((ContextMenuStrip)sender).Items[0] == e.ClickedItem)
            {
                string url=null;
                //如果选择的是 复制网址
                ListView listview = (ListView)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
                url = listview.SelectedItems[0].SubItems[2].Text;
                Clipboard.SetDataObject(url);
            }
            if (((ContextMenuStrip)sender).Items[1] == e.ClickedItem)
            {
                string text = null;
                //如果选择的是 复制网址和文件名

                ListView listview = (ListView)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
                text = listview.SelectedItems[0].SubItems[0].Text + System.Environment.NewLine + listview.SelectedItems[0].SubItems[2].Text;

                if (listview.SelectedItems.Count > 1)
                { 
                    for(int i=1;i<listview.SelectedItems.Count;i++)
                        text += System.Environment.NewLine + listview.SelectedItems[i].SubItems[0].Text + System.Environment.NewLine + listview.SelectedItems[i].SubItems[2].Text;
                }
                Clipboard.SetDataObject(text);
            }

            if (((ContextMenuStrip)sender).Items[2] == e.ClickedItem)
            {                
                //如果选择的是  打开下载页面
                ListView listview = (ListView)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];           
                for (int i = 0; i < listview.SelectedItems.Count; i++)
                    Process.Start(listview.SelectedItems[i].SubItems[2].Text);          
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

            System.Environment.Exit(0);
        }

        //当选择不同的选项卡时，文本框装载对应的关键字
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = tabControl1.TabPages[tabControl1.SelectedIndex].Text;
            //设置文本框被点击次数为零
            numOftextBoxClicked = 0;
            label2.Text = "";//设置 无显示
        }


        //实现双击删除选项卡操作
        private void tabControl1_DoubleClick(object sender, EventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            TabPage tabpage = tabControl.TabPages[tabControl.SelectedIndex];
            if (tabControl.TabPages.Count > 1)
                tabControl.TabPages.Remove(tabpage);
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
        }

        //实现鼠标单击文本框时选中所有文字
        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            numOftextBoxClicked++;
            //如果是点击搜索按钮之后第一次点击文本框，才选中所所有文字
            if (numOftextBoxClicked == 1)
            { 
                textBox1.SelectionStart = 0;
                textBox1.SelectionLength = textBox1.Text.Length;
                textBox1.SelectAll();
            }
           
        }

        //点击 加载下一页按钮时
        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            if (oldThreadIsRunning)
            {
                MessageBox.Show("请等待搜索完成！", "提示！", MessageBoxButtons.OK);
                return;
            }
            new Thread(threadLoadNextPage).Start();
        }
    }
}
