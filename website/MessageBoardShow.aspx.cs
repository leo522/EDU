using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KMU.EduActivity.ApplicationLayer.DTO;

public partial class MessageBoardShow : AuthPage
{
    private int MessageID
    {
        get
        {
            return Convert.ToInt32(Request.QueryString["id"]);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null)
        {
            ShowMessageAndGo("參數錯誤!", "MessageBoard.aspx");
            return;
        }

        if (!IsPostBack)
        {
            ReadData();
        }
    }


    private string headerformatstr
    {
        get
        {
            string str = "<div style=\" font-size:18px;\"><b>主題：#MessageTitle</b></div><div align=\"right\" style=\"font-size:14px;\"><a href=\"#ReplyMessage\">回應主題</a></div><div style=\"background-color:#CCC;\">&nbsp;</div><div style=\"background-color:#CCC; color:#930; font-size:16px;\"><b>發表人：#EmpName</b></div><div style=\"background-color:#CCC; font-size:12px;\">#SendTimeStr</div><div style=\"background-color:#CCC;\" align=\"right\">&nbsp;#Delbtn</div>";
            str += "            <div>&nbsp;</div>";
            str += "<div style=\"color:#000000; font-size:14px;\">#MessageContent</div>";
            str += "<div>&nbsp;</div>";
            return str;
        }
    }

    private string replyformatstr
    {
        get
        {
            string str = "<div style=\"background-color:#EEEEEF;\">&nbsp;</div><div style=\"background-color:#EEEEEF; color:#930; font-size:16px;\"><b>#EmpName</b></div><div style=\"background-color:#EEEEEF; font-size:12px;\"><table width=\"100%\"><tr><td align=\"left\">#SendTimeStr</td><td align=\"right\">#floor</td></tr></table></div><div style=\"background-color:#EEEEEF;\" align=\"right\">&nbsp;#Delbtn</div>";
            str += "            <div>&nbsp;</div>";
            str += "<div style=\"color:#000000; font-size:14px;\">#MessageContent</div>";
            str += "<div>&nbsp;</div>";
            return str;
        }
    }

    private void ReadData()
    {
        MessageBoardDto headermsg = service.GetMessageBoard(MessageID);
        List<MessageBoardDto> replaies = service.GetMessageBoardReplys(MessageID);
        liMainThread.Text = headerformatstr.Replace("#MessageTitle", headermsg.MessageTitle).Replace("#EmpName", headermsg.EmpName).Replace("#SendTimeStr", headermsg.SendTimeStr).Replace("#MessageContent", headermsg.MessageContent);

        if (headermsg.Status == 'C')
        {
            //已結案
            Panel1.Visible = false;
        }

        if (this.AuthRoles.Contains("Admin"))
        {
            cbClose.Visible = true;
            cbClose.Checked = true;
        }
        else
        {
            cbClose.Visible = false;
            cbClose.Checked = false;
        }



        if (this.EmpCode == headermsg.EMP_CODE || this.AuthRoles.Contains("Admin"))
        {
            liMainThread.Text = liMainThread.Text.Replace("#Delbtn", "<input type=\"button\" value=\"刪除主題\" id=\"btnDelheader\" onClick=\"DeleteBtnClick('" + headermsg.MessageID.ToString() + "',true);return false; \"/>");
        }
        else
        {
            liMainThread.Text = liMainThread.Text.Replace("#Delbtn", "");
        }


        string replieshtml = "";
        int count = 1;
        foreach (MessageBoardDto reply in replaies)
        {
            string localstr = replyformatstr.Replace("#EmpName", reply.EmpName).Replace("#SendTimeStr", headermsg.SendTimeStr).Replace("#MessageContent", reply.MessageContent).Replace("#floor", count.ToString() + "樓");

            if (this.EmpCode == reply.EMP_CODE || this.AuthRoles.Contains("Admin"))
            {
                localstr = localstr.Replace("#Delbtn", "<input type=\"button\" value=\"刪除留言\" id=\"btnDel" + count.ToString() + "\" onClick=\"DeleteBtnClick('" + reply.MessageID.ToString() + "',true);return false; \"/>");
            }
            else
            {
                localstr = localstr.Replace("#Delbtn", "");
            }
            replieshtml += localstr;
            count++;
        }

        liReplies.Text = replieshtml;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        bool success = service.InsertMessageBoard("", "", null, reContent.Content, this.EmpCode, MessageID, true, cbClose.Checked);
        if (success)
        {
            reContent.Content = "";
            ReadData();   
        }
        else
        {
            ShowMessage("留言失敗，請重試");
        }
    }
    protected void lbtnDel_Click(object sender, EventArgs e)
    {
        string id = hidMessageID.Value;

        

        service.DeleteMessageBoard(Convert.ToInt32(id));
        if (id == MessageID.ToString())
        {
            Response.Redirect("MessageBoard.aspx");
        }
        else
        {
            ReadData();
        }
    }
}