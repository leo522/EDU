using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AppFramework.Sequence;
using HtmlAgilityPack;

namespace HtmlFormUtility.Components
{
    public class ProcessComponent
    {
        DataContextDataContext context = new DataContextDataContext();


        public int CreateFormInstance(FORM_INSTANCES ins)
        {
            context.FORM_INSTANCES.InsertOnSubmit(ins);
            context.SubmitChanges();
            return ins.INSTANCE_ID;
        }

        public FORM_TEMPLATES InsertTemplate(string templateName, int? parentTemplateId,string type, string hospcode)
        {
            FORM_TEMPLATES template = new FORM_TEMPLATES();
            template.TEMPLATE_NAME = templateName;
            template.PARENT_TEMPLATE_ID = parentTemplateId;
            template.TEMPLATE_TYPE = type;
            template.TEMPLATE_CATEGORY = "EduActivity";
            template.TEMPLATE_CREATE_DATATIME = DateTime.Now;
            template.TEMPLATE_CONTENT = "";
            template.ENABLED = true;
            context.FORM_TEMPLATES.InsertOnSubmit(template);
            context.SubmitChanges();

            FORM_TEMPLATE_PERMISSION perm = new FORM_TEMPLATE_PERMISSION();
            perm.CREATEDATE = DateTime.Now;
            perm.HOSPCODE = hospcode;
            perm.TEMPLATE_ID = template.TEMPLATE_ID;
            context.FORM_TEMPLATE_PERMISSION.InsertOnSubmit(perm);
            context.SubmitChanges();

            
            return template;



        }

        public void UpdateTemplateUserDefine(int templateid, bool isuserdefine)
        {
            FORM_TEMPLATES template = context.FORM_TEMPLATES.Where(c => c.TEMPLATE_ID == templateid).FirstOrDefault();
            if(template!=null)
            {
                template.IS_USER_DEFINE_TARGET = isuserdefine;
                context.SubmitChanges();
            }
        }
        public void UpdateTemplateNeedPass(int templateid, bool needpass, bool allow_return, bool allow_takeback, bool display_to_evaltarget, string remark, bool queryevaltarget)
        {
            FORM_TEMPLATES template = context.FORM_TEMPLATES.Where(c => c.TEMPLATE_ID == templateid).FirstOrDefault();
            if (template != null)
            {
                template.ALLOW_VIEW_EVALTARGETDATA = queryevaltarget;
                template.NEEDPASS = needpass;
                template.ALLOW_RETURN = allow_return;
                template.ALLOW_TAKEBACK = allow_takeback;
                template.DISPLAY_TO_EVALTARGET = display_to_evaltarget;
                template.TEMPLATE_REMARK = remark;
                
                context.SubmitChanges();
            }
        }


        public FORM_TEMPLATES CopyTemplate(int fromtemplateid,string oritemplateName,  string templateName , int? parentid)
        {
            FORM_TEMPLATES fromtemp = context.FORM_TEMPLATES.Where(c => c.TEMPLATE_ID == fromtemplateid).FirstOrDefault();
            if (fromtemp == null)
            {
                return null;
            }
            string oriname = oritemplateName;
            if(oriname == null)
            {
                oriname = fromtemp.TEMPLATE_NAME;
            }

            FORM_TEMPLATES template = new FORM_TEMPLATES();
            template.ALERT_NEXT_MESSAGE = fromtemp.ALERT_NEXT_MESSAGE;
            template.ALLOW_ATTACHMENT = fromtemp.ALLOW_ATTACHMENT;
            template.DISPLAY_TO_EVALTARGET = fromtemp.DISPLAY_TO_EVALTARGET;
            template.PARENT_TEMPLATE_ID = parentid;
            template.SCORE_FIELD_ID = fromtemp.SCORE_FIELD_ID;
            template.TEMPLATE_ALTER_DATATIME = DateTime.Now;
            template.TEMPLATE_CATEGORY = fromtemp.TEMPLATE_CATEGORY;
            template.TEMPLATE_CONTENT = fromtemp.TEMPLATE_CONTENT;
            template.TEMPLATE_CREATE_DATATIME = DateTime.Now;
            template.TEMPLATE_NAME = fromtemp.TEMPLATE_NAME.Replace(oriname, templateName);
            template.TEMPLATE_REMARK = fromtemp.TEMPLATE_REMARK;
            template.TEMPLATE_TYPE = fromtemp.TEMPLATE_TYPE;
            template.ENABLED = true;

            context.FORM_TEMPLATES.InsertOnSubmit(template);
            context.SubmitChanges();

            foreach (var ssql in fromtemp.FORM_TEMPLATE_SUBMIT_SQL)
            {
                FORM_TEMPLATE_SUBMIT_SQL s = new FORM_TEMPLATE_SUBMIT_SQL();
                s.EXECUTE_FIRST_TIME = ssql.EXECUTE_FIRST_TIME;
                s.KEY = ssql.KEY;
                s.SOURCEREFSTATEMENT = ssql.SOURCEREFSTATEMENT;
                s.TEMPLATE_ID = template.TEMPLATE_ID;
                context.FORM_TEMPLATE_SUBMIT_SQL.InsertOnSubmit(s);
            }
            context.SubmitChanges();

            foreach (var data in context.FORM_TEMPLATE_SQL.Where(c => c.TEMPLATE_ID == fromtemp.TEMPLATE_ID))
            {
                FORM_TEMPLATE_SQL s = new FORM_TEMPLATE_SQL();
                s.KEY = data.KEY;
                s.SOURCEREFSTATEMENT = data.SOURCEREFSTATEMENT;
                s.TEMPLATE_ID = template.TEMPLATE_ID;
                context.FORM_TEMPLATE_SQL.InsertOnSubmit(s);
            }
            context.SubmitChanges();

            foreach (var data in context.FORM_TEMPLATE_SINGLE.Where(c => c.TemplateID == fromtemp.TEMPLATE_ID))
            {
                FORM_TEMPLATE_SINGLE s = new FORM_TEMPLATE_SINGLE();
                s.IDs = data.IDs;
                s.TemplateID = template.TEMPLATE_ID;
                context.FORM_TEMPLATE_SINGLE.InsertOnSubmit(s);
            }
            context.SubmitChanges();

            foreach (var data in context.FORM_TEMPLATE_SCRIPT.Where(c => c.TEMPLATE_ID == fromtemp.TEMPLATE_ID))
            {
                FORM_TEMPLATE_SCRIPT s = new FORM_TEMPLATE_SCRIPT();
                s.SCRIPT_CONTENT = data.SCRIPT_CONTENT;
                s.TEMPLATE_ID = template.TEMPLATE_ID;
                context.FORM_TEMPLATE_SCRIPT.InsertOnSubmit(s);
            }
            context.SubmitChanges();

            foreach (var data in context.FORM_TEMPLATE_NECESSARY.Where(c => c.TEMPLATE_ID == fromtemp.TEMPLATE_ID))
            {
                FORM_TEMPLATE_NECESSARY s = new FORM_TEMPLATE_NECESSARY();
                s.ENABLE = data.ENABLE;
                s.MESSAGE = data.MESSAGE;
                s.NAME = data.NAME;
                s.TEMPLATE_ID = template.TEMPLATE_ID;
                context.FORM_TEMPLATE_NECESSARY.InsertOnSubmit(s);
            }
            context.SubmitChanges();

            Dictionary<int, int> libidmap = new Dictionary<int, int>();
            foreach (var data in context.FORM_TEMPLATE_LIBRARY.Where(c => c.FORM_TEMPLATE_ID == fromtemp.TEMPLATE_ID))
            {
                FORM_TEMPLATE_LIBRARY s = new FORM_TEMPLATE_LIBRARY();
                s.DISPLAY = data.DISPLAY;
                s.QUESTION_CONTENT = data.QUESTION_CONTENT;
                s.QUESTION_TYPE = data.QUESTION_TYPE;
                s.FORM_TEMPLATE_ID = template.TEMPLATE_ID;
                context.FORM_TEMPLATE_LIBRARY.InsertOnSubmit(s);
                context.SubmitChanges();
                libidmap.Add(data.FORM_TEMPLATE_LIBRARY_ID, s.FORM_TEMPLATE_LIBRARY_ID);
            }

            foreach (int key in libidmap.Keys)
            {
                foreach (var data in context.FORM_TEMPLATE_LIBRARY_OPTION.Where(c => c.LIBRARY_ID == key))
                {
                    FORM_TEMPLATE_LIBRARY_OPTION s = new FORM_TEMPLATE_LIBRARY_OPTION();
                    s.DISPLAY_ORDER = data.DISPLAY_ORDER;
                    s.IS_ANSWER = data.IS_ANSWER;
                    s.OPTION_POINTS = data.OPTION_POINTS;
                    s.OPTION_TEXT = data.OPTION_TEXT;
                    s.OPTION_TYPE = data.OPTION_TYPE;
                    s.LIBRARY_ID = libidmap[data.LIBRARY_ID.Value];
                    context.FORM_TEMPLATE_LIBRARY_OPTION.InsertOnSubmit(s);
                }
            }
            context.SubmitChanges();


            foreach (var data in context.FORM_TEMPLATE_IMAGES.Where(c => c.TEMPLATE_ID == fromtemp.TEMPLATE_ID))
            {
                FORM_TEMPLATE_IMAGES s = new FORM_TEMPLATE_IMAGES();
                s.FILE_NAME = data.FILE_NAME;
                s.IMAGE_CONTENT = data.IMAGE_CONTENT;
                s.TEMPLATE_ID = template.TEMPLATE_ID;
                context.FORM_TEMPLATE_IMAGES.InsertOnSubmit(s);
            }

            context.SubmitChanges();

            foreach (var data in context.FORM_TEMPLATE_PERMISSION.Where(c => c.TEMPLATE_ID == fromtemp.TEMPLATE_ID))
            {
                FORM_TEMPLATE_PERMISSION s = new FORM_TEMPLATE_PERMISSION();
                s.CREATEDATE = DateTime.Now;
                s.CREATER = data.CREATER;
                s.HOSPCODE = data.HOSPCODE;
                s.TEMPLATE_ID = template.TEMPLATE_ID;
                context.FORM_TEMPLATE_PERMISSION.InsertOnSubmit(s);
            }

            context.SubmitChanges();


            Dictionary<int, int> groupidmap = new Dictionary<int, int>();
            foreach (var data in context.FORM_TEMPLATE_GROUPS.Where(c => c.TEMPLATE_ID == fromtemp.TEMPLATE_ID))
            {
                FORM_TEMPLATE_GROUPS s = new FORM_TEMPLATE_GROUPS();
                s.DISPLAY_ORDER = data.DISPLAY_ORDER;
                s.GROUP_NAME = data.GROUP_NAME;
                s.TO_EVALTARGET = data.TO_EVALTARGET;
                s.TEMPLATE_ID = template.TEMPLATE_ID;
                context.FORM_TEMPLATE_GROUPS.InsertOnSubmit(s);
                context.SubmitChanges();
                groupidmap.Add(data.GROUP_ID, s.GROUP_ID);
            }

            foreach (var data in context.FORM_TEMPLATE_EXPRESSIONS.Where(c => c.TEMPLATE_ID == fromtemp.TEMPLATE_ID))
            {
                FORM_TEMPLATE_EXPRESSIONS s = new FORM_TEMPLATE_EXPRESSIONS();
                s.ALLOWUSERDEFINE = data.ALLOWUSERDEFINE;
                s.EXECUTE_ORDER = data.EXECUTE_ORDER;
                s.EXPRESSION = data.EXPRESSION;
                s.ISFINALSCORE = data.ISFINALSCORE;
                s.TEMPLATE_EXPRESSION_NAME = data.TEMPLATE_EXPRESSION_NAME;
                s.TEMPLATE_ID = template.TEMPLATE_ID;
                context.FORM_TEMPLATE_EXPRESSIONS.InsertOnSubmit(s);
            }

            context.SubmitChanges();

            Dictionary<string, string> eleidmap = new Dictionary<string, string>();
            foreach (var data in context.FORM_TEMPLATE_ELEMENTS.Where(c => c.TEMPLATE_ID == fromtemp.TEMPLATE_ID))
            {
                FORM_TEMPLATE_ELEMENTS s = new FORM_TEMPLATE_ELEMENTS();
                s.ALLOWOVER = data.ALLOWOVER;
                s.BINDSQL = data.BINDSQL;
                s.BINDVALUE = data.BINDVALUE;
                s.CONTROL_TYPE = data.CONTROL_TYPE;
                s.DATA_TYPE = data.DATA_TYPE;
                s.DISPLAY_NAME = data.DISPLAY_NAME;
                if (data.GROUP_ID.HasValue && groupidmap.ContainsKey(data.GROUP_ID.Value))
                {
                    s.GROUP_ID = groupidmap[data.GROUP_ID.Value];
                }
                s.ID = data.ID;
                s.ISHIDE = data.ISHIDE;
                s.MAXPOINT = data.MAXPOINT;
                s.NAME = data.NAME;
                s.POINTS = data.POINTS;
                s.TEMPLATE_ELEMENT_ID = template.TEMPLATE_ID.ToString() + data.TEMPLATE_ELEMENT_ID.Substring(data.TEMPLATE_ID.ToString().Length - 1);
                s.TEMPLATE_ID = template.TEMPLATE_ID;
                context.FORM_TEMPLATE_ELEMENTS.InsertOnSubmit(s);

                eleidmap.Add(data.TEMPLATE_ELEMENT_ID, s.TEMPLATE_ELEMENT_ID);
            }

            context.SubmitChanges();

            foreach (string key in eleidmap.Keys)
            {
                foreach (var data in context.FORM_TEMPLATE_ELEMENT_READONLies.Where(c => c.TEMPLATE_ELEMELT_ID == key))
                {
                    FORM_TEMPLATE_ELEMENT_READONLY s = new FORM_TEMPLATE_ELEMENT_READONLY();
                    s.JOB_CODE = data.JOB_CODE;
                    s.SETTINGID = data.SETTINGID;
                    s.SETTINGTYPE = data.SETTINGTYPE;
                    s.TEMPLATE_ELEMELT_ID = eleidmap[key];
                    context.FORM_TEMPLATE_ELEMENT_READONLies.InsertOnSubmit(s);
                }
            }

            context.SubmitChanges();

            foreach (var data in context.FORM_TEMPLATE_DYNAMIC_ELEMENTS.Where(c => c.TEMPLATE_ID == fromtemp.TEMPLATE_ID))
            {
                FORM_TEMPLATE_DYNAMIC_ELEMENTS s = new FORM_TEMPLATE_DYNAMIC_ELEMENTS();
                s.DISPLAY_DIRECTION = data.DISPLAY_DIRECTION;
                s.KEY = data.KEY;
                s.SOURCEREFSTATEMENT = data.SOURCEREFSTATEMENT;
                s.TEMPLATE_ID = template.TEMPLATE_ID;
                context.FORM_TEMPLATE_DYNAMIC_ELEMENTS.InsertOnSubmit(s);
            }

            context.SubmitChanges();

            foreach (var t in context.FORM_TEMPLATES.Where(c => c.PARENT_TEMPLATE_ID == fromtemplateid))
            {
                CopyTemplate(t.TEMPLATE_ID, oriname, templateName, template.TEMPLATE_ID);
            }


            return template;
        }

