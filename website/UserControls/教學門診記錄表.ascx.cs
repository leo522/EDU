﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_教學門診記錄表 : IRecordBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (TextBox5.Text == "")
            {
                if (CurrentRecordIns != null)
                {
                    TextBox5.Text = CurrentRecordIns.CreaterName;
                }
            }
        }
    }
}