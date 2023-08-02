using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.ComponentModel;
using System.Collections.Specialized; // For Reading Connection String from Web.Config
///
/// Th class for handling Common Connection String from Web.Config file by the Default Constructor for all DBML Files
///
namespace HtmlFormUtility
{
    ///
    /// The class for handling Common Connection String from Web.Config file by the UserClassesDataContext Constructor.
    ///

    public partial class DataContextDataContext
    {
        public DataContextDataContext()
            : base(ConfigurationManager.ConnectionStrings["dsEduActivity"].ConnectionString, mappingSource)
        {
            OnCreated();
        }
        partial void OnCreated()
        {
            this.CommandTimeout = 360000;
        }
    }
    

    [Serializable]
    public partial class FORM_OPTION_TYPE : INotifyPropertyChanging, INotifyPropertyChanged
    {
        public List<FORM_OPTION_TYPE> GetOptionType()
        {
            DataContextDataContext context = new DataContextDataContext();

            return context.FORM_OPTION_TYPE.OrderBy(c => c.DISPLAY_ORDER).ToList();

        }
    }

    [Serializable]
    public partial class FORM_TEMPLATES : INotifyPropertyChanging, INotifyPropertyChanged
    {
        public bool IsMultiTargetForm
        {
            get
            {
                if (this.TEMPLATE_CONTENT != null)
                {
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(this.TEMPLATE_CONTENT);
                    HtmlAgilityPack.HtmlNodeCollection coll = doc.DocumentNode.SelectNodes("//div[@editor]");
                    if (coll != null)
                    {
                        if (coll.Count > 0)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
    }
    [Serializable]
    public partial class FORM_INSTANCE_ATTACHMENTS
    {

    }

    [Serializable]
    public partial class FORM_INSTANCE_TARGETS
    {

    }


    [Serializable]
    public partial class FORM_INSTANCES : INotifyPropertyChanging, INotifyPropertyChanged
    {
        public bool IsMultiTargetForm
        {
            get
            {
                
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(this.INSTANCE_CONTENT);
                HtmlAgilityPack.HtmlNodeCollection coll = doc.DocumentNode.SelectNodes("//div[@editor]");
                if (coll != null)
                {
                    if (coll.Count > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }

    [Serializable]
    public partial class FORM_TEMPLATE_LIBRARY_OPTION : INotifyPropertyChanging, INotifyPropertyChanged
    {
        public string OPTION_NAME
        {
            get
            {
                DataContextDataContext context = new DataContextDataContext();
                return context.FORM_OPTION_TYPE.Where(c => c.CODE == this.OPTION_TYPE).FirstOrDefault().NAME;
            }
        }
    }

    public class STATISTIC_GROUP_DATA
    {
        private string _groupName = null;
        public string GroupName
        {
            get
            {
                return _groupName;
            }
            set
            {
                _groupName = value;
            }
        }

        private string _value = null;
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
    }


    //統計資料清單
    public class STATISTIC_DATA_LIST
    {
        private int _instanceID;
        public int InstanceID
        {
            get
            {
                return _instanceID;
            }
            set
            {
                _instanceID = value;
            }
        }

        private DateTime _createDate;
        public DateTime CreateDate
        {
            get
            {
                return _createDate;
            }
            set
            {
                _createDate = value;
            }
        }

        private string _eduTermID;
        public string EduTermID
        {
            get
            {
                return _eduTermID;
            }
            set
            {
                _eduTermID = value;
            }

        }

        private string _targetID = null;
        public string TargetID
        {
            get
            {
                return _targetID;
            }
            set
            {
                _targetID = value;
            }
        }

        private string _targetName = null;
        public string TargetName
        {
            get
            {
                return _targetName;
            }
            set
            {
                _targetName = value;
            }
        }
        private string _targetType = null;
        public string TargetType
        {
            get
            {
                return _targetType;
            }
            set
            {
                _targetType = value;
            }
        }

        private string _targetMemberCode = null;
        public string TargetMemberCode
        {
            get
            {
                return _targetMemberCode;
            }
            set
            {
                _targetMemberCode = value;
            }
        }

        private string _targetCoach = null;
        public string TargetCoach
        {
            get
            {
                return _targetCoach;
            }
            set
            {
                _targetCoach = value;
            }
        }


        private string _evalTargetID = null;
        public string EvalTargetID
        {
            get
            {
                return _evalTargetID;
            }
            set
            {
                _evalTargetID = value;
            }
        }

        private string _evalTargetName = null;
        public string EvalTargetName
        {
            get
            {
                return _evalTargetName;
            }
            set
            {
                _evalTargetName = value;
            }
        }

        private string _evalTargetMemberCode = null;
        public string EvalTargetMemberCode
        {
            get
            {
                return _evalTargetMemberCode;
            }
            set
            {
                _evalTargetMemberCode = value;
            }
        }

        private List<STATISTIC_GROUP_DATA> _groupData = new List<STATISTIC_GROUP_DATA>();
        public List<STATISTIC_GROUP_DATA> GroupData
        {
            get
            {
                return _groupData;
            }
            set
            {
                _groupData = value;
            }
        }

        private string _statusName = null;
        public string StatusName
        {
            get
            {
                return _statusName;
            }
            set
            {
                _statusName = value;
            }
        }
        private string _completeStatus = null;
        public string CompleteStatus
        {
            get
            {
                return _completeStatus;
            }
            set
            {
                _completeStatus = value;
            }
        }
    }

    public class STATISTIC_LIST
    {
        private string name = null;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private string id = null;
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        private string controlType = null;
        public string ControlType
        {
            get
            {
                return controlType;
            }
            set
            {
                controlType = value;
            }
        }

        private NameValueCollection dataList = new NameValueCollection();
        public NameValueCollection DataList
        {
            get
            {
                return dataList;
            }
            set
            {
                dataList = value;
            }
        }
    }

    public class STATISTIC_DATA
    {
        private string name = null;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private int count = 0;
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
            }
        }

        private string id = null;
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        private string eleValue = null;
        public string EleValue
        {
            get
            {
                return eleValue;
            }
            set
            {
                eleValue = value;
            }
        }
    }
}