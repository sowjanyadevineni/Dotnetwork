<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DigitalSignature.aspx.cs"
    Inherits="Assignment4.DigitalSignature" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="tinymce/jscripts/tiny_mce/tiny_mce.js"></script>
    <script type="text/javascript">
        tinyMCE.init({
            mode: "textareas",
            theme: "advanced",
            plugins: "safari,spellchecker,pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template,imagemanager,filemanager",
            theme_advanced_buttons1: "save,newdocument,|,bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|,styleselect,formatselect,fontselect,fontsizeselect",
            theme_advanced_buttons2: "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor",
            theme_advanced_buttons3: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
            theme_advanced_buttons4: "insertlayer,moveforward,movebackward,absolute,|,styleprops,spellchecker,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,blockquote,pagebreak,|,insertfile,insertimage",
            theme_advanced_toolbar_location: "top",
            theme_advanced_toolbar_align: "left",
            theme_advanced_statusbar_location: "bottom",
            theme_advanced_resizing: false,
            template_external_list_url: "js/template_list.js",
            external_link_list_url: "js/link_list.js",
            external_image_list_url: "js/image_list.js",
            media_external_list_url: "js/media_list.js"
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center;"> <h2>Encryption-Decryption using Digital Signature</h2></div>
    <table align="center" width="90%"   >
        <tr>
            <td width="20%">Browse XML Document :</td>
            <td width="80%">
                <table width="100%">
                    <tr>
                        <td width="40%">
                            <asp:FileUpload ID="fileXMLUploader" runat="server" Width="250" />
                            <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="fileXMLUploader" ErrorMessage="Please select file!" 
                            ForeColor="Red" Display="Dynamic" ValidationGroup="SYM">
                    </asp:RequiredFieldValidator> 
                        </td>
                        <td width="60%">
                            <asp:Button ID="btnReadFiles" CssClass="btn" runat="server" Text="Read File" OnClick="btnReadFiles_Click" ValidationGroup="SYM" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>Plain XML Content :</td>
            <td>
                <asp:TextBox ID="RichTextBoxPlane" runat="server" TextMode="MultiLine" Columns="80" Style="resize: none;" Rows="10"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" height="50px" style="padding-left:190px;">
                <asp:Button ID="btnGetDigitalSignature" CssClass="btn" runat="server" Text="Get Digital Signature" OnClick="btnGetDigitalSignature_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Button ID="btnDownload" CssClass="btn" runat="server" Text="Download Digital Signature" OnClick="btnDownload_Click" />
            </td>
        </tr>
        <tr>
            <td>Plain XML Content :</td>
            <td>
                <asp:TextBox ID="RichTextBoxConverted" runat="server" TextMode="MultiLine" Columns="80" Style="resize: none;" Rows="10"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Browse Same XML Document :</td>
            <td>
                <table width="100%">
                    <tr>
                        <td width="40%">
                            <asp:FileUpload ID="fileUploadValidate" runat="server" Width="250" />
                            <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="fileUploadValidate" ErrorMessage="Please select file!" 
                            ForeColor="Red" Display="Dynamic" ValidationGroup="S">
                    </asp:RequiredFieldValidator> 
                        </td>
                        <td width="60%">
                            <asp:Button ID="btnValidateXML" CssClass="btn" runat="server" Text="Validate Digital Signature" OnClick="btnValidateXML_Click" ValidationGroup="S"/>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" height="50px" align="center">
                <asp:Button ID="btnReset" CssClass="btn" runat="server" Text="Reset" OnClick="btnReset_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
