#region Header
//=============================================
//作    者: 贺晓伟 
//日    期: 2016-01-07
//功能描述: 二维码生成与解码
//第三方类库:ThoughtWorks.QRCode.DLL 文件不要改名字
//=============================================
#endregion Header

using System;
using System.Drawing;
using System.Text;

using ThoughtWorks.QRCode.Codec;

namespace QRCODE
{
    public static class QrCodeHelper
    {

        /// <summary>
        /// 生成二维码,大小和传入的文字长度有关
        /// </summary>
        /// <param name="str">传入文字</param>
        /// <returns></returns>
        public static void StrToImg(string str)
        {
            try
            {
                Bitmap bm;
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeVersion = 0;

                if (str.Length >= 500)
                {
                    throw new Exception("字符串长度太大,请小于500");
                }


                //加密文件
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(str);
                string base64Str = Convert.ToBase64String(byteArray);

                string filePath = System.Web.HttpRuntime.AppDomainAppPath + "images\\";
                if (!System.IO.Directory.Exists(filePath))
                {
                    System.IO.Directory.CreateDirectory(filePath);
                }
                bm = qrCodeEncoder.Encode(base64Str, Encoding.UTF8);
                bm.Save(filePath + "base64.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                bm = qrCodeEncoder.Encode(str, Encoding.UTF8);

                bm.Save(filePath + "原文字.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                #region base64解码 示例

                //base64解码 示例
                string strPath = "5om55qyhOjEwOTE5MeacieaViOacnzoyMDE2LzIvMjbnga3oj4zml6XmnJ86MjAxNi8xMi8zMeS8geS4mueggToxMTExMTExMTExMTExMTM0NDQ0NDQ0NDQ0NTU1NTU1NQ==";
                byte[] bpath = Convert.FromBase64String(strPath);
                strPath = System.Text.Encoding.UTF8.GetString(bpath);

                bm.Dispose();
                #endregion



            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="path">图片地址</param>
        /// <returns></returns>
        public static string ImgToStr(string path)
        {
            try
            {
                Bitmap bm;
                QRCodeDecoder qrCodeDecoder = new QRCodeDecoder();


                Image img = Image.FromFile(path);
                bm = new Bitmap(img);


                string decodeStr = qrCodeDecoder.decode(new ThoughtWorks.QRCode.Codec.Data.QRCodeBitmapImage(bm));
             
                byte[] bpath = Convert.FromBase64String(decodeStr);
                decodeStr = System.Text.ASCIIEncoding.UTF8.GetString(bpath);
                img.Dispose();
                bm.Dispose();
                return decodeStr;

            }
            catch
            {
                throw;
            }
        }
    }
}
