<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Suma.aspx.cs" Inherits="Laboratorio153.Suma" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Laboratorio 153 Suma</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Laboratorio 153 - Suma de Números</h2>
            
            <p>Primer número:</p>
            <asp:TextBox ID="txtNumero1" runat="server" Width="150px"></asp:TextBox>
            
            <p>Segundo número:</p>
            <asp:TextBox ID="txtNumero2" runat="server" Width="150px"></asp:TextBox>
            
            <br /><br />
            <asp:Button ID="btnSumar" runat="server" Text="Sumar" OnClick="btnSumar_Click" />
            
            <br /><br />
            <asp:Label ID="lblResultado" runat="server" Text="Resultado: " ></asp:Label>
        </div>
    </form>
</body>
</html>