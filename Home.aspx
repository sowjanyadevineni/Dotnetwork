<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Assignment4.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Assignment 3.1</title>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center" width="70%">
                <tr>
                    <td colspan="4" height="50px"></td>
                </tr>
                <tr>
                    <td height="50px" align="right">Message To Encrypt :</td>
                    <td height="50px">
                        <asp:TextBox ID="txtPlainText" CssClass="txt" runat="server"></asp:TextBox></td>
                    </td>
                     <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td height="50px" width="25%">
                        <asp:Button ID="btnGenerateSymKey" CssClass="btn" runat="server" Text="Generate a symmetric key" OnClick="btnGenerateSymKey_Click" /></td>
                    <td width="25%">
                        <asp:TextBox ID="txtSymKey" CssClass="txt" runat="server"></asp:TextBox>
                    </td>
                    <td width="25%">
                        <asp:Button ID="btnEncryptSym" CssClass="btn" runat="server" Text="Encrypt Message" OnClick="btnEncryptSym_Click" /></td>
                    <td width="25%">
                        <asp:TextBox ID="txtCiphertext" CssClass="txt" runat="server"></asp:TextBox>
                    </td>
                </tr>
                  <tr>
                    <td height="50px" width="25%">
                    <td width="25%">
                    </td>
                    <td width="25%">
                        <asp:Button ID="btnDecryptSym" CssClass="btn" runat="server" Text="Decrypt Message" OnClick="btnDecryptSym_Click" /></td>
                    <td width="25%">
                        <asp:TextBox ID="txtCipherToPlain" CssClass="txt" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="50px">
                        <asp:Button ID="btnPublicPrivate" CssClass="btn" runat="server" Text="Generate Public-Private Key Paire" OnClick="btnPublicPrivate_Click" /></td>
                    <td>
                        <asp:TextBox ID="txtPublicKey" CssClass="txt" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPrivateKey" CssClass="txt" runat="server"></asp:TextBox></td>
                    <td></td>
                </tr>
                <tr>
                    <td height="50px">3.</td>
                    <td>Type Text :</td>
                    <td>
                </tr>
                <tr>
                    <td height="50px">4.</td>
                    <td>
                        <asp:Button ID="btngenerateHash" CssClass="btn" runat="server" Text="Generate Hash" OnClick="btngenerateHash_Click" /></td>
                    <td>
                        <asp:TextBox ID="txtGenerateHash" CssClass="txt" runat="server"></asp:TextBox>

                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td height="50px"></td>
                    <td>Text To Validate :
                        <asp:TextBox ID="txtPlainTextAgain" CssClass="txt" runat="server"></asp:TextBox>
                        <td>Hash To Validate :
                            <asp:TextBox ID="txtHashToValidate" CssClass="txt" runat="server"></asp:TextBox>

                        </td>
                        <td>
                            <asp:Button ID="btnValidateHash" CssClass="btn" runat="server" Text="Validate Hash" OnClick="btnValidateHash_Click" /></td>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