        public FORM_TEMPLATES InsertTemplate(HtmlDocument doc, string templateName, int? parentTemplateId, string category, string remark, Dictionary<string, byte[]> uploadimages, string hospcode)
        {
            return AddTemplate(doc, templateName, parentTemplateId, category, remark, uploadimages, hospcode);
        }

        private FORM_TEMPLATES AddTemplate(HtmlDocument doc, string templateName, int? parentTemplateId, string category, string remark, Dictionary<string, byte[]> uploadimages, string hospcode)
        {

            FORM_TEMPLATES template = new FORM_TEMPLATES();

            template.PARENT_TEMPLATE_ID = parentTemplateId;
            template.TEMPLATE_ALTER_DATATIME = DateTime.Now;
            template.TEMPLATE_CATEGORY = category;

            template.TEMPLATE_CONTENT = doc.DocumentNode.WriteTo();
            template.ENABLED = true;

            template.TEMPLATE_CREATE_DATATIME = DateTime.Now;

            template.TEMPLATE_NAME = templateName;
            template.TEMPLATE_REMARK = remark;

            context.FORM_TEMPLATES.InsertOnSubmit(template);
            context.SubmitChanges();


            FORM_TEMPLATE_PERMISSION perm = new FORM_TEMPLATE_PERMISSION();
            perm.CREATEDATE = DateTime.Now;
            perm.HOSPCODE = hospcode;
            perm.TEMPLATE_ID = template.TEMPLATE_ID;
            context.FORM_TEMPLATE_PERMISSION.InsertOnSubmit(perm);
            context.SubmitChanges();

            List<FORM_TEMPLATE_ELEMENTS> list = new List<FORM_TEMPLATE_ELEMENTS>();

            HtmlNodeCollection coll = Utilities.GetAllNodes(doc);

            int idcount = 0;
           
            List<FORM_TEMPLATE_GROUPS> groups = new List<FORM_TEMPLATE_GROUPS>();


            foreach (HtmlNode node in coll)
            {
                string l_type = "";
                bool isradio = false;
                if (node.Attributes.Contains("type"))
                {
                    l_type = node.Attributes["type"].Value;
                    if (node.Attributes["type"].Value.ToLower() == "radio")
                    {
                        isradio = true;
                    }
                }
                else
                {
                    l_type = node.OriginalName;
                }


                FORM_TEMPLATE_GROUPS g = null;

                if(isradio && node.Attributes.Contains("name"))
                {
                    string groupname = node.Attributes["name"].ToString();
                    g = groups.Where(c => c.GROUP_NAME == groupname).FirstOrDefault();
                    if (g == null)
                    {
                        g = new FORM_TEMPLATE_GROUPS();
                        g.TEMPLATE_ID = template.TEMPLATE_ID;
                        g.GROUP_NAME = groupname;
                        groups.Add(g);
                        context.FORM_TEMPLATE_GROUPS.InsertOnSubmit(g);
                        context.SubmitChanges();
                    }
                }

                    


                if ((!node.Attributes.Contains("id")) || (node.Attributes["id"].Value == ""))
                {
                    node.Attributes.Add("id", "controlid" + idcount.ToString());
                    idcount++;
                }

                if ((!node.Attributes.Contains("name")) || (node.Attributes["name"].Value == ""))
                {
                    node.Attributes.Add("name", node.Attributes["id"].Value);
                }

                FORM_TEMPLATE_ELEMENTS element = new FORM_TEMPLATE_ELEMENTS();
                element.CONTROL_TYPE = l_type;
                element.DATA_TYPE = "string";
                element.ID = node.Attributes["id"].Value;
                element.NAME = node.Attributes["name"].Value;
                element.TEMPLATE_ELEMENT_ID = template.TEMPLATE_ID.ToString() + "_" + element.ID;
                element.TEMPLATE_ID = template.TEMPLATE_ID;
                if (isradio)
                {
                    if(g!=null)
                    {
                        element.GROUP_ID = g.GROUP_ID;
                    }
                    element.DISPLAY_NAME = node.Attributes["value"].Value;
                    try
                    {
                        double point = Convert.ToDouble(node.Attributes["value"].Value);
                        element.POINTS = point;
                    }
                    catch
                    {
                    }
                }
                else
                {
                    element.DISPLAY_NAME = node.Attributes["name"].Value;
                }
                

                list.Add(element);
            }

            List<FORM_TEMPLATE_IMAGES> image_list = new List<FORM_TEMPLATE_IMAGES>();
            foreach (KeyValuePair<string, byte[]> pair in uploadimages)
            {
                FORM_TEMPLATE_IMAGES image = new FORM_TEMPLATE_IMAGES();
                image.FILE_NAME = pair.Key;
                image.IMAGE_CONTENT = pair.Value;
                image.TEMPLATE_ID = template.TEMPLATE_ID;
                //image.TEMPLATE_IMAGE_ID =
                //    SequenceProviderFactory.CreateSequenceProvider(SequenceType.Custom, "T_IMAGE_ID").getNext();
                image_list.Add(image);
            }

            foreach (FORM_TEMPLATE_ELEMENTS element in list)
            {
                List<FORM_TEMPLATE_ELEMENTS> ed_elements = context.FORM_TEMPLATE_ELEMENTS.Where(c => c.TEMPLATE_ID == element.TEMPLATE_ID
                                                           && c.ID == element.ID).ToList();
                if (ed_elements.Count > 0)
                {
                    ed_elements[0].NAME = element.NAME;
                    ed_elements[0].DATA_TYPE = element.DATA_TYPE;
                    ed_elements[0].CONTROL_TYPE = element.CONTROL_TYPE;
                }
                else
                {
                    context.FORM_TEMPLATE_ELEMENTS.InsertOnSubmit(element);
                }
            }

            foreach (FORM_TEMPLATE_IMAGES image in image_list)
            {
                context.FORM_TEMPLATE_IMAGES.InsertOnSubmit(image);
            }


            context.SubmitChanges();
            return template;
        }

