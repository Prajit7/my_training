using SampleWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var data = ProductRepo.AllProduct;
                foreach (var item in data)
                    lstProducts.Items.Add(new ListItem
                    {
                        Text = item.ProductName,
                        Value = item.ProductId.ToString()
                    });
            }

        }

        protected void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            var id = int.Parse(lstProducts.SelectedValue);
            var selected = ProductRepo.AllProduct.FirstOrDefault((p) => p.ProductId == id);
            txtId.Text = selected.ProductId.ToString();
            txtName.Text = selected.ProductName;
            txtPrice.Text = selected.Price.ToString();
            imgPic.ImageUrl = selected.Image;

        }
     protected void btnDelete_Click(object sender,EventArgs e)
        {
            ProductRepo.DeleteProduct(int.Parse(txtId.Text));
            Response.Redirect("Product.aspx");
        }
        protected void btnAdd_Click(object sender,EventArgs e)
        {
            var product = new Products
            {
                Image = imgPic.ImageUrl,
                Price = int.Parse(txtPrice.Text),
                ProductId = int.Parse(txtId.Text),
                ProductName = txtName.Text,
                Quantity = int.Parse(dpQuantity.Text)
            };
            ProductRepo.AddNewProduct(product);
            Response.Redirect("Product.aspx");



        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var product = new Products
            {
                Image = imgPic.ImageUrl,
                Price = int.Parse(txtPrice.Text),
                ProductId = int.Parse(txtId.Text),
                ProductName = txtName.Text,
                Quantity = int.Parse(dpQuantity.Text)
            };
            ProductRepo.UpdateProduct(product);
            Response.Redirect("Product.aspx");
        }


    }
}