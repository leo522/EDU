using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ILCalc;
using System.Reflection;
using System.Data;
using System.Collections.Specialized;
using HtmlAgilityPack;

namespace HtmlFormUtility.Components
{
    [Serializable]
    public class HtmlForm
    {
        
        #region private variables & function
        //DataContextDataContext context = new DataContextDataContext();
        private HtmlDocument _instanceDocument;
        private int _templateID;
        private string _templateName = "";
        private int _instanceID;
        private FORM_INSTANCES _currentInstance;
        private FORM_TEMPLATES _currentTemplate;
        private bool _editMode = false;
        private bool _readOnly = false;
        private Dictionary<string, IDataReader> _dataDic = new Dictionary<string, IDataReader>();
        private List<FORM_INSTANCE_EXPRESSIONS> _scores;
        private HashSet<string> _editRole = new HashSet<string>();
        private List<string> _executeSqlAfterSubmit = new List<string>();
        private List<System.Data.SqlClient.SqlCommand> _submitSQL = new List<System.Data.SqlClient.SqlCommand>();



        public List<System.Data.SqlClient.SqlCommand> SubmitSQL
        {
            get
            {
                return _submitSQL;
            }
        }

        public HashSet<string> EditRole
        {
            get
            {
                return _editRole;
            }
            set
            {
                _editRole = value;
            }
        }


        public FORM_INSTANCES CurrentInstance
        {
            get
            {
                return _currentInstance;
            }
        }

        public FORM_TEMPLATES CurrentTemplate
        {
            get
            {
                return _currentTemplate;
            }
        }

        private bool _hasHindFeild = false;
        public bool HasHindField
        {
            get
            {
                return _hasHindFeild;
            }
            set
            {
                _hasHindFeild = value;
            }
        }

        public bool EditMode
        {
            get
            {
                return _editMode;
            }
        }

        //是否為多人填寫一分的表單
        public bool IsMultiTargetForm
        {
            get
            {
                return CurrentInstance.IsMultiTargetForm;
            }
        }

        public List<string> ExecuteSqlAfterSubmit
        {
            get
            {
                return _executeSqlAfterSubmit;
            }
        }

        private bool _submitSuccess = true;
        public bool SubmitSuccess
        {
            get
            {
                return _submitSuccess;
            }
            set
            {
                _submitSuccess = value;
            }
        }

        private string _submitMessage = null;
        public string SubmitMessage
        {
            get
            {
                return _submitMessage;
            }
            set
            {
                _submitMessage = value;
            }
        }

        /// <summary>
        /// 以instance id 讀取instance
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        private HtmlDocument LoadInstance(int instanceId)
        {
            this._instanceID = instanceId;

            ViewComponent component = new ViewComponent();
            _currentInstance = component.SelectFormInstance(instanceId);
            if (_currentInstance != null)
            {

                this._templateID = _currentInstance.TEMPLATE_ID;

                _templateName = _currentInstance.INSTANCE_NAME;

                HtmlDocument doc = new HtmlDocument();


                doc.LoadHtml(_currentInstance.INSTANCE_CONTENT.Replace("&lt;", "＜").Replace("&gt;", "＞").Replace("&amp;", "＆").Replace("&quot;", "＼").Replace("&apos;", "’"));//.Replace("##AppImagePath##", System.Windows.Forms.Application.StartupPath + @"\tempImage\" + _currentInstance.TEMPLATE_ID + @"\"));

                if (_currentInstance.INSTANCE_CONTENT == null || _currentInstance.INSTANCE_CONTENT == "")
                {
                    HtmlDocument doc2 = new HtmlDocument();
                    doc2.LoadHtml(GenerateTemplateQuestion(_currentInstance.TEMPLATE_ID));

                    doc.DocumentNode.AppendChild(doc2.DocumentNode.Clone());
                }

                _editMode = true;

                SetImageFiles(_currentInstance.TEMPLATE_ID);
                try
                {
                    CheckSelections(_currentInstance.TEMPLATE_ID, ref doc);
                }
                catch (Exception ex)
                {
                }
                return doc;
            }
            else
            {
                return null;
            }
        }

        


        /// <summary>
        /// 以template id 讀取template
        /// </summary>
        /// <param name="templateId"></param>
        /// <returns></returns>
        private HtmlDocument LoadTemplate(int templateId)
        {
            this._templateID = templateId;

            ViewComponent component = new ViewComponent();

            _currentTemplate = component.SelectFormTemplate(templateId);

            _templateName = _currentTemplate.TEMPLATE_NAME;

            HtmlDocument doc = new HtmlDocument();

            doc.LoadHtml(_currentTemplate.TEMPLATE_CONTENT);//.Replace("##AppImagePath##", System.Windows.Forms.Application.StartupPath + @"\tempImage\" + templateId + @"\"));

            HtmlDocument doc2 = new HtmlDocument();
            doc2.LoadHtml(GenerateTemplateQuestion());

            doc.DocumentNode.AppendChild(doc2.DocumentNode.Clone());

            _editMode = false;

            SetImageFiles(templateId);

            try
            {
                CheckSelections(templateId, ref doc);
            }
            catch (Exception ex)
            {
            }

            


            return doc;
        }

        private string GenerateTemplateQuestion()
        {
            return GenerateTemplateQuestion(_currentTemplate.TEMPLATE_ID);
        }

        private string GenerateTemplateQuestion(int template_id)
        {
            string result = "";
            ViewComponent component = new ViewComponent();
            List<FORM_TEMPLATE_LIBRARY> libs = component.ListFormTemplateLibrary(template_id, "");
            foreach (FORM_TEMPLATE_LIBRARY lib in libs)
            {
                if (lib.DISPLAY)
                {
                    result += "<div style=\"font-size:2em;\"><b>" + lib.QUESTION_CONTENT + "</b></div>";
                    List<FORM_TEMPLATE_LIBRARY_OPTION> opts = component.ListFormTemplateLibraryOption(lib.FORM_TEMPLATE_LIBRARY_ID);
                    foreach (FORM_TEMPLATE_LIBRARY_OPTION opt in opts)
                    {
                        result += "<div>";

                        switch (opt.OPTION_TYPE)
                        {
                            case "radio":
                                result += "<input type=\"" + opt.OPTION_TYPE + "\" displayname=\"" + opt.OPTION_TEXT + "\" id=\"" + opt.OPTION_TYPE + opt.OPTION_ID.ToString() + "\" name=\"radio" + lib.FORM_TEMPLATE_LIBRARY_ID.ToString() + "\" value=\"" + opt.OPTION_TEXT + "\" text=\"" + opt.OPTION_TEXT + "\" ";
                                if (opt.OPTION_POINTS.HasValue)
                                {
                                    result += " score=\"" + opt.OPTION_POINTS.Value.ToString() + "\" ";
                                }
                                result += "</input>";
                                result += opt.OPTION_TEXT;
                                break;
                            case "checkbox":
                                result += "<input type=\"" + opt.OPTION_TYPE + "\" displayname=\"" + opt.OPTION_TEXT + "\" id=\"" + opt.OPTION_TYPE + opt.OPTION_ID.ToString() + "\" name=\"" + opt.OPTION_TYPE + opt.OPTION_ID.ToString() + "\" value=\"" + opt.OPTION_TEXT + "\" text=\"" + opt.OPTION_TEXT + "\" ";
                                if (opt.OPTION_POINTS.HasValue)
                                {
                                    result += " score=\"" + opt.OPTION_POINTS.Value.ToString() + "\" ";
                                }
                                result += "</input>";
                                result += opt.OPTION_TEXT;
                                break;
                            case "text":
                                result += opt.OPTION_TEXT + "<input type=\"" + opt.OPTION_TYPE + "\" size=\"35\" id=\"" + opt.OPTION_TYPE + opt.OPTION_ID.ToString() + "\" name=\"" + opt.OPTION_TYPE + opt.OPTION_ID.ToString() + "\"  ";
                                if (opt.OPTION_POINTS.HasValue)
                                {
                                    result += " score=\"" + opt.OPTION_POINTS.Value.ToString() + "\" ";
                                }
                                result += "</input>";
                                break;
                        }
                        result += "</div>";
                    }


                }
            }
            return result;
        }


