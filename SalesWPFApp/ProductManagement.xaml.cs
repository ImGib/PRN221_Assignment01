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
                if (MessageBox.Show("Do you wanna delete this product?", "Delete Product", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    productReposity.DeleteProduct(GetProductInfor());
                    LoadProductList();
                    MessageBox.Show("Delete Successful!", "Delete Product");
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
    }
}
