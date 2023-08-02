using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using SD = System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using KMU.EduActivity.ApplicationLayer.DTO;

public partial class AvatarCopy : Page
{
    String path = HttpContext.Current.Request.PhysicalApplicationPath + "photo\\";
    String savepath = HttpContext.Current.Request.PhysicalApplicationPath + "Avatar\\";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService service = new KMU.EduActivity.ApplicationLayer.Services.EduActivityAppService();
            List<string> members = service.ReadMembers().Select(c => c.IsHospMember).Distinct().ToList();

            foreach (string m in members)
            {
                string empcode = "";
                if(m.Length == 6)
                {
                    empcode = "0" + m;
                }
                else
                {
                    empcode = m;
                }

                if (File.Exists(path + empcode + ".jpg") && !File.Exists(savepath + empcode + ".jpg"))
                {
                    SD.Image image = SD.Image.FromFile(path + empcode + ".jpg");
                    //int minLength = Math.Max(image.Width, image.Width);

                    //byte[] b = Crop(path + empcode + ".jpg", minLength, minLength, 0, 0);

                    //image = SD.Image.FromStream(new MemoryStream(b, 0, b.Length));
                    double rate = Convert.ToDouble(image.Height) / 320.0;

                    SD.Bitmap smallimage = new SD.Bitmap(image,Convert.ToInt32( image.Width/rate), 320);//Convert.ToInt32(320 * (image.Height / image.Width)));

                    smallimage.Save(savepath + m + ".jpg");

                    smallimage = new SD.Bitmap(image, 20, 20);
                    smallimage.Save(savepath + m + "s.jpg");

                    image.Dispose();
                    smallimage.Dispose();
                }
            }
        }      
    }

    static byte[] Crop(string Img, int Width, int Height, int X, int Y)
    {
        try
        {
            using (SD.Image OriginalImage = SD.Image.FromFile(Img))
            {
                using (SD.Bitmap bmp = new SD.Bitmap(Width, Height))
                {
                    bmp.SetResolution(OriginalImage.HorizontalResolution, OriginalImage.VerticalResolution);
                    using (SD.Graphics Graphic = SD.Graphics.FromImage(bmp))
                    {
                        Graphic.SmoothingMode = SmoothingMode.AntiAlias;
                        Graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        Graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        Graphic.DrawImage(OriginalImage, new SD.Rectangle(0, 0, Width, Height), X, Y, Width, Height, SD.GraphicsUnit.Pixel);
                        MemoryStream ms = new MemoryStream();
                        bmp.Save(ms, OriginalImage.RawFormat);
                        return ms.GetBuffer();
                    }
                }
            }
        }
        catch (Exception Ex)
        {
            throw (Ex);
        }
    }
    
}