        public bool DeleteTemplate(int templateId)
        {
            return DeleteFromTemplateImages(templateId)
                //&& dal.DeleteFromTemplateExpressions(templateId)
                && DeleteFromTemplateElements(templateId)
                && DeleteFromTemplate(templateId);
        }

        public bool DeleteTemplate(int templateId, HtmlDocument doc)
        {
            return DeleteFromTemplateImages(templateId)
                //&& dal.DeleteFromTemplateExpressions(templateId)
                && DeleteFromTemplateElements(templateId, doc);
        }

        public FORM_TEMPLATES RenewTemplateEle(int templateId, HtmlDocument doc, Dictionary<string, byte[]> uploadimages)
        {
            FORM_TEMPLATES template = SelectFormTemplate(templateId);

            template.TEMPLATE_CONTENT = doc.DocumentNode.WriteTo();
            template.TEMPLATE_ALTER_DATATIME = DateTime.Now;


            List<FORM_TEMPLATE_GROUPS> oldgroups = context.FORM_TEMPLATE_GROUPS.Where(c => c.TEMPLATE_ID == templateId).ToList();
            List<FORM_TEMPLATE_ELEMENTS> oldelelist = context.FORM_TEMPLATE_ELEMENTS.Where(c => c.TEMPLATE_ID == templateId).ToList();


            List<FORM_TEMPLATE_ELEMENTS> list = new List<FORM_TEMPLATE_ELEMENTS>();
            HtmlNodeCollection coll = Utilities.GetAllNodes(doc);

            foreach (HtmlNode node in coll)
            {
                string l_type = "";
                if (node.Attributes.Contains("type"))
                {
                    l_type = node.Attributes["type"].Value;
                }
                else
                {
                    if (node.Name == "input")
                    {
                        l_type = "text";

                    }
                    else
                    {
                        l_type = node.OriginalName;
                    }
                }

                if ((!node.Attributes.Contains("name")) || (node.Attributes["name"].Value == ""))
                {
                    node.Attributes.Add("name", node.Attributes["id"].Value);
                }




                FORM_TEMPLATE_ELEMENTS element = new FORM_TEMPLATE_ELEMENTS();
                element.CONTROL_TYPE = l_type;
                element.DATA_TYPE = "string";
                element.ID = node.Attributes["id"].Value;
                element.TEMPLATE_ELEMENT_ID = template.TEMPLATE_ID.ToString() + "_" + element.ID;
                element.NAME = node.Attributes["name"].Value;
                element.TEMPLATE_ID = template.TEMPLATE_ID;

                FORM_TEMPLATE_ELEMENTS oldele = oldelelist.Where(c => c.ID == element.ID).FirstOrDefault();

                if (oldele == null)
                {
                    list.Add(element);
                }




                
            }

            foreach (FORM_TEMPLATE_ELEMENTS element in list)
            {
                context.FORM_TEMPLATE_ELEMENTS.InsertOnSubmit(element);
            }

            context.SubmitChanges();


            return template;
        }

        public FORM_TEMPLATES RenewTemplate(int templateId, HtmlDocument doc, Dictionary<string, byte[]> uploadimages)
        {
            FORM_TEMPLATES template = SelectFormTemplate(templateId);

            template.TEMPLATE_CONTENT = doc.DocumentNode.WriteTo();
            template.TEMPLATE_ALTER_DATATIME = DateTime.Now;


            List<FORM_TEMPLATE_GROUPS> oldgroups = context.FORM_TEMPLATE_GROUPS.Where(c => c.TEMPLATE_ID == templateId).ToList();
            List<FORM_TEMPLATE_ELEMENTS> oldelelist = context.FORM_TEMPLATE_ELEMENTS.Where(c => c.TEMPLATE_ID == templateId).ToList();


            List<FORM_TEMPLATE_ELEMENTS> list = new List<FORM_TEMPLATE_ELEMENTS>();
            HtmlNodeCollection coll = Utilities.GetAllNodes(doc);

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

                if ((!node.Attributes.Contains("name")) || (node.Attributes["name"].Value == ""))
                {
                    node.Attributes.Add("name", node.Attributes["id"].Value);
                }


                
                
                FORM_TEMPLATE_ELEMENTS element = new FORM_TEMPLATE_ELEMENTS();
                element.CONTROL_TYPE = l_type;
                element.DATA_TYPE = "string";
                element.ID = node.Attributes["id"].Value;
                element.TEMPLATE_ELEMENT_ID = template.TEMPLATE_ID.ToString() + "_" + element.ID;
                element.NAME = node.Attributes["name"].Value;
                element.TEMPLATE_ID = template.TEMPLATE_ID;

                FORM_TEMPLATE_ELEMENTS oldele = oldelelist.Where(c => c.ID == element.ID).FirstOrDefault();

                if (oldele != null)
                {
                    element.POINTS = oldele.POINTS;
                    element.GROUP_ID = oldele.GROUP_ID;
                    element.ALLOWOVER = oldele.ALLOWOVER;
                    element.BINDSQL = oldele.BINDSQL;
                    element.BINDVALUE = oldele.BINDVALUE;
                    element.DISPLAY_NAME = oldele.DISPLAY_NAME;
                    element.ISHIDE = oldele.ISHIDE;
                    element.MAXPOINT = oldele.MAXPOINT;
                }

                if (element.CONTROL_TYPE == "radio" && element.GROUP_ID == null)
                {

                    FORM_TEMPLATE_GROUPS g = oldgroups.Where(c => c.GROUP_NAME == element.NAME).FirstOrDefault();
                    if (g == null)
                    {
                        g = new FORM_TEMPLATE_GROUPS();
                        g.TEMPLATE_ID = template.TEMPLATE_ID;
                        g.GROUP_NAME = element.NAME;
                        oldgroups.Add(g);
                        context.FORM_TEMPLATE_GROUPS.InsertOnSubmit(g);
                        context.SubmitChanges();
                    }
                    element.GROUP_ID = g.GROUP_ID;
                }



                list.Add(element);
            }

            List<FORM_TEMPLATE_IMAGES> image_list = new List<FORM_TEMPLATE_IMAGES>();
            foreach (KeyValuePair<string, byte[]> pair in uploadimages)
            {
                FORM_TEMPLATE_IMAGES image = new FORM_TEMPLATE_IMAGES();
                image.FILE_NAME = pair.Key;
                image.IMAGE_CONTENT = pair.Value;
                image.TEMPLATE_ID = template.TEMPLATE_ID;
                image_list.Add(image);
            }

