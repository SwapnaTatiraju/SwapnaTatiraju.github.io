<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="DrawASCIShapes._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        #Div_Options
        {
            width: 675px;
        }
        #Div_ShapeTextArea
        {
            width: 272px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="Div_Options" runat="server">
    <asp:Panel ID="DrawingOptions" runat="server" Direction="LeftToRight" 
        Wrap="False">
        Choose shape to draw:&nbsp;&nbsp;
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
            RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Selected="True" Text="Triangle" />
            <asp:ListItem Text="Rectangle" />
            <asp:ListItem Text="Square" />
            <asp:ListItem Text="Diamond-1" />
            <asp:ListItem Text="Diamond-2" />
        </asp:RadioButtonList>
        <p>
            Enter height of shape: *&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TxtBx_Height" runat="server" CausesValidation="True" 
                ontextchanged="TxtBx_Height_TextChanged">4</asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="TxtBx_Height" Display="Dynamic" 
                ErrorMessage="Please enter a Numeric value" ForeColor="Red" 
                SetFocusOnError="True" ValidationExpression="\d+" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="TxtBx_Height" ErrorMessage="Height Required!!" 
                ForeColor="Red" SetFocusOnError="True" ToolTip="Height of shape " />
            <asp:Label ID="lbl_Diamond2Err" runat="server" ForeColor="Red" 
                Visible="False" />
            <p>
                Label to display in shape:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TXtBx_DisplayLable" runat="server" CausesValidation="True">Hi</asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="TXtBx_DisplayLable" 
                    ErrorMessage="Special characters not allowed" ForeColor="Red" 
                    ValidationExpression="^[0-9a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>
            </p>
            <p>
                Row number to display text:&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TxtBx_rowNum" runat="server" CausesValidation="True" 
                    ontextchanged="TxtBx_rowNum_TextChanged">4</asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="TxtBx_rowNum" Display="Static" 
                    ErrorMessage="Please enter Numeric values" ForeColor="Red" 
                    SetFocusOnError="True" ValidationExpression="\d+" />
            </p>
        </p>
        
    </asp:Panel>
    </div>

    <div id="Div_ShapeTextArea" runat="server">

        <br />

        <asp:GridView ID="GridView1" runat="server" BorderStyle="None" CellPadding="-1" 
            GridLines="None" ShowHeader="False">
            <%--<AlternatingRowStyle HorizontalAlign="Left" VerticalAlign="Middle" />--%>
        </asp:GridView>

    </div>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Btn_Draw" Text="Draw Shape" runat="server" 
            onclick="Btn_Draw_Click"  />&nbsp;   
        <asp:Button ID="Btn_Redraw" Text="Redraw Shape" Visible="false" runat="server" 
            onclick="Btn_Redraw_Click" />
             </p>
    <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Wrap="true" BorderStyle="Double" >        
        <asp:Label Text="User History" Visible="true" runat="server" Font-Bold="true" Font-Underline="true" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button Text="Clear History" runat="server" ID="Btn_ClearHistory" 
            onclick="Btn_ClearHistory_Click" />
        <br />
        
        <asp:BulletedList ID="BList_userHistory" runat="server" 
            BulletStyle="Disc" DisplayMode="LinkButton" style="table-layout:auto" 
            onclick="BList_userHistory_Click">
        </asp:BulletedList>
        <br />
        <asp:Label ID="Lbl_PageErr" Visible="false" Text="" runat="server" />
    </asp:Panel>
</asp:Content>
