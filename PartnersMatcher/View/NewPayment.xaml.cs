using PartnersMatcher.Controller;
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

namespace PartnersMatcher.View
{
    /// <summary>
    /// Interaction logic for NewPayment.xaml
    /// </summary>
    public partial class NewPayment : Window
    {
        private IController m_controller;
        string ad_id;
        public NewPayment(IController controller)
        {
            m_controller = controller;
            InitializeComponent();
            lastDate.DisplayDateStart = DateTime.Today;
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {

            if (type.Text == "" || amount.Text == "" || way.Text == "" || lastDate.Text == "")
            {
                System.Windows.MessageBox.Show("אנא ודא שהכל השדות מוזנים, אחרת התשלום לא יוזן למערכת");
                return;
            }

            m_controller.AddNewPayment(m_controller.UserName, ad_id, type.Text, amount.Text, way.Text, lastDate.Text);

        }

        public void displayUserAds(List<string> ads)
        {

            AdsCheckListBox.ItemsSource = ads;
        }
        private void adSelected(object sender, SelectionChangedEventArgs e)
        {
            Send.IsEnabled = true;
            ad_id = AdsCheckListBox.SelectedItem.ToString();

        }
    }
}
