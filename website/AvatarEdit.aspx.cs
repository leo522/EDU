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

public partial class AvatarEdit : AuthPage
{
    String path = HttpContext.Current.Request.PhysicalApplicationPath + "temp\\";
    protected void Page_Load(object sender, EventArgs e)
    {
        imgCurrent.ImageUrl = "Avatar/" + this.EmpCode + ".jpg";
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        Boolean FileOK = false;
        Boolean FileSaved = false;
        if (Upload.HasFile)
        {
            Session["WorkingImage"] = "(" + Guid.NewGuid().ToString() + ")" + Upload.FileName;
            String FileExtension = Path.GetExtension(Session["WorkingImage"].ToString()).ToLower();
            String[] allowedExtensions = { ".png", ".jpeg", ".jpg", ".gif" };
            for (int i = 0; i < allowedExtensions.Length; i++)
            {
                if (FileExtension == allowedExtensions[i])
                {
                    FileOK = true;
                }
            }
        }

        if (FileOK)
        {
            try
            {
                //Upload.PostedFile.SaveAs(path + Session["WorkingImage"]);

                System.Drawing.Image.GetThumbnailImageAbort callBack = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                SD.Image image = SD.Image.FromStream(Upload.PostedFile.InputStream);

                SD.Bitmap smallimage = new SD.Bitmap(image, 320, 320);//Convert.ToInt32(320 * (image.Height / image.Width)));

                smallimage.Save(path + Session["WorkingImage"]);

                //System.Drawing.Image smallImage =
                // image.GetThumbnailImage(640, 640 * (image.Height / image.Width), callBack, IntPtr.Zero);

                //// 將縮圖存檔
                //smallImage.Save(path + Session["WorkingImage"]);

                // 釋放並刪除暫存檔

                image.Dispose();
                FileSaved = true;
            }
            catch (Exception ex)
            {
                lblError.Text = "File could not be uploaded." + ex.Message.ToString();
                lblError.Visible = true;
                FileSaved = false;
            }
        }

        else
        {
            lblError.Text = "Cannot accept files of this type.";
            lblError.Visible = true;
        }

        if (FileSaved)
        {
            pnlUpload.Visible = false;
            pnlCrop.Visible = false;
            pnlCropped.Visible = true;
            //imgCrop.ImageUrl = "temp/" + Session["WorkingImage"].ToString();
            imgCropped.ImageUrl = "temp/" + Session["WorkingImage"].ToString();
        }

    }

    private bool ThumbnailCallback()
    {
        return false;
    }

    protected void btnCrop_Click(object sender, EventArgs e)
    {
        string ImageName = Session["WorkingImage"].ToString();

        int w = Convert.ToInt32(W.Value);

        int h = Convert.ToInt32(H.Value);

        int x = Convert.ToInt32(X.Value);

        int y = Convert.ToInt32(Y.Value);

        byte[] CropImage = Crop(path + ImageName, w, h, x, y);

        using (MemoryStream ms = new MemoryStream(CropImage, 0, CropImage.Length))
        {
            ms.Write(CropImage, 0, CropImage.Length);

            using (SD.Image CroppedImage = SD.Image.FromStream(ms, true))
            {
                string SaveTo = path + "crop" + ImageName;

                SD.Bitmap transimage = new SD.Bitmap(CroppedImage, 320, 320);

                transimage.Save(SaveTo, CroppedImage.RawFormat);

                pnlCrop.Visible = false;

                pnlCropped.Visible = true;

                imgCropped.ImageUrl = "temp/crop" + ImageName;
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SD.Bitmap image = new SD.Bitmap(path + "" + Session["WorkingImage"]);
        string savepath = HttpContext.Current.Request.PhysicalApplicationPath + "Avatar\\";
        image.Save(savepath + this.EmpCode + ".jpg");

        SD.Bitmap smallimage = new SD.Bitmap(image, 20, 20);
        smallimage.Save(savepath + this.EmpCode + "s.jpg");

        image.Dispose();
        smallimage.Dispose();
        
        File.Delete(path + Session["WorkingImage"]);
        //File.Delete(path + "crop" + Session["WorkingImage"]);
        Response.Redirect("AvatarEdit.aspx");
    }
}