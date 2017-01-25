using PartnersMatcher.Controller;
using PartnersMatcher.Model;
using PartnersMatcher.View;
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
using System.Data.OleDb;

namespace PartnersMatcher.View//morrr
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        private IController m_controller;
        private Search m_search;
        private NewAd m_NewAd;
        private openRequest m_op;//mor
        private RequestManagement m_rm;//mor
        private NewPayment m_newPayment;//hila
        public static int IDAd;//adi


        public MainWindow()
        {
            IDAd = int.Parse(System.IO.File.ReadAllText(@"LastIdAd.txt")) + 1;//adi

            m_controller = new MyController();
            IModel model = new MyModel(m_controller);
            m_controller.Model = model;
            m_controller.View = this;         
            InitializeComponent();
            Searchbtn.IsEnabled = false;
            NewAdbtn.IsEnabled = false;
            NewPaymentbtn.IsEnabled = false;
            RequestManagebtn.IsEnabled = false;
        }
        private void register_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow rw = new RegisterWindow(m_controller);
            rw.ShowDialog();
        }
        private void connect_Click(object sender, RoutedEventArgs e)
        {
            m_controller.connect(passwordBox.Password, tb_userName.Text);             
        }
        public void message(string msg)
        {
            MessageBox.Show(msg);
        }
        public void privateZone()
        {
            textBlockConnect.Text = "שלום, " + m_controller.UserName;
            Searchbtn.IsEnabled = true;
            NewAdbtn.IsEnabled = true;
            NewPaymentbtn.IsEnabled = true;
            RequestManagebtn.IsEnabled = true;
        }
        public void displayCategoryList(List<string> categoriesList, CurrentWindow window)
        {
            if (window.Equals(CurrentWindow.Search))
            {
                m_search.displayCategoryList(categoriesList);
            }
            else
            {
                m_NewAd.displayCategoryList(categoriesList);
            }          
        }
        public void displayCityList(List<string> cityList)
        {
            m_search.displayCityList(cityList);          
        }
        public void displaySearchResult(List<List<string>> reader)
        {
            m_search.displaySearchResult(reader);
        }
        public void openRequest(int adID, string userName)//mor
        {
            m_op = new openRequest(adID, userName, m_controller);
            m_op.ShowDialog();
        }
        public void closeRequestWindow()//mor
        {
            m_op.Close();
        }
        private void NewAdbtn_Click(object sender, RoutedEventArgs e)
        {
            m_NewAd = new NewAd(m_controller);
            m_controller.updateCategoryList(CurrentWindow.NewAd);
            m_NewAd.ShowDialog();
        }
        private void Searchbtn_Click(object sender, RoutedEventArgs e)
        {
            m_search = new Search(m_controller);
            m_controller.updateCategoryList(CurrentWindow.Search);
            m_search.ShowDialog();
        }
        private void RequestManagebtn_Click(object sender, RoutedEventArgs e)//mor
        {
            m_controller.requestMangmentWindowLists(m_controller.UserName);
        }
        private void NewPaymentbtn_Click(object sender, RoutedEventArgs e)//hila
        {
            m_newPayment = new NewPayment(m_controller);
            m_controller.ShowUserAds(m_controller.UserName);
            m_newPayment.ShowDialog();
        }
        public void displayUserAds(List<string> ads)//hila
        {
            m_newPayment.displayUserAds(ads);
        }
        public void OpenRequestManagementWindow(Tuple<List<string>, List<string>> info)//mor
        {
            m_rm = new RequestManagement(m_controller, m_controller.UserName, info);
            m_rm.ShowDialog();
        }
        public void updateRequestList(Tuple<List<string>, List<string>> reqInfo)//mor
        {
            m_rm.listBox_waitForMe.Items.Clear();
            m_rm.listBox_waitForResponse.Items.Clear();
            m_rm.displayWaitforMeRequests(reqInfo.Item1);
            m_rm.displayMyRequests(reqInfo.Item2);
        }
        public void addPartnerToAd(string userName)
        {
            m_NewAd.addPartnerToAd(userName);
        }//adi
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.IO.File.WriteAllText(@"LastIdAd.txt", IDAd.ToString());
        }//adi

    }
}
