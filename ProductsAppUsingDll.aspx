﻿<%@ Page Language="C#" MasterPageFile="~/MasterSheet.Master" AutoEventWireup="true" CodeBehind="ProductsAppUsingDll.aspx.cs" Inherits="SampleWebApp.ProductsAppUsingDll" %>
<asp:Content runat="server" ContentPlaceHolderID="mainContent">
    <h1 class="h1 text-bg-primary" >Product Information</h1>
        <div class ="container">
            <div class="row">
                <div class="col-md-4">
                    <asp:ListBox ID="lstProducts" CssClass="form-control" runat="server" Height="386px" Width="213px" OnSelectedIndexChanged="lstProducts_SelectedIndexChanged" AutoPostBack="True">
                    </asp:ListBox>

                </div>
                <div class="col-md-7">
                    <h2>Details of Product</h2>
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Image ID="imgPic" runat="server" Height="262px" Width="300px" />
                        </div>
                        <div class="col-md-4">
                            <p>Product Id: <asp:TextBox runat="server" CssClass="form-control" ID="txtId" /></p>
                            <p>Name: <asp:TextBox runat="server" CssClass="form-control" ID="txtName" /></p>
                            <p>Price: <asp:TextBox runat="server" CssClass="form-control" ID="txtPrice" /></p>
                            <p>Quantity: 
                                <asp:DropDownList runat="server" CssClass="form-control" ID="dpQuantity">
                                   <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>

                                </asp:DropDownList>
                            </p>
                            <p> 
                                <asp:FileUpload runat="server" ID="fileUp" />
                            </p>
                        </div>
                       <div class="col-md-1 align-items-center" >
                            <button runat="server" onserverclick="btnEdit_Click" class="btn btn-info m-2">
                                <i class="fa fa-pencil"></i>
                            </button>
                            <button onserverclick="btnDelete_Click" runat="server" class="btn btn-danger m-2">
                                <i class="fa fa-trash"></i>
                            </button>
                             <button onserverclick="btnAdd_Click" runat="server" class="btn btn-primary m-2">
                                <i class="fa fa-plus-circle"></i>
                            </button>


                           
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>



