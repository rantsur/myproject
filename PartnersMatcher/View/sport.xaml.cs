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
    /// Interaction logic for sport.xaml
    /// </summary>
    public partial class sport : UserControl
    {
        private NewAd m_NewAd;
        List<BitmapImage> imgList = new List<BitmapImage>();

        public sport(NewAd NewAd)
        {
            m_NewAd = NewAd;
            InitializeComponent();
            lb_sportType.Items.Add("כדורגל"); //initialize sport list
            lb_sportType.Items.Add("כדורסל");
            lb_sportType.Items.Add("פוטבול");
            lb_sportType.Items.Add("ריצה");
            lb_sportType.Items.Add("שחייה");
            lb_sportType.Items.Add("חדר כושר");
            lb_sportType.Items.Add("טניס");

            lb_diffiLevel.Items.Add("קל"); //initialize difficulty level
            lb_diffiLevel.Items.Add("בינוני");
            lb_diffiLevel.Items.Add("קשה");

            date.DisplayDateStart = DateTime.Today;
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
            adData.Add("Ad Id", MainWindow.IDAd.ToString());
            adData.Add("place", tb_place.Text);
            adData.Add("Partners Number", tb_numberOfpartners.Text);
            adData.Add("discription", tb_general.Text);
            adData.Add("Date", date.SelectedDate.ToString());

            Dictionary<string, ComboBox> comboBox = new Dictionary<string, ComboBox>();
            comboBox.Add("sportKind", lb_sportType);
            comboBox.Add("difficultyLevel", lb_diffiLevel);

            m_NewAd.Controller.createNewAd(AdCategory.sport, adData, comboBox, null, null, tb_partnersList, imgList);
        }
    }
}
