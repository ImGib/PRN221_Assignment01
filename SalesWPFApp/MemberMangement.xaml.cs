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
    /// Interaction logic for MemberMangement.xaml
    /// </summary>
    public partial class MemberMangement : Window
    {
        IMemberRepository memberRepository;
        public MemberMangement(IMemberRepository memberRepository)
        {
            InitializeComponent();
            this.memberRepository = memberRepository;
            LoadMemberList();
        }

        private void LoadMemberList()
        {
            var source = memberRepository.GetAllMembers();
            lvMember.ItemsSource = source;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ModifyMember modifyMember = new ModifyMember(memberRepository);
                modifyMember.ShowDialog();
                LoadMemberList();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ModifyMember modifyMember = new ModifyMember(memberRepository,false, GetMemberInfor());
                modifyMember.ShowDialog();
                LoadMemberList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(MessageBox.Show("Do you wanna delete this member?", "Delete Member", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    memberRepository.DeleteMember(GetMemberInfor());
                    LoadMemberList();
                    MessageBox.Show("Delete Successful!", "Delete Member");
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Delete Error: " + ex.Message, "Delete Member");
            }
        }

        private Member GetMemberInfor()
        {
            Member member = new Member();
            try
            {
                member.MemberId = int.Parse(txtMemberId.Text);
                member.Email = txtEmail.Text;
                member.Country = txtCountry.Text;
                member.City = txtCity.Text;
                member.CompanyName = txtCompany.Text;
                //member.Password = txtPassword.Text;
            } catch (Exception ex)
            {
                MessageBox.Show("GetMemberInfor: " + ex.Message);
            }
            return member;
        }
    }
}
