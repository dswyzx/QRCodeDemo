using System;
using System.IO;
using System.Windows.Forms;
using QRCODE;


namespace WebTest
{
    public partial class QrCodeTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string filePath = System.Web.HttpRuntime.AppDomainAppPath + "images\\base64.jpg";
            if (File.Exists(filePath))
            {
                //return;
            }
            else
            {
                QrCodeHelper.StrToImg(@"123+abc+网上的例QrcodeVersion的范围值是0-40,0的含义是表示压缩的信息量将会根据实际传入值确定，只有最高上限的控制，而且图片的大小将会根据信息量自动缩放。1-40的范围值，则有固定的信息量上限，而且图片的大小会固定在一个大小上，不会根据信息量的多少而变化。");
                // Bitmap mp = Qrcodehelper.StrToImg(@"123+abc+网");
            }
            string s = QrCodeHelper.ImgToStr(filePath);
            Label1.Text = s;
        }

        public static InputLanguage GetDesiredInputLanguage(string layoutName)
        {
            InputLanguageCollection ilc = InputLanguage.InstalledInputLanguages;
            foreach (InputLanguage il in ilc)
            {
                if (il.LayoutName.IndexOf(layoutName) != -1)
                    return il;
            }
            return null;
        }
    }
}
