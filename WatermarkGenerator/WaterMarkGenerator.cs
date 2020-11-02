using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WatermarkGenerator
{
    public partial class WaterMarkGenerator : Form
    {
        private string strSavePath = string.Empty, strExt = ".jpg";
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
            tbWorkArea.LostFocus += TextLostFocus;
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

            if (tb.Name.Equals("tbWorkArea"))
            {
                if (string.IsNullOrWhiteSpace(tb.Text.Trim()))
                {
                    tb.Text = "公卫";
                }
                strSavePath = string.Format("{0}\\PIC\\{1}\\", Application.StartupPath, tbWorkArea.Text);
                if (!Directory.Exists(strSavePath))
                {
                    MessageBox.Show(string.Format("{0}目录未创建.", tbWorkArea.Text));
                    tbWorkArea.Focus();
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
            //设置质量
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            //InterpolationMode不能使用High或者HighQualityBicubic,如果是灰色或者部分浅色的图像是会在边缘处出一白色透明的线
            //用HighQualityBilinear却会使图片比其他两种模式模糊（需要肉眼仔细对比才可以看出）
            g.InterpolationMode = InterpolationMode.Default;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            int imgWidth = img.Width;
            int imgHeight = img.Height;
            //蓝色区域
            int blueRectX = imgWidth / 19;
            int blueRectY = imgHeight - imgHeight / 4 - imgHeight / 20;
            int blueRectWidth = imgWidth / 2;
            int blueRectHeight = (imgHeight / 5 / 4) * 1;
            if (imgWidth > imgHeight)
            {
                blueRectWidth = imgHeight / 2;
                blueRectHeight = (imgWidth / 2 / 9) * 1;
            }
            Rectangle blueRect = new Rectangle(blueRectX, blueRectY, blueRectWidth, blueRectHeight);
            FillRoundRectangle(g, new SolidBrush(Color.FromArgb(176, 0, 0, 255)), blueRect, blueRectWidth / 14, true);

            g.DrawString("工程记录", new Font("黑体", blueRect.Width / 15), Brushes.White, (float)(blueRect.Width / 2.5), blueRect.Y + blueRect.Height / 5);

            //白色区域
            int whiteRectY = blueRectY + (imgHeight / 5 / 4) * 1;
            int whiteRectHeight = (imgHeight / 5 / 4) * 3;
            if (imgWidth > imgHeight)
            {
                whiteRectY = blueRectY + (imgWidth / 2 / 9) * 1;
                whiteRectHeight = (imgHeight / 2 / 9) * 4;
            }
            Rectangle whiteRect = new Rectangle(blueRectX, whiteRectY, blueRectWidth, whiteRectHeight);
            FillRoundRectangle(g, new SolidBrush(Color.FromArgb(176, Color.GhostWhite)), whiteRect, blueRectWidth / 14, false);

            int coefficient = 0;
            string viewStr = string.Format("{0}{1}{2}", lblConstructionArea.Text, tbConstructionArea.Text.Trim() + floorNumber + tbHomeNumber.Text.Trim() + tbWorkArea.Text, Environment.NewLine);
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
            g.FillEllipse(Brushes.Yellow, new Rectangle(imgWidth / 13, imgHeight - imgHeight / 4 - imgHeight / 60, blueRectWidth / 25, blueRectWidth / 25));
            g.Dispose();
            return bitmap;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            //按下确定选择的按钮  
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                InitFileList();
                //记录选中的目录 
                strSavePath = folderDialog.SelectedPath + "\\";
            }
            else
            {
                btnSave.Enabled = true;
                return;
            }
            frmProgress progress = new frmProgress();
            progress.Show();
            int startFloor = int.Parse(tbStartFloor.Text.Trim());
            int endFloor = int.Parse(tbEndFloor.Text.Trim());
            int floorCount = endFloor - startFloor;
            Random random = new Random();
            string homeNumber = tbHomeNumber.Text.Trim();
            for (int i = 0; i <= floorCount; i++)
            {
                try
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
                    SaveImage2File(savePath, bitmap, 50);
                    //bitmap.Save(savePath);
                    progress.Invoke(new Action(delegate
                    {
                        progress.RefreshView(i + 1, floorCount + 1, this.Bounds.X, this.Bounds.Y, this.Bounds.Width, this.Bounds.Height);
                    }));
                    startFloor++;
                }
                catch
                {
                    int fileNumber = random.Next(0, fileInfo.Length - 1);
                    img = Image.FromFile(fileInfo[fileNumber].FullName);
                }
            }
            progress.Close();
            btnSave.Enabled = true;
            //pbImgView.Image.Save(strSavePath);
        }

        private void SaveImage2File(string path, Image destImage, int quality, string mimeType = "image/jpeg")
        {
            if (quality <= 0 || quality > 100) quality = 95;
            //创建保存的文件夹
            FileInfo fileInfo = new FileInfo(path);
            if (!Directory.Exists(fileInfo.DirectoryName))
            {
                Directory.CreateDirectory(fileInfo.DirectoryName);
            }

            EncoderParameters ep = new EncoderParameters(2);
            long[] qy = new long[1];
            qy[0] = 90;//设置压缩的比例1-100
            EncoderParameter eParam1 = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            EncoderParameter eParam2 = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, 5);
            ep.Param[0] = eParam1;
            ep.Param[1] = eParam2;

            ImageCodecInfo myImageCodecInfo = GetEncoderInfo(mimeType);
            CompressImage(destImage, path);
            //destImage.Save(path, myImageCodecInfo, ep);
        }

        /// <summary>
        /// 无损压缩图片
        /// </summary>
        /// <param name="sFile">原图片地址</param>
        /// <param name="dFile">压缩后保存图片地址</param>
        /// <param name="flag">压缩质量（数字越小压缩率越高）1-100</param>
        /// <param name="size">压缩后图片的最大大小</param>
        /// <param name="sfsc">是否是第一次调用</param>
        /// <returns></returns>
        public bool CompressImage(Image sFile, string dFile, int flag = 90, int size = 300, bool sfsc = true)
        {
            ////如果是第一次调用，原始图像的大小小于要压缩的大小，则直接复制文件，并且返回true
            //FileInfo firstFileInfo = new FileInfo(sFile);
            //if (sfsc == true && firstFileInfo.Length < size * 1024)
            //{
            //    firstFileInfo.CopyTo(dFile);
            //    return true;
            //}
            Image iSource = sFile;
            ImageFormat tFormat = iSource.RawFormat;
            int dHeight = iSource.Height / 2;
            int dWidth = iSource.Width / 2;
            int sW = 0, sH = 0;
            //按比例缩放
            Size tem_size = new Size(iSource.Width, iSource.Height);
            if (tem_size.Width > dHeight || tem_size.Width > dWidth)
            {
                if ((tem_size.Width * dHeight) > (tem_size.Width * dWidth))
                {
                    sW = dWidth;
                    sH = (dWidth * tem_size.Height) / tem_size.Width;
                }
                else
                {
                    sH = dHeight;
                    sW = (tem_size.Width * dHeight) / tem_size.Height;
                }
            }
            else
            {
                sW = tem_size.Width;
                sH = tem_size.Height;
            }

            Bitmap ob = new Bitmap(dWidth, dHeight);
            Graphics g = Graphics.FromImage(ob);

            g.Clear(Color.WhiteSmoke);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            g.DrawImage(iSource, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);

            g.Dispose();

            //以下代码为保存图片时，设置压缩质量
            EncoderParameters ep = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = flag;//设置压缩的比例1-100
            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            ep.Param[0] = eParam;

            try
            {
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICIinfo = null;
                for (int x = 0; x < arrayICI.Length; x++)
                {
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICIinfo = arrayICI[x];
                        break;
                    }
                }
                if (jpegICIinfo != null)
                {
                    ob.Save(dFile, jpegICIinfo, ep);//dFile是压缩后的新路径
                    FileInfo fi = new FileInfo(dFile);
                    if (fi.Length > 1024 * size)
                    {
                        flag = flag - 10;
                        CompressImage(sFile, dFile, flag, size, false);
                    }
                }
                else
                {
                    ob.Save(dFile, tFormat);
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                iSource.Dispose();
                ob.Dispose();
            }
        }

        private ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        private void InitFileList()
        {
            strSavePath = string.Format("{0}\\PIC\\{1}\\", Application.StartupPath, tbWorkArea.Text);
            DirectoryInfo directoryInfo = Directory.CreateDirectory(strSavePath);
            fileInfo = directoryInfo.GetFiles();
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
                roundedRect.AddLine(rect.X, rect.Y + rect.Height, rect.X, rect.Y + rect.Height);//顶部左下角补齐
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
