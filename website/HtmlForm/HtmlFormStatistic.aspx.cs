using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;
using System.Text;
using HtmlAgilityPack;
using Telerik.Web.UI;
using HtmlFormUtility;
using System.Web.UI.DataVisualization.Charting;

public partial class _Default : System.Web.UI.Page
{
    private HtmlFormUtility.Components.ViewComponent vc = new HtmlFormUtility.Components.ViewComponent();

    private int TemplateID
    {
        get
        {
            return Convert.ToInt32(Request.QueryString["template_id"]);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["template_id"] != null || Request.QueryString["template_id"] != null)
        {
            if (!IsPostBack)
            {
                HtmlFormUtility.Components.HtmlForm htmlform = new HtmlFormUtility.Components.HtmlForm();
                htmlform.Create(TemplateID);

                HtmlNodeCollection coll = htmlform.InstanceDocument.DocumentNode.SelectNodes("//input");

                if (coll != null)
                {
                    foreach (HtmlNode node in coll)
                    {
                        node.Attributes.Add("onClick",
                            "ElementClick('" + lbtnPostBack.ClientID + "','" + node.Attributes["id"].Value + "','" + HiddenID.ClientID + "',false);"
                            + "ElementClick('" + lbtnPostBack.ClientID + "','" + node.Attributes["name"].Value + "','" + HiddenName.ClientID + "',false);"
                            + "ElementClick('" + lbtnPostBack.ClientID + "','" + (node.Attributes["displayname"] == null ? node.Attributes["name"].Value : node.Attributes["displayname"].Value) + "','" + HiddenDisplayName.ClientID + "',true);"
                            + "return false;");
                    }
                }

                htmlContent.InnerHtml = htmlform.InstanceDocument.DocumentNode.InnerHtml;

                Session["htmlform"] = htmlform;

            }
            else
            {


            }
        }

    }


    protected void lbtnPostBack_Click(object sender, EventArgs e)
    {

        bool check = false;
        foreach (ListItem citem in ListBox1.Items)
        {
            if (citem.Value == HiddenID.Value)
            {
                check = true;
            }
        }

        if (!check)
        {
            ListItem item = new ListItem();
            item.Value = HiddenID.Value;
            item.Text = HiddenDisplayName.Value == "" ? HiddenName.Value : HiddenDisplayName.Value;
            ListBox1.Items.Add(item);
        }

    }

    protected void btnStatistic_Click(object sender, EventArgs e)
    {
        List<string> names = new List<string>();
        Dictionary<string, string> displayname = new Dictionary<string, string>();
        foreach(ListItem i in ListBox1.Items)
        {
            displayname.Add(i.Value, i.Text);
        }
        int count = 0;
        List<STATISTIC_DATA> list = vc.GetStatisticData(TemplateID, displayname, ref count);

        lblCount.Text = count.ToString();

        Series barseries = barChart.Series[0];
        barseries.XValueMember = "EleValue";
        barseries.YValueMembers = "Count";
        barChart.DataSource = list;
        barChart.Titles[0].Text = tbTitle.Text;
        barChart.DataBind();

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].Count == 0)
            {
                list.RemoveAt(i);
                i--;
            }
        }

        Series pieseries = pieChart.Series[0];
        pieseries.XValueMember = "EleValue";
        pieseries.YValueMembers = "Count";
        pieChart.DataSource = list;
        pieChart.Titles[0].Text = tbTitle.Text;
        pieChart.DataBind();

        RadTabStrip1.SelectedIndex = 1;
        RadMultiPage1.SelectedIndex = 1;


        List<STATISTIC_LIST> listdata = vc.GetStatisticList(TemplateID, displayname);
        lblData.Text = "";
        foreach (STATISTIC_LIST data in listdata)
        {
            lblData.Text += "<b>[" + data.Name + "]</b></br>";
            if (data.ControlType == "checkbox" || data.ControlType == "radio")
            {
                foreach (string key in data.DataList.AllKeys)
                {
                    if (data.DataList[key] == "true")
                    {
                        lblData.Text +=key + "</br>";
                    }
                }
            }
            else
            {
                foreach (string key in data.DataList.AllKeys)
                {
                    lblData.Text += key + " - " + data.DataList[key] + "</br>";
                }
            }

        }

    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        tbItemName.Text = ListBox1.SelectedItem.Text;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ListBox1.SelectedItem.Text = tbItemName.Text;
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        ListBox1.Items.Remove(ListBox1.SelectedItem);
    }
}

