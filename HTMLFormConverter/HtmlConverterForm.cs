using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace HTMLFormConverter
{
    public partial class HtmlConverterForm : Form
    {
        #region IHtmlConverterView

        #region 取得UI的相關參數
        public HtmlAgilityPack.HtmlDocument DocOri
        {
            get { return docOri; }
        }

        public HtmlAgilityPack.HtmlDocument DocAfter
        {
            get { return docAfter; }
        }

        public bool IsConvertCheckBox
        {
            get { return convertCheckBox.Checked; }
        }

        public bool IsConvertTextBox
        {
            get { return convertTextBox.Checked; }
        }

        public bool IsConvertImageSrc
        {
            get { return ConvertImageSrc.Checked; }
        }

        public bool IsAddTableControl
        {
            get { return addTableControl.Checked; }
        }

        public bool IsSetInputSize 
        { 
            get { return setInputSize.Checked; } 
        }

        public string InputSizeStr
        {
            get { return numericUpDown1.Value.ToString("0"); }
        }

        public bool IsConvertHint
        {
            get { return convertHint.Checked; }
        }

        public bool IsRenameId
        {
            get { return checkBox1.Checked; }
        }

        public bool IsRenameName
        {
            get { return cbRenameName.Checked; }
        }

        #endregion

        #region UI's Control DataBinding
        public void LoadDocOk(HtmlAgilityPack.HtmlDocument loadedDoc)
        {
            docOri = loadedDoc;
            docAfter = loadedDoc;

        }

        public void ConvertDocOk(HtmlAgilityPack.HtmlDocument loadedDoc)
        {
            docAfter = loadedDoc;
            richTextBox2.Text = docAfter.DocumentNode.InnerHtml;
        }
        #endregion

        #region UI's Event Handler

        public event EventHandler LoadDoc;

        public event EventHandler ConvertDoc;

        #endregion UI's Event Handler

        #endregion IHtmlConverterView

        #region "Members"
        private HtmlAgilityPack.HtmlDocument docOri = new HtmlAgilityPack.HtmlDocument();
        private HtmlAgilityPack.HtmlDocument docAfter = new HtmlAgilityPack.HtmlDocument();

        #endregion

        #region Constructors and Form's Event Handlers

        public HtmlConverterForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the Form control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Form_Load(object sender, EventArgs e)
        {

            #endregion Init UI Process

            #region Init UI's Properties

            #endregion Init UI's Properties

            #region Init Event Handler

            #region Binding BindingSource(UI) Event Handler

            #endregion

            #region Binding Control's Event Handler

            #endregion
            #endregion Init Event Handler
        }



        #region Event Handler


        #region BindingSource(UI) Event Handlers

        #endregion

        #region Controls Events Handlers

        #region BindingNavigator Event Handler

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (openFileDialog1.FileNames.Length > 1)
            {
                foreach (string str in openFileDialog1.FileNames)
                {
                    docOri = new HtmlAgilityPack.HtmlDocument();
                    docAfter = new HtmlAgilityPack.HtmlDocument();
                    docOri.Load(str, true);
                    docAfter.Load(str, true);
                    richTextBox1.Text = docOri.DocumentNode.InnerHtml;
                    button2_Click(button2, e);
                    docAfter.Save(str + ".convert.htm", docAfter.Encoding);
                }
            }
            else
            {
                docOri = new HtmlAgilityPack.HtmlDocument();
                docAfter = new HtmlAgilityPack.HtmlDocument();
                docOri.Load(openFileDialog1.FileName, true);
                docAfter.Load(openFileDialog1.FileName, true);
                richTextBox1.Text = docOri.DocumentNode.InnerHtml;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            f_ConvertDoc();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            docAfter.Save(saveFileDialog1.FileName, docAfter.Encoding);
        }



        #endregion Event Handler

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        #endregion

        private const string checkBoxStr = "<input type=\"checkbox\" name=\"%name\" id=\"%id\">";
        private const string textBoxStr = "<input id=\"%id\" name=\"%name\" type=\"text\" size=\"%size\">";
        private int checkBoxCount = 0;
        private int textBoxCount = 0;


        void f_ConvertDoc()
        {
            checkBoxCount = 0;
            textBoxCount = 0;

            if (this.IsRenameId)
            {
                renameId(docAfter.DocumentNode);

            }
            else
            {
                if (this.IsConvertCheckBox)
                    f_convertCheckBox(docAfter.DocumentNode);
                if (this.IsConvertTextBox)
                    f_convertTextBox(docAfter.DocumentNode);
                if (this.IsConvertImageSrc)
                    f_ConvertImageSrc(docAfter.DocumentNode);
                if (this.IsAddTableControl)
                    f_addTableControl(docAfter.DocumentNode);
                if (this.IsConvertHint)
                    ConvertHint(docAfter.DocumentNode);
                if (this.IsRenameName)
                    renameName(docAfter.DocumentNode);

                if(cbRemoveWidth.Checked)
                    removeWidth();
            }

            this.ConvertDocOk(docAfter);
        }
        private void renameName(HtmlAgilityPack.HtmlNode node)
        {
            HtmlAgilityPack.HtmlNodeCollection coll = node.SelectNodes(@"//input[@name=""%name""]");
            if (coll != null)
            {
                foreach (HtmlAgilityPack.HtmlNode note in coll)
                {
                    if (note.Attributes.Contains("id"))
                    {
                        if (note.Attributes.Contains("name"))
                        {
                            note.Attributes["name"].Value = note.Attributes["id"].Value;
                        }
                    }
                }
            }
        }


        private void renameId(HtmlAgilityPack.HtmlNode node)
        {
            HtmlAgilityPack.HtmlNodeCollection coll = node.SelectNodes("//*");

            int idcount = 0;
            foreach (HtmlAgilityPack.HtmlNode note in coll)
            {
                if (note.Attributes.Contains("id"))
                {
                    if (note.Attributes["id"].Value.StartsWith("check_"))
                    {
                        note.Attributes["id"].Value = "check_" + checkBoxCount.ToString();
                        checkBoxCount++;
                    }

                    if (note.Attributes["id"].Value.StartsWith("text_"))
                    {
                        note.Attributes["id"].Value = "text_" + textBoxCount.ToString();
                        textBoxCount++;
                    }

                }
                else
                {
                    if (note.Attributes.Contains("name"))
                    {
                        note.Attributes.Add("id", "control_" + idcount.ToString());
                        idcount++;
                    }
                }
            }

        }

        private void f_setInputSize(HtmlAgilityPack.HtmlNode node)
        {
            HtmlAgilityPack.HtmlNodeCollection coll = node.SelectNodes("//style");
            string insert = "　INPUT" +
                            "{" +
                            "FONT-SIZE: 7pt;" +
                            "}  ";
            coll[0].InnerHtml.Replace("-->", insert + "-->");
        }

        private void removeWidth()
        {

            HtmlAgilityPack.HtmlNodeCollection nodes = docAfter.DocumentNode.SelectNodes("//*");
            foreach (HtmlAgilityPack.HtmlNode editNode in nodes)
            {
                if (editNode.Attributes.Contains("width"))
                {
                    editNode.Attributes.Remove("width");
                    if (editNode.Name == "table")
                    {
                        editNode.Attributes.Add("width", "100%");
                    }
                }

                if (editNode.Attributes.Contains("style"))
                {
                    editNode.Attributes["style"].Value = editNode.Attributes["style"].Value.Replace("\r\n", "");
                    if (System.Text.RegularExpressions.Regex.IsMatch(editNode.Attributes["style"].Value, "width:\\w*.\\w*pt;border"))
                        editNode.Attributes["style"].Value = System.Text.RegularExpressions.Regex.Replace(editNode.Attributes["style"].Value, "width:\\w*.\\w*pt;border", "border");
                }
            }

        }


        private void f_addTableControl(HtmlAgilityPack.HtmlNode node)
        {
            string javascriptStr = "<script language=\"javascript\">" +
                                   "function popmenu(tableName){" +
                                   "   var table = document.getElementById(tableName);" +
                                   "   var lable = document.getElementById(\"lb_\"+tableName);" +
                                   "   if (table.style.display==\"none\"){" +
                                   "     table.style.display=\"block\";" +
                                   "     lable.innerHTML = \"- \"+table.title;" +
                                   "   }else{" +
                                   "     table.style.display=\"none\";" +
                                   "     lable.innerHTML = \"+ \"+table.title;" +
                                   "   }" +
                                   "} " +
                                   "function settable(tableName,displayvalue){" +
                                   "   var table = document.getElementById(tableName);" +
                                   "   var lable = document.getElementById(\"lb_\"+tableName);" +
                                   "   table.style.display=displayvalue;" +
                                   "   var flag = \"- \";" +
                                   "   if (displayvalue==\"none\"){" +
                                   "      flag = \"+ \";" +
                                   "   }else{" +
                                   "      flag=\"- \";" +
                                   "   }" +
                                   "   lable.innerHTML = flag+table.title;" +
                                   "} " +
                                   "function setall(displayvalue)" +
                                   "{" +
                                   "	var coll = document.getElementsByTagName(\"table\");" +
                                   "	for(i=0;i<coll.length;i++)" +
                                   "	{" +
                                   "		if(coll[i].id!=\"\")" +
                                   "		{" +
                                   "  		   settable(coll[i].id,displayvalue);" +
                                   "		}" +
                                   "	}" +
                                   "}" +
                                   "</script>";

            string controlStr =
                "<label id=\"lb_%tbname\" onClick=\"popmenu('%tbname');\">+ %title</label>";

            HtmlAgilityPack.HtmlNodeCollection nodes = node.SelectNodes("//head");
            if (nodes.Count > 0)
            {
                nodes[0].InnerHtml += javascriptStr;
            }

            int count = 0;
            nodes = node.SelectNodes("//table");

            foreach (HtmlAgilityPack.HtmlNode tb_node in nodes)
            {
                HtmlAgilityPack.HtmlNode td_node = tb_node.ChildNodes.FindFirst("td");
                string title = td_node.InnerText.Replace("\r\n", "").Trim();
                tb_node.Attributes.Add("id", "table" + count.ToString());
                tb_node.Attributes.Add("title", title);
                if (tb_node.Attributes.Contains("style"))
                    tb_node.Attributes["style"].Value += ";display:none";

                HtmlAgilityPack.HtmlNode new_node =
                    new HtmlAgilityPack.HtmlNode(HtmlAgilityPack.HtmlNodeType.Element,
                                                          docAfter, count + 1);

                if (count == 0)
                {


                    HtmlAgilityPack.HtmlNode openclose_node =
    new HtmlAgilityPack.HtmlNode(HtmlAgilityPack.HtmlNodeType.Element,
                                          docAfter, count);

                    openclose_node.Name = "div";
                    openclose_node.InnerHtml = "<a href=\"\"><label id=\"openall\" onClick=\"setall('block');\">全部展開</label></a>" +
                        "&nbsp;&nbsp;&nbsp;" +
                        "<a href=\"\"><label id=\"closeall\" onClick=\"setall('none');\">全部縮合</label></a><br>";

                    tb_node.ParentNode.InsertBefore(openclose_node, tb_node);
                }

                new_node.Name = "a";
                new_node.Attributes.Add("href", "");
                new_node.InnerHtml = controlStr.Replace("%tbname", "table" + count.ToString()).Replace("%title", title);

                tb_node.ParentNode.InsertBefore(new_node, tb_node);

                count++;
            }

        }

        private void f_convertCheckBox(HtmlAgilityPack.HtmlNode parentNode)
        {

            foreach (HtmlAgilityPack.HtmlNode node in parentNode.ChildNodes)
            {

                if (node.ChildNodes.Count == 0)
                {
                    if (node.InnerText.Contains("□"))
                    {
                        if (node.InnerText == "□")
                        {
                            string check = checkBoxStr;
                            check = check.Replace("%id", "check_" + checkBoxCount.ToString());
                            check = check.Replace("%name", "check_" + checkBoxCount.ToString());
                            node.InnerHtml = check;
                            checkBoxCount++;
                        }
                        else
                        {
                            //check = check.Replace("%id", node.InnerHtml.Replace("□", "").Trim());
                            string[] words = node.InnerHtml.Split(new string[] { "□" }, StringSplitOptions.None);

                            string total = "";
                            foreach (string str in words)
                            {
                                if (str == words[0])
                                {
                                    total += str;
                                }
                                else
                                {
                                    string check = checkBoxStr;
                                    string id = "check_" + checkBoxCount.ToString();
                                    check = check.Replace("%id", id);
                                    if (str.Trim() != "")
                                    {
                                        check = check.Replace("%name", str.Trim());
                                    }
                                    else
                                    {
                                        check = check.Replace("%name", id);
                                    }
                                    //node.InnerHtml.Replace("□", "").Trim());
                                    total += check + str;
                                    checkBoxCount++;
                                }
                            }
                            node.InnerHtml = total;
                        }
                    }

                    if (node.InnerText.Contains("¨"))
                    {
                        if (node.InnerText == "¨")
                        {
                            string check = checkBoxStr;
                            check = check.Replace("%id", "check_" + checkBoxCount.ToString());
                            check = check.Replace("%name", "check_" + checkBoxCount.ToString());
                            node.InnerHtml = check;
                            checkBoxCount++;
                        }
                        else
                        {
                            //check = check.Replace("%id", node.InnerHtml.Replace("□", "").Trim());
                            string[] words = node.InnerHtml.Split(new string[] { "¨" }, StringSplitOptions.None);

                            string total = "";
                            foreach (string str in words)
                            {
                                if (str == words[0])
                                {
                                    total += str;
                                }
                                else
                                {
                                    string check = checkBoxStr;
                                    string id = "check_" + checkBoxCount.ToString();
                                    check = check.Replace("%id", id);
                                    if (str.Trim() != "")
                                    {
                                        check = check.Replace("%name", str.Trim());
                                    }
                                    else
                                    {
                                        check = check.Replace("%name", id);
                                    }
                                    //node.InnerHtml.Replace("□", "").Trim());
                                    total += check + str;
                                    checkBoxCount++;
                                }
                            }
                            node.InnerHtml = total;
                        }
                    }

                }
                else
                {
                    f_convertCheckBox(node);
                }
            }
        }

        private bool checkunderline(string str)
        {
            bool isunderline = true;
            foreach (char word in str.Trim().ToCharArray())
            {
                if (word != '_')
                {
                    isunderline = false;
                    break;
                }
            }
            return isunderline;
        }

        private void f_convertTextBox(HtmlAgilityPack.HtmlNode parentNode)
        {
            foreach (HtmlAgilityPack.HtmlNode node in parentNode.ChildNodes)
            {
                if (node.Name == "u")
                {
                    if ((node.InnerText.Trim() == "") || checkunderline(node.InnerText))
                    {
                        string text = textBoxStr;
                        string id = "text_" + textBoxCount.ToString();
                        text = text.Replace("%id", id);
                        text = text.Replace("%name", id);
                        text = text.Replace("%size", node.InnerText.Length.ToString());
                        node.InnerHtml = text;
                        textBoxCount++;
                    }
                }
                else
                {
                    bool isunderline = true;
                    if (node.InnerText.Trim() == "")
                    {
                        isunderline = false;
                    }
                    else
                    {
                        isunderline = checkunderline(node.InnerText);
                    }
                    
                    if (isunderline)
                    {
                        string text = textBoxStr;
                        text = text.Replace("%id", "text_" + textBoxCount.ToString());
                        text = text.Replace("%name", "text_" + textBoxCount.ToString());
                        text = text.Replace("%size", node.InnerText.Length.ToString());
                        node.InnerHtml = text;
                        textBoxCount++;
                    }
                    else
                    {
                        if ((node.ChildNodes.Count != 0))
                        {
                            f_convertTextBox(node);
                        }
                    }
                }
            }
        }

        private void f_ConvertImageSrc(HtmlAgilityPack.HtmlNode parentNode)
        {
            HtmlAgilityPack.HtmlNodeCollection coll = parentNode.SelectNodes("//img");
            if (coll != null)
            {
                foreach (HtmlAgilityPack.HtmlNode node in coll)
                {
                    if (node.Attributes.Contains("src"))
                    {
                        node.Attributes["src"].Value = "##AppImagePath##" +
                                                       node.Attributes["src"].Value.Substring(
                                                           node.Attributes["src"].Value.LastIndexOf("/") + 1);
                    }
                }
            }
        }

        private void ConvertHint(HtmlAgilityPack.HtmlNode parentNode)
        {
            HtmlAgilityPack.HtmlNodeCollection notes = parentNode.SelectNodes("//span");
            for (int i = 0; i < notes.Count; i++)
            {
                if (notes[i].InnerHtml.Trim() == "&lt;i&gt;")
                {
                    parentNode.InnerHtml = parentNode.InnerHtml.Replace(notes[i].OuterHtml, "<div style=\"cursor:help\"  id=\"hint_01\" OnClick=\"window.external.DisplayHint(this.id);\">");
                    //HtmlAgilityPack.HtmlNode note = new HtmlAgilityPack.HtmlNode(HtmlAgilityPack.HtmlNodeType.Document, parentNode.OwnerDocument, i);
                    //note.InnerHtml = "<div style=\"cursor:help\"  id=\"hint_01\" OnClick=\"window.external.DisplayHint(this.id);\">";
                    //notes[i].ParentNode.ReplaceChild(notes[i], note);
                }

                if (notes[i].InnerHtml.Trim() == "&lt;/i&gt;")
                {
                    parentNode.InnerHtml = parentNode.InnerHtml.Replace(notes[i].OuterHtml, "</div>");
                    //HtmlAgilityPack.HtmlNode note = new HtmlAgilityPack.HtmlNode(HtmlAgilityPack.HtmlNodeType.Document, parentNode.OwnerDocument, i);
                    //note.InnerHtml = "</div>";
                    //notes[i].ParentNode.ReplaceChild(notes[i], note);
                }
            }


            parentNode.InnerHtml = parentNode.InnerHtml.Replace("&lt;i&gt;", "<div style=\"cursor:help\"  id=\"hint_01\" OnClick=\"window.external.DisplayHint(this.id);\">").Replace("&lt;/i&gt;", "</div>");
            //parentNode.OwnerDocument.LoadHtml(parentNode.InnerHtml.Replace("&lt;i&gt;", "<div style=\"cursor:help\"  id=\"hint_01\" OnClick=\"window.external.DisplayHint(this.id);\">").Replace("&lt;/i&gt;", "</div>"));
            //foreach (HtmlAgilityPack.HtmlNode node in parentNode.ChildNodes)
            //{
            //    if (node.Name == "span")
            //    {
            //        if (node.InnerText.Trim() == "")
            //        {
            //            string text = textBoxStr;
            //            text = text.Replace("%id", "text_" + textBoxCount.ToString());
            //            text = text.Replace("%size", node.InnerText.Length.ToString());
            //            node.InnerHtml = text;
            //            textBoxCount++;
            //        }
            //    }
            //    else
            //    {
            //        if ((node.ChildNodes.Count != 0))
            //        {
            //            convertTextBox(node);
            //        }
            //    }
            //}


        }
    }
}
