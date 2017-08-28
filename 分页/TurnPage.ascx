<%@ Control Language="C#" AutoEventWireup="true" Codebehind="TurnPage.ascx.cs" Inherits="Maticsoft.Web.TurnPage" %>
<div align="center">
<table width="100%" style="font-size:12px;">
    <tr>
        <td id="pleft" style="width: 34%">
            总共有<asp:Label ID="lbl_TotalCount" runat="server" Text="0"></asp:Label>条记录 &nbsp; &nbsp;&nbsp; 
            每页显示<asp:DropDownList ID="ddl_PageSize" runat="server" AutoPostBack="True" Width="50px" Height="24px" OnSelectedIndexChanged="ddl_PageSize_SelectedIndexChanged">
                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                <asp:ListItem Text="20" Value="20"></asp:ListItem>
                <asp:ListItem Text="40" Value="40"></asp:ListItem>
            </asp:DropDownList>条记录
        </td>
        <td>
            <asp:Label ID="Label7" runat="server" Text="当前页码为："></asp:Label>
            [
            <asp:Label ID="lbl_CurrPage" runat="server" Text="0"></asp:Label>
            &nbsp;]
            <asp:Label ID="Label6" runat="server" Text="总页码为："></asp:Label>
            [
            <asp:Label ID="lbl_TotalPage" runat="server">0</asp:Label>
            &nbsp;] 
            <asp:LinkButton ID="btn_FristPage" runat="server" Font-Underline="False" OnClick="btn_FristPage_Click" >第一页</asp:LinkButton>
            <asp:LinkButton ID="btn_PrevPage" runat="server" Font-Underline="False" OnClick="btn_PrevPage_Click">上一页</asp:LinkButton>
            <asp:LinkButton ID="btn_NextPage" runat="server" Font-Underline="False" OnClick="btn_NextPage_Click" >下一页</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="btn_LastPage" runat="server" Font-Underline="False" OnClick="btn_LastPage_Click">最后一页</asp:LinkButton>&nbsp;&nbsp;转到第<asp:TextBox ID="txt_PageNum" runat="server" Width="30px" Height="16px"></asp:TextBox>页 
            <asp:LinkButton ID="btn_GO" runat="server" OnClick="btn_GO_Click">GO</asp:LinkButton>
        </td>
    </tr>
</table>
</div>
