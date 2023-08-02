using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HtmlAgilityPack;
using System.Data;

/// <summary>
/// HtmlUtility 的摘要描述
/// </summary>
public class HtmlUtility
{
    public HtmlUtility()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    #region Public Methods

    public static string GetInnerHtmlById(string id, HtmlDocument htmlDoc)
    {
        HtmlNode node = GetNodeById(id, htmlDoc);
        
        if (node != null)
        {
            return node.InnerHtml;
        }
        else
        {
            return String.Empty;
        }
    }

    public static string GetValueById(string id, HtmlDocument htmlDoc)
    {
        HtmlNode node = GetNodeById(id, htmlDoc);
        if (node != null)
        {
            if (node.Attributes["value"] != null)
            {
                return node.Attributes["value"].Value;
            }
            else
            {
                return String.Empty;
            }
        }
        else
        {
            return String.Empty;
        }
    }

    public static HtmlNode GetNodeById(string id, HtmlDocument htmlDoc)
    {
        HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes("//*[@id = '" + id + "']");
        if (nodes != null)
        {
            return nodes[0];
        }
        else
        {
            return null;
        }
    }

    public static HtmlNodeCollection GetNodesByName(string name, HtmlDocument htmlDoc)
    {
        HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes("//*[@name = '" + name + "']");
        return nodes;
    }

    public static void SetInnerHtml(string strValue, HtmlNode node)
    {
        if (node == null)
        {
            return;
        }

        node.InnerHtml = strValue;
    }

    public static void SetInnerHtml(string id, string strValue, HtmlDocument htmlDoc)
    {
        HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes("//*[@id = '" + id + "']");
        if (nodes == null)
        {
            return;
        }
        foreach (HtmlNode node in nodes)
        {
            SetInnerHtml(strValue, node);
        }
    }

    public static void SetAttribute(string strAttribute, string strValue, HtmlNode node)
    {
        if (node == null)
        {
            return;
        }

        if (node.Attributes[strAttribute] == null)
        {
            node.Attributes.Add(strAttribute, "");
        }
        node.Attributes[strAttribute].Value = strValue;
    }

    public static void SetAttribute(string id, string strAttribute, string strValue, HtmlDocument htmlDoc)
    {
        HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes("//*[@id = '" + id + "']");
        if (nodes == null)
        {
            return;
        }
        foreach (HtmlNode node in nodes)
        {
            SetAttribute(strAttribute, strValue, node);
        }
    }

    public static void SetSelectAttribute(string id, string strValue, HtmlDocument htmlDoc)
    {
        HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes("//select[@id = '" + id + "']");
        if (nodes == null)
        {
            return;
        }
        foreach (HtmlNode node in nodes)
        {
            if (node.InnerHtml == strValue)
            {
                SetAttribute("selected", "selected", node);
            }
            else
            {
                node.Attributes.Remove("selected");
            }
        }
    }

    public static HtmlDocument LoadDocument(string docPath)
    {
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(docPath);
        //doc.Load(docPath);
        return doc;
    }

    public static HtmlNodeCollection GetAllNodes(HtmlDocument doc)
    {
        HtmlNodeCollection l_col = new HtmlNodeCollection(null);
        
        //處理input
        HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//input");
        if (nodes != null)
        {
            foreach (HtmlNode node in nodes)
            {
                if (node.Attributes.Contains("id") && node.Attributes.Contains("type") && node.Attributes.Contains("name"))
                    l_col.Add(node);
            }
        }

        //處理textarea
        nodes = doc.DocumentNode.SelectNodes("//textarea");
        if (nodes != null)
        {
            foreach (HtmlNode node in nodes)
            {
                if (node.Attributes.Contains("id") && node.Attributes.Contains("name"))
                    l_col.Add(node);

            }
        }

        //處理select
        nodes = doc.DocumentNode.SelectNodes("//select");
        if (nodes != null)
        {
            foreach (HtmlNode node in nodes)
            {
                if (node.Attributes.Contains("id") && node.Attributes.Contains("name"))
                    l_col.Add(node);
            }
        }
        return l_col;
    }

