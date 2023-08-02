using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace HtmlFormUtility
{
    public class Utilities
    {
        public static HtmlNodeCollection GetAllNodes(HtmlDocument doc)
        {
            HtmlNodeCollection coll = HtmlUtility.GetAllNodes(doc);

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//textarea");
            if (nodes != null)
            {
                foreach (HtmlNode node in nodes)
                {
                    if (!coll.Contains(node))
                    {
                        coll.Add(node);
                    }
                }
            }

            nodes = doc.DocumentNode.SelectNodes("//select");
            if (nodes != null)
            {
                foreach (HtmlNode node in nodes)
                {
                    if (!coll.Contains(node))
                    {
                        coll.Add(node);
                    }
                }
            }

            return coll;
        }

        public static HtmlNodeCollection GetAllNodes(HtmlNode doc)
        {
            HtmlNodeCollection coll = HtmlUtility.GetAllNodes(doc);

            HtmlNodeCollection nodes = doc.SelectNodes("//textarea");
            if (nodes != null)
            {
                foreach (HtmlNode node in nodes)
                {
                    if (!coll.Contains(node))
                    {
                        coll.Add(node);
                    }
                }
            }

            nodes = doc.SelectNodes("//select");
            if (nodes != null)
            {
                foreach (HtmlNode node in nodes)
                {
                    if (!coll.Contains(node))
                    {
                        coll.Add(node);
                    }
                }
            }
            return coll;
        }
    }
}
