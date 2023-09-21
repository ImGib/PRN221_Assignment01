using BusinessObject.Repository;
using DataAccess.DataAccess;
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
    /// Interaction logic for UserFunction.xaml
    /// </summary>
    public partial class UserFunction : Window
    {
        IMemberRepository memberRepository;
        IOrderRepository orderRepository;
        Member user;
        public UserFunction(IMemberRepository memberRepository, IOrderRepository orderRepository ,Member member)
        {
            InitializeComponent();
            this.memberRepository = memberRepository;
            this.orderRepository = orderRepository;
            this.user = member;
            BindingProfile();
            BindingLvOrder();
        }
        private void BindingProfile()
        {
            try
            {
                txtMemberId.Text = user.MemberId.ToString();
                txtEmail.Text = user.Email;
                txtCountry.Text = user.Country;
                txtCompany.Text = user.CompanyName;
                txtCity.Text = user.City;
            } catch (Exception ex)
            {
                MessageBox.Show("Cannot bind User Profile. " + ex.Message);
            }
        }
        private Boolean BindingLvOrder()
        {
            try
            {
                var orders = user.Orders;
                lvOrder.ItemsSource = orders;
            }catch (Exception ex)
            {
                MessageBox.Show("Cannot bind Order History. " + ex.Message);
            }
            return true;
        }
    }
}