            context.FORM_TEMPLATE_ELEMENTS.DeleteAllOnSubmit(oldelelist);
            context.FORM_TEMPLATE_IMAGES.DeleteAllOnSubmit(context.FORM_TEMPLATE_IMAGES.Where(c => c.TEMPLATE_ID == templateId));

            context.SubmitChanges();

            foreach (FORM_TEMPLATE_ELEMENTS element in list)
            {
                try
                {
                    context.FORM_TEMPLATE_ELEMENTS.InsertOnSubmit(element);

                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }

            foreach (FORM_TEMPLATE_IMAGES image in image_list)
            {
                context.FORM_TEMPLATE_IMAGES.InsertOnSubmit(image);
            }


            context.SubmitChanges();


            return template;
        }


        public FORM_TEMPLATES UpdateTemplate(int templateId, HtmlDocument doc, Dictionary<string, byte[]> uploadimages)
        {
            FORM_TEMPLATES template = SelectFormTemplate(templateId);
            string templateName = template.TEMPLATE_NAME;
            string category = template.TEMPLATE_CATEGORY;
            string remark = template.TEMPLATE_REMARK;
            int? parentTemplateId = template.PARENT_TEMPLATE_ID;

            DeleteTemplate(templateId, doc);

            return UpdateTemplate(templateId, doc, templateName, parentTemplateId, category, remark, uploadimages);
        }


        public string AdminSaveTemplateContent(int templateId, string content)
        {
            string msg = null;
            try
            {
                FORM_TEMPLATES template = SelectFormTemplate(templateId);

                template.TEMPLATE_CONTENT = content;

                context.SubmitChanges();
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(content);

                RenewTemplateEle(templateId, doc, new Dictionary<string, byte[]>());

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }



            return msg;
        }

        public string UpdateTemplateContent(int templateId, string content)
        {
            string msg = null;
            try
            {
                FORM_TEMPLATES template = SelectFormTemplate(templateId);

                template.TEMPLATE_CONTENT = content;

                context.SubmitChanges();
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(content);

                RenewTemplate(templateId, doc, new Dictionary<string, byte[]>());

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }



            return msg;
        }

        private FORM_TEMPLATES UpdateTemplate(int templateId, HtmlDocument doc, string templateName, int? parentTemplateId, string category, string remark, Dictionary<string, byte[]> uploadimages)
        {

            FORM_TEMPLATES template = SelectFormTemplate(templateId);

            template.PARENT_TEMPLATE_ID = parentTemplateId;
            template.TEMPLATE_ALTER_DATATIME = DateTime.Now;
            template.TEMPLATE_CATEGORY = category;

            template.TEMPLATE_CONTENT = doc.DocumentNode.WriteTo();


            template.TEMPLATE_CREATE_DATATIME = DateTime.Now;

            template.TEMPLATE_NAME = templateName;
            template.TEMPLATE_REMARK = remark;

            context.FORM_TEMPLATES.InsertOnSubmit(template);

            context.SubmitChanges();

            List<FORM_TEMPLATE_ELEMENTS> list = new List<FORM_TEMPLATE_ELEMENTS>();


            HtmlNodeCollection coll = Utilities.GetAllNodes(doc);

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

                if ((!node.Attributes.Contains("name")) || (node.Attributes["name"].Value == ""))
                {
                    node.Attributes.Add("name", node.Attributes["id"].Value);
                }

                FORM_TEMPLATE_ELEMENTS element = new FORM_TEMPLATE_ELEMENTS();
                element.CONTROL_TYPE = l_type;
                element.DATA_TYPE = "string";
                element.ID = node.Attributes["id"].Value;
                element.NAME = node.Attributes["name"].Value;
                element.TEMPLATE_ELEMENT_ID = template.TEMPLATE_ID.ToString() + "_" + element.ID;
                element.TEMPLATE_ID = template.TEMPLATE_ID;
                list.Add(element);
            }

            List<FORM_TEMPLATE_IMAGES> image_list = new List<FORM_TEMPLATE_IMAGES>();
            foreach (KeyValuePair<string, byte[]> pair in uploadimages)
            {
                FORM_TEMPLATE_IMAGES image = new FORM_TEMPLATE_IMAGES();
                image.FILE_NAME = pair.Key;
                image.IMAGE_CONTENT = pair.Value;
                image.TEMPLATE_ID = template.TEMPLATE_ID;
                //image.TEMPLATE_IMAGE_ID =
                //    SequenceProviderFactory.CreateSequenceProvider(SequenceType.Custom, "T_IMAGE_ID").getNext();
                image_list.Add(image);
            }

            foreach (FORM_TEMPLATE_ELEMENTS element in list)
            {
                List<FORM_TEMPLATE_ELEMENTS> ed_elements = context.FORM_TEMPLATE_ELEMENTS.Where(c => c.TEMPLATE_ID == element.TEMPLATE_ID
                                                           && c.ID == element.ID).ToList();
                if (ed_elements.Count > 0)
                {
                    ed_elements[0].NAME = element.NAME;
                    ed_elements[0].DATA_TYPE = element.DATA_TYPE;
                    ed_elements[0].CONTROL_TYPE = element.CONTROL_TYPE;
                }
                else
                {
                    context.FORM_TEMPLATE_ELEMENTS.InsertOnSubmit(element);
                }
            }

            foreach (FORM_TEMPLATE_IMAGES image in image_list)
            {
                context.FORM_TEMPLATE_IMAGES.InsertOnSubmit(image);
            }


            context.SubmitChanges();
            return template;
        }

        public bool InsertTemplateExpression(int templateId, List<FORM_TEMPLATE_EXPRESSIONS> list)
        {
            foreach (FORM_TEMPLATE_EXPRESSIONS exp in list)
            {
                exp.TEMPLATE_ID = templateId;
            }

            return DeleteFromTemplateExpressions(templateId) && InsertFormTemplateExpressions(list);

        }


