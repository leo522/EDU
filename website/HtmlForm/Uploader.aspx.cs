using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using HtmlAgilityPack;

    public partial class Updater : System.Web.UI.Page
    {
        private HtmlFormUtility.Components.ProcessComponent pc = new HtmlFormUtility.Components.ProcessComponent();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["library"] == "true")
            {
                panUpload.Visible = false;
            }

            if (Request.QueryString["update"] == "true")
            {
                panTemplateName.Visible = false;
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            

            if (Request.QueryString["library"] == "true")
            {
                HtmlFormUtility.FORM_TEMPLATES temp = pc.InsertTemplate(TextBox1.Text, null, "Library", Session["EduAct_HospCode"].ToString());
                Response.Redirect("~/HtmlForm/EditLibrary.aspx?template_id=" + temp.TEMPLATE_ID.ToString());
            }
            else
            {
                if (Request.QueryString["update"] != "true")
                {
                    if (TextBox1.Text == "")
                    {
                        return;
                    }
                }

                HtmlDocument doc = new HtmlDocument();
                if (FileUpload1.HasFile)
                {
                    int len = FileUpload1.PostedFile.ContentLength;
                    byte[] filedata = new byte[len];
                    FileUpload1.PostedFile.InputStream.Read(filedata, 0, len);

                    doc.Load(new MemoryStream(filedata));
                }
                int? id = null;
                if (Request.QueryString["update"] != "true")
                {
                    if (Request.QueryString["parentID"] != null)
                    {
                        id = Convert.ToInt32(Request.QueryString["parentID"]);
                    }
                    pc.InsertTemplate(doc, TextBox1.Text, id, tbCategory.Text, "", new Dictionary<string, byte[]>(), Session["EduAct_HospCode"].ToString());
                }
                else
                {
                    if (Request.QueryString["templateid"] != null)
                    {
                        id = Convert.ToInt32(Request.QueryString["templateid"]);
                    }
                    pc.RenewTemplate(id.Value, doc, new Dictionary<string, byte[]>());
                }
                Response.Redirect("HtmlAgilityAdmin.aspx");

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("HtmlAgilityAdmin.aspx");
        }
    }

