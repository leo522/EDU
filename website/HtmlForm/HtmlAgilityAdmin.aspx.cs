using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Reflection;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using Telerik.Web.UI;

    public partial class List : AuthPage
    {
        private HtmlFormUtility.Components.ViewComponent vc = new HtmlFormUtility.Components.ViewComponent();
        private HtmlFormUtility.Components.ProcessComponent pc = new HtmlFormUtility.Components.ProcessComponent();

        #region Protected Methods


        protected void Page_Load(object sender, EventArgs e)
        {
            AddPostbackControl(RadTreeView1);
            AddPostbackControl(btnDownload);
            List<string> authrole = Session["EduAct_AuthRoles"] as List<string>;
            if(authrole== null || !authrole.Contains("FormAdmin"))
            {
                string[] notallow = new string[] { "更新表單", "新增子表", "填寫", "停用", "維護題庫", "統計","刪除","啟用" };
                
                for (int i = 0; i < RadTreeView1.ContextMenus[0].Items.Count; i++)
                {
                    if (notallow.Contains(RadTreeView1.ContextMenus[0].Items[i].Text))
                    {
                        RadTreeView1.ContextMenus[0].Items.RemoveAt(i);
                        i--;
                    }
                }
                btnAddRoot.Visible = false;
                btnAddLibraryTemplate.Visible = false;
            }

            if (EmpCode != "1020640" && !authrole.Contains("FormSAdmin"))
            {
                string[] notallow = new string[] { "更新表單", "新增子表", "填寫", "統計", "刪除" };

                for (int i = 0; i < RadTreeView1.ContextMenus[0].Items.Count; i++)
                {
                    if (notallow.Contains(RadTreeView1.ContextMenus[0].Items[i].Text))
                    {
                        RadTreeView1.ContextMenus[0].Items.RemoveAt(i);
                        i--;
                    }
                }
            }

            //if (Session["EduAct_DeptCode"] != "7000")
            //{
            //    //string[] notallow = new string[] { "更新表單", "新增子表", "填寫", "停用", "維護題庫", "統計" };
            //    string[] notallow = new string[] { "停用" };
            //    for (int i = 0; i < RadTreeView1.ContextMenus[0].Items.Count; i++)
            //    {
            //        if (notallow.Contains(RadTreeView1.ContextMenus[0].Items[i].Text))
            //        {
            //            RadTreeView1.ContextMenus[0].Items.RemoveAt(i);
            //            i--;
            //        }
            //    }
                
            //    //btnAddRoot.Visible = false;
            //    //btnAddLibraryTemplate.Visible = false;
            //}
            btnDownload.Visible = false;
            if (!IsPostBack)
            {

                if (Request.QueryString["template_id"] != null)
                {
                    GoDetail(Request.QueryString["template_id"]);
                }

                ReloadList();
            }
        }
        protected void ReloadList()
        {
            List<HtmlFormUtility.FORM_TEMPLATES> list = new List<HtmlFormUtility.FORM_TEMPLATES>();
            if (this.AuthRoles.Contains("SuperAdmin"))
            {
                list = vc.ListAllFormTemplatesSimple();
            }
            else
            {
                list = vc.ListFormTemplatesSimple(this.HospCode);
            }
            if(!cbDisplayDisable.Checked)
            {
                list = list.Where(c => c.ENABLED).ToList();
            }


            RadTreeView1.DataFieldID = "TEMPLATE_ID";
            RadTreeView1.DataFieldParentID = "PARENT_TEMPLATE_ID";
            
            RadTreeView1.DataTextField = "TEMPLATE_NAME";
            RadTreeView1.DataValueField = "TEMPLATE_ID";
            RadTreeView1.DataSource = list;

            RadTreeView1.DataBind();
            
            //RadTreeView1.ExpandAllNodes();
        }

        #region RadTreeView Events

        protected void RadTreeView1_ContextMenuItemClick(object sender, Telerik.Web.UI.RadTreeViewContextMenuEventArgs e)
        {
            switch (e.MenuItem.Text)
            {
                //case "編輯":
                //    Response.Redirect("Editor.aspx?templateId=" + e.Node.Value);
                //    break;
                case "更新表單":
                    Response.Redirect("~/HtmlForm/Uploader.aspx?templateid=" + e.Node.Value + "&update=true");
                    break;
                case "新增子表":
                    Response.Redirect("~/HtmlForm/Uploader.aspx?parentID=" + e.Node.Value);
                    break;
                case "複製":
                    Response.Redirect("~/HtmlForm/Copy.aspx?templateid=" + e.Node.Value);
                    break;
                case "維護":
                    //Session["template_id"] =Convert.ToInt32( e.Node.Value);
                    OpenNewWindow("EditHtmlForm.aspx?template_id=" + e.Node.Value);
                    //Response.Redirect("~/HtmlForm/EditHtmlForm.aspx?template_id=" + e.Node.Value);
                    break;
                case "停用":
                    pc.DisableFormTemplate(Convert.ToInt32(e.Node.Value));
                    ReloadList();
                    break;
                case "啟用":
                    pc.EnableFormTemplate(Convert.ToInt32(e.Node.Value));
                    ReloadList();
                    break;
                case "刪除":
                    if (e.Node.Nodes.Count == 0)
                    {
                        pc.DeleteFromTemplate(Convert.ToInt32(e.Node.Value));
                        ReloadList();
                    }
                    break;
                case "填寫":
                    GoDetail(e.Node.Value);
                    break;
                case "維護題庫":
                    Response.Redirect("~/HtmlForm/EditLibrary.aspx?template_id=" + e.Node.Value);
                    break;
                case "統計":
                    Response.Redirect("~/HtmlForm/HtmlFormStatistic.aspx?template_id=" + e.Node.Value);
                    break;
            }
        }
        protected void RadTreeView1_NodeDrop(object sender, Telerik.Web.UI.RadTreeNodeDragDropEventArgs e)
        {
            int? parentID = null;
            if (e.DestDragNode != null)
            {
                parentID = Convert.ToInt32(e.DestDragNode.Value);
            }

            pc.UpdateTemplateParentID(Convert.ToInt32(e.DraggedNodes[0].Value), parentID);
            MoveToTop.Enabled = false;
            ReloadList();
        }

        protected void GoDetail(string templateId)
        {

            Session["template_id"] = templateId;


            Response.Redirect("~/Detial.aspx");

        }

        protected void RadTreeView1_NodeEdit(object sender, Telerik.Web.UI.RadTreeNodeEditEventArgs e)
        {
            pc.UpdateTemplateName(Convert.ToInt32(e.Node.Value), e.Text);
            ReloadList();
        }

        protected void RadTreeView1_NodeDataBound(object sender, Telerik.Web.UI.RadTreeNodeEventArgs e)
        {
            if (e.Node.Value != "")
            {
                List<HtmlFormUtility.FORM_TEMPLATES> list = RadTreeView1.DataSource as List<HtmlFormUtility.FORM_TEMPLATES>;
                HtmlFormUtility.FORM_TEMPLATES data = list.Where(c => c.TEMPLATE_ID == Convert.ToInt32(e.Node.Value)).FirstOrDefault();
                
                foreach (PropertyInfo dc in data.GetType().GetProperties())
                {
                    e.Node.Attributes.Add(dc.Name, (dc.GetValue(data, null) == null ? null : dc.GetValue(data, null).ToString()));
                }
                e.Node.ToolTip = "Category : " + e.Node.Attributes["TEMPLATE_CATEGORY"];
                if(!data.ENABLED)
                {
                    e.Node.BackColor = System.Drawing.Color.Red;
                    e.Node.ForeColor = System.Drawing.Color.White;
                }
            }
        }

        protected void RadTreeView1_NodeClick(object sender, Telerik.Web.UI.RadTreeNodeEventArgs e)
        {
            if (e.Node.ParentNode == null)
            {
                MoveToTop.Enabled = false;
            }
            else
            {
                MoveToTop.Enabled = true;
            }

        }
        #endregion

        protected void MoveToTop_Click(object sender, EventArgs e)
        {
            
            //dsTestDB.UpdateTemplateParentID(null, RadTreeView1.SelectedNode.Value);
            //ReloadList();
            //MoveToTop.Enabled = false;
        }
        #endregion

        protected void btnAddRoot_Click(object sender, EventArgs e)
        {
            Response.Redirect("Uploader.aspx");
        }

        protected void btnAddLibraryTemplate_Click(object sender, EventArgs e)
        {
            Response.Redirect("Uploader.aspx?library=true");
        }
        protected void btnDownload_Click(object sender, EventArgs e)
        {

            MemoryStream output = new MemoryStream();
            ZipOutputStream stream = new ZipOutputStream(output);
            stream.SetLevel(3);
            List<HtmlFormUtility.FORM_TEMPLATES> temps = vc.ListFormTemplates();
            foreach (HtmlFormUtility.FORM_TEMPLATES temp in temps)
            {
                //MemoryStream ms = new MemoryStream();

                //HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                //doc.LoadHtml(temp.TEMPLATE_CONTENT);
                //doc.Save(ms);


                //byte[] binaryData = ms.ToArray();

                byte[] binaryData = System.Text.Encoding.UTF8.GetBytes(temp.TEMPLATE_CONTENT);


                stream.PutNextEntry(new ZipEntry(temp.TEMPLATE_NAME + ".html"));

                stream.Write(binaryData, 0, binaryData.Length);
            }
            stream.Finish();
            stream.Close();


            Response.Clear();
            Response.AddHeader("Content-Length", output.ToArray().Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "attachment; filename=output.zip");
            Response.OutputStream.Write(output.ToArray(), 0, output.ToArray().Length);

            Response.Flush();
            Response.End();

        }
        protected void cbDisplayDisable_CheckedChanged(object sender, EventArgs e)
        {
            ReloadList();
        }
}