        public bool DeleteInstance(int instanceID)
        {
            FORM_INSTANCES instance = context.FORM_INSTANCES.Where(c => c.INSTANCE_ID == instanceID).FirstOrDefault();

            if (instance != null)
            {
                if (instance.PARENT_INSTANCE_ID != null)
                {
                    foreach (FORM_INSTANCES delins in context.FORM_INSTANCES.Where(c => c.PARENT_INSTANCE_ID == instance.PARENT_INSTANCE_ID || c.INSTANCE_ID == instance.PARENT_INSTANCE_ID).ToList())
                    {
                        context.FORM_INSTANCE_TARGETS.DeleteAllOnSubmit(context.FORM_INSTANCE_TARGETS.Where(c => c.INSTANCE_ID == delins.INSTANCE_ID));
                        context.FORM_INSTANCE_ELEMENTS.DeleteAllOnSubmit(context.FORM_INSTANCE_ELEMENTS.Where(c => c.INSTANCE_ID == delins.INSTANCE_ID));
                        context.FORM_INSTANCE_EXPRESSIONS.DeleteAllOnSubmit(context.FORM_INSTANCE_EXPRESSIONS.Where(c => c.INSTANCE_ID == delins.INSTANCE_ID));
                        context.FORM_INSTANCE_ATTACHMENTS.DeleteAllOnSubmit(context.FORM_INSTANCE_ATTACHMENTS.Where(c => c.INSTANCE_ID == delins.INSTANCE_ID));
                        context.FORM_INSTANCES.DeleteOnSubmit(delins);
                    }
                }
                else
                {

                    context.FORM_INSTANCE_TARGETS.DeleteAllOnSubmit(context.FORM_INSTANCE_TARGETS.Where(c => c.INSTANCE_ID == instance.INSTANCE_ID));
                    context.FORM_INSTANCE_ELEMENTS.DeleteAllOnSubmit(context.FORM_INSTANCE_ELEMENTS.Where(c => c.INSTANCE_ID == instance.INSTANCE_ID));
                    context.FORM_INSTANCE_EXPRESSIONS.DeleteAllOnSubmit(context.FORM_INSTANCE_EXPRESSIONS.Where(c => c.INSTANCE_ID == instance.INSTANCE_ID));
                    context.FORM_INSTANCE_ATTACHMENTS.DeleteAllOnSubmit(context.FORM_INSTANCE_ATTACHMENTS.Where(c => c.INSTANCE_ID == instance.INSTANCE_ID));
                    context.FORM_INSTANCES.DeleteOnSubmit(instance);

                    
                }
                try
                {
                    context.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }


            return true;
        }


        public void DeleteInstanceByRemark(string remark)
        {
            if (remark != null)
            {
                List<FORM_INSTANCES> list = context.FORM_INSTANCES.Where(c => c.INSTANCE_REMARK == remark).ToList();

                foreach (FORM_INSTANCES instance in list)
                {
                    context.FORM_INSTANCE_TARGETS.DeleteAllOnSubmit(context.FORM_INSTANCE_TARGETS.Where(c => c.INSTANCE_ID == instance.INSTANCE_ID));
                    context.FORM_INSTANCE_ELEMENTS.DeleteAllOnSubmit(context.FORM_INSTANCE_ELEMENTS.Where(c => c.INSTANCE_ID == instance.INSTANCE_ID));
                    context.FORM_INSTANCE_EXPRESSIONS.DeleteAllOnSubmit(context.FORM_INSTANCE_EXPRESSIONS.Where(c => c.INSTANCE_ID == instance.INSTANCE_ID));
                    context.FORM_INSTANCE_ATTACHMENTS.DeleteAllOnSubmit(context.FORM_INSTANCE_ATTACHMENTS.Where(c => c.INSTANCE_ID == instance.INSTANCE_ID));
                    context.FORM_INSTANCES.DeleteOnSubmit(instance);
                }

                context.SubmitChanges();
            }
        }


        public int InsertInstance(HtmlDocument doc, int templateId, string instanceName, string remark, List<FORM_INSTANCE_EXPRESSIONS> exp_list, bool? ispass)
        {
            return InsertInstance(doc, templateId, instanceName, remark, exp_list, null, ispass);
        }

        public int InsertInstance(HtmlDocument doc, int templateId, string instanceName, string remark, List<FORM_INSTANCE_EXPRESSIONS> exp_list, string creater, bool? ispass)
        {
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//input"))
            {
                if (!node.Attributes.Contains("type"))
                {
                    node.Attributes.Add("type", "text");
                }
            }

            FORM_INSTANCES instance = new FORM_INSTANCES();

            instance.INSTANCE_ALTER_DATETIME = DateTime.Now;


            instance.IsPass = ispass;


            instance.INSTANCE_CREATE_DATETIME = DateTime.Now;

            instance.INSTANCE_NAME = instanceName;
            instance.INSTANCE_REMARK = remark;
            instance.TEMPLATE_ID = templateId;
            instance.INHOSPID = null;
            if (creater != null)
            {
                instance.TargetID = creater;
                instance.CREATER = creater;
            }
            instance.INSTANCE_CONTENT = doc.DocumentNode.WriteTo();
            instance.Status = "0";

            context.FORM_INSTANCES.InsertOnSubmit(instance);
            context.SubmitChanges();


            List<FORM_INSTANCE_ELEMENTS> list = new List<FORM_INSTANCE_ELEMENTS>();

            HtmlNodeCollection coll = Utilities.GetAllNodes(doc);


            foreach (HtmlNode node in coll)
            {
                FORM_INSTANCE_ELEMENTS element = new FORM_INSTANCE_ELEMENTS();

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
                        if (node.Attributes.Contains("checked"))
                        {
                            element.ELEMENT_VALUE = "true";
                        }
                        else
                        {
                            element.ELEMENT_VALUE = "false";
                        }
                        break;
                    case "select":
                        HtmlNodeCollection options = node.SelectNodes("option");
                        if (options != null)
                        {
                            foreach (HtmlNode option in options)
                            {
                                if (option.Attributes.Contains("selected"))
                                {
                                    element.ELEMENT_VALUE = option.Attributes["value"].Value;
                                    if (option.Attributes.Contains("text"))
                                    {
                                        element.SELECT_VALUE = option.Attributes["text"].Value;
                                    }
                                }
                            }
                        }
                        break;
                    case "text":
                    case "hidden":
                        if (node.Attributes.Contains("value"))
                        {
                            element.ELEMENT_VALUE = node.Attributes["value"].Value;
                        }
                        else
                        {
                            element.ELEMENT_VALUE = "";
                            node.Attributes.Add("value", "");
                        }
                        break;
                    case "textarea":
                        element.ELEMENT_VALUE = node.InnerText;
                        break;
                }

                element.ID = node.Attributes["id"].Value;
                element.INSTANCE_ELEMENT_ID = instance.INSTANCE_ID + "_" + element.ID;
                element.INSTANCE_ID = instance.INSTANCE_ID;
                element.NAME = node.Attributes["name"].Value;
                list.Add(element);
            }
            List<FORM_INSTANCE_BLOCKS> block_list = new List<FORM_INSTANCE_BLOCKS>();

            if (doc.DocumentNode.SelectNodes("//table") != null)
            {
                foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//table"))
                {
                    if (node.Attributes.Contains("id") && node.Attributes.Contains("title"))
                    {
                        FORM_INSTANCE_BLOCKS block = new FORM_INSTANCE_BLOCKS();
                        block.BLOCK_CONTENT = node.WriteTo();
                        block.INSTANCE_ID = instance.INSTANCE_ID;
                        block.TABLE_BLOCK_ID = node.Attributes["id"].Value;
                        block.TABLE_BLOCK_TITLE = node.Attributes["title"].Value;
                        block_list.Add(block);
                    }
                }
            }


            foreach (FORM_INSTANCE_EXPRESSIONS exp in exp_list)
            {
                exp.INSTANCE_ID = instance.INSTANCE_ID;
            }

            context.FORM_INSTANCE_ELEMENTS.InsertAllOnSubmit(list);

            context.FORM_INSTANCE_BLOCKS.InsertAllOnSubmit(block_list);

            context.FORM_INSTANCE_EXPRESSIONS.InsertAllOnSubmit(exp_list);

            context.SubmitChanges();

            return instance.INSTANCE_ID;
        }


        public int UpdateInstance(HtmlDocument doc, FORM_INSTANCES instance, List<FORM_INSTANCE_EXPRESSIONS> exp_list,bool submit, bool? ispass)
        {
            instance.INSTANCE_CONTENT = doc.DocumentNode.WriteTo();

            List<FORM_INSTANCE_ELEMENTS> list = new List<FORM_INSTANCE_ELEMENTS>();

            HtmlNodeCollection coll = Utilities.GetAllNodes(doc);


            foreach (HtmlNode node in coll)
            {
                FORM_INSTANCE_ELEMENTS element = new FORM_INSTANCE_ELEMENTS();

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
                        if (node.Attributes.Contains("checked"))
                        {
                            element.ELEMENT_VALUE = "true";
                        }
                        else
                        {
                            element.ELEMENT_VALUE = "false";
                        }
                        break;
                    case "select":
                        HtmlNodeCollection options = node.SelectNodes("option");
                        if (options != null)
                        {
                            foreach (HtmlNode option in options)
                            {
                                if (option.Attributes.Contains("selected"))
                                {
                                    element.ELEMENT_VALUE = option.Attributes["value"].Value;
                                    if (option.Attributes.Contains("text"))
                                    {
                                        element.SELECT_VALUE = option.Attributes["text"].Value;
                                    }
                                }
                            }
                        }
                        break;
                    case "text":
                    case "hidden":

                        element.ELEMENT_VALUE = node.Attributes["value"].Value;
                        break;
                    case "textarea":
                        element.ELEMENT_VALUE = node.InnerText;
                        break;
                }

                element.ID = node.Attributes["id"].Value;
                element.NAME = node.Attributes["name"].Value;

                list.Add(element);

            }

            //foreach (FORM_INSTANCE_EXPRESSION exp in exp_list)
            //{
            //    exp.INSTANCE_EXPRESSION_ID =
            //        SequenceProviderFactory.CreateSequenceProvider(SequenceType.Custom, "I_EXPRESSION_ID").getNext();
            //}

            List<FORM_INSTANCE_BLOCKS> block_list = new List<FORM_INSTANCE_BLOCKS>();

            if (doc.DocumentNode.SelectNodes("//table") != null)
            {
                foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//table"))
                {
                    if (node.Attributes.Contains("id") && node.Attributes.Contains("title"))
                    {
                        FORM_INSTANCE_BLOCKS block = new FORM_INSTANCE_BLOCKS();
                        block.BLOCK_CONTENT = node.WriteTo();
                        //block.INSTANCE_BLOCKS_ID = SequenceProviderFactory.CreateSequenceProvider(SequenceType.Custom, "I_BLOCK_ID").getNext();
                        block.TABLE_BLOCK_ID = node.Attributes["id"].Value;
                        block.TABLE_BLOCK_TITLE = node.Attributes["title"].Value;
                        block_list.Add(block);
                    }
                }
            }

