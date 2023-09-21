using BusinessObject.Repository;
using DataAccess.DataAccess;
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
        private void ClearText()
        {
            txtEmail.Text = string.Empty;
            txtPassword.Password = string.Empty;
            txtEmail.Focus();
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
                    Member? member = memberRepository.LoginCheck(email, password);
                    if (member != null)
                    {
                        UserFunction userFunction = new UserFunction(memberRepository, orderRepository,member);
                        Hide();
                        userFunction.ShowDialog();
                        this.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Email or password has been wrong. Please Enter Again!");
                    }
                }
                ClearText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private Boolean AdminCheck()
        {
            var admin = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("appsettings.json").Build().GetSection("Admin");

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
                MessageBox.Show("email must not blank! Please Enter again.");
                return false;
            }

            password = txtPassword.Password;

            if (String.IsNullOrEmpty(password))
            {
                MessageBox.Show("password must not blank! Please Enter again.");
                return false;
            }
            return true;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MemberRegister memberRegister = new MemberRegister(memberRepository);
                Hide();
                memberRegister.ShowDialog();
                ClearText();
                ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
