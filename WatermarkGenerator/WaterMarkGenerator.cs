﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WatermarkGenerator
{
    public partial class WaterMarkGenerator : Form
    {
        private string strSavePath = string.Empty, strExt = string.Empty;
        private Image img;
        private Bitmap bitmap;
        private FileInfo[] fileInfo;

        public WaterMarkGenerator()
        {
            InitializeComponent();
            img = pbImgView.Image;
            tbConstructionArea.SelectAll();
            tbEndFloor.LostFocus += TextLostFocus;
            tbHomeNumber.LostFocus += TextLostFocus;
        }

        private void TextLostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Name.Equals("tbEndFloor"))
            {
                if (!(int.Parse(tb.Text.Trim()) >= int.Parse(tbStartFloor.Text.Trim())))
                {
                    tb.Text = tbStartFloor.Text.Trim();
                }
            }

            if (tb.Name.Equals("tbHomeNumber"))
            {
                if (string.IsNullOrWhiteSpace(tb.Text.Trim()))
                {
                    tb.Text = "01";
                }
            }
        }

        private new void TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (!int.TryParse(tb.Text.Trim(), out int floorNumber))
            {
                tb.Text = "1";
            }
        }

        private void btnLoadImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                strSavePath = openFile.FileName.Replace(openFile.SafeFileName, string.Format(""));
                strExt = openFile.SafeFileName.Substring(openFile.SafeFileName.LastIndexOf('.'));
                DirectoryInfo directoryInfo = Directory.CreateDirectory(strSavePath);
                fileInfo = directoryInfo.GetFiles();

                pbImgView.Load(openFile.FileName);
                img = pbImgView.Image;
                btnView.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            bitmap = DrawWaterMark(tbStartFloor.Text.Trim());
            pbImgView.Image = bitmap;
        }

        private void WaterMarkGenerator_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private Bitmap DrawWaterMark(string floorNumber)
        {
            Bitmap bitmap = new Bitmap(img);
            Graphics g = Graphics.FromImage(bitmap);

            //蓝色区域
            Rectangle blueRect = new Rectangle(img.Width / 19, img.Height - (img.Height / 4) - (img.Height / 35), img.Width / 2, ((img.Height / 5) / 4) * 1);
            FillRoundRectangle(g, new SolidBrush(Color.FromArgb(176, 0, 0, 255)), blueRect, (img.Width / 2) / 14, true);

            g.DrawString("工程记录", new Font("黑体", blueRect.Width / 15), Brushes.White, (float)(blueRect.Width / 2.5), blueRect.Y + blueRect.Height / 4);

            //白色区域
            Rectangle whiteRect = new Rectangle(img.Width / 19, (img.Height - (img.Height / 4) - (img.Height / 35)) + ((img.Height / 5) / 4) * 1, img.Width / 2, ((img.Height / 5) / 4) * 3);
            FillRoundRectangle(g, new SolidBrush(Color.FromArgb(176, Color.GhostWhite)), whiteRect, (img.Width / 2) / 14, false);

            int coefficient = 0;
            string viewStr = string.Format("{0}{1}{2}", lblConstructionArea.Text, tbConstructionArea.Text.Trim() + floorNumber + tbHomeNumber.Text.Trim(), Environment.NewLine);
            viewStr = viewStr.Length > 18 ? viewStr.Insert(17, "\r\n          ") : viewStr;

            g.DrawString(viewStr, new Font("黑体", whiteRect.Width / 21), Brushes.Black, blueRect.Width / 7, whiteRect.Y + blueRect.Height / 4);

            if (viewStr.Length > 18)
            {
                coefficient++;
            }

            viewStr = string.Format("{0}{1}{2}", lblLocation.Text, tbLocation.Text.Trim(), Environment.NewLine);
            viewStr = viewStr.Length > 18 ? viewStr.Insert(17, "\r\n          ") : viewStr;

            g.DrawString(viewStr, new Font("黑体", whiteRect.Width / 21), Brushes.Black, blueRect.Width / 7, whiteRect.Y + blueRect.Height / 4 + ((whiteRect.Width / 21) * (2 + coefficient)));

            if (viewStr.Length > 18)
            {
                coefficient++;
            }

            viewStr = string.Format("{0}{1}{2}", lblRemarks.Text, tbRemarks.Text.Trim(), Environment.NewLine);
            viewStr = viewStr.Length > 18 ? viewStr.Insert(17, "\r\n          ") : viewStr;

            g.DrawString(viewStr, new Font("黑体", whiteRect.Width / 21), Brushes.Black, blueRect.Width / 7, whiteRect.Y + blueRect.Height / 4 + ((whiteRect.Width / 21) * (4 + coefficient)));

            //黄色圆点
            g.FillEllipse(Brushes.Yellow, new Rectangle(img.Width / 13, (img.Height - (img.Height / 4) - (img.Height / 60)), (img.Width / 2) / 25, (img.Width / 2) / 25));
            g.Dispose();
            return bitmap;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            frmProgress progress = new frmProgress();
            progress.Show();
            int startFloor = int.Parse(tbStartFloor.Text.Trim());
            int endFloor = int.Parse(tbEndFloor.Text.Trim());
            int floorCount = endFloor - startFloor;
            Random random = new Random();
            string homeNumber = tbHomeNumber.Text.Trim();
            for (int i = 0; i <= floorCount; i++)
            {
                int currentFloorNumber = startFloor;
                string savePath = strSavePath + "Mark\\";
                int fileNumber = random.Next(0, fileInfo.Length - 1);
                img = Image.FromFile(fileInfo[fileNumber].FullName);
                Application.DoEvents();
                bitmap = DrawWaterMark(currentFloorNumber.ToString());
                if (File.Exists(savePath))
                {
                    File.Delete(savePath);
                }
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                savePath += startFloor + homeNumber + strExt;
                bitmap.Save(savePath);
                progress.Invoke(new Action(delegate
                {
                    progress.RefreshView(i + 1, floorCount + 1, this.Bounds.X, this.Bounds.Y, this.Bounds.Width, this.Bounds.Height);
                }));
                startFloor++;
            }
            progress.Close();
            //pbImgView.Image.Save(strSavePath);
        }

        private void FillRoundRectangle(Graphics g, Brush brush, Rectangle rect, int cornerRadius, bool radiusIsTop)
        {
            using (GraphicsPath path = CreateRoundedRectanglePath(rect, cornerRadius, radiusIsTop))
            {
                g.FillPath(brush, path);
            }
        }

        private GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int cornerRadius, bool radiusIsTop)
        {
            GraphicsPath roundedRect = new GraphicsPath();
            if (radiusIsTop)
            {
                roundedRect.AddArc(rect.X, rect.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
                roundedRect.AddLine(rect.X, rect.Y, rect.Right, rect.Y);
            }
            else
            {
                roundedRect.AddLine(rect.X + cornerRadius, rect.Y, rect.Right - cornerRadius * 2, rect.Y);
            }

            if (radiusIsTop)
            {
                roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
                roundedRect.AddLine(rect.Right, rect.Y, rect.Right, rect.Y + rect.Height);
            }
            else
            {
                roundedRect.AddLine(rect.Right, rect.Y, rect.Right, rect.Y + rect.Height);
            }

            if (!radiusIsTop)
            {
                roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y + rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
                roundedRect.AddLine(rect.Right, rect.Bottom, rect.X, rect.Bottom);
            }
            else
            {
                roundedRect.AddLine(rect.Right - cornerRadius * 2, rect.Bottom, rect.X + cornerRadius * 2, rect.Bottom);
                roundedRect.AddLine(rect.X, rect.Y + cornerRadius * 3, rect.X, rect.Y + rect.Height);
            }

            if (!radiusIsTop)
            {
                roundedRect.AddArc(rect.X, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
                roundedRect.AddLine(rect.X, rect.Bottom, rect.X, rect.Y);
            }
            else
            {
                roundedRect.AddLine(rect.X, rect.Bottom - cornerRadius * 2, rect.X, rect.Y + cornerRadius * 2);
            }
            roundedRect.CloseFigure();
            return roundedRect;
        }

    }
}
