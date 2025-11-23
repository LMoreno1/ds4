<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio202.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Laptops</title>
    <style>
        .container {
            width: 80%;
            margin: 20px auto;
            font-family: Arial;
        }
        .form-group {
            margin: 10px 0;
        }
        .form-group label {
            display: inline-block;
            width: 100px;
            font-weight: bold;
        }
        .form-group input {
            padding: 5px;
            width: 200px;
        }
        .toolbar {
            margin: 15px 0;
        }
        .toolbar button {
            padding: 8px 15px;
            margin: 0 5px;
            cursor: pointer;
        }
        .search-box {
            margin: 15px 0;
            padding: 10px;
            background-color: #f5f5f5;
            border-radius: 5px;
        }
        .message {
            padding: 10px;
            margin: 10px 0;
            border-radius: 5px;
        }
        .success {
            background-color: #d4edda;
            color: #155724;
            border: 1px solid #c3e6cb;
        }
        .error {
            background-color: #f8d7da;
            color: #721c24;
            border: 1px solid #f5c6cb;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Gestión de Laptops</h1>
            
            <asp:Panel ID="pnlMessage" runat="server" CssClass="message" Visible="false">
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </asp:Panel>

            <div class="search-box">
                <strong>Buscar por ID:</strong>
                <asp:TextBox ID="txtBuscarId" runat="server" placeholder="ID a buscar"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
            </div>

            <div class="form-group">
                <asp:Label ID="lblId" runat="server" Text="ID:" AssociatedControlID="txtId"></asp:Label>
                <asp:TextBox ID="txtId" runat="server" Enabled="false"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre:" AssociatedControlID="txtNombre"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" Enabled="false"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblPrecio" runat="server" Text="Precio:" AssociatedControlID="txtPrecio"></asp:Label>
                <asp:TextBox ID="txtPrecio" runat="server" Enabled="false" TextMode="Number" step="0.01"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblStock" runat="server" Text="Stock:" AssociatedControlID="txtStock"></asp:Label>
                <asp:TextBox ID="txtStock" runat="server" Enabled="false" TextMode="Number"></asp:TextBox>
            </div>

            <div class="toolbar">
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" Enabled="false" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" Enabled="false" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" Enabled="false" />
                <asp:Button ID="btnSalir" runat="server" Text="Salir" OnClick="btnSalir_Click" />
            </div>
        </div>
    </form>
</body>
</html>