        /// <summary>
        /// 進行算式運算
        /// </summary>
        /// <param name="editedDoc"></param>
        /// <returns></returns>
        private Dictionary<string,double> DoExpression(HtmlDocument editedDoc)
        {
            Dictionary<string, double> result = new Dictionary<string, double>();
            ViewComponent component = new ViewComponent();
            List<FORM_TEMPLATE_EXPRESSIONS> exp_list = component.ListFormTemplateExpressions(_templateID);

            //if(exp_list.Count == 0)
            //{
            //    return result;
            //}

            CalcContext<double> calc = new CalcContext<double>();

            HtmlNodeCollection coll = editedDoc.DocumentNode.SelectNodes("//input");

            if (coll != null)
            {
                foreach (HtmlNode node in coll)
                {
                    switch (node.Attributes["type"].Value.ToLower())
                    {

                        case "radio":
                        case "checkbox":
                            if (node.Attributes.Contains("checked"))
                            {
                                try
                                {
                                    calc.Constants.Add(node.Attributes["id"].Value.Replace(".", "_").Replace("-", "_"), Convert.ToDouble(node.Attributes["score"].Value));
                                }
                                catch
                                {
                                    calc.Constants.Add(node.Attributes["id"].Value.Replace(".", "_").Replace("-", "_"), 0);
                                }
                            }
                            else
                            {
                                calc.Constants.Add(node.Attributes["id"].Value.Replace(".", "_").Replace("-", "_"), 0);
                            }
                            break;
                        case "text":
                        case "number":
                        case "hidden":
                            try
                            {
                                calc.Constants.Add(node.Attributes["id"].Value.Replace(".", "_").Replace("-", "_"), Convert.ToDouble(node.Attributes["value"].Value));
                            }
                            catch
                            {
                                calc.Constants.Add(node.Attributes["id"].Value.Replace(".", "_").Replace("-", "_"), 0);
                            }
                            break;
                    }
                }
            }


            

            //List<FORM_TEMPLATE_ELEMENTS> list = component.ListFormTemplateElement(_templateID);

            //foreach (FORM_TEMPLATE_ELEMENTS element in list)
            //{
            //    HtmlNode node = editedDoc.GetElementbyId(element.ID);
            //    if (node != null)
            //    {
            //        switch (element.CONTROL_TYPE.ToLower())
            //        {

            //            case "radio":
            //            case "checkbox":
            //                if (node.Attributes.Contains("checked"))
            //                {
            //                    try
            //                    {
            //                        calc.Constants.Add(element.ID.Replace(".", "_").Replace("-", "_"), Convert.ToDouble(element.POINTS.Value));
            //                    }
            //                    catch
            //                    {
            //                        calc.Constants.Add(element.ID.Replace(".", "_").Replace("-", "_"), 0);
            //                    }
            //                }
            //                else
            //                {
            //                    calc.Constants.Add(element.ID.Replace(".", "_").Replace("-", "_"), 0);
            //                }
            //                break;
            //            case "text":
            //            case "number":
            //            case "hidden":
            //                try
            //                {
            //                    calc.Constants.Add(element.ID.Replace(".", "_").Replace("-", "_"), Convert.ToDouble(node.Attributes["value"].Value));
            //                }
            //                catch
            //                {
            //                    calc.Constants.Add(element.ID.Replace(".", "_").Replace("-", "_"), 0);
            //                }
            //                break;
            //        }
            //    }
            //    else
            //    {
            //        calc.Constants.Add(element.ID.Replace(".", "_").Replace("-", "_"), 0);
            //    }
            //}

            

            _scores = new List<FORM_INSTANCE_EXPRESSIONS>();

            foreach (FORM_TEMPLATE_EXPRESSIONS exp in exp_list)
            {
                double value = Math.Round(calc.Evaluate(exp.EXPRESSION.Replace(".", "_")), 2);
                HtmlNode valuenode = editedDoc.GetElementbyId(exp.TEMPLATE_EXPRESSION_NAME);
                double udvalue = 0;
                if (exp.ALLOWUSERDEFINE && valuenode != null && valuenode.Attributes.Contains("value") && valuenode.Attributes["value"].Value != null && valuenode.Attributes["value"].Value != "" && double.TryParse(valuenode.Attributes["value"].Value, out udvalue))
                {

                    FORM_INSTANCE_EXPRESSIONS newexp = new FORM_INSTANCE_EXPRESSIONS();
                    newexp.EXPRESSION_VALUE = udvalue;
                    newexp.TEMPLATE_EXPRESSION_ID = exp.TEMPLATE_EXPRESSION_ID;
                    if (calc.Constants.ContainsKey(exp.TEMPLATE_EXPRESSION_NAME))
                    {
                        calc.Constants[exp.TEMPLATE_EXPRESSION_NAME] = udvalue;
                    }
                    else
                    {
                        calc.Constants.Add(exp.TEMPLATE_EXPRESSION_NAME, udvalue);
                    }
                    _scores.Add(newexp);

                    result.Add(exp.TEMPLATE_EXPRESSION_NAME, udvalue);
                }
                else
                {

                    FORM_INSTANCE_EXPRESSIONS newexp = new FORM_INSTANCE_EXPRESSIONS();
                    newexp.EXPRESSION_VALUE = value;
                    //exp.INSTANCE_EXPRESSION_ID = SequenceProviderFactory.CreateSequenceProvider(SequenceType.Custom, "INSTANCE_EXPRESSION_ID").getNext();
                    //newexp.INSTANCE_ID = this._instanceID;
                    newexp.TEMPLATE_EXPRESSION_ID = exp.TEMPLATE_EXPRESSION_ID;
                    if (calc.Constants.ContainsKey(exp.TEMPLATE_EXPRESSION_NAME))
                    {
                        calc.Constants[exp.TEMPLATE_EXPRESSION_NAME] = value;
                    }
                    else
                    {
                        calc.Constants.Add(exp.TEMPLATE_EXPRESSION_NAME, value);
                    }
                    _scores.Add(newexp);

                    result.Add(exp.TEMPLATE_EXPRESSION_NAME, value);
                }

            }






            return result;
        }

        #endregion

        #region Constructor

        public HtmlForm()
        {

        }

        #endregion

        #region public variables & function

        /// <summary>
        /// 取得HtmlDocument的head
        /// </summary>
        /// <returns>head的html字串</returns>
        private string GetHead()
        {
            //取回原html的head
            string header = "";
            HtmlNodeCollection nodes = this._instanceDocument.DocumentNode.SelectNodes("//head");

            if (nodes != null)
            {
                header = "<head>" + nodes.First<HtmlNode>().InnerHtml + "</head>";
            }

            return header;
        }

        /// <summary>
        /// 設定文件是否為ReadOnly
        /// </summary>
        private void checkReadOnly()
        {
            if (_instanceDocument != null)
            {
                if (!_readOnly)
                {
                    foreach (HtmlNode node in Utilities.GetAllNodes(_instanceDocument))
                    {
                        string disablestr = "readonly";
                        string disablevalue = "";
                        if (node.OriginalName.ToLower() == "textarea")
                        {
                            disablestr = "readonly";
                        }
                        else
                        {
                            if (node.OriginalName.ToLower() == "input" && node.Attributes.Contains("type") && node.Attributes["type"].Value == "text")
                            {
                                disablestr = "readonly";
                            }
                            else if (node.OriginalName.ToLower() == "input" && node.Attributes.Contains("type") && (node.Attributes["type"].Value == "radio" || node.Attributes["type"].Value == "checkbox"))
                            {
                                disablestr = "onclick";
                                disablevalue = "return false;";
                            }
                            else
                            {
                                disablestr = "disabled";
                            }
                        }
                        if (node.Attributes.Contains(disablestr))
                        {
                            if (disablestr == "onclick")
                            {
                                if (node.Attributes[disablestr].Value == disablevalue)
                                {
                                    node.Attributes.Remove(disablestr);
                                }
                                else
                                {
                                    node.Attributes[disablestr].Value = node.Attributes[disablestr].Value.Replace(disablevalue, "");
                                }
                            }
                            else
                            {
                                node.Attributes.Remove(disablestr);
                            }
                        }
                    }
                }
                else
                {
                    foreach (HtmlNode node in Utilities.GetAllNodes(_instanceDocument))
                    {
                        string disablestr = "readonly";
                        string disablevalue = "";
                        if (node.OriginalName.ToLower() == "textarea")
                        {
                            disablestr = "readonly";
                        }
                        else
                        {
                            if (node.OriginalName.ToLower() == "input" && node.Attributes.Contains("type") && node.Attributes["type"].Value == "text")
                            {
                                disablestr = "readonly";
                            }
                            else if (node.OriginalName.ToLower() == "input" && node.Attributes.Contains("type") && (node.Attributes["type"].Value == "radio" || node.Attributes["type"].Value == "checkbox"))
                            {
                                disablestr = "onclick";
                                disablevalue = "return false;";
                            }
                            else
                            {
                                disablestr = "disabled";
                            }
                        }
                        if (!node.Attributes.Contains(disablestr))
                        {
                            node.Attributes.Add(disablestr, disablevalue);
                        }
                        else
                        {
                            if(disablestr == "onclick")
                            {
                                node.Attributes[disablestr].Value = disablevalue + node.Attributes[disablestr].Value;
                            }
                        }

                        node.Attributes.Remove("name");
                    }

                }
            }
        }

        /// <summary>
        /// 取得目前html字串
        /// </summary>
        /// <returns></returns>
        public string GetCurrentHtml()
        {
            return _instanceDocument.DocumentNode.WriteTo();
        }

        /// <summary>
        /// 設定目前html字串
        /// </summary>
        /// <param name="html"></param>
        public void SetCurrentHtml(string html)
        {
            _instanceDocument.LoadHtml(html);
        }

