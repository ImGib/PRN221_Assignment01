﻿using BusinessObject.Repository;
using DataAccess.DataAccess;
using System;
using System.Windows;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for ModifyMember.xaml
    /// </summary>
    public partial class ModifyMember : Window
    {
        IMemberRepository memberRepository;
        private Boolean isAdd = true;
        private string strOption = "Add New";
        private Member updMember = new Member();
        public ModifyMember(IMemberRepository memberRepository)
        {
            InitializeComponent();
            this.memberRepository = memberRepository;
        }
        public ModifyMember(IMemberRepository memberRepository, Boolean isAdd, Member updMember)
        {
            InitializeComponent();
            this.memberRepository = memberRepository;
            this.isAdd = isAdd;
            this.updMember = updMember;
            UpdateInitialize();
        }

        private void UpdateInitialize()
        {
            try
            {
                btnAccept.Content = "Update";
                lbTitle.Content = "Update Member";
                strOption = "Update";

                txtMemberId.Text = updMember.MemberId.ToString();
                txtEmail.Text = updMember.Email;
                txtCountry.Text = updMember.Country;
                txtCity.Text = updMember.City;
                txtCompany.Text = updMember.CompanyName;
                txtPassword.Text = updMember.Password;
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
                if (MessageBox.Show("Do You Wanna " +strOption+" Member?", strOption+" Member", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Member member = GetScreenInfo();
                    memberRepository.InsertMember(member);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAccept_Click: " + ex.Message);
            }
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

        private Member GetScreenInfo()
        {
            Member member = new Member();

            try
            {
                member.Email = txtEmail.Text;
                member.Country = txtCountry.Text;
                member.City = txtCity.Text;
                member.CompanyName = txtCompany.Text;
                member.Password = txtPassword.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetScreenInfo: " + ex.Message);
            }

            return member;
        }
    }
}
