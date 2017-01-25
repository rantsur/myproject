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
    /// Interaction logic for NewAdd.xaml
    /// </summary>
    public partial class NewAd : Window
    {
        private IController m_controller;
        UserControl m_ad;


        public NewAd(IController controller)
        {
            m_controller = controller;
            InitializeComponent();

        }

        public IController Controller
        {
            get
            {
                return m_controller;
            }
        }
        private void category_changed(object sender, RoutedEventArgs e)
        {
            switch (categories.SelectedValue.ToString())
            {

                case "דיור":
                    m_ad = new accommodation(this);
                    Grid.SetRow(m_ad, 2);
                    MainGrid.Children.Add(m_ad);
                    break;
                case "דייט רומנטי":
                    m_ad = new romantic_Date(this);
                    Grid.SetRow(m_ad, 2);
                    MainGrid.Children.Add(m_ad);
                    break;
                case "ספורט":
                    m_ad = new sport(this);
                    Grid.SetRow(m_ad, 2);
                    MainGrid.Children.Add(m_ad);
                    break;
                case "טיול":
                    m_ad = new trip(this);
                    Grid.SetRow(m_ad, 2);
                    MainGrid.Children.Add(m_ad);
                    break;

            }

        }

        public void displayCategoryList(List<string> categoriesList)
        {
            categories.ItemsSource = categoriesList;
        }
        internal void addPartnerToAd(string userName)
        {
            switch (categories.SelectedValue.ToString())
            {
                case "דיור":
                    ((accommodation)m_ad).tb_partnersList.Items.Add(userName);
                    ((accommodation)m_ad).tb_partner.Clear();
                    break;
                case "דייט רומנטי":
                    ((romantic_Date)m_ad).tb_partnersList.Items.Add(userName);
                    ((romantic_Date)m_ad).tb_partner.Clear();
                    break;
                case "ספורט":
                    ((sport)m_ad).tb_partnersList.Items.Add(userName);
                    ((sport)m_ad).tb_partner.Clear();
                    break;
                case "טיול":
                    ((trip)m_ad).tb_partnersList.Items.Add(userName);
                    ((trip)m_ad).tb_partner.Clear();
                    break;
            }
        }

    }
}
