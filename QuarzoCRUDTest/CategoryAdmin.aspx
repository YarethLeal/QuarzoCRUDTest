<%@ Page Title="Categorias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryAdmin.aspx.cs" Inherits="QuarzoCRUDTest.CategoryAdmin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div>
            <h2>Gestión de Categorías</h2>

            <asp:GridView ID="gvCategories" runat="server" AutoGenerateColumns="false" OnRowEditing="gvCategories_RowEditing"
                OnRowDeleting="gvCategories_RowDeleting" OnRowCancelingEdit="gvCategories_RowCancelingEdit"
                OnRowUpdating="gvCategories_RowUpdating" DataKeyNames="CategoryId">
                <Columns>
                    <asp:BoundField DataField="CategoryId" HeaderText="ID" ReadOnly="true" />

                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                            <%# Eval("Name") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCategoryName" runat="server" Text='<%# Bind("Name") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Activo">
                        <ItemTemplate>
                            <%# Eval("Active") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlActivo" runat="server">
                                <asp:ListItem Text="Sí" Value="true" />
                                <asp:ListItem Text="No" Value="false" />
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
                </Columns>
            </asp:GridView>

            <br />

            <h2>Agregar Categoría</h2>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label><br />
            <asp:TextBox ID="txtCategoryID" runat="server" Placeholder="ID de la Categoría"></asp:TextBox><br />
            <asp:TextBox ID="txtNewCategory" runat="server" Placeholder="Nombre de la Categoría"></asp:TextBox><br />
            <asp:Button ID="btnAddCategory" runat="server" Text="Agregar" OnClick="btnAddCategory_Click" />

        </div>
    </main>
</asp:Content>
