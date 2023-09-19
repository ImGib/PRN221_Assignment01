using BusinessObject.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Windows;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        private string email = "";
        private string password = "";
        private readonly IMemberRepository memberRepository;
        private readonly IProductReposity productReposity;
        private readonly IOrderRepository orderRepository;
        private readonly IOrderDetailRepository orderDetailRepository;
        public MainWindow()
        {
            InitializeComponent();
            memberRepository = new MemberRepository();
            productReposity = new ProductRepository();
            orderRepository = new OrderRepository();
            orderDetailRepository = new OrderDetailsRepository();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //validate input
                if (!ValidateInput())
                {
                    return;
                }

                //admin check
                if (AdminCheck())
                {
                    //admin
                    HomeSalesManagement homeSalesManagement = new HomeSalesManagement(memberRepository, orderDetailRepository, orderRepository, productReposity);
                    this.Hide();
                    homeSalesManagement.ShowDialog();
                    this.ShowDialog();
                }
                else
                {
                    //member

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private Boolean AdminCheck()
        {
            var admin = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetSection("Admin");

            if (!admin["email"].Equals(email) || !admin["password"].Equals(password))
            {
                return false;
            }
            return true;
        }

        private Boolean ValidateInput()
        {
            email = txtEmail.Text;

            if (String.IsNullOrEmpty(email))
            {
                MessageBox.Show("email must not blank! Please Ener again.");
                return false;
            }

            password = txtPassword.Text;

            if (String.IsNullOrEmpty(password))
            {
                MessageBox.Show("password must not blank! Please Ener again.");
                return false;
            }
            return true;
        }

    }
}
