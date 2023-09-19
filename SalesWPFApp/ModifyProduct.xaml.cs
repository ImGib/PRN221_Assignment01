using BusinessObject.Repository;
using DataAccess.DataAccess;
using System;
using System.Windows;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for ModifyProduct.xaml
    /// </summary>
    public partial class ModifyProduct : Window
    {
        IProductReposity productReposity;
        private Boolean isAdd = true;
        private string strOption = "Add New";
        private Product updPro = new Product();
        public ModifyProduct(IProductReposity productReposity)
        {
            InitializeComponent();
            this.productReposity = productReposity;
        }

        public ModifyProduct(IProductReposity productReposity, Boolean isAdd, Product pro)
        {
            InitializeComponent();
            this.productReposity = productReposity;
            this.isAdd = isAdd;
            this.updPro = pro;
            UpdateInitialize();
        }

        private void UpdateInitialize()
        {
            try
            {
                btnAccept.Content = "Update";
                lbTitle.Content = "Update Member";
                strOption = "Update";

                txtProductId.Text = updPro.ProductId.ToString();
                txtCategoryId.Text = updPro.CategoryId.ToString();
                txtProductName.Text = updPro.ProductName.ToString();
                txtWeight.Text = updPro.Weight.ToString();
                txtUnitPrice.Text = updPro.UnitPrice.ToString();
                txtUnitsInStock.Text = updPro.UnitsInStock.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("UpdateInitialize: " + ex.Message);
            }
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do You Wanna " + strOption + " Product?", strOption + " Product", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Product pro = GetScreenInfo();
                    if (isAdd)
                    {
                        productReposity.InsertProduct(pro);
                    }
                    else
                    {
                        productReposity.UpdateProduct(pro);
                    }
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAccept_Click: " + ex.Message);
            }
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnNo_Click: " + ex.Message);
            }
        }
        private Product GetScreenInfo()
        {
            Product pro = new Product();

            try
            {
                if (!isAdd)
                {
                    pro.ProductId = int.Parse(txtProductId.Text);
                }
                pro.CategoryId = int.Parse(txtCategoryId.Text);
                pro.ProductName = txtProductName.Text;
                pro.Weight = txtWeight.Text;
                pro.UnitPrice = decimal.Parse(txtUnitPrice.Text);
                pro.UnitsInStock = int.Parse(txtUnitsInStock.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetScreenInfo: " + ex.Message);
            }

            return pro;
        }
    }
}
