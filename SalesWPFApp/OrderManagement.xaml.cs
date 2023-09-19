using BusinessObject.Repository;
using DataAccess.DataAccess;
using System;
using System.Windows;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for OrderManagement.xaml
    /// </summary>
    public partial class OrderManagement : Window
    {
        IOrderRepository orderRepository;
        public OrderManagement(IOrderRepository orderRepository)
        {
            InitializeComponent();
            this.orderRepository = orderRepository;
            LoadOrderList();
        }

        private void LoadOrderList()
        {
            var source = orderRepository.GetAll();
            lvOrder.ItemsSource = source;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ModifyOrder modifyOrder = new ModifyOrder(orderRepository);
                modifyOrder.ShowDialog();
                LoadOrderList();
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
                ModifyOrder modifyOrder = new ModifyOrder(orderRepository, false, GetOrderInfor());
                modifyOrder.ShowDialog();
                LoadOrderList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Open Window Update: " + ex.Message);
            }
        }

        private Order GetOrderInfor()
        {
            Order order = new Order();
            try
            {
                order.OrderId = int.Parse(txtOrderId.Text);
                order.MemberId = int.Parse(txtMemberId.Text);
                order.OrderDate = DateTime.Parse(txtOrderDate.Text);
                order.RequiredDate = String.IsNullOrEmpty(txtRequiredDate.Text) ? null : DateTime.Parse(txtRequiredDate.Text);
                order.ShippedDate = String.IsNullOrEmpty(txtShippedDate.Text) ? null : DateTime.Parse(txtShippedDate.Text);
                order.Freight = String.IsNullOrEmpty(txtFreight.Text) ? null : Decimal.Parse(txtFreight.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetOrderInfor: " + ex.Message);
            }
            return order;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you wanna delete this order?", "Delete Order", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    orderRepository.DeleteOrder(GetOrderInfor());
                    LoadOrderList();
                    MessageBox.Show("Delete Successful!", "Delete Order");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Error: " + ex.Message, "Delete Order");
            }
        }
    }
}
