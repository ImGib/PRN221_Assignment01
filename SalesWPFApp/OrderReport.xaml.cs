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
    /// Interaction logic for OrderReport.xaml
    /// </summary>
    public partial class OrderReport : Window
    {
        IOrderRepository orderRepository;
        
        public OrderReport(IOrderRepository orderRepository)
        {
            InitializeComponent();
            this.orderRepository = orderRepository;
        }

        private Boolean CheckValidate(out DateTime startDate, out DateTime endDate)
        {
            try
            {
                startDate = DateTime.Parse(dpStart.Text);
                endDate = DateTime.Parse(dpEnd.Text);
            }
            catch (Exception ex)
            {
                startDate = new DateTime();
                endDate = new DateTime();
                MessageBox.Show("Date Time Validate Error: " + ex.Message);
                return false;
            }
            return true;
        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime startDate = new DateTime();
                DateTime endDate = new DateTime();
                if(!CheckValidate(out startDate, out endDate))
                {
                    return;
                }

                var source = orderRepository.filterOrder(startDate, endDate);
                lvOrder.ItemsSource = source;
            } catch (Exception ex)
            {
                MessageBox.Show("Cannot filter order: " + ex.Message);

            }
        }

        
    }
}
