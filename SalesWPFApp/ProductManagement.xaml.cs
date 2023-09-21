using BusinessObject.Repository;
using DataAccess.DataAccess;
using System;
using System.Windows;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for ProductManagement.xaml
    /// </summary>
    public partial class ProductManagement : Window
    {
        IProductReposity productReposity;
        public ProductManagement(IProductReposity productReposity)
        {
            InitializeComponent();
            this.productReposity = productReposity;
            LoadProductList();
        }

        private void LoadProductList()
        {
            var source = productReposity.GetProducts();
            lvProduct.ItemsSource = source;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ModifyProduct modifyProduct = new ModifyProduct(productReposity);
                modifyProduct.ShowDialog();
                LoadProductList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Open Window Add: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ModifyProduct modifyProduct = new ModifyProduct(productReposity, false, GetProductInfor());
                modifyProduct.ShowDialog();
                LoadProductList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Open Window Update: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = GetProductInfor();
                if (product != null)
                {
                    if (MessageBox.Show("Do you wanna delete this product?", "Delete Product", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        productReposity.DeleteProduct(GetProductInfor());
                        LoadProductList();
                        MessageBox.Show("Delete Successful!", "Delete Product");
                    }
                } else
                {
                    MessageBox.Show("You Have to enter value!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Error: " + ex.Message, "Delete Product");
            }
        }

        private Product GetProductInfor()
        {
            Product pro = new Product();

            try
            {
                pro.ProductId = int.Parse(txtProductId.Text);
                pro.CategoryId = int.Parse(txtCategoryId.Text);
                pro.ProductName = txtProductName.Text;
                pro.Weight = txtWeight.Text;
                pro.UnitPrice = decimal.Parse(txtUnitPrice.Text);
                pro.UnitsInStock = int.Parse(txtUnitsInStock.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetProductInfor: " + ex.Message);
            }

            return pro;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            LoadProductList();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                searchProduct();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search Product: " + ex.Message);
            }
        }
        private void searchProduct()
        {
            try
            {
                int proId = txtProductIdFilter.Text != "" ? int.Parse(txtProductIdFilter.Text) : -1;
                string proName = txtProductNameFilter.Text;
                decimal unitPrice = txtUniPriceFilter.Text != "" ? decimal.Parse(txtUniPriceFilter.Text) : -1;
                int unitInStock = txtUnitInStockFilter.Text != "" ? int.Parse(txtUnitInStockFilter.Text) : -1;
                //get data
                var source = productReposity.filterProduct(proId, proName, unitPrice, unitInStock);
                //put data
                lvProduct.ItemsSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search Product: " + ex.Message);
            }
        }

        private void txtProductNameFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                searchProduct();
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtProductNameFilter_TextChanged_Search Product: " + ex.Message);
            }
        }
    }
}
