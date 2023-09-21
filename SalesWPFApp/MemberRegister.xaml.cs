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
        Boolean isRegis = true;
        Member user;
        string strUpd = "Register";
        public MemberRegister(IMemberRepository memberRepository)
        {
            InitializeComponent();
            this.memberRepository = memberRepository;
        }
        public MemberRegister(IMemberRepository memberRepository, Boolean isRegis, Member user)
        {
            InitializeComponent();
            this.memberRepository = memberRepository;
            this.isRegis = isRegis;
            this.user = user;
            UpdateProfile();
        }

        private void UpdateProfile()
        {
            lbTitle.Content = "Update Profile";
            btnRegister.Content = "Update";
            strUpd = "Update";

            txtEmail.Text = user.Email;
            txtCountry.Text = user.Country;
            txtCity.Text = user.City;
            txtCompany.Text = user.CompanyName;
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
                if (isRegis)
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
                }
                else
                {
                    user.Email = txtEmail.Text;
                    user.CompanyName = txtCompany.Text;
                    user.Country = txtCountry.Text;
                    user.City = txtCity.Text;


                    memberRepository.UpdateMember(user);
                    MessageBox.Show("Update successfully!");
                }

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
                if (isRegis)
                {
                    if (memberRepository.GetMemberByEmail(txtEmail.Text) != null)
                    {
                        MessageBox.Show("Email has already Exist!");
                        return false;
                    }
                    if (String.IsNullOrEmpty(txtPassword.Password))
                    {
                        MessageBox.Show("Please Enter Password!");
                        return false;
                    }
                    if (!txtPassword.Password.Equals(txtConfirmPassword.Password))
                    {
                        MessageBox.Show("Your password is was wrong!");
                        return false;
                    }
                }
                else
                {
                    if (!txtEmail.Text.Equals(user.Email) && memberRepository.GetMemberByEmail(txtEmail.Text) != null)
                    {
                        MessageBox.Show("Email has already Exist!");
                        return false;
                    }
                    if (!String.IsNullOrEmpty(txtPassword.Password))
                    {
                        if (txtPassword.Password.Equals(txtConfirmPassword.Password))
                        {
                            user.Password = txtPassword.Password;
                        }
                        else
                        {
                            MessageBox.Show("Your Confirm Password is wrong!");
                            return false;
                        }
                    }
                    else if (!String.IsNullOrEmpty(txtConfirmPassword.Password))
                    {
                        MessageBox.Show("Enter your Password");
                        return false;
                    }
                }

                if (String.IsNullOrEmpty(txtCompany.Text))
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
            if (MessageBox.Show("Do you want to stop " + strUpd + "?", "Cancel", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Close();
            }
        }
    }
}
