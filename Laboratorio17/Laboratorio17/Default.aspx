<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio17._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <asp:GridView ID="GridView1" runat="server" 
            DataSourceID="MyDataSource1"
            AutoGenerateColumns="False"
            DataKeyNames="ProductId"
            AutoGenerateEditButton="True">
            <Columns>
                <asp:BoundField DataField="ProductId" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" DataFormatString="{0:F2}" />
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="MyDataSource1" runat="server"
            ConnectionString="Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True"
            ProviderName="System.Data.SqlClient"
            SelectCommand="SELECT ProductId, ProductName, UnitPrice FROM Products"
            UpdateCommand="UPDATE Products SET ProductName=@ProductName, UnitPrice=@UnitPrice WHERE ProductId=@ProductId">
        </asp:SqlDataSource>
    </div>
</asp:Content>