            return UpdateInstance(instance, list, exp_list, block_list, submit, ispass);

        }

        public bool InsertTemplateSql(int templateid, string key, string sql)
        {
            FORM_TEMPLATE_SQL s = new FORM_TEMPLATE_SQL();
            s.TEMPLATE_ID = templateid;
            s.KEY = key;
            s.SOURCEREFSTATEMENT = sql;

            context.FORM_TEMPLATE_SQL.InsertOnSubmit(s);
            try
            {
                context.SubmitChanges();
                return true;
            }
            catch
            {
                context.Transaction.Rollback();
                return false;
            }


        }

        public bool UpdateTemplateSql(int templateid, string key, string sql)
        {
            FORM_TEMPLATE_SQL s = ListFormTemplateSql(templateid, key).FirstOrDefault();

            if (s == null)
            {
                return false;
            }

            s.SOURCEREFSTATEMENT = sql;


            try
            {
                context.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }


        }

        public bool DeleteTemplateSql(int templateid, string key)
        {
            List<FORM_TEMPLATE_SQL> s = ListFormTemplateSql(templateid, key);
            if (s == null || s.Count == 0)
            {
                return false;
            }

            context.FORM_TEMPLATE_SQL.DeleteAllOnSubmit(s);

            try
            {
                context.SubmitChanges();
                return true;
            }
            catch
            {
                context.Transaction.Rollback();
                return false;
            }

        }


        public virtual FORM_TEMPLATES SelectFormTemplate(int templateId)
        {

            FORM_TEMPLATES template = context.FORM_TEMPLATES.Where(c => c.TEMPLATE_ID == templateId).FirstOrDefault();
            return template;
        }

        public virtual bool DisableFormTemplate(int templateID)
        {
            try
            {
                var temp = context.FORM_TEMPLATES.Where(c => c.TEMPLATE_ID == templateID).FirstOrDefault();
                if (temp != null)
                {
                    temp.ENABLED = false;
                    context.SubmitChanges();
                    
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public virtual bool EnableFormTemplate(int templateID)
        {
            try
            {
                var temp = context.FORM_TEMPLATES.Where(c => c.TEMPLATE_ID == templateID).FirstOrDefault();
                if (temp != null)
                {
                    temp.ENABLED = true;
                    context.SubmitChanges();

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public virtual bool DeleteFromTemplate(int templateId)
        {
            try
            {
                context.FORM_TEMPLATE_PERMISSION.DeleteAllOnSubmit(context.FORM_TEMPLATE_PERMISSION.Where(c => c.TEMPLATE_ID == templateId));
                context.FORM_TEMPLATE_ELEMENTS.DeleteAllOnSubmit(ListFormTemplateElements(templateId));
                context.FORM_TEMPLATE_EXPRESSIONS.DeleteAllOnSubmit(ListFormTemplateExpressions(templateId));
                context.FORM_TEMPLATE_IMAGES.DeleteAllOnSubmit(ListFormTemplateImages(templateId));
                context.FORM_TEMPLATE_SQL.DeleteAllOnSubmit(ListFormTemplateSql(templateId));
                context.FORM_TEMPLATES.DeleteOnSubmit(SelectFormTemplate(templateId));
                if (context.GetChangeSet().Deletes.Count > 0)
                    context.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public virtual FORM_INSTANCES SelectFormInstance(int instanceId)
        {
            FORM_INSTANCES instance = context.FORM_INSTANCES.Where(c => c.INSTANCE_ID == instanceId).FirstOrDefault();
            return instance;
        }

        public virtual List<FORM_TEMPLATES> ListFormTemplates()
        {
            List<FORM_TEMPLATES> list = context.FORM_TEMPLATES.OrderBy(c => c.TEMPLATE_CATEGORY).ThenBy(c => c.TEMPLATE_CREATE_DATATIME).ToList();
            return list;
        }

        public virtual List<FORM_TEMPLATE_ELEMENTS> ListFormTemplateElements(int templateId)
        {
            List<FORM_TEMPLATE_ELEMENTS> list = context.FORM_TEMPLATE_ELEMENTS.Where(c => c.TEMPLATE_ID == templateId).ToList();
            return list;

        }

        public virtual bool DeleteFromTemplateElements(int templateId)
        {
            try
            {
                context.FORM_TEMPLATE_ELEMENTS.DeleteAllOnSubmit(ListFormTemplateElements(templateId));

                if (context.GetChangeSet().Deletes.Count > 0)
                    context.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public virtual bool DeleteFromTemplateElements(int templateId, HtmlDocument doc)
        {
            try
            {
                List<FORM_TEMPLATE_ELEMENTS> list = ListFormTemplateElements(templateId);

                for (int i = 0; i < list.Count; i++)
                {
                    if ((doc.GetElementbyId(list[i].ID) != null) && (list[i].POINTS != null))
                    {
                        list.RemoveAt(i);
                        i--;
                    }
                }

                context.FORM_TEMPLATE_ELEMENTS.DeleteAllOnSubmit(list);
                if (context.GetChangeSet().Deletes.Count > 0)
                    context.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual List<FORM_TEMPLATE_EXPRESSIONS> ListFormTemplateExpressions(int templateId)
        {
            List<FORM_TEMPLATE_EXPRESSIONS> list = context.FORM_TEMPLATE_EXPRESSIONS.Where(c => c.TEMPLATE_ID == templateId).OrderBy(c => c.EXECUTE_ORDER).ToList();
            return list;

        }

        public virtual bool InsertFormTemplateExpressions(List<FORM_TEMPLATE_EXPRESSIONS> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                FORM_TEMPLATE_EXPRESSIONS exp = new FORM_TEMPLATE_EXPRESSIONS();
                exp.EXECUTE_ORDER = (short)(i + 1);
                exp.EXPRESSION = list[i].EXPRESSION;
                exp.TEMPLATE_EXPRESSION_NAME = list[i].TEMPLATE_EXPRESSION_NAME;
                exp.TEMPLATE_ID = list[i].TEMPLATE_ID;
                context.FORM_TEMPLATE_EXPRESSIONS.InsertOnSubmit(exp);
            }
            try
            {
                context.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool InsertFormTemplateExpression(FORM_TEMPLATE_EXPRESSIONS newexp)
        {
            context.FORM_TEMPLATE_EXPRESSIONS.InsertOnSubmit(newexp);

            try
            {
                context.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool UpdateFormTemplateExpression(FORM_TEMPLATE_EXPRESSIONS exp)
        {


            FORM_TEMPLATE_EXPRESSIONS editexp = context.FORM_TEMPLATE_EXPRESSIONS.Where(c => c.TEMPLATE_EXPRESSION_ID == exp.TEMPLATE_EXPRESSION_ID).FirstOrDefault();
            if (editexp != null)
            {
                editexp.TEMPLATE_EXPRESSION_NAME = exp.TEMPLATE_EXPRESSION_NAME;
                editexp.EXPRESSION = exp.EXPRESSION;
                editexp.EXECUTE_ORDER = exp.EXECUTE_ORDER;
            }
            try
            {
                context.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool DeleteFromTemplateExpression(FORM_TEMPLATE_EXPRESSIONS exp)
        {
            try
            {
                context.FORM_TEMPLATE_EXPRESSIONS.DeleteOnSubmit(context.FORM_TEMPLATE_EXPRESSIONS.Where(c => c.TEMPLATE_EXPRESSION_ID == exp.TEMPLATE_EXPRESSION_ID).FirstOrDefault());
                if (context.GetChangeSet().Deletes.Count > 0)
                    context.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool DeleteFromTemplateExpressions(int templateId)
        {
            try
            {
                context.FORM_TEMPLATE_EXPRESSIONS.DeleteAllOnSubmit(ListFormTemplateExpressions(templateId));
                if (context.GetChangeSet().Deletes.Count > 0)
                    context.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual List<FORM_TEMPLATE_IMAGES> ListFormTemplateImages(int templateId)
        {
            List<FORM_TEMPLATE_IMAGES> list = context.FORM_TEMPLATE_IMAGES.Where(c => c.TEMPLATE_ID == templateId).ToList();

            return list;
        }

        public virtual bool DeleteFromTemplateImages(int templateId)
        {
            try
            {
                context.FORM_TEMPLATE_IMAGES.DeleteAllOnSubmit(ListFormTemplateImages(templateId));
                if (context.GetChangeSet().Deletes.Count > 0)
                    context.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private List<FORM_INSTANCE_ELEMENTS> ListFormInstanceElements(int instanceId)
        {
            List<FORM_INSTANCE_ELEMENTS> list = context.FORM_INSTANCE_ELEMENTS.Where(c => c.INSTANCE_ID == instanceId).OrderBy(c => c.INSTANCE_ELEMENT_ID).ToList();
            return list;
        }

        private List<FORM_INSTANCE_EXPRESSIONS> ListFormInstanceExpressions(int instanceId)
        {
            List<FORM_INSTANCE_EXPRESSIONS> list = context.FORM_INSTANCE_EXPRESSIONS.Where(c => c.INSTANCE_ID == instanceId).OrderBy(c => c.INSTANCE_EXPRESSION_ID).ToList();
            return list;
        }


        private List<FORM_INSTANCE_BLOCKS> ListFormInstanceBlockByInstance(int instanceId)
        {
            List<FORM_INSTANCE_BLOCKS> list = context.FORM_INSTANCE_BLOCKS.Where(c => c.INSTANCE_ID == instanceId).OrderBy(c => c.INSTANCE_BLOCKS_ID).ToList();
            return list;
        }

        public virtual List<FORM_TEMPLATE_SQL> ListFormTemplateSql(int templateId)
        {
            List<FORM_TEMPLATE_SQL> list = context.FORM_TEMPLATE_SQL.Where(c => c.TEMPLATE_ID == templateId).ToList();
            return list;
        }
        public virtual List<FORM_TEMPLATE_SQL> ListFormTemplateSql(int templateId, string id)
        {
            List<FORM_TEMPLATE_SQL> list = context.FORM_TEMPLATE_SQL.Where(c => c.TEMPLATE_ID == templateId && c.KEY == id).ToList();
            return list;
        }

        public virtual void InsertInstance(FORM_INSTANCES instance, List<FORM_INSTANCE_ELEMENTS> list, List<FORM_INSTANCE_EXPRESSIONS> exp_list, List<FORM_INSTANCE_BLOCKS> block_list)
        {
            try
            {

                context.FORM_INSTANCE_ELEMENTS.InsertAllOnSubmit(list);

                context.FORM_INSTANCE_BLOCKS.InsertAllOnSubmit(block_list);

                context.FORM_INSTANCE_EXPRESSIONS.InsertAllOnSubmit(exp_list);


                context.FORM_INSTANCES.InsertOnSubmit(instance);
                context.SubmitChanges();
            }
            catch (Exception ex)
            {
                context.Transaction.Rollback();
                throw ex;
            }

        }





        public virtual int UpdateInstance(FORM_INSTANCES instance, List<FORM_INSTANCE_ELEMENTS> list, List<FORM_INSTANCE_EXPRESSIONS> exp_list, List<FORM_INSTANCE_BLOCKS> block_list,bool submit, bool? ispass)
        {
            try
            {
                FORM_INSTANCES newInstance = context.FORM_INSTANCES.Where(c => c.INSTANCE_ID == instance.INSTANCE_ID).FirstOrDefault();
                //newInstance.CREATER = instance.CREATER;
                newInstance.INHOSPID = instance.INHOSPID;
                newInstance.INSTANCE_ALTER_DATETIME = DateTime.Now;
                newInstance.INSTANCE_CONTENT = instance.INSTANCE_CONTENT;
                newInstance.INSTANCE_CREATE_DATETIME = instance.INSTANCE_CREATE_DATETIME;
                newInstance.INSTANCE_NAME = instance.INSTANCE_NAME;
                newInstance.INSTANCE_REMARK = instance.INSTANCE_REMARK;
                newInstance.TEMPLATE_ID = instance.TEMPLATE_ID;
                newInstance.IsPass = ispass;

                if (submit)
                {
                    //FORM_INSTANCE_TARGETS firstdata = context.FORM_INSTANCE_TARGETS.Where(c => c.INSTANCE_ID == instance.INSTANCE_ID && c.TargetID == instance.CREATER && c.Status == "0").OrderBy(c => c.TargetOrder).FirstOrDefault();
                    
                    //int? order = null;
                    //if (firstdata != null)
                    //{
                    //    order = firstdata.TargetOrder;
                    //}

                    //List<FORM_INSTANCE_TARGETS> targets = context.FORM_INSTANCE_TARGETS.Where(c => c.INSTANCE_ID == instance.INSTANCE_ID && c.TargetID == instance.CREATER && (order == null || c.TargetOrder == order)).ToList();
                    //foreach (FORM_INSTANCE_TARGETS target in targets)
                    //{
                    //    target.Status = (target.TargetOrder.Value + 1).ToString();
                    //}

                    List<FORM_INSTANCE_TARGETS> targets = null;
                    if (context.FORM_INSTANCE_TARGETS.Count(c => c.INSTANCE_ID == instance.INSTANCE_ID) == 1)
                    {
                        targets = context.FORM_INSTANCE_TARGETS.Where(c => c.INSTANCE_ID == instance.INSTANCE_ID).ToList();
                    }
                    else
                    {
                        targets = context.FORM_INSTANCE_TARGETS.Where(c => c.INSTANCE_ID == instance.INSTANCE_ID && c.TargetID == instance.CREATER).ToList();
                    }

                     
                    foreach (FORM_INSTANCE_TARGETS target in targets)
                    {
                        target.Status = (target.TargetOrder.Value + 1).ToString();
                    }

                }

                //if (newInstance.Status == "0")
                //{
                //    newInstance.Status = "1";
                //}

                context.FORM_INSTANCE_ELEMENTS.DeleteAllOnSubmit(ListFormInstanceElements(instance.INSTANCE_ID));
                context.SubmitChanges();
                context.FORM_INSTANCE_EXPRESSIONS.DeleteAllOnSubmit(ListFormInstanceExpressions(instance.INSTANCE_ID));
                context.SubmitChanges();
                context.FORM_INSTANCE_BLOCKS.DeleteAllOnSubmit(ListFormInstanceBlockByInstance(instance.INSTANCE_ID));
                context.SubmitChanges();

                List<string> elementidlist = new List<string>();
                foreach (FORM_INSTANCE_ELEMENTS element in list)
                {
                    element.INSTANCE_ID = newInstance.INSTANCE_ID;
                    element.INSTANCE_ELEMENT_ID = newInstance.INSTANCE_ID.ToString() + "_" + element.ID;

                    if (!elementidlist.Contains(element.INSTANCE_ELEMENT_ID))
                    {
                        context.FORM_INSTANCE_ELEMENTS.InsertOnSubmit(element);
                    }
                    else
                    {
                        //("[HtmlForm] InstanceID:" + element.INSTANCE_ID + "的element:" + element.INSTANCE_ELEMENT_ID + "重複").LogError();
                    }
                    elementidlist.Add(element.INSTANCE_ELEMENT_ID);

                }

                foreach (FORM_INSTANCE_EXPRESSIONS exp in exp_list)
                {
                    exp.INSTANCE_ID = newInstance.INSTANCE_ID;
                    context.FORM_INSTANCE_EXPRESSIONS.InsertOnSubmit(exp);
                }

                foreach (FORM_INSTANCE_BLOCKS block in block_list)
                {
                    block.INSTANCE_ID = newInstance.INSTANCE_ID;
                    context.FORM_INSTANCE_BLOCKS.InsertOnSubmit(block);
                }


                context.SubmitChanges();
                return newInstance.INSTANCE_ID;
            }
            catch (Exception ex)
            {
                context.Transaction.Rollback();
                throw ex;
            }
        }



        public virtual void UpdateTemplateElements(List<FORM_TEMPLATE_ELEMENTS> list)
        {
            try
            {
                foreach (FORM_TEMPLATE_ELEMENTS element in list)
                {
                    FORM_TEMPLATE_ELEMENTS ed_element = context.FORM_TEMPLATE_ELEMENTS.Where(c => c.TEMPLATE_ELEMENT_ID == element.TEMPLATE_ELEMENT_ID).ToList().FirstOrDefault();
                    ed_element.POINTS = element.POINTS;
                }

                context.SubmitChanges();
            }
            catch (Exception ex)
            {
                context.Transaction.Rollback();
                throw ex;
            }

        }
        public virtual void InsertTemplateElement(FORM_TEMPLATE_ELEMENTS ele)
        {
            try
            {
                context.FORM_TEMPLATE_ELEMENTS.InsertOnSubmit(ele);
                context.SubmitChanges();

            }
            catch (Exception ex)
            {
                context.Transaction.Rollback();
                throw ex;
            }
        }

        public virtual void UpdateTemplateElementsScore(FORM_TEMPLATE_ELEMENTS ele)
        {
            try
            {
                FORM_TEMPLATE_ELEMENTS ed_element = context.FORM_TEMPLATE_ELEMENTS.Where(c => c.TEMPLATE_ID == ele.TEMPLATE_ID && c.ID == ele.ID).FirstOrDefault();

                if (ed_element != null)
                {
                    ed_element.NAME = ele.NAME;
                    ed_element.POINTS = ele.POINTS;
                    ed_element.DISPLAY_NAME = ele.DISPLAY_NAME;
                    ed_element.ISHIDE = ele.ISHIDE;
                    ed_element.MAXPOINT = ele.MAXPOINT;
                    ed_element.MaxTextCount = ele.MaxTextCount;
                    ed_element.MinTextCount = ele.MinTextCount;
                    ed_element.BINDVALUE = ele.BINDVALUE;
                    
                }
                else
                {
                    ed_element = new FORM_TEMPLATE_ELEMENTS();
                    ed_element.TEMPLATE_ELEMENT_ID = ele.TEMPLATE_ID.ToString() + "_" + ele.ID;
                    ed_element.TEMPLATE_ID = ele.TEMPLATE_ID;
                    ed_element.ID = ele.ID;
                    ed_element.NAME = ele.NAME;
                    ed_element.POINTS = ele.POINTS;
                    ed_element.MAXPOINT = ele.MAXPOINT;
                    ed_element.MinTextCount = ele.MinTextCount;
                    ed_element.MaxTextCount = ele.MaxTextCount;
                    ed_element.DISPLAY_NAME = ele.DISPLAY_NAME;
                    ed_element.DATA_TYPE = "string";
                    ed_element.CONTROL_TYPE = ele.CONTROL_TYPE;
                    ed_element.ISHIDE = ele.ISHIDE;
                    ed_element.BINDVALUE = ele.BINDVALUE;
                    context.FORM_TEMPLATE_ELEMENTS.InsertOnSubmit(ed_element);
                }

                context.SubmitChanges();
            }
            catch (Exception ex)
            {
                context.Transaction.Rollback();
                throw ex;
            }

        }
        public virtual void UpdateTemplateParentID(int templateid, int? parenttemplateid)
        {
            FORM_TEMPLATES template = SelectFormTemplate(templateid);
            template.PARENT_TEMPLATE_ID = parenttemplateid;
            context.SubmitChanges();
        }

        public virtual void UpdateTemplateName(int templateid, string templatename)
        {
            FORM_TEMPLATES template = SelectFormTemplate(templateid);
            template.TEMPLATE_NAME = templatename;
            context.SubmitChanges();
        }

        public virtual FORM_TEMPLATE_LIBRARY InsertTemplateLibrary(int templateid, string content, string type)
        {
            FORM_TEMPLATE_LIBRARY lib = new FORM_TEMPLATE_LIBRARY();
            lib.FORM_TEMPLATE_ID = templateid;
            lib.QUESTION_CONTENT = content;
            lib.QUESTION_TYPE = type;

            context.FORM_TEMPLATE_LIBRARY.InsertOnSubmit(lib);

            context.SubmitChanges();

            return lib;
        }

        public virtual void UpdateTemplateLibrary(int libraryid, string content, string type,bool display)
        {
            FORM_TEMPLATE_LIBRARY lib = context.FORM_TEMPLATE_LIBRARY.Where(c => c.FORM_TEMPLATE_LIBRARY_ID == libraryid).FirstOrDefault();
            lib.QUESTION_CONTENT = content;
            lib.QUESTION_TYPE = type;
            lib.DISPLAY = display;
            context.SubmitChanges();
        }

        public virtual void DeleteTemplateLibrary(int libraryid)
        {
            FORM_TEMPLATE_LIBRARY lib = context.FORM_TEMPLATE_LIBRARY.Where(c => c.FORM_TEMPLATE_LIBRARY_ID == libraryid).FirstOrDefault();

            context.FORM_TEMPLATE_LIBRARY.DeleteOnSubmit(lib);
            context.SubmitChanges();
        }


        public virtual FORM_TEMPLATE_LIBRARY_OPTION InsertTemplateLibraryOption(int libraryid, string type, string text,double? point,int order,bool isanswer)
        {
            FORM_TEMPLATE_LIBRARY_OPTION lib = new FORM_TEMPLATE_LIBRARY_OPTION();
            lib.LIBRARY_ID = libraryid;
            lib.OPTION_TYPE = type;
            lib.OPTION_TEXT = text;
            lib.OPTION_POINTS = point;
            if (isanswer)
                lib.IS_ANSWER = 'V';
            

            context.FORM_TEMPLATE_LIBRARY_OPTION.InsertOnSubmit(lib);

            context.SubmitChanges();

            return lib;
        }

        public virtual void UpdateTemplateLibraryOption(int optionid, string type, string text, double? point, int order, bool isanswer)
        {
            FORM_TEMPLATE_LIBRARY_OPTION lib = context.FORM_TEMPLATE_LIBRARY_OPTION.Where(c => c.OPTION_ID == optionid).FirstOrDefault();
            lib.OPTION_TYPE = type;
            lib.OPTION_TEXT = text;
            lib.OPTION_POINTS = point;
            if (isanswer)
                lib.IS_ANSWER = 'V';
            else
                lib.IS_ANSWER = null;


            context.SubmitChanges();
        }

        public virtual void DeleteTemplateLibraryOption(int optionid)
        {
            FORM_TEMPLATE_LIBRARY_OPTION lib = context.FORM_TEMPLATE_LIBRARY_OPTION.Where(c => c.OPTION_ID == optionid).FirstOrDefault();
            context.FORM_TEMPLATE_LIBRARY_OPTION.DeleteOnSubmit(lib);
            context.SubmitChanges();
        }

        public virtual void DeleteTemplateGroup(string elementid)
        {
            FORM_TEMPLATE_ELEMENTS element = context.FORM_TEMPLATE_ELEMENTS.Where(c => c.TEMPLATE_ELEMENT_ID == elementid).FirstOrDefault();
            element.GROUP_ID = null;
            context.SubmitChanges();
        }

        public virtual void SaveTemplateGroup(int groupid, List<string> elementid)
        {
            IEnumerable<FORM_TEMPLATE_ELEMENTS> elements = context.FORM_TEMPLATE_ELEMENTS.Where(c => c.GROUP_ID == groupid);
            foreach (FORM_TEMPLATE_ELEMENTS element in elements)
            {
                element.GROUP_ID = null;
            }

            IEnumerable<FORM_TEMPLATE_ELEMENTS> setelements = context.FORM_TEMPLATE_ELEMENTS.Where(c => elementid.Contains(c.TEMPLATE_ELEMENT_ID));
            foreach (FORM_TEMPLATE_ELEMENTS element in setelements)
            {
                element.GROUP_ID = groupid;
            }

            context.SubmitChanges();
        }


        public virtual bool UpdateTemplatePermission(int templateid, List<string> hosps, string creater)
        {
            try
            {
                var permissions = context.FORM_TEMPLATE_PERMISSION.Where(c => c.TEMPLATE_ID == templateid).ToList();
                context.FORM_TEMPLATE_PERMISSION.DeleteAllOnSubmit(permissions.Where(c => !hosps.Contains(c.HOSPCODE)));

                foreach (string hosp in hosps.Where(c => permissions.Count(d => d.HOSPCODE == c) == 0))
                {
                    FORM_TEMPLATE_PERMISSION newp = new FORM_TEMPLATE_PERMISSION();
                    newp.HOSPCODE = hosp;
                    newp.TEMPLATE_ID = templateid;
                    newp.CREATER = creater;
                    newp.CREATEDATE = DateTime.Now;
                    context.FORM_TEMPLATE_PERMISSION.InsertOnSubmit(newp);
                }
                context.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }


        public virtual FORM_TEMPLATE_GROUPS InsertTemplateGroup(int templateid, string groupname, int? displayorder, bool to_evaltarget)
        {
            FORM_TEMPLATE_GROUPS group = new FORM_TEMPLATE_GROUPS();
            group.TEMPLATE_ID = templateid;
            group.GROUP_NAME = groupname;
            group.DISPLAY_ORDER = displayorder;
            group.TO_EVALTARGET = to_evaltarget;

            context.FORM_TEMPLATE_GROUPS.InsertOnSubmit(group);
            context.SubmitChanges();

            return group;
        }

        public virtual void UpdateTemplateGroup(int groupid, string groupname, int? displayorder, bool to_evaltarget)
        {
            FORM_TEMPLATE_GROUPS group = context.FORM_TEMPLATE_GROUPS.Where(c => c.GROUP_ID == groupid).FirstOrDefault();
            group.GROUP_NAME = groupname;
            group.DISPLAY_ORDER = displayorder;
            group.TO_EVALTARGET = to_evaltarget;
            context.SubmitChanges();
        }

        public virtual void RemoveTemplateGroup(int groupid)
        {
            IEnumerable<FORM_TEMPLATE_ELEMENTS> elements = context.FORM_TEMPLATE_ELEMENTS.Where(c => c.GROUP_ID == groupid);
            foreach (FORM_TEMPLATE_ELEMENTS element in elements)
            {
                element.GROUP_ID = null;
            }
            FORM_TEMPLATE_GROUPS group = context.FORM_TEMPLATE_GROUPS.Where(c => c.GROUP_ID == groupid).FirstOrDefault();
            context.FORM_TEMPLATE_GROUPS.DeleteOnSubmit(group);
            context.SubmitChanges();
        }

        public void UpdateFormInstanceExpireDate(List<int> instanceids, DateTime expiredate)
        {
            foreach (FORM_INSTANCES instance in context.FORM_INSTANCES.Where(c => instanceids.Contains(c.INSTANCE_ID)))
            {
                if (instance.expireDate < DateTime.Now)
                {
                    foreach (FORM_INSTANCE_TARGETS tar in instance.FORM_INSTANCE_TARGETS)
                    {
                        tar.AlertTime = null;
                    }
                }

                //if (instance.PARENT_INSTANCE_ID != null)
                //{
                //    int shiftdays = Math.Abs(Convert.ToInt32((expiredate - instance.expireDate.Value).TotalDays));

                //    foreach (FORM_INSTANCES otherinstances in context.FORM_INSTANCES.Where(c => c.PARENT_INSTANCE_ID == instance.PARENT_INSTANCE_ID && c.INSTANCE_ID != instance.INSTANCE_ID))
                //    {
                //        if (otherinstances.expireDate != null)
                //        {
                //            otherinstances.expireDate = otherinstances.expireDate.Value.AddDays(shiftdays);
                //        }
                //    }
                //}


                instance.expireDate = expiredate;
            }
            context.SubmitChanges();
        }

        public void AddFormTemplateNecessary(int templateid, string name, string message)
        {
            if (context.FORM_TEMPLATE_NECESSARY.Count(c => c.TEMPLATE_ID == templateid && c.NAME == name) == 0)
            {

                FORM_TEMPLATE_NECESSARY newitem = new FORM_TEMPLATE_NECESSARY();
                newitem.TEMPLATE_ID = templateid;
                newitem.NAME = name;
                newitem.MESSAGE = message;
                context.FORM_TEMPLATE_NECESSARY.InsertOnSubmit(newitem);
                context.SubmitChanges();
            }

        }

        public void RemoveFormTemplateNecessary(int templateid, string name)
        {
            FORM_TEMPLATE_NECESSARY toremove = context.FORM_TEMPLATE_NECESSARY.Where(c => c.TEMPLATE_ID == templateid && c.NAME == name).FirstOrDefault();
            if (toremove != null)
            {
                context.FORM_TEMPLATE_NECESSARY.DeleteOnSubmit(toremove);
                context.SubmitChanges();
            }
        }

        public void RemoveFormTemplateSingle(int templateid,string ids)
        {
            FORM_TEMPLATE_SINGLE toremove = context.FORM_TEMPLATE_SINGLE.Where(c => c.TemplateID == templateid && c.IDs == ids).FirstOrDefault();
            if(toremove!=null)
            {
                context.FORM_TEMPLATE_SINGLE.DeleteOnSubmit(toremove);
                context.SubmitChanges();
            }
        }


        public void AddFormTemplateSingle(int templateid, string ids)
        {
            if (context.FORM_TEMPLATE_SINGLE.Count(c => c.TemplateID == templateid && c.IDs == ids) == 0)
            {

                FORM_TEMPLATE_SINGLE newitem = new FORM_TEMPLATE_SINGLE();
                newitem.TemplateID = templateid;
                newitem.IDs = ids;
                context.FORM_TEMPLATE_SINGLE.InsertOnSubmit(newitem);
                context.SubmitChanges();
            }

        }
    }

}