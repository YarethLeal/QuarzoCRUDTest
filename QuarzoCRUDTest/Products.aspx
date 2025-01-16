<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="QuarzoCRUDTest.Products" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div>
            <asp:DropDownList ID="ddlCategories" runat="server" AutoPostBack="false">
            </asp:DropDownList>
            <asp:Button ID="btnFilter" runat="server" Text="Filtrar" OnClick="btnFilter_Click" />
            <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="ProductID" HeaderText="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Nombre" />
                    <asp:BoundField DataField="Price" HeaderText="Precio" />
                    <asp:BoundField DataField="Category.Name" HeaderText="Categoría" />
                </Columns>
            </asp:GridView>
        </div>
    </main>
</asp:Content>
