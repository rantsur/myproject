using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PartnersMatcher.View
{
    /// <summary>
    /// Interaction logic for accommodation.xaml
    /// </summary>
    public partial class accommodation : UserControl
    {
        private NewAd m_NewAd;
        List<BitmapImage> imgList;
        public accommodation(NewAd NewAd)
        {
            m_NewAd = NewAd;
            InitializeComponent();
            lb_furniture.ItemsSource = new List<string> { "מרוהטת", "מרוהטת חלקית", "לא מרוהטת", "אחר" };
            lb_condition.ItemsSource = new List<string> { "חדשה", "משופצת", "שמורה", "ישנה" };
            Date.DisplayDateStart = DateTime.Today;
            imgList = new List<BitmapImage>();

        }

        private void addNewPartner_Click(object sender, RoutedEventArgs e)
        {
            if (tb_partnersList.Items.Contains(tb_partner.Text))
            {
                MessageBox.Show("השותף כבר משוייך למודעה זו");
                tb_partner.Clear();
            }
            else
            {
                m_NewAd.Controller.addNewPartner(tb_partner.Text);
            }
        }
        private void addPhotos_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgList.Add(new BitmapImage(new Uri(op.FileName)));
            }
        }
        private void createNewAd_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> adData = new Dictionary<string, string>();
            adData.Add("user name", m_NewAd.Controller.UserName);
            adData.Add("Cost", tb_cost.Text);
            adData.Add("size", tb_size.Text);
            adData.Add("Ad Id", MainWindow.IDAd.ToString());
            adData.Add("Rooms Number", tb_numberOfUsers.Text);
            adData.Add("city", tb_city.Text);
            adData.Add("street", tb_address.Text);
            adData.Add("Partners Number", tb_numberOfUsers_Copy.Text);
            adData.Add("discription", tb_general.Text);
            adData.Add("Date", Date.SelectedDate.ToString());

            Dictionary<string, ComboBox> comboBox = new Dictionary<string, ComboBox>();
            comboBox.Add("condition", lb_condition);
            comboBox.Add("furniture", lb_furniture);

            m_NewAd.Controller.createNewAd(AdCategory.accommodation, adData, comboBox, cb_smoke, cb_elvator, tb_partnersList, imgList);
        }
    }
}
