using BusinessObject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for HomeSalesManagement.xaml
    /// </summary>
    public partial class HomeSalesManagement : Window
    {
        IMemberRepository memberRepository;
        IOrderDetailRepository orderDetailRepository;
        IOrderRepository orderRepository;
        IProductReposity productReposity;
        public HomeSalesManagement(IMemberRepository memberRepository, IOrderDetailRepository orderDetailRepository, IOrderRepository orderRepository, IProductReposity productReposity)
        {
            InitializeComponent();
            this.memberRepository = memberRepository;
            this.orderDetailRepository = orderDetailRepository;
            this.orderRepository = orderRepository;
            this.productReposity = productReposity;
        }

        private void btnMember_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MemberMangement memberMangement = new MemberMangement(memberRepository);
                Hide();
                memberMangement.ShowDialog();
                ShowDialog();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Open Member Management Error: "+ex.Message);
            }
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProductManagement productManagement = new ProductManagement(productReposity);
                Hide();
                productManagement.ShowDialog();
                ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Open Product Management Error: " + ex.Message);
            }
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OrderManagement orderManagement = new OrderManagement(orderRepository);
                Hide();
                orderManagement.ShowDialog();
                ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Open Order Management Error: " + ex.Message);
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Close();
            }catch (Exception ex)
            {
                throw new Exception("Cannot Logout." + ex.Message);
            }
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OrderReport orderReport = new OrderReport(orderRepository);
                Hide();
                orderReport.ShowDialog();
                ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Open Report Statistic Error: " + ex.Message);
            }
        }
    }
}
