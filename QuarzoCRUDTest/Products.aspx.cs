using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuarzoCRUDTest.Services;

namespace QuarzoCRUDTest
{
    public partial class Products : System.Web.UI.Page
    {
        private readonly CategoryService _categoryService = new CategoryService();
        private readonly ProductService _productService = new ProductService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
                LoadProducts((int?)null);
            }
        }
        private void LoadCategories()
        {
            var categories = _categoryService.GetAllCategorie();
            ddlCategories.DataSource = categories;
            ddlCategories.DataTextField = "Name";
            ddlCategories.DataValueField = "CategoryId";
            ddlCategories.DataBind();
            ddlCategories.Items.Insert(0, new ListItem("Seleccione una categoría", "0"));
        }
        private void LoadProducts(int? categoryId)
        {
            var products = _productService.GetProducts(categoryId);
            gvProducts.DataSource = products;
            gvProducts.DataBind();
        }
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            int selectedCategoryId = int.Parse(ddlCategories.SelectedValue);
            LoadProducts(selectedCategoryId == 0 ? (int?)null : selectedCategoryId);
        }
    }
}