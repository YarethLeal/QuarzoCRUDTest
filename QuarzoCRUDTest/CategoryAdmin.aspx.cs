using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Antlr.Runtime.Misc;
using QuarzoCRUDTest.Models;
using QuarzoCRUDTest.Services;
using static System.Net.Mime.MediaTypeNames;

namespace QuarzoCRUDTest
{
    public partial class CategoryAdmin : System.Web.UI.Page
    {
        private readonly CategoryService _categoryService = new CategoryService();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }
        private void LoadCategories()
        {
            var categories = _categoryService.GetAllCategorie();
            gvCategories.DataSource = categories;
            gvCategories.DataBind();
        }
        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            string idInput = txtCategoryID.Text.Trim();
            string categoryName = txtNewCategory.Text.Trim();

            if (string.IsNullOrEmpty(idInput) || string.IsNullOrEmpty(categoryName))
            {
                lblMessage.Text = "El ID y el nombre de la categoría son obligatorios.";
                return;
            }

            if (!int.TryParse(idInput, out int categoryId))
            {
                lblMessage.Text = "El ID debe ser un número válido.";
                return;
            }

            try
            {
                // Verificar si el ID ya existe.
                var existingCategories = _categoryService.GetAllCategorie();
                if (existingCategories.Any(c => c.CategoryId == categoryId))
                {
                    lblMessage.Text = "El ID proporcionado ya está en uso.";
                    return;
                }

                // Agregar la nueva categoría.
                _categoryService.AddCategory(new Category
                {
                    CategoryId = categoryId,
                    Name = categoryName,
                    Active = true
                });

                lblMessage.Text = "Categoría agregada exitosamente.";
                txtCategoryID.Text = string.Empty;
                txtNewCategory.Text = string.Empty;
                LoadCategories();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error al agregar la categoría: " + ex.Message;
            }
        }
        protected void gvCategories_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCategories.EditIndex = e.NewEditIndex;
            LoadCategories();
        }
        protected void gvCategories_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int rowNumber = e.RowIndex;
                int categoryId = Convert.ToInt32(gvCategories.DataKeys[rowNumber].Value);
                string categoryName = ((TextBox)gvCategories.Rows[rowNumber].FindControl("txtCategoryName")).Text;
                bool isActive = ((DropDownList)gvCategories.Rows[rowNumber].FindControl("ddlActivo")).SelectedValue == "true";

                var category = new Category
                {
                    CategoryId = categoryId,
                    Name = categoryName,
                    Active = isActive
                };

                _categoryService.UpdateCategory(category);
                gvCategories.EditIndex = -1;
                LoadCategories();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error al actualizar la categoría: " + ex.Message;
            }
        }
        protected void gvCategories_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCategories.EditIndex = -1;
            LoadCategories();
        }
        protected void gvCategories_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
        }

    }
}