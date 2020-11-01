namespace WatermarkGenerator
{
    partial class WaterMarkGenerator
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaterMarkGenerator));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pbImgView = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbConstructionArea = new System.Windows.Forms.TextBox();
            this.lblConstructionArea = new System.Windows.Forms.Label();
            this.tbStartFloor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbEndFloor = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.tbLocation = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLoadImg = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbRemarks = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImgView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1030, 543);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(290, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(100, 50, 50, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(740, 543);
            this.panel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Info;
            this.groupBox2.Controls.Add(this.pbImgView);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(100, 50, 50, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(740, 543);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "预览区";
            // 
            // pbImgView
            // 
            this.pbImgView.BackColor = System.Drawing.SystemColors.Desktop;
            this.pbImgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImgView.Location = new System.Drawing.Point(3, 25);
            this.pbImgView.Name = "pbImgView";
            this.pbImgView.Size = new System.Drawing.Size(734, 515);
            this.pbImgView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImgView.TabIndex = 0;
            this.pbImgView.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(50, 50, 100, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 543);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作区";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 515);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.tbConstructionArea);
            this.flowLayoutPanel1.Controls.Add(this.lblConstructionArea);
            this.flowLayoutPanel1.Controls.Add(this.tbStartFloor);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.tbEndFloor);
            this.flowLayoutPanel1.Controls.Add(this.lblLocation);
            this.flowLayoutPanel1.Controls.Add(this.tbLocation);
            this.flowLayoutPanel1.Controls.Add(this.lblRemarks);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(272, 373);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "施工区域: ";
            // 
            // tbConstructionArea
            // 
            this.tbConstructionArea.Location = new System.Drawing.Point(8, 42);
            this.tbConstructionArea.Multiline = true;
            this.tbConstructionArea.Name = "tbConstructionArea";
            this.tbConstructionArea.Size = new System.Drawing.Size(252, 54);
            this.tbConstructionArea.TabIndex = 9;
            this.tbConstructionArea.Text = "113号465外墙";
            // 
            // lblConstructionArea
            // 
            this.lblConstructionArea.AutoSize = true;
            this.lblConstructionArea.Location = new System.Drawing.Point(8, 104);
            this.lblConstructionArea.Margin = new System.Windows.Forms.Padding(3, 5, 3, 10);
            this.lblConstructionArea.Name = "lblConstructionArea";
            this.lblConstructionArea.Size = new System.Drawing.Size(111, 19);
            this.lblConstructionArea.TabIndex = 2;
            this.lblConstructionArea.Text = "楼层区间: ";
            // 
            // tbStartFloor
            // 
            this.tbStartFloor.Location = new System.Drawing.Point(125, 102);
            this.tbStartFloor.Name = "tbStartFloor";
            this.tbStartFloor.Size = new System.Drawing.Size(53, 29);
            this.tbStartFloor.TabIndex = 3;
            this.tbStartFloor.Text = "100";
            this.tbStartFloor.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "-";
            // 
            // tbEndFloor
            // 
            this.tbEndFloor.Location = new System.Drawing.Point(210, 102);
            this.tbEndFloor.Name = "tbEndFloor";
            this.tbEndFloor.Size = new System.Drawing.Size(53, 29);
            this.tbEndFloor.TabIndex = 11;
            this.tbEndFloor.Text = "109";
            this.tbEndFloor.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(8, 139);
            this.lblLocation.Margin = new System.Windows.Forms.Padding(3, 5, 3, 10);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(115, 19);
            this.lblLocation.TabIndex = 4;
            this.lblLocation.Text = "地    点: ";
            // 
            // tbLocation
            // 
            this.tbLocation.Location = new System.Drawing.Point(8, 171);
            this.tbLocation.Multiline = true;
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.Size = new System.Drawing.Size(252, 54);
            this.tbLocation.TabIndex = 5;
            this.tbLocation.Text = "苏州市姑苏区干将东路";
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(8, 233);
            this.lblRemarks.Margin = new System.Windows.Forms.Padding(3, 5, 3, 10);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(111, 19);
            this.lblRemarks.TabIndex = 6;
            this.lblRemarks.Text = "备注信息: ";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnLoadImg);
            this.flowLayoutPanel2.Controls.Add(this.btnView);
            this.flowLayoutPanel2.Controls.Add(this.btnSave);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(6, 388);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(20);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(272, 121);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // btnLoadImg
            // 
            this.btnLoadImg.Location = new System.Drawing.Point(23, 23);
            this.btnLoadImg.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btnLoadImg.Name = "btnLoadImg";
            this.btnLoadImg.Size = new System.Drawing.Size(65, 95);
            this.btnLoadImg.TabIndex = 0;
            this.btnLoadImg.Text = "载入";
            this.btnLoadImg.UseVisualStyleBackColor = true;
            this.btnLoadImg.Click += new System.EventHandler(this.btnLoadImg_Click);
            // 
            // btnView
            // 
            this.btnView.Enabled = false;
            this.btnView.Location = new System.Drawing.Point(101, 23);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(65, 95);
            this.btnView.TabIndex = 1;
            this.btnView.Text = "预览";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(179, 23);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 95);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbRemarks);
            this.panel3.Location = new System.Drawing.Point(8, 265);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(264, 100);
            this.panel3.TabIndex = 12;
            // 
            // tbRemarks
            // 
            this.tbRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRemarks.Location = new System.Drawing.Point(0, 0);
            this.tbRemarks.Multiline = true;
            this.tbRemarks.Name = "tbRemarks";
            this.tbRemarks.Size = new System.Drawing.Size(264, 100);
            this.tbRemarks.TabIndex = 8;
            this.tbRemarks.Text = "防水防电";
            // 
            // WaterMarkGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 543);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WaterMarkGenerator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "水印生成器";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WaterMarkGenerator_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImgView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pbImgView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblConstructionArea;
        private System.Windows.Forms.TextBox tbStartFloor;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox tbLocation;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnLoadImg;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbConstructionArea;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbEndFloor;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tbRemarks;
    }
}