    public static HtmlNodeCollection GetAllNodes(HtmlNode doc)
    {
        HtmlNodeCollection l_col = new HtmlNodeCollection(null);

        //處理input
        HtmlNodeCollection nodes = doc.SelectNodes("//input");
        if (nodes != null)
        {
            foreach (HtmlNode node in nodes)
            {
                if (node.Attributes.Contains("id") && node.Attributes.Contains("type") && node.Attributes.Contains("name"))
                    l_col.Add(node);
            }
        }

        //處理textarea
        nodes = doc.SelectNodes("//textarea");
        if (nodes != null)
        {
            foreach (HtmlNode node in nodes)
            {
                if (node.Attributes.Contains("id") && node.Attributes.Contains("name"))
                    l_col.Add(node);

            }
        }

        //處理select
        nodes = doc.SelectNodes("//select");
        if (nodes != null)
        {
            foreach (HtmlNode node in nodes)
            {
                if (node.Attributes.Contains("id") && node.Attributes.Contains("name"))
                    l_col.Add(node);
            }
        }
        return l_col;
    }


    public static void BindDocument(HtmlDocument doc, DataSet dsBind)
    {
        //處理input
        HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//input");
        if (nodes != null)
        {

            foreach (HtmlNode node in nodes)
            {
                if((node.Attributes["type"]!=null)&&(node.Attributes["name"]!=null))
                {
                    DataRow[] drs =
                        dsBind.Tables[0].Select("Control_Type='" + node.Attributes["type"].Value + "' and Name='" +
                                                node.Attributes["name"].Value + "" +
                                                //' and id='" + node.Attributes["id"].Value +
                                                "'");
                    if (drs.Length > 0)
                    {
                        switch (node.Attributes["type"].Value.ToLower())
                        {
                            case "radio":
                            case "checkbox":
                                if ((node.Attributes["value"] != null) &&
                                    (node.Attributes["value"].Value == drs[0]["Element_Value"].ToString()))
                                    SetAttribute("checked", "checked", node);
                                else
                                    node.Attributes.Remove("checked");
                                break;
                            case "text":
                            case "hidden":
                            case "password":
                                SetAttribute("value", drs[0]["Element_Value"].ToString(), node);
                                break;
                        }
                    } else
                    {
                        switch (node.Attributes["type"].Value.ToLower())
                        {
                            case "radio":
                            case "checkbox":
                                node.Attributes.Remove("checked");
                                break;
                        }
                    }
                }
            }
        }

        //處理textarea
        nodes = doc.DocumentNode.SelectNodes("//textarea");
        if (nodes != null)
        {
            foreach (HtmlNode node in nodes)
            {
                if(node.Attributes["name"]!=null)
                {
                    DataRow[] drs =
                        dsBind.Tables[0].Select("Control_Type='textarea' and Name='" + node.Attributes["name"].Value +
                                                "'"); // and id='" +node.Attributes["id"].Value + "'");
                    if (drs.Length > 0)
                    {
                        SetInnerHtml(drs[0]["Element_Value"].ToString(), node);
                    }
                }
            }
        }

        //處理select
        nodes = doc.DocumentNode.SelectNodes("//select");
        if (nodes != null)
        {
            foreach (HtmlNode node in nodes)
            {
                if(node.Attributes["name"]!=null)
                {
                    DataRow[] drs =
                        dsBind.Tables[0].Select("Control_Type='select' and Name='" + node.Attributes["name"].Value + "'");
                        // and id='" + node.Attributes["id"].Value + "'");
                    if (drs.Length > 0)
                    {
                        HtmlNodeCollection selectnodes = node.SelectNodes("//option");
                        if (selectnodes != null)
                        {
                            foreach (HtmlNode selectnode in selectnodes)
                            {
                                if ((selectnode.Attributes["value"] != null) &&
                                    (selectnode.Attributes["value"].Value == drs[0]["Element_Value"].ToString()))
                                {
                                    SetAttribute("selected", "selected", selectnode);
                                } else
                                {
                                    selectnode.Attributes.Remove("selected");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion

}
