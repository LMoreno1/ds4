<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio201.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Matriz Diagonal Inversa</title>
    <style>
        .matriz-table {
            border-collapse: collapse;
            margin: 20px 0;
        }
        .matriz-table td {
            width: 30px;
            height: 30px;
            text-align: center;
            border: 1px solid #000;
            font-family: Arial;
        }
        .numero-uno {
            background-color: #ffffcc;
            font-weight: bold;
        }
        .numero-cero {
            background-color: #f0f0f0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Matriz Diagonal Inversa</h1>
            <p>Ingrese la dimensión N para la matriz N x N:</p>
            <asp:TextBox ID="txtDimension" runat="server" TextMode="Number" Min="1" Max="20"></asp:TextBox>
            <asp:Button ID="btnGenerarMatriz" runat="server" Text="Generar Matriz" OnClick="btnGenerarMatriz_Click" />
            <br /><br />
            
            <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
            
            <asp:Panel ID="pnlMatriz" runat="server" Visible="false">
                <h2>Matriz <%= Dimension %> x <%= Dimension %></h2>
                <asp:Table ID="tblMatriz" runat="server" CssClass="matriz-table"></asp:Table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>