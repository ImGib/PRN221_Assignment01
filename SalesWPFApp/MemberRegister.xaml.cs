using BusinessObject.Repository;
using DataAccess.DataAccess;
using System;
using System.Net.Mail;
using System.Windows;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for MemberRegister.xaml
    /// </summary>
    public partial class MemberRegister : Window
    {
        IMemberRepository memberRepository;
        public MemberRegister(IMemberRepository memberRepository)
        {
            InitializeComponent();
            this.memberRepository = memberRepository;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!ValidateInput())
                {
                    return;
                }

                RegisterUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RegisterUser()
        {
            try
            {
                Member member = new Member
                {
                    Email = txtEmail.Text,
                    Password = txtPassword.Password,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    CompanyName = txtCompany.Text
                };
                memberRepository.InsertMember(member);
                MessageBox.Show("Register successfully!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot register: " + ex.Message);
            }
        }

        private bool ValidateInput()
        {
            try
            {
                //check mail is validate
                MailAddress mail = new MailAddress(txtEmail.Text);
                //check exist
                if (memberRepository.GetMemberByEmail(txtEmail.Text) != null)
                {
                    MessageBox.Show("Email has already Exist!");
                    return false;
                }
                if (String.IsNullOrEmpty(txtPassword.Password))
                {
                    MessageBox.Show("Please Enter Password");
                    return false;
                }
                //compare password
                if (!txtPassword.Password.Equals(txtConfirmPassword.Password))
                {
                    MessageBox.Show("Confirm Password has been wrong!");
                    return false;
                }
                if(String.IsNullOrEmpty(txtCompany.Text))
                {
                    MessageBox.Show("Please Enter Company");
                    return false;
                }
                if (String.IsNullOrEmpty(txtCity.Text))
                {
                    MessageBox.Show("Please Enter City");
                    return false;
                }
                if (String.IsNullOrEmpty(txtCountry.Text))
                {
                    MessageBox.Show("Please Enter Country");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to stop register?", "Cancel", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Close();
            }
        }
    }
}
