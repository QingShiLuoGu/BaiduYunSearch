namespace fileSearch
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_copy_url = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_copy_url_title = new System.Windows.Forms.ToolStripMenuItem();
            this.打开下载页面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonNextPage = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "关键字：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(92, 25);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(355, 29);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseDown);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(516, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "搜索";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(18, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "小提示：点击右键或双击下载！";
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(16, 93);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(639, 390);
            this.tabControl1.TabIndex = 6;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            this.tabControl1.DoubleClick += new System.EventHandler(this.tabControl1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_copy_url,
            this.toolStripMenuItem_copy_url_title,
            this.打开下载页面ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(197, 70);
            // 
            // toolStripMenuItem_copy_url
            // 
            this.toolStripMenuItem_copy_url.Name = "toolStripMenuItem_copy_url";
            this.toolStripMenuItem_copy_url.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItem_copy_url.Text = "复制下载地址";
            this.toolStripMenuItem_copy_url.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripMenuItem_copy_url_title
            // 
            this.toolStripMenuItem_copy_url_title.Name = "toolStripMenuItem_copy_url_title";
            this.toolStripMenuItem_copy_url_title.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItem_copy_url_title.Text = "复制文件名与下载地址";
            this.toolStripMenuItem_copy_url_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // 打开下载页面ToolStripMenuItem
            // 
            this.打开下载页面ToolStripMenuItem.Name = "打开下载页面ToolStripMenuItem";
            this.打开下载页面ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.打开下载页面ToolStripMenuItem.Text = "打开下载页面";
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.ForeColor = System.Drawing.Color.Red;
            this.buttonNextPage.Location = new System.Drawing.Point(516, 69);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(137, 23);
            this.buttonNextPage.TabIndex = 7;
            this.buttonNextPage.Text = "加载下一页";
            this.buttonNextPage.UseVisualStyleBackColor = true;
            this.buttonNextPage.Click += new System.EventHandler(this.buttonNextPage_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(665, 495);
            this.Controls.Add(this.buttonNextPage);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "青石资源搜索工具V";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_copy_url;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_copy_url_title;
        private System.Windows.Forms.ToolStripMenuItem 打开下载页面ToolStripMenuItem;
        private System.Windows.Forms.Button buttonNextPage;
    }
}

