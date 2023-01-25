using SampleWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class ProductDatBase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                

                var data = ProductRepoDB.AllProduct;

                foreach (var item in data)
                    lstProducts.Items.Add(new ListItem
                    {
                        Text = item.PRODUCTNAME,
                        Value = item.PRODUCTID.ToString()
                       
                    });
            }
        }

        protected void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtId.Enabled = false;
            var id = int.Parse(lstProducts.SelectedValue);
            var selected = ProductRepoDB.AllProduct.FirstOrDefault((p) => p.PRODUCTID == id);
            txtId.Text = selected.PRODUCTID.ToString();
            txtName.Text = selected.PRODUCTNAME;
            txtPrice.Text = selected.PRICE.ToString();
            imgPic.ImageUrl = selected.IMAGE;
            lstProducts.Text = selected.QUANTITY.ToString();

        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ProductRepoDB.DeleteProduct(int.Parse(txtId.Text));
            Response.Redirect("ProductDatBase.aspx");
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var product = new PRODUCTSDB
            {

                
                //IMAGE = fileUp.PostedFiles(),
                PRICE = int.Parse(txtPrice.Text),
                PRODUCTID = int.Parse(txtId.Text),
                PRODUCTNAME = txtName.Text,
                QUANTITY = int.Parse(dpQuantity.Text)
            };
            ProductRepoDB.AddNewProduct(product);
            
            Response.Redirect("ProductDatBase.aspx");



        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var product = new PRODUCTSDB
            {
                PRICE = int.Parse(txtPrice.Text),
                PRODUCTID = int.Parse(txtId.Text),
                PRODUCTNAME = txtName.Text,
                QUANTITY = int.Parse(dpQuantity.Text)
            };
            ProductRepoDB.UpdateProduct(product);
            Response.Redirect("ProductDatBase.aspx");
        }
    }
}