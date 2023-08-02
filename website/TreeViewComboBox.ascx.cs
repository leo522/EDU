using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

    public partial class TreeViewComboBox : System.Web.UI.UserControl
    {
        public event EventHandler SelectedChanged;
        private bool _autoPostBack = true;


        public RadTreeView TreeView
        {
            get
            {
                return RadDropDownTree1.EmbeddedTree;
            }
        }
        public bool AutoPostBack
        {
            get
            {
                return _autoPostBack;
            }
            set
            {
                _autoPostBack = value;
                RadDropDownTree1.AutoPostBack = value;
                if (_autoPostBack)
                {
                    btnClear.Click += new EventHandler(btnClear_Click);
                }
                else
                {
                    btnClear.Click -= new EventHandler(btnClear_Click);
                }
                
            }
        }


        public Unit Width
        {
            get
            {
                return RadDropDownTree1.Width;
            }
            set
            {
                RadDropDownTree1.Width = value;
            }
        }
        public bool Enabled
        {
            get
            {
                return RadDropDownTree1.Enabled;
            }
            set
            {
                RadDropDownTree1.Enabled = value;
            }
        }

        public string TreeDataSourceID
        {
            get
            {
                return this.RadDropDownTree1.DataSourceID;
            }
            set
            {
                SetTreeFieldID();
                RadDropDownTree1.DataSourceID = value;
                
                //this.TreeView.DataBind();
            }
        }


        //設定treeview datasource
        private object _treeViewDataSource = null;
        public object TreeDataSource
        {
            get
            {
                return _treeViewDataSource;
            }
            set
            {

                _treeViewDataSource = value;
                SetTreeFieldID();
                this.RadDropDownTree1.DataSource = _treeViewDataSource;
                this.RadDropDownTree1.DataBind();

            }
        }

        //設定treeview顯示欄位
        private string _treeDataTextField = "";
        public string TreeDataTextField
        {
            get
            {
                return _treeDataTextField;
            }
            set
            {
                _treeDataTextField = value;
            }
        }

        //設定treeview key欄位
        private string _treeDataFieldID = "";
        public string TreeDataFieldID
        {
            get
            {
                return _treeDataFieldID;
            }
            set
            {
                _treeDataFieldID = value;
            }
        }

        //設定treeview parent key欄位
        private string _treeDataFieldParentID = "";
        public string TreeDataFieldParentID
        {
            get
            {
                return _treeDataFieldParentID;
            }
            set
            {
                _treeDataFieldParentID = value;
            }
        }
        /// <summary>
        /// 設定treeview個資料對應欄位
        /// </summary>
        private void SetTreeFieldID()
        {
            this.RadDropDownTree1.DataTextField = _treeDataTextField;
            this.RadDropDownTree1.DataValueField = _treeDataFieldID;
            this.RadDropDownTree1.DataFieldID = _treeDataFieldID;
            this.RadDropDownTree1.DataFieldParentID = _treeDataFieldParentID;
            
        }

        /// <summary>
        /// 回傳整個RadComboBox
        /// </summary>
        public RadDropDownTree Combobox
        {
            get
            {
                return this.RadDropDownTree1;
            }
        }

        public string DivID
        {
            get
            {
                return this.ClientID + "div1";
            }
        }

        string _selectedValue = null;
        public string SelectedValue
        {
            get
            {
                if (!IsPostBack)
                {
                    return _selectedValue == null ? "" : _selectedValue;
                }
                else
                {
                    return RadDropDownTree1.SelectedValue;
                }

            }
            set
            {
                _selectedValue = value;
                RadDropDownTree1.SelectedValue = value;
            }
        }

        public Dictionary<string,string> CheckedNameValues
        {
            get
            {
                Dictionary<string, string> result = new Dictionary<string, string>();
                foreach (var node in RadDropDownTree1.EmbeddedTree.CheckedNodes)
                {
                    result.Add(node.Value,node.Text);
                }

                return result;
            }
        }

        public List<string> CheckedValues
        {
            get
            {
                List<string> result = new List<string>();
                foreach(var node in RadDropDownTree1.EmbeddedTree.CheckedNodes)
                {
                    result.Add(node.Value);
                }

                return result;
            }
        }

        public List<string> CheckedTexts
        {
            get
            {
                List<string> result = new List<string>();
                foreach (var node in RadDropDownTree1.EmbeddedTree.CheckedNodes)
                {
                    result.Add(node.Text);
                }

                return result;
            }
        }

        public string SelectedText
        {
            get
            {
                return RadDropDownTree1.SelectedText;

            }
            set
            {
                RadDropDownTree1.SelectedText = value;

            }
        }


        bool _allowSelectParent = true;
        public bool AllowSelectParent
        {
            get
            {
                return _allowSelectParent;
            }
            set
            {
                _allowSelectParent = value;
            }
        }

        DropDownTreeCheckBoxes _checkBoxes = DropDownTreeCheckBoxes.None;
        public DropDownTreeCheckBoxes CheckBoxes
        {
            get
            {
                return _checkBoxes;
            }
            set
            {
                _checkBoxes = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            btnClear.OnClientClick = "clearSelection" + RadDropDownTree1.ClientID + "();";
            Label1.Attributes.Add("onClick", "clearSelection" + RadDropDownTree1.ClientID + "();");

            if (_autoPostBack)
            {
                TreeView.NodeClick += new RadTreeViewEventHandler(rtvContrl_NodeClick);
            }
            else
            {
                TreeView.NodeClick -= new RadTreeViewEventHandler(rtvContrl_NodeClick);
            }


            string script = "";

            script += @"<script>



            function clearSelection" + RadDropDownTree1.ClientID + @"(){         
                var dropdowntree1 = $find('" +RadDropDownTree1.ClientID+@"');
                dropdowntree1.get_entries().clear();
            }
            
</script>";

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), this.ClientID + "NodeClick",
                script, false);            

            SetTreeFieldID();
        }

        protected void CallSelectedChanged()
        {
            SelectedChanged(this, null);
        }

        protected void rtvContrl_NodeClick(object sender, RadTreeNodeEventArgs e)
        {
            if (SelectedChanged != null)
            {
                SelectedChanged(this, null);
            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            if (SelectedChanged != null)
            {
                SelectedChanged(this, null);
            }
        }
        protected void RadDropDownTree1_DataBinding(object sender, EventArgs e)
        {
            if (_selectedValue != null)
            {
                this.RadDropDownTree1.SelectedValue = _selectedValue;

            }

            if (!AllowSelectParent)
            {
                foreach (RadTreeNode node in this.RadDropDownTree1.EmbeddedTree.GetAllNodes())
                {
                    if (node.Nodes.Count > 0)
                    {
                        node.Enabled = false;
                    }
                }
                this.RadDropDownTree1.EmbeddedTree.ExpandAllNodes();
            }

            RadDropDownTree1.CheckBoxes = _checkBoxes;
        }
}