        /// <summary>
        /// 是否唯讀
        /// </summary>
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                checkReadOnly();
                checkHideSetting();
            }
        }

        /// <summary>
        /// 取得目前instance的htmldocument
        /// </summary>
        public HtmlDocument InstanceDocument
        {
            get { return _instanceDocument; }
            set
            {
                _instanceDocument = value;
            }
        }

        /// <summary>
        /// 取得根據TemplateId(新填寫)或InstanceId(查詢)取出的Html
        /// </summary>
        public string InstanceHtml
        {
            get { return _instanceDocument.DocumentNode.WriteTo(); }
        }

        /// <summary>
        /// 取得計算出的分數
        /// </summary>
        public List<FORM_INSTANCE_EXPRESSIONS> Score
        {
            get { return this._scores; }
        }

        /// <summary>
        /// 取得目前的instance id
        /// </summary>
        public int InstanceID
        {
            get { return this._instanceID; }
        }

        /// <summary>
        /// 取得目前的template id
        /// </summary>
        public int TemplateID
        {
            get { return this._templateID; }
        }


        //private void SetOutSideValues(object valueobj)
        //{
        //  SetOutSideValues(valueobj,true);
        //}

        /// <summary>
        /// 設定外部參數
        /// </summary>
        /// <param name="valueobj"></param>
        /// <param name="replace">若已經有值是否取代</param>
        private void SetOutSideValues(bool replace)
        {

            ViewComponent vc = new ViewComponent();
            List<FORM_TEMPLATE_ELEMENTS> elements = vc.ListFormTemplateElement(this.TemplateID);

            foreach (FORM_TEMPLATE_ELEMENTS ele in elements)
            {
                if (ele.BINDVALUE != null && ele.BINDVALUE.Trim() != "")
                {
                    HtmlNode node = this._instanceDocument.DocumentNode.SelectSingleNode("//input[@id='" + ele.ID + "']");//.GetElementbyId(ele.ID);
                    if (node != null)
                    {
                        if (node.Attributes.Contains("bindvalue"))
                        {
                            string orihtml = node.OuterHtml;

                            node.Attributes["bindvalue"].Value = ele.BINDVALUE;
                            _instanceDocument.DocumentNode.InnerHtml = _instanceDocument.DocumentNode.InnerHtml.Replace(orihtml, node.OuterHtml);
                        }
                        else
                        {
                            string orihtml = node.OuterHtml;

                            node.Attributes.Add("bindvalue", ele.BINDVALUE);
                            _instanceDocument.DocumentNode.InnerHtml = _instanceDocument.DocumentNode.InnerHtml.Replace(orihtml, node.OuterHtml);

                        }

                    }
                }

                if(ele.ALLOWOVER)
                {
                    HtmlNode node = this._instanceDocument.GetElementbyId(ele.ID);
                    if (node != null)
                    {
                        double inputvalue = 0.0;
                        if (node.Attributes.Contains("value") && Double.TryParse(node.Attributes["value"].ToString(), out inputvalue))
                        {
                            if (ele.MAXPOINT < inputvalue)
                            {
                                if (!node.Attributes.Contains("style"))
                                {
                                    node.Attributes.Add("style", "background-color:#FF3333;");
                                }
                                else
                                {
                                    if (!node.Attributes["style"].Value.EndsWith(";"))
                                    {
                                        node.Attributes["style"].Value += ";";
                                    }

                                    node.Attributes["style"].Value += "background-color:#FF3333;";
                                }
                            }
                        }
                    }
                }

                //if (ele.BINDSQL != null && ele.BINDSQL.Trim() != "")
                //{
                //    HtmlNode node = this._instanceDocument.GetElementbyId(ele.ID);
                //    if (node != null)
                //    {
                //        if (node.Attributes.Contains("bindsql"))
                //        {
                //            string orihtml = node.OuterHtml;

                //            node.Attributes["bindsql"].Value = ele.BINDVALUE;
                //            _instanceDocument.DocumentNode.InnerHtml = _instanceDocument.DocumentNode.InnerHtml.Replace(orihtml, node.OuterHtml);
                //        }
                //        else
                //        {
                //            string orihtml = node.OuterHtml;

                //            node.Attributes.Add("bindsql", ele.BINDVALUE);
                //            _instanceDocument.DocumentNode.InnerHtml = _instanceDocument.DocumentNode.InnerHtml.Replace(orihtml, node.OuterHtml);

                //        }

                //    }
                //}

            }




            if (ParameterCollection.Count != 0)
            {




                foreach (string key in ParameterCollection.AllKeys)
                {
                    HtmlNodeCollection coll = this._instanceDocument.DocumentNode.SelectNodes("//*[@bindvalue = '" + key + "']");
                    if (coll != null)
                    {
                        foreach (HtmlNode node in coll)
                        {
                            //背景變色
                            if (!node.Attributes.Contains("style"))
                            {
                                node.Attributes.Add("style", "background-color:#EAE8E8;");
                            }
                            else
                            {
                                if (!node.Attributes["style"].Value.EndsWith(";"))
                                {
                                    node.Attributes["style"].Value += ";";
                                }

                                node.Attributes["style"].Value += "background-color:#EAE8E8;";
                            }
                            string disablestr = "readonly";
                            if (node.OriginalName.ToLower() == "textarea")
                            {
                                disablestr = "readonly";
                            }
                            else
                            {
                                disablestr = "disabled";
                            }
                            if (node.Attributes.Contains(disablestr))
                            {
                                continue;
                            }

                            if (!replace)
                            {
                                if (node.OriginalName.ToLower() == "textarea")
                                {
                                    if (node.InnerHtml != "")
                                    {
                                        continue;
                                    }
                                }
                                else
                                {

                                    if (node.Attributes.Contains("value") && node.Attributes["value"].Value != "")
                                    {
                                        continue;
                                    }
                                }
                            }



                            object value = null;
                            try
                            {
                                value = ParameterCollection[key];
                            }
                            catch
                            {
                            }
                            if (value != null)
                            {
                                if (node.OriginalName.ToLower() == "textarea")
                                {
                                    node.InnerHtml = value.ToString();
                                }
                                else
                                {
                                    HtmlUtility.SetAttribute("value", value.ToString(), node);

                                }
                            }
                        }

                    }

                }
            }
        }

        /// <summary>
        /// 帶入外部參數(動態sql)
        /// </summary>
        /// <param name="valuedic"></param>
        /// <param name="replace"></param>
        private void SetOutSideValues(Dictionary<string, IDataReader> valuedic, bool replace)
        {
            foreach (KeyValuePair<string, IDataReader> pair in valuedic)
            {

                if (pair.Value != null)
                {
                    for (int i = 1; i < 4; i++)
                    {
                        string fieldname = "Des" + i.ToString();
                        HtmlNode node = this._instanceDocument.GetElementbyId(pair.Key + "." + fieldname);
                        if (node != null)
                        {
                            if (!replace)
                            {
                                if (node.OriginalName.ToLower() == "textarea")
                                {
                                    if (node.InnerHtml != "")
                                    {
                                        continue;
                                    }
                                }
                                else
                                {

                                    if (node.Attributes.Contains("value") && node.Attributes["value"].Value != "")
                                    {
                                        continue;
                                    }
                                }
                            }


                            object value = null;
                            try
                            {
                                pair.Value.Read();
                                value = pair.Value[fieldname];
                            }
                            catch
                            {
                            }
                            if (value != null)
                            {
                                if (node.OriginalName.ToLower() == "textarea")
                                {
                                    node.InnerHtml = value.ToString();
                                }
                                else
                                {
                                    HtmlUtility.SetAttribute("value", value.ToString(), node);
                                    //node.SetAttribute("value", value.ToString());
                                }
                            }
                        }
                    }

                }

            }

        }
        /// <summary>
        /// 取得本template的hint內容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetHint(string id)
        {

            ViewComponent vc = new ViewComponent();
            DataTable reader = vc.ListFormTemplateSqlById(_templateID, id, "");
            if (reader == null)
            {
                return "";
            }
            
            return reader.Rows[0][0].ToString();
        }

        public void Create(int templateId)
        {
            Create(templateId, false);
        }


        /// <summary>
        /// 產生新Instance
        /// </summary>
        /// <param name="templateId">templateId</param>
        /// <param name="patientInfo">病患資訊</param>
        public void Create(int templateId,bool enableall)
        {
            //this._patientinfo = null;
            this._instanceDocument = LoadTemplate(templateId);

            //SetOutSideValues(patientInfo, true);

            //ViewComponent vc = new ViewComponent();
            //string inhospid = "";
            //if (patientInfo != null)
            //{
                //inhospid = patientInfo.INHOSPID;
            //}
            //SetOutSideValues(vc.ListFormTemplateSql(templateId, inhospid), true);


            FillExtraAttribute(templateId);
            //GenerateSelection(templateId);
            //GenerateCheckbox(templateId);
            GenerateControls(templateId);

            checkReadOnly();
            if (!enableall)
            {
                CheckEditor();
            }
            SetOutSideValues(false);
        }


        /// <summary>
        /// 將目前instance升級為最新template
        /// </summary>
        /// <param name="instanceId"></param>
        public void Upgrade(int instanceId)
        {
            HtmlDocument instancedoc = new HtmlDocument();

            instancedoc.LoadHtml(LoadInstance(instanceId).DocumentNode.InnerHtml);
            
            //ViewComponent component = new ViewComponent();

            //_currentTemplate = component.SelectFormTemplate(this._templateID);


            Create(this._templateID);

            //HtmlDocument doc = new HtmlDocument();

            //doc.LoadHtml(_currentTemplate.TEMPLATE_CONTENT);//.Replace("##AppImagePath##", System.Windows.Forms.Application.StartupPath + @"\tempImage\" + this._templateID + @"\"));

            HtmlDocument doc = _instanceDocument;

            //將原本已填的內容帶到新單子
            HtmlNodeCollection nodes = instancedoc.DocumentNode.SelectNodes("//input");
            if (nodes != null)
            {
                foreach (HtmlNode node in nodes)
                {
                    HtmlNode editnode = doc.GetElementbyId(node.Id);
                    if (editnode != null)
                    {
                        if (node.Attributes.Contains("value"))
                        {
                            HtmlUtility.SetAttribute("value", node.Attributes["value"].Value, editnode);
                            //editnode.SetAttribute("value", node.Attributes["value"].Value);
                        }

                        if (node.Attributes.Contains("checked"))
                        {
                            editnode.Attributes.Add("checked", "");
                        }
                    }


                }
            }
            nodes = instancedoc.DocumentNode.SelectNodes("//textarea");
            if (nodes != null)
            {
                foreach (HtmlNode node in nodes)
                {
                    HtmlNode editnode = doc.GetElementbyId(node.Id);
                    if (editnode != null)
                    {
                        editnode.InnerHtml = node.InnerHtml;
                    }
                }
            }

            this._instanceDocument = doc;

            //重新帶入外部參數
            //SetOutSideValues(component.ListFormTemplateSql(_currentInstance.TEMPLATE_ID, _currentInstance.INHOSPID), false);


            checkReadOnly();

            CheckEditor();
        }


        /// <summary>
        /// 查詢Instance
        /// </summary>
        /// <param name="instanceId">instanceId</param>
        public void Upgrade(int instanceId, bool replace)
        {
            HtmlDocument instancedoc = new HtmlDocument();

            instancedoc.LoadHtml(LoadInstance(instanceId).DocumentNode.InnerHtml);

            //ViewComponent component = new ViewComponent();

            //_currentTemplate = component.SelectFormTemplate(this._templateID);


            Create(this._templateID);

            //HtmlDocument doc = new HtmlDocument();

            //doc.LoadHtml(_currentTemplate.TEMPLATE_CONTENT);//.Replace("##AppImagePath##", System.Windows.Forms.Application.StartupPath + @"\tempImage\" + this._templateID + @"\"));

            HtmlDocument doc = _instanceDocument;

            HtmlNodeCollection nodes = instancedoc.DocumentNode.SelectNodes("//input");
            if (nodes != null)
            {
                foreach (HtmlNode node in nodes)
                {
                    HtmlNode editnode = doc.GetElementbyId(node.Id);
                    if (editnode != null)
                    {
                        if (node.Attributes.Contains("value"))
                        {
                            HtmlUtility.SetAttribute("value", node.Attributes["value"].Value, editnode);
                            //editnode.SetAttribute("value", node.Attributes["value"].Value);
                        }

                        if (node.Attributes.Contains("checked"))
                        {
                            editnode.Attributes.Add("checked", "");
                        }
                    }


                }
            }
            nodes = instancedoc.DocumentNode.SelectNodes("//textarea");
            if (nodes != null)
            {
                foreach (HtmlNode node in nodes)
                {
                    HtmlNode editnode = doc.GetElementbyId(node.Id);
                    if (editnode != null)
                    {
                        editnode.InnerHtml = node.InnerHtml;
                    }
                }
            }

            this._instanceDocument = doc;

            //SetOutSideValues(component.ListFormTemplateSql(_currentInstance.TEMPLATE_ID, _currentInstance.INHOSPID), false);
            checkReadOnly();

            CheckEditor();
        }


        /// <summary>
        /// 查詢Instance
        /// </summary>
        /// <param name="instanceId">instanceId</param>
        public List<HtmlForm> Query(int instanceId)
        {
            return Query(instanceId, true);
        }


        private List<FORM_INSTANCES> _beforeInstances = new List<FORM_INSTANCES>();
        public List<FORM_INSTANCES> BeforeInstances
        {
            get
            {
                return _beforeInstances;
            }
        }

        private List<FORM_INSTANCES> _afterInstances = new List<FORM_INSTANCES>();
        public List<FORM_INSTANCES> AfterInstances
        {
            get
            {
                return _afterInstances;
            }
        }

        public bool IsAfterEdited
        {
            get
            {
                bool result = false;
                foreach (FORM_INSTANCES ins in AfterInstances)
                {
                    if (ins.Status != "0")
                        result = true;
                }
                return result;
            }
        }

        private List<HtmlForm> _beforeForms = new List<HtmlForm>();
        public List<HtmlForm> BeforeForms
        {
            get
            {
                return _beforeForms;
            }
        }

        private List<HtmlForm> _afterForms = new List<HtmlForm>();
        public List<HtmlForm> AfterForms
        {
            get
            {
                return _afterForms;
            }
        }

        public List<HtmlForm> Query(int instanceId, bool replace, bool loadref)
        {
            return Query(instanceId, replace, loadref, true);
        }


        public List<HtmlForm> Query(int instanceId, bool replace, bool loadref, bool upgrade)
        {
            //this._patientinfo = patientInfo;

            this._instanceDocument = LoadInstance(instanceId);

            if (upgrade)
            {
                ViewComponent component = new ViewComponent();

                HtmlForm templateform = new HtmlForm();
                templateform.EditRole = this.EditRole;
                templateform.ParameterCollection = this.ParameterCollection;
                templateform.Create(_currentInstance.TEMPLATE_ID);
                //FORM_TEMPLATES template = component.SelectFormTemplate(_currentInstance.TEMPLATE_ID);
                HtmlDocument doc = new HtmlDocument();
                //doc.LoadHtml(template.TEMPLATE_CONTENT);
                doc.LoadHtml(templateform.InstanceHtml);

                HtmlNodeCollection nodes = _instanceDocument.DocumentNode.SelectNodes("//input");
                if (nodes != null)
                {
                    foreach (HtmlNode node in nodes)
                    {
                        HtmlNode editnode = doc.GetElementbyId(node.Id);
                        if (editnode != null)
                        {
                            if (node.Attributes.Contains("value"))
                            {
                                HtmlUtility.SetAttribute("value", node.Attributes["value"].Value, editnode);
                                //editnode.SetAttribute("value", node.Attributes["value"].Value);
                            }

                            if (node.Attributes.Contains("checked"))
                            {
                                editnode.Attributes.Add("checked", "");
                            }
                        }


                    }
                }
                nodes = _instanceDocument.DocumentNode.SelectNodes("//textarea");
                if (nodes != null)
                {
                    foreach (HtmlNode node in nodes)
                    {
                        HtmlNode editnode = doc.GetElementbyId(node.Id);
                        if (editnode != null)
                        {
                            editnode.InnerHtml = node.InnerHtml;
                        }
                    }
                }


                //try
                //{
                //    CheckSelections(_currentInstance.TEMPLATE_ID, ref doc);
                //}
                //catch (Exception ex)
                //{
                //}


                this._instanceDocument = doc;
                
            }

            FillExtraAttribute(_currentInstance.TEMPLATE_ID);

            ViewComponent vc = new ViewComponent();
            List<FORM_INSTANCES> list = vc.GetBeforeFormInstance(_currentInstance);
            List<FORM_INSTANCES> afterlist = vc.GetAfterFormInstance(_currentInstance);

            _beforeInstances = list;
            _afterInstances = afterlist;

            List<HtmlForm> result = new List<HtmlForm>();

            List<HtmlForm> after = new List<HtmlForm>();
            if (loadref)
            {

                foreach (FORM_INSTANCES ins in list)
                {
                    HtmlForm cform = new HtmlForm();
                    cform.ParameterCollection = this.ParameterCollection;
                    cform.Query(ins.INSTANCE_ID, true, false, false);
                    cform.ReadOnly = true;
                    result.Add(cform);
                }
                _beforeForms = result;


                foreach (FORM_INSTANCES ins in afterlist)
                {
                    HtmlForm cform = new HtmlForm();
                    cform.Query(ins.INSTANCE_ID, true, false, false);
                    cform.ReadOnly = true;
                    after.Add(cform);
                }

                _afterForms = after;
            }


            checkReadOnly();

            CheckEditor();

            checkReadOnlySetting();

            SetOutSideValues(false);

            return result;
        }

        public void checkHideSetting()
        {
            if (this.ReadOnly)
            {
                ViewComponent vc = new ViewComponent();
                List<FORM_TEMPLATE_ELEMENTS> elements = vc.ListFormTemplateElement(this.TemplateID);

                foreach (FORM_TEMPLATE_ELEMENTS ele in elements)
                {
                    if (ele.ISHIDE)
                    {
                        HtmlNode node = this._instanceDocument.GetElementbyId(ele.ID);
                        if (node != null)
                        {
                            if (node.OriginalName.ToLower() == "textarea")
                            {
                                string orihtml = node.OuterHtml;

                                node.InnerHtml = "本內容隱藏";
                                _instanceDocument.DocumentNode.InnerHtml = _instanceDocument.DocumentNode.InnerHtml.Replace(orihtml, node.OuterHtml);
                                HasHindField = true;
                            }
                            else
                            {
                                string orihtml = node.OuterHtml;

                                node.Attributes["value"].Value = "本內容隱藏";
                                _instanceDocument.DocumentNode.InnerHtml = _instanceDocument.DocumentNode.InnerHtml.Replace(orihtml, node.OuterHtml);
                                HasHindField = true;
                            }
                        }
                    }
                }
            }

        }

        public void checkReadOnlySetting()
        {
            ViewComponent vc = new ViewComponent();

            List<FORM_TEMPLATE_ELEMENT_READONLY> settings = vc.GetReadOnlySetting(this.TemplateID);

            foreach (FORM_TEMPLATE_ELEMENT_READONLY sett in settings)
            {
                if (sett.JOB_CODE != null && ParameterCollection.AllKeys.Contains("JobCode") && !ParameterCollection["JobCode"].Split(',').Contains(sett.JOB_CODE))
                {
                    continue;
                }
                if (this.ParameterCollection.AllKeys.Contains(sett.SETTINGTYPE) && this.ParameterCollection[sett.SETTINGTYPE] == sett.SETTINGID)
                {
                    FORM_TEMPLATE_ELEMENTS ele = vc.GetTemplateElementByTemplateElementID(sett.TEMPLATE_ELEMELT_ID);
                    if (ele != null)
                    {
                        HtmlNode node = this._instanceDocument.GetElementbyId(ele.ID);
                        if (node != null)
                        {
                            string disablestr = "readonly";
                            if (node.OriginalName.ToLower() == "textarea")
                            {
                                disablestr = "readonly";
                            }
                            else
                            {
                                disablestr = "disabled";
                            }
                            string orihtml = node.OuterHtml;
                            if (!node.Attributes.Contains(disablestr))
                            {
                                node.Attributes.Add(disablestr, "");
                            }

                            _instanceDocument.DocumentNode.InnerHtml = _instanceDocument.DocumentNode.InnerHtml.Replace(orihtml, node.OuterHtml);
                        }
                    }
                }
            }

        }

        private void CheckSelections(int templateid,ref HtmlDocument doc)
        {

            ViewComponent vc = new ViewComponent();
            List<FORM_TEMPLATE_ELEMENTS> elements = vc.ListFormTemplateElement(templateid);

            foreach (FORM_TEMPLATE_ELEMENTS ele in elements)
            {
              
                if (ele.BINDSQL != null && ele.BINDSQL.Trim() != "")
                {
                    HtmlNode node = doc.GetElementbyId(ele.ID);
                    if (node != null)
                    {
                        if (node.Attributes.Contains("bindsql"))
                        {
                            string orihtml = node.OuterHtml;

                            node.Attributes["bindsql"].Value = ele.BINDSQL;
                            doc.DocumentNode.InnerHtml = doc.DocumentNode.InnerHtml.Replace(orihtml, node.OuterHtml);
                        }
                        else
                        {
                            string orihtml = node.OuterHtml;

                            node.Attributes.Add("bindsql", ele.BINDSQL);
                            doc.DocumentNode.InnerHtml = doc.DocumentNode.InnerHtml.Replace(orihtml, node.OuterHtml);

                        }

                    }
                }

            }


            HtmlNodeCollection colls = doc.DocumentNode.SelectNodes("//select");
            if (colls != null)
            {
                foreach (HtmlNode node in colls)
                {
                    if (node.Attributes.Contains("bindsql"))
                    {
                        string innerhtml = "";


                        DataTable data = vc.ListFormTemplateSqlById(templateid, node.Attributes["bindsql"].Value, this.ParameterCollection);

                        foreach (DataRow dr in data.Rows)
                        {
                            var opnode = node.SelectNodes("//option[@value='" + dr["code"].ToString() + "']");
                            
                            string selected = "";

                            if (opnode != null)
                            {
                                foreach (var opn in opnode)
                                {

                                    if (opn.ParentNode == node && opn.Attributes.Contains("selected"))
                                    {
                                        selected = "selected=\"\"";
                                    }
                                }
                            }

                            innerhtml += "<option value=\"" + dr["code"].ToString() + "\" text=\"" + dr["name"].ToString() + "\" " + selected + " >" + dr["name"].ToString() + "</option>";
                        }

                        node.InnerHtml = innerhtml;
                        node.Attributes.Remove("bindsql");
                    }
                }
            }

        }


        private void CheckEditor()
        {
            HtmlNodeCollection coll = this._instanceDocument.DocumentNode.SelectNodes("//div[@editor]");
            if (coll != null)
            {
                foreach (HtmlNode node in coll)
                {
                    string[] roles = node.Attributes["editor"].Value.Split(',');
                    bool editable = false;

                    foreach (string role in EditRole)
                    {
                        if (roles.Contains(role))
                        {
                            editable = true;
                            break;
                        }
                    }

                    if (!editable)
                    {
                        HtmlDocument newdoc = new HtmlDocument();
                        newdoc.LoadHtml(node.OuterHtml);
                        foreach (HtmlNode subnode in Utilities.GetAllNodes(newdoc))
                        {
                            string orihtml = subnode.OuterHtml;
                            string disablestr = "readonly";
                            if (node.OriginalName.ToLower() == "textarea")
                            {
                                disablestr = "readonly";
                            }
                            else
                            {
                                disablestr = "disabled";
                            }
                            if (!subnode.Attributes.Contains(disablestr))
                            {
                                subnode.Attributes.Add(disablestr, "");
                            }

                            _instanceDocument.DocumentNode.InnerHtml = _instanceDocument.DocumentNode.InnerHtml.Replace(orihtml, subnode.OuterHtml);
                        }
                        //string html = SetDisable(node);
                        //_instanceDocument.DocumentNode.InnerHtml.Replace(node.InnerText, html);
                    }
                    else
                    {
                        HtmlDocument newdoc = new HtmlDocument();
                        newdoc.LoadHtml(node.OuterHtml);
                        foreach (HtmlNode subnode in Utilities.GetAllNodes(newdoc))
                        {
                            string orihtml = subnode.OuterHtml;
                            string disablestr = "readonly";
                            if (node.OriginalName.ToLower() == "textarea")
                            {
                                disablestr = "readonly";
                            }
                            else
                            {
                                disablestr = "disabled";
                            }
                            if (subnode.Attributes.Contains(disablestr))
                            {
                                subnode.Attributes.Remove(disablestr);
                            }

                            _instanceDocument.DocumentNode.InnerHtml = _instanceDocument.DocumentNode.InnerHtml.Replace(orihtml, subnode.OuterHtml);
                        }
                    }
                }
            }
        }

        private string SetDisable(HtmlNode node)
        {

            foreach (HtmlNode subnode in Utilities.GetAllNodes(node))
            {

                string disablestr = "readonly";
                if (subnode.OriginalName.ToLower() == "textarea")
                {
                    disablestr = "readonly";
                }
                else
                {
                    disablestr = "disabled";
                }

                if (!subnode.Attributes.Contains(disablestr))
                {
                    subnode.Attributes.Add(disablestr, "");
                }

            }

            return node.InnerHtml;
        }


        /// <summary>
        /// 查詢Instance
        /// </summary>
        /// <param name="instanceId">instanceId</param>
        public List<HtmlForm> Query(int instanceId, bool replace)
        {
            return Query(instanceId, replace, true);
        }

        private NameValueCollection _parameterCollection = new NameValueCollection();
        public NameValueCollection ParameterCollection
        {
            get
            {
                return _parameterCollection;
            }
            set
            {
                _parameterCollection = value;
            }
        }

        private NameValueCollection _sqlParameterCollection = new NameValueCollection();
        public NameValueCollection SqlParameterCollection
        {
            get
            {
                return _sqlParameterCollection;
            }
            set
            {
                _sqlParameterCollection = value;
            }
        }

        public void FillExtraAttribute(int templateid)
        {
            ViewComponent vc = new ViewComponent();
            List<FORM_TEMPLATE_ELEMENTS> list = vc.ListFormTemplateElement(templateid);
            HtmlNodeCollection nodes = this._instanceDocument.DocumentNode.SelectNodes("//input");
            if (nodes != null)
            {
                foreach (HtmlNode node in nodes)
                {
                    if (node.Attributes.Contains("id"))
                    {
                        FORM_TEMPLATE_ELEMENTS element = list.Where(c => c.ID == node.Attributes["id"].Value).FirstOrDefault();
                        if (element != null)
                        {
                            if (!node.Attributes.Contains("score"))
                            {
                                node.Attributes.Add("score", element.POINTS.HasValue ? element.POINTS.ToString() : "");
                            }
                            else
                            {
                                if (node.Attributes["score"].Value == "")
                                {
                                    node.SetAttributeValue("score", element.POINTS.HasValue ? element.POINTS.ToString() : "");
                                }
                            }

                            if (!node.Attributes.Contains("displayname"))
                            {
                                node.Attributes.Add("displayname", element.DISPLAY_NAME);
                            }
                            else
                            {
                                if (node.Attributes["displayname"].Value == "")
                                {
                                    node.SetAttributeValue("displayname", element.DISPLAY_NAME);
                                }
                            }

                        }
                    }
                }
            }
        }

        public void GenerateControls(int templateid)
        {
            ViewComponent vc = new ViewComponent();

            HtmlNodeCollection nodes = this._instanceDocument.DocumentNode.SelectNodes("//listgroup");

            GenerateSelection(templateid);
            GenerateCheckbox(templateid);

            if (nodes != null)
            {
                foreach (HtmlNode node in nodes)
                {
                    

                    string html = "";



                    string direction = "";
                    Dictionary<string, string> parmdic = new Dictionary<string, string>();

                    foreach (string key in SqlParameterCollection.AllKeys)
                    {
                        parmdic.Add(key, SqlParameterCollection[key]);
                    }

                    DataTable groupdt = vc.ListDynamicElementById(templateid, node.Attributes["id"].Value, parmdic, out direction);
                    int count = 0;
                    foreach (DataRow groupdr in groupdt.Rows)
                    {
                        HtmlNode copynode = node.Clone();
                        count++;
                        html += "<div><b>" + groupdr["value"].ToString() + "</b></div>";
                        Dictionary<string, string> parms = new Dictionary<string, string>();

                        foreach (DataColumn column in groupdt.Columns)
                        {
                            if (column.ColumnName.StartsWith("parm"))
                            {
                                parms.Add(column.ColumnName, groupdr[column.ColumnName].ToString());
                            }
                        }

                        GenerateSelection(templateid, copynode, parms, count);
                        GenerateCheckbox(templateid, copynode, parms, count);

                        html += copynode.InnerHtml;
                        copynode = null;
                    }

                    _instanceDocument.DocumentNode.InnerHtml = _instanceDocument.DocumentNode.InnerHtml.Replace(node.OuterHtml, html);
                }
            }



        }

        public void GenerateSelection(int templateid)
        {
            GenerateSelection(templateid, this._instanceDocument.DocumentNode, new Dictionary<string, string>(), 0);
        }

        public void GenerateSelection(int templateid, HtmlNode parentnode, Dictionary<string, string> parms, int parentcount)
        {
            ViewComponent vc = new ViewComponent();

            HtmlNodeCollection nodes = parentnode.SelectNodes("//selection");

            string parentcountstr = "";

            if (parentnode.OriginalName == "listgroup")
            {
                parentcountstr = parentnode.Attributes["id"].Value + "_" + parentcount.ToString() + "_";
            }

            if (nodes != null)
            {
                foreach (HtmlNode node in nodes)
                {
                    if ((parentnode.OriginalName != "listgroup" && node.ParentNode.OriginalName != "listgroup") || (parentnode.OriginalName == "listgroup"))
                    {

                        foreach (string key in SqlParameterCollection.AllKeys)
                        {
                            parms.Add(key, SqlParameterCollection[key]);
                        }

                        string direction = "";
                        DataTable dt = vc.ListDynamicElementById(templateid, node.Attributes["id"].Value, parms, out direction);


                        int columncount = 1;

                        if (node.Attributes.Contains("columncount"))
                        {
                            columncount = Convert.ToInt32(node.Attributes["columncount"].Value);
                        }

                        string html = "";
                        string format = "<input type = \"radio\" id=\"{0}\" name=\"{1}\" value=\"{2}\" displayname=\"{3}\" score=\"{4}\">{5}&nbsp;&nbsp;";// +direction;

                        int i = 0;
                        int count = 0;
                        foreach (DataRow dr in dt.Rows)
                        {
                            html += String.Format(format, parentcountstr + node.Attributes["id"].Value + "_" + i.ToString(), parentcountstr + node.Attributes["id"].Value, dr["value"].ToString(), dr["value"].ToString(), dt.Columns.Contains("score") ? dr["score"].ToString() : "", dr["value"].ToString());
                            i++;
                            count++;
                            if (count == columncount)
                            {
                                html += "<br/>";
                                count = 0;
                            }
                        }


                        if (node.Attributes.Contains("endwithother"))
                        {

                            //html += node.Attributes["endwithother"].Value + ":<br/>";
                            html += "<div>" + String.Format(format, parentcountstr + node.Attributes["id"].Value + "_otherrb", parentcountstr + node.Attributes["id"].Value, node.Attributes["endwithother"].Value, node.Attributes["endwithother"].Value, "", node.Attributes["endwithother"].Value);
                            html += "<input type=\"text\" size=\"40\" id=\"" + parentcountstr + node.Attributes["id"].Value + "_othertb" + "\" name=\"" + parentcountstr + node.Attributes["id"].Value + "_othertb" + "\"></div>";
                        }
                        parentnode.InnerHtml = parentnode.InnerHtml.Replace(node.OuterHtml, html);
                    }
                }

            }
        }

        public void GenerateCheckbox(int templateid)
        {
            GenerateCheckbox(templateid, this._instanceDocument.DocumentNode, new Dictionary<string, string>(), 0);
        }

        public void GenerateCheckbox(int templateid, HtmlNode parentnode, Dictionary<string, string> parms, int parentcount)
        {
            ViewComponent vc = new ViewComponent();
            HtmlNodeCollection nodes = parentnode.SelectNodes("//checklist");
            string parentcountstr = "";

            if (parentnode.OriginalName == "listgroup")
            {
                parentcountstr = parentnode.Attributes["id"].Value + "_" + parentcount.ToString() + "_";
            }

            if (nodes != null)
            {
                foreach (HtmlNode node in nodes)
                {
                    if ((parentnode.OriginalName != "listgroup" && node.ParentNode.OriginalName != "listgroup") || (parentnode.OriginalName == "listgroup"))
                    {
                        foreach (string key in SqlParameterCollection.AllKeys)
                        {
                            parms.Add(key, SqlParameterCollection[key]);
                        }
                        string direction = "";
                        DataTable dt = vc.ListDynamicElementById(templateid, node.Attributes["id"].Value, parms, out direction);

                        int columncount = 1;

                        if (node.Attributes.Contains("columncount"))
                        {
                            columncount = Convert.ToInt32(node.Attributes["columncount"].Value);
                        }

                        string html = "";
                        string format = "<input type = \"checkbox\" id=\"{0}\" name=\"{1}\" value=\"{2}\" displayname=\"{3}\" score=\"{4}\">{5}&nbsp;&nbsp;";// +direction;

                        int i = 0;
                        int count = 0;
                        foreach (DataRow dr in dt.Rows)
                        {
                            html += String.Format(format, parentcountstr + node.Attributes["id"].Value + "_" + i.ToString(), parentcountstr + node.Attributes["id"].Value + "_" + i.ToString(), dr["value"].ToString(), dr["value"].ToString(), dt.Columns.Contains("score") ? dr["score"].ToString() : "", dr["value"].ToString());
                            i++;
                            count++;
                            if (count == columncount)
                            {
                                html += "<br/>";
                                count = 0;
                            }
                        }

                        if (node.Attributes.Contains("endwithother"))
                        {

                            //html += node.Attributes["endwithother"].Value + ":<br/>";
                            html += "<div>" + String.Format(format, parentcountstr + node.Attributes["id"].Value + "_othercb", parentcountstr + node.Attributes["id"].Value + "_othercb", node.Attributes["endwithother"].Value, node.Attributes["endwithother"].Value, "", node.Attributes["endwithother"].Value);
                            html += "<input type=\"text\" size=\"40\" id=\"" + parentcountstr + node.Attributes["id"].Value + "_othertb" + "\" name=\"" + parentcountstr + node.Attributes["id"].Value + "_othertb" + "\"></div>";
                        }

                        parentnode.InnerHtml = parentnode.InnerHtml.Replace(node.OuterHtml, html);
                    }
                }
            }
        }


        /// <summary>
        /// 設定圖片
        /// </summary>
        /// <param name="templateId"></param>
        public void SetImageFiles(int templateId)
        {
            //string dir = System.Windows.Forms.Application.StartupPath + @"\tempImage\" + templateId;
            //ClearImageFiles(templateId);

            //ViewComponent component = new ViewComponent();
            //List<FORM_TEMPLATE_IMAGE> list = component.ListFormTemplateImage(templateId);
            //if (!Directory.Exists(System.Windows.Forms.Application.StartupPath + @"\tempImage"))
            //{
            //    Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + @"\tempImage");
            //}

            //if (list.Count > 0)
            //{
            //    Directory.CreateDirectory(dir);
            //}

            //foreach (FORM_TEMPLATE_IMAGE image in list)
            //{
            //    FileStream myFile = File.Open(dir + @"\" + image.FILE_NAME, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            //    BinaryWriter sw = new BinaryWriter(myFile);

            //    sw.Write(image.IMAGE_CONTENT);
            //    sw.Close();
            //    myFile.Close();
            //}

        }


        /// <summary>
        /// 清除暫存的圖片檔
        /// </summary>
        /// <param name="templateId"></param>
        public void ClearImageFiles(int templateId)
        {
            //string dir = System.Windows.Forms.Application.StartupPath + @"\tempImage\" + templateId;
            //if (Directory.Exists(dir))
            //{
            //    Directory.Delete(dir, true);
            //}
        }


        public void ReCalc()
        {
            
            HtmlDocument doc = InstanceDocument;

            HtmlNodeCollection coll = Utilities.GetAllNodes(doc);

            NameValueCollection nvcoll = new NameValueCollection();


            ViewComponent vc = new ViewComponent();
            List<FORM_INSTANCE_ELEMENTS> elements = vc.ListFormInstanceElements(_currentInstance.INSTANCE_ID);

            foreach (FORM_INSTANCE_ELEMENTS ele in elements)
            {
                if (elements.Count(c => c.NAME == ele.NAME) > 1)
                {
                    if (nvcoll.AllKeys.Contains(ele.NAME))
                    {
                        if (ele.ID == elements.Where(c => c.NAME == ele.NAME && c.ELEMENT_VALUE == "true").OrderBy(c => c.ID).FirstOrDefault().ID)
                        {
                            nvcoll[ele.NAME] = doc.GetElementbyId(ele.ID).Attributes["value"].Value;
                        }

                    }
                    else
                    {
                        if (ele.ELEMENT_VALUE == "true")
                        {
                            nvcoll.Add(ele.NAME, doc.GetElementbyId(ele.ID).Attributes["value"].Value);
                        }

                    }
                }
                else
                {
                    if (doc.GetElementbyId(ele.ID).Attributes.Contains("type") && doc.GetElementbyId(ele.ID).Attributes["type"].Value.ToLower() == "checkbox")
                    {
                        if (ele.ELEMENT_VALUE != "false")
                        {
                            nvcoll.Add(ele.NAME, ele.ELEMENT_VALUE);
                        }
                    }
                    else
                    {
                        nvcoll.Add(ele.NAME, ele.ELEMENT_VALUE);
                    }

                }
            }




            foreach (HtmlNode node in coll)
            {
                string l_type = "";
                if (node.Attributes.Contains("type"))
                {
                    l_type = node.Attributes["type"].Value;
                }
                else
                {
                    l_type = node.OriginalName;

                }

                if (nvcoll.AllKeys.Contains(node.Attributes["name"].Value))
                {
                    switch (l_type.ToLower())
                    {
                        case "radio":
                            if (node.Attributes.Contains("value") && (nvcoll[node.Attributes["name"].Value].Split(',').Contains(node.Attributes["value"].Value)))
                            {
                                if (!node.Attributes.Contains("checked"))
                                {
                                    node.Attributes.Add("checked", "");
                                }
                            }
                            else
                            {
                                if (node.Attributes.Contains("checked"))
                                {
                                    node.Attributes.Remove("checked");
                                }
                            }
                            break;
                        case "select":
                            foreach (HtmlNode option in node.ChildNodes)
                            {
                                if (option.OriginalName == "option")
                                {
                                    if (option.Attributes.Contains("value") && (nvcoll[node.Attributes["name"].Value].Split(',').Contains(option.Attributes["value"].Value)))
                                    {
                                        if (!option.Attributes.Contains("selected"))
                                        {
                                            option.Attributes.Add("selected", "");
                                        }
                                    }
                                    else
                                    {
                                        if (option.Attributes.Contains("selected"))
                                        {
                                            option.Attributes.Remove("selected");
                                        }

                                    }
                                }
                            }
                            break;
                        case "checkbox":

                            if (!node.Attributes.Contains("checked"))
                            {
                                node.Attributes.Add("checked", "");
                            }

                            break;
                        case "text":
                        case "number":
                        case "hidden":
                            if (node.Attributes.Contains("value"))
                            {
                                node.Attributes["value"].Value = nvcoll[node.Attributes["name"].Value];
                            }
                            else
                            {
                                node.Attributes.Add("value", nvcoll[node.Attributes["name"].Value]);
                            }
                            break;
                        case "textarea":
                            if (nvcoll[node.Attributes["name"].Value] != null)
                            {
                                node.InnerHtml = nvcoll[node.Attributes["name"].Value];
                            }
                            break;
                    }

                }
                else
                {
                    switch (l_type.ToLower())
                    {
                        case "radio":
                        case "checkbox":
                            if (node.Attributes.Contains("checked"))
                            {
                                node.Attributes.Remove("checked");
                            }
                            break;
                    }
                }
            }



            Submit(doc.DocumentNode.WriteTo(), _currentInstance.CREATER, false, null);
        }



        /// <summary>
        /// 填寫完畢作submit時呼叫
        /// </summary>
        /// <param name="inEditedHtml">經過畫面編輯後的html</param>
        /// <returns>填數分數欄位後的html</returns>
        public string Submit(string inEditedHtml, bool? ispass)
        {
            return Submit(inEditedHtml, null, true, ispass);
        }

        public string PreSave(NameValueCollection nvcoll, bool? ispass)
        {
            return PreSave(nvcoll, null, ispass);
        }
        public string Submit(NameValueCollection nvcoll, bool? ispass)
        {
            return Submit(nvcoll, null, true, ispass);
        }

        public string PreSave(NameValueCollection nvcoll, string creater, bool? ispass)
        {
            return Submit(nvcoll, creater, false, ispass);
        }

        public string Submit(NameValueCollection nvcoll, string creater, bool submit,bool? ispass)
        {
            this.SubmitSuccess = true;
            this.SubmitMessage = null;

            HtmlDocument doc = InstanceDocument;

            HtmlNodeCollection coll = Utilities.GetAllNodes(doc);

            List<string> canwritenames = new List<string>();

            foreach (HtmlNode node in coll)
            {
                string l_type = "";
                if (node.Attributes.Contains("type"))
                {
                    l_type = node.Attributes["type"].Value;
                }
                else
                {
                    l_type = node.OriginalName;

                }

                string disablestr = "readonly";
                if (node.OriginalName.ToLower() == "textarea")
                {
                    disablestr = "readonly";
                }
                else
                {
                    disablestr = "disabled";
                }

                if (!node.Attributes.Contains(disablestr))
                {
                    canwritenames.Add(node.Attributes["name"].Value);
                }

                if (node.Attributes["name"]!= null && nvcoll.AllKeys.Contains(node.Attributes["name"].Value))
                {
                    switch (l_type.ToLower())
                    {
                        case "radio":
                            if (node.Attributes.Contains("value") && (nvcoll[node.Attributes["name"].Value].Split(',').Contains(node.Attributes["value"].Value)))
                            {
                                if (!node.Attributes.Contains("checked"))
                                {
                                    node.Attributes.Add("checked", "");
                                }
                            }
                            else
                            {
                                if (node.Attributes.Contains("checked"))
                                {
                                    node.Attributes.Remove("checked");
                                }
                            }
                            break;
                        case "select":
                            foreach (HtmlNode option in node.ChildNodes)
                            {
                                if (option.OriginalName == "option")
                                {
                                    if (option.Attributes.Contains("value") && (nvcoll[node.Attributes["name"].Value].Split(',').Contains(option.Attributes["value"].Value)))
                                    {
                                        if (!option.Attributes.Contains("selected"))
                                        {
                                            option.Attributes.Add("selected", "");
                                        }
                                    }
                                    else
                                    {
                                        if (option.Attributes.Contains("selected"))
                                        {
                                            option.Attributes.Remove("selected");
                                        }

                                    }
                                }
                            }
                            break;
                        case "checkbox":

                            if (!node.Attributes.Contains("checked"))
                            {
                                node.Attributes.Add("checked", "");
                            }

                            break;
                        case "text":
                        case "number":
                        case "hidden":
                            if (node.Attributes.Contains("value"))
                            {
                                node.Attributes["value"].Value = nvcoll[node.Attributes["name"].Value].Replace("<", "&lt;").Replace(">", "&gt;").Replace("&", "&amp;").Replace("\"", "&quot;").Replace("'", "&apos;");
                            }
                            else
                            {
                                node.Attributes.Add("value", nvcoll[node.Attributes["name"].Value].Replace("<", "&lt;").Replace(">", "&gt;").Replace("&", "&amp;").Replace("\"", "&quot;").Replace("'", "&apos;"));
                            }
                            break;
                        case "textarea":

                            node.InnerHtml = nvcoll[node.Attributes["name"].Value].Replace("<", "&lt;").Replace(">", "&gt;").Replace("&", "&amp;").Replace("\"", "&quot;").Replace("'", "&apos;");
                            break;
                    }

                }
                else
                {
                    switch (l_type.ToLower())
                    {
                        //case "radio":
                        case "checkbox":
                            if (node.Attributes.Contains("checked"))
                            {
                                node.Attributes.Remove("checked");
                            }
                            break;
                    }
                }
            }

            ViewComponent vc = new ViewComponent();


            if (submit)
            {
                List<FORM_TEMPLATE_NECESSARY> neclist = vc.GetTemplateNecessary(_templateID);
                List<FORM_TEMPLATE_ELEMENTS> checkeles = vc.ListFormTemplateElement(_templateID);

                foreach (FORM_TEMPLATE_NECESSARY nec in neclist)
                {
                    string[] necs = nec.NAME.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                    bool hasvalue = false;
                    bool needcheck = false;
                    foreach (string necname in necs)
                    {

                        if (canwritenames.Contains(necname))
                        {
                            FORM_TEMPLATE_ELEMENTS checkele = checkeles.Where(c => c.NAME == necname).FirstOrDefault();
                            string controltype = "";
                            if (checkele != null)
                            {
                                controltype = checkele.CONTROL_TYPE;
                            }
                            needcheck = true;
                            if (nvcoll[necname] == null || nvcoll[necname].Trim() == "" && controltype != "checkbox")
                            {

                            }
                            else
                            {
                                hasvalue = true;
                            }

                        }
                    }
                    if (needcheck && !hasvalue)
                    {
                        this.SubmitSuccess = false;
                        this.SubmitMessage = nec.MESSAGE;
                        _instanceDocument.DocumentNode.InnerHtml = doc.DocumentNode.WriteTo();
                        return null;
                    }
                }


                //檢查老師設定
                FORM_TEMPLATES temp = vc.GetFormTemplateById(_templateID);
                if (this.AfterInstances != null && this.AfterInstances.Count > 0 && this.AfterInstances[0].FORM_TEMPLATES.TEMPLATE_REMARK == "C")
                {
                    List<FORM_INSTANCE_TARGETS> targets = vc.GetInstanceTargets(this.AfterInstances[0].INSTANCE_ID);
                    if (targets.Count > 0 && (targets[0].TargetID == null || targets[0].TargetID == ""))
                    {
                        this.SubmitSuccess = false;
                        this.SubmitMessage = "請先選擇老師";
                        _instanceDocument.DocumentNode.InnerHtml = doc.DocumentNode.WriteTo();
                        return null;
                    }
                }



                List<FORM_TEMPLATE_SINGLE> singlelist = vc.GetTemplateSingle(_templateID);
                bool checkok = true;
                foreach (FORM_TEMPLATE_SINGLE sing in singlelist)
                {
                    string[] ids = sing.IDs.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    bool haschecked = false;
                    foreach (string id in ids)
                    {
                        foreach (HtmlNode node in coll)
                        {
                            if (node.Attributes["id"].Value != id)
                            {
                                continue;
                            }
                            if (!canwritenames.Contains(node.Attributes["name"].Value))
                            {
                                continue;
                            }

                            if (node.Attributes.Contains("checked"))
                            {
                                if (!haschecked)
                                {
                                    haschecked = true;
                                }
                                else
                                {
                                    checkok = false;
                                }
                            }
                        }
                    }

                }

                if (!checkok)
                {
                    this.SubmitSuccess = false;
                    this.SubmitMessage = "請確認單選項目是否重複勾選";
                    _instanceDocument.DocumentNode.InnerHtml = doc.DocumentNode.WriteTo();
                    return null;
                }

                List<FORM_TEMPLATE_ELEMENTS> eles = vc.GetFormTemplateElementMaxScore(_templateID);

                foreach (FORM_TEMPLATE_ELEMENTS maxele in eles)
                {
                    if (!(nvcoll[maxele.NAME] == null || nvcoll[maxele.NAME].Trim() == ""))
                    {
                        try
                        {
                            if (Convert.ToDouble(nvcoll[maxele.NAME]) > maxele.MAXPOINT.Value)
                            {
                                if (!maxele.ALLOWOVER)
                                {
                                    this.SubmitSuccess = false;
                                    this.SubmitMessage = "輸入值超出上限";
                                    _instanceDocument.DocumentNode.InnerHtml = doc.DocumentNode.WriteTo();
                                    return null;
                                }
                                else
                                {
                                    HtmlNode node = doc.GetElementbyId(maxele.ID);
                                    if (node != null)
                                    {
                                        if (!node.Attributes.Contains("style"))
                                        {
                                            node.Attributes.Add("style", "background-color:#FF3333;");
                                        }
                                        else
                                        {
                                            if (!node.Attributes["style"].Value.EndsWith(";"))
                                            {
                                                node.Attributes["style"].Value += ";";
                                            }

                                            node.Attributes["style"].Value += "background-color:#FF3333;";
                                        }
                                    }
                                }
                            }
                        }
                        catch
                        {
                            this.SubmitSuccess = false;
                            this.SubmitMessage = "輸入值非數字格式";
                            _instanceDocument.DocumentNode.InnerHtml = doc.DocumentNode.WriteTo();
                            return null;
                        }
                    }
                }


                List<FORM_TEMPLATE_ELEMENTS> mintexteles = vc.GetFormTemplateElementMinTextCount(_templateID);

                foreach (FORM_TEMPLATE_ELEMENTS maxele in mintexteles)
                {
                    if (canwritenames.Contains(maxele.NAME))
                    {
                        if (!(nvcoll[maxele.NAME] == null || nvcoll[maxele.NAME].Trim() == ""))
                        {

                            if (nvcoll[maxele.NAME].Trim().Length < maxele.MinTextCount.Value)
                            {
                                this.SubmitSuccess = false;
                                this.SubmitMessage = maxele.DISPLAY_NAME + "欄位請至少輸入" + maxele.MinTextCount.Value.ToString() + "字以上";
                                _instanceDocument.DocumentNode.InnerHtml = doc.DocumentNode.WriteTo();
                                return null;
                            }
                        }
                    }
                }

                List<FORM_TEMPLATE_ELEMENTS> maxtexteles = vc.GetFormTemplateElementMaxTextCount(_templateID);

                foreach (FORM_TEMPLATE_ELEMENTS maxele in maxtexteles)
                {
                    if (canwritenames.Contains(maxele.NAME))
                    {
                        if (!(nvcoll[maxele.NAME] == null || nvcoll[maxele.NAME].Trim() == ""))
                        {

                            if (nvcoll[maxele.NAME].Trim().Length > maxele.MaxTextCount.Value)
                            {
                                this.SubmitSuccess = false;
                                this.SubmitMessage = maxele.DISPLAY_NAME + "欄位最多只能輸入" + maxele.MinTextCount.Value.ToString() + "字";
                                _instanceDocument.DocumentNode.InnerHtml = doc.DocumentNode.WriteTo();
                                return null;
                            }
                        }
                    }
                }


            }

            List<FORM_TEMPLATE_SUBMIT_SQL> submitsqllist = vc.GetSubmitSql(_templateID);

            string status =null;
            if (CurrentInstance != null)
            {
                if (CurrentInstance.FORM_INSTANCE_TARGETS.Count == 1)
                {
                    var instar = CurrentInstance.FORM_INSTANCE_TARGETS.FirstOrDefault();
                    if (instar != null)
                    {
                        status = instar.Status;
                    }
                }
                else
                {
                    var instar = CurrentInstance.FORM_INSTANCE_TARGETS.Where(c => c.TargetID == creater).FirstOrDefault();
                    if (instar != null)
                    {
                        status = instar.Status;
                    }
                }
            }
            foreach (FORM_TEMPLATE_SUBMIT_SQL submitsql in submitsqllist)
            {
                //只有第一次submit要執行的話跳過
                if (submitsql.EXECUTE_FIRST_TIME && status != "0")
                {
                    continue;
                }
                string _sql = submitsql.SOURCEREFSTATEMENT;
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandText = _sql;
                foreach (string key in this.ParameterCollection.Keys)
                {
                    if (_sql.ToLower().Contains("@" + key.ToLower()))
                    {
                        System.Data.SqlClient.SqlParameter parm = new System.Data.SqlClient.SqlParameter("@" + key, ParameterCollection[key]);
                        cmd.Parameters.Add(parm);
                    }
                }

                foreach (string key in nvcoll.Keys)
                {
                    if (_sql.ToLower().Contains("@" + key.ToLower()))
                    {
                        System.Data.SqlClient.SqlParameter parm = new System.Data.SqlClient.SqlParameter("@" + key, nvcoll[key]);
                        cmd.Parameters.Add(parm);
                    }
                }
                DataContextDataContext context = new DataContextDataContext();
                cmd.Connection = context.Connection as System.Data.SqlClient.SqlConnection;
                SubmitSQL.Add(cmd);
            }



            return Submit(doc.DocumentNode.WriteTo(), creater, submit, ispass);
        }


        /// <summary>
        /// 填寫完畢作submit時呼叫
        /// </summary>
        /// <param name="inEditedHtml">經過畫面編輯後的html</param>
        /// <returns>填數分數欄位後的html</returns>
        public string Submit(string inEditedHtml, string creater,bool submit, bool? ispass)
        {
            #region Setp1 Load edited html into HtmlDocument

            string header = this.GetHead();

            //寫入head+body以避免格式跑掉
            inEditedHtml = header + "<body>" + inEditedHtml + "</body>";


            HtmlDocument editedDoc = new HtmlDocument();
            editedDoc.LoadHtml(inEditedHtml);

            //替換圖片
            //AppFramework.Html.Parser.HtmlNodeCollection coll = editedDoc.DocumentNode.SelectNodes("//img");
            //if (coll != null)
            //{
            //    foreach (AppFramework.Html.Parser.HtmlNode node in coll)
            //    {
            //        if (node.Attributes.Contains("src"))
            //        {
            //            node.Attributes["src"].Value = "##AppImagePath##" +
            //                                           node.Attributes["src"].Value.Substring(
            //                                               node.Attributes["src"].Value.LastIndexOf("/") + 1);
            //        }
            //    }
            //}


            #endregion

            #region fix type

            HtmlNodeCollection coll = editedDoc.DocumentNode.SelectNodes("//input");
            if (coll != null)
            {
                foreach (HtmlNode node in coll)
                {
                    if (!node.Attributes.Contains("type"))
                    {
                        node.Attributes.Add("type", "text");
                    }
                    if (!node.Attributes.Contains("value"))
                    {
                        node.Attributes.Add("value", "");
                    }
                }
            }

            #endregion

            #region 多填寫者時防複寫特別處理

            if (_editMode)
            {
                if (_currentInstance.FORM_INSTANCE_TARGETS.Count > 1)
                {
                    HtmlNodeCollection checkcoll = Utilities.GetAllNodes(editedDoc);
                    ViewComponent vc = new ViewComponent();

                    List<FORM_INSTANCE_ELEMENTS> checkeles = vc.ListFormInstanceElements(_currentInstance.INSTANCE_ID);

                    
                    foreach (HtmlNode node in checkcoll)
                    {
                        if (node.Attributes["disabled"] != null)
                        {
                            FORM_INSTANCE_ELEMENTS cele = checkeles.Where(c => c.ID == node.Attributes["id"].Value).FirstOrDefault();

                            if (cele != null)
                            {
                                string l_type = "";
                                if (node.Attributes.Contains("type"))
                                {
                                    l_type = node.Attributes["type"].Value;
                                }
                                else
                                {
                                    l_type = node.OriginalName;
                                }

                                switch (l_type.ToLower())
                                {
                                    case "radio":
                                    case "checkbox":
                                        if (cele.ELEMENT_VALUE == "true")
                                        {
                                            node.Attributes.Add("checked", "");
                                        }
                                        else
                                        {
                                            node.Attributes.Remove("checked");
                                        }

                                        break;
                                    case "select":
                                        HtmlNodeCollection options = node.SelectNodes("option");
                                        if (options != null)
                                        {
                                            foreach (HtmlNode option in options)
                                            {
                                                if (option.Attributes["value"].Value == cele.ELEMENT_VALUE)
                                                {
                                                    option.Attributes.Add("selected", "");
                                                }
                                                else
                                                {
                                                    option.Attributes.Remove("selected");
                                                }
                                            }
                                        }
                                        break;
                                    case "text":
                                    case "hidden":

                                        HtmlUtility.SetAttribute("value", cele.ELEMENT_VALUE, node);
                                        break;
                                    case "textarea":
                                        node.InnerHtml = cele.ELEMENT_VALUE;

                                        break;
                                }
                            }
                        }

                    }

                }
            }

            #endregion


            #region Setp2 Do expressions and calculate score

            Dictionary<string, double> valuelist = this.DoExpression(editedDoc);

            foreach (string ctr_id in valuelist.Keys)
            {
                try
                {
                    HtmlUtility.SetAttribute(ctr_id, "value", valuelist[ctr_id].ToString(), editedDoc);
                }
                catch
                {

                }
                //editedDoc.SetAttribute(ctr_id, "value", valuelist[ctr_id].ToString());
            }

            #endregion

            #region Setp3 Replace Img src
            //if (editedDoc.DocumentNode.SelectNodes("//img") != null)
            //{
            //    foreach (HtmlNode node in editedDoc.DocumentNode.SelectNodes("//img"))
            //    {
            //        if (node.Attributes.Contains("src"))
            //        {
            //            node.Attributes["src"].Value = "##AppImagePath##" + node.Attributes["src"].Value.Substring(node.Attributes["src"].Value.LastIndexOf(@"\") + 1);
            //        }
            //    }
            //}

            #endregion

            #region Setp4 Write instance data to database

            ProcessComponent component = new ProcessComponent();
            if (_editMode)
            {
                _currentInstance.CREATER = creater;
                _instanceID = component.UpdateInstance(editedDoc, _currentInstance, _scores, submit, ispass);
            }
            else
            {
                _instanceID = component.InsertInstance(editedDoc, _templateID, _templateName, null, _scores, creater, ispass);
                _editMode = true;
                ViewComponent vc = new ViewComponent();
                _currentInstance = vc.SelectFormInstance(_instanceID);
            }

            #endregion

            #region Setp5 Return score

            return editedDoc.DocumentNode.InnerHtml;

            #endregion
        }

        #endregion
    }
}
