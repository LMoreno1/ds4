<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Laboratorio152.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Laboratorio 152</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Laboratorio 152</h2>
            <p>Introduzca un Texto:</p>
            <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>
            <br /><br />
            <asp:Button ID="Button1" runat="server" Text="Enviar Saludo" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>