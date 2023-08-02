<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecordBase.ascx.cs" Inherits="UserControls_RecordBase" %>

<script type="text/javascript">
    function OnClientPasteHtml(editor, args) {
        var value = args.get_value();
        if (value.indexOf("data:") >= 0) {
            var strippedContent = value.replace(/\<img .+?\>/ig, "");

            args.set_value(strippedContent);
        }
        
    }
</script>
