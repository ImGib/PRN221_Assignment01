using BusinessObject.Repository;
using DataAccess.DataAccess;
using System;
using System.Windows;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for ModifyOrder.xaml
    /// </summary>
    public partial class ModifyOrder : Window
    {
        IOrderRepository orderRepository;
        private Boolean isAdd = true;
        private string strOption = "Add New";
        private Order updOrder = new Order();
        public ModifyOrder(IOrderRepository orderRepository)
        {
            InitializeComponent();
            this.orderRepository = orderRepository;
        }
        public ModifyOrder(IOrderRepository orderRepository, Boolean isAdd, Order order)
        {
            InitializeComponent();
            this.orderRepository = orderRepository;
            this.isAdd = isAdd;
            this.updOrder = order;
            UpdateInitialize();
        }

        private void UpdateInitialize()
        {
            try
            {
                btnAccept.Content = "Update";
                lbTitle.Content = "Update Member";
                strOption = "Update";

                txtOrderId.Text = updOrder.OrderId.ToString();
                txtMemberId.Text = updOrder.MemberId.ToString();
                txtOrderDate.Text = updOrder.OrderDate.ToString("yyyy/dd/MM");
                txtRequiredDate.Text = updOrder.RequiredDate.ToString();
                txtShippedDate.Text = updOrder.ShippedDate.ToString();
                txtFreight.Text = updOrder.Freight.ToString();
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
                    Order order = GetScreenInfo();
                    if (isAdd)
                    {
                        orderRepository.InsertOrder(order);
                    }
                    else
                    {
                        orderRepository.UpdateOrder(order);
                    }
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAccept_Click: " + ex.Message);
            }
        }

        private Order GetScreenInfo()
        {
            Order order = new Order();
            try
            {
                if (!isAdd)
                {
                    order.OrderId = int.Parse(txtOrderId.Text);
                }
                order.MemberId = int.Parse(txtMemberId.Text);
                order.OrderDate = DateTime.Parse(txtOrderDate.Text);
                order.RequiredDate = String.IsNullOrEmpty(txtRequiredDate.Text) ? null : DateTime.Parse(txtRequiredDate.Text);
                order.ShippedDate = String.IsNullOrEmpty(txtShippedDate.Text) ? null : DateTime.Parse(txtShippedDate.Text);
                order.Freight = String.IsNullOrEmpty(txtFreight.Text) ? null : Decimal.Parse(txtFreight.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetScreenInfo: " + ex.Message);
            }
            return order;
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
    }
}
