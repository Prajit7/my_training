using DataAccessLib;
using SampleLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class ProductsAppUsingDll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var component = ProductFactory.GetComponent();
                lstProducts.DataSource = component.GetAllProducts();
                lstProducts.DataTextField = "ProductName";
                lstProducts.DataValueField = "ProductId";
                lstProducts.DataBind();
            }
        }

        protected void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var component = ProductFactory.GetComponent();
            var pId = int.Parse(lstProducts.SelectedItem.Value);
            var selectedProduct = component.GetAllProducts().Find((p) => p.PRODUCTID == pId);
            populateData(selectedProduct);
        }

        private void populateData(PRODUCTSDB product)
        {
           
            txtId.Text = product.PRODUCTID.ToString();
            txtName.Text = product.PRODUCTNAME;
            txtPrice.Text = product.PRICE.ToString();
            imgPic.ImageUrl = product.IMAGE;
            dpQuantity.Text = product.QUANTITY.ToString();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var component = ProductFactory.GetComponent();
            var product = new PRODUCTSDB
            {
                IMAGE = uploadFile(),
                PRICE = int.Parse(txtPrice.Text),
                PRODUCTID = int.Parse(txtId.Text),
                PRODUCTNAME = txtName.Text,
                QUANTITY = int.Parse(dpQuantity.Text)
            };
            component.UpdateProduct(product);
            Response.Redirect("ProductsAppUsingDll.aspx");

        }
        private string uploadFile()
        {
            string imgName = string.Empty;
            string imgPath = string.Empty;
            if (fileUp.PostedFile.FileName != String.Empty)
            {
                //get the file name of the posted image           
                imgName = fileUp.PostedFile.FileName;
                //sets the image path           
                imgPath = "./Images/" + imgName;
                //then save it to the Folder  
                fileUp.SaveAs(Server.MapPath(imgPath));
            }
            return imgPath;
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {

            var imgPath = uploadFile();

            var product = new PRODUCTSDB
            {
                PRODUCTID=int.Parse(txtId.Text),
                IMAGE = imgPath,
                PRICE = int.Parse(txtPrice.Text),
                PRODUCTNAME = txtName.Text,
                QUANTITY = int.Parse(dpQuantity.Text)
            };
            var component = ProductFactory.GetComponent();
            component.AddProduct(product);
            Response.Redirect("ProductsAppUsingDll.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var component = ProductFactory.GetComponent();
            component.DeleteProduct(int.Parse(txtId.Text));
            Response.Redirect("ProductsAppUsingDll.aspx");
        }
    }
}
