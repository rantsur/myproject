using PartnersMatcher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.OleDb;
using System.Windows.Media.Imaging;

namespace PartnersMatcher.Controller
{
    public class MyController : IController
    {
        private IModel m_model;
        private IView m_view;
        private string m_userName;
        public MyController()
        {

        }
        public IModel Model
        {
            set
            {
                m_model = value;
            }
        }
        public IView View
        {
            set
            {
                m_view = value;
            }
        }
        public string UserName
        {
            get
            {
                return m_userName;
            }

            set
            {
                m_userName = value;
            }
        }
        public void connect(string password, string userName)
        {
            m_model.connect(password, userName);
        }
        public void createNewUser(Dictionary<string, string> userData, Dictionary<string, ComboBox> comboBox, CheckBox isSmoking)
        {
            m_model.createNewUser(userData, comboBox, isSmoking);
        }
        public void message(string msg)
        {
            m_view.message(msg);
        }
        public void privateZone()
        {
            m_view.privateZone();
        }
        public void updateCategoryList(CurrentWindow window)
        {
            m_model.updateCategoryList(window);
        }
        public void displayCategoryList(List<string> categories, CurrentWindow window)
        {
            m_view.displayCategoryList(categories, window);
        }
        public void updateCityList(string search_category)
        {
            m_model.updateCityList(search_category);
        }
        public void displayCityList(List<string> categories)
        {
            m_view.displayCityList(categories);
        }
        public void search(string search_category, string search_city)
        {
            m_model.search(search_category, search_city);
        }
        public void displaySearchResult(List<List<string>> reader)
        {
            m_view.displaySearchResult(reader);
        }
        public void openRequest(int adID, string userName)
        {
            m_view.openRequest(adID, userName);
        }
        public void openRequestWindow(int adID, string userName)//mor
        {
            m_model.openRequest(adID, userName);
        }
        public void sendRequest(int m_adId, string m_userName, string content)
        {
            m_model.sendRequest(m_adId, m_userName, content);
        }//mor
        public void closeRequestWindow()//mor
        {
            m_view.closeRequestWindow();
        }
        public void requestMangmentWindowLists(string userName)//mor
        {
            m_model.requestManagemntWindowLists(userName);
        }
        public void OpenRequestManagementWindow(Tuple<List<string>, List<string>> info)//mor
        {
            m_view.OpenRequestManagementWindow(info);
        }
        public void approveRequest(int adID, string userName, string partnerName)//mor
        {
            m_model.approveRequest( adID,  userName,  partnerName);
        }
        public void rejectRequest(int adID, string userName, string partnerName)
        {
            m_model.rejectRequest(adID, userName, partnerName);
        }//mor

        public void updateRequestList(Tuple<List<string>, List<string>> reqInfo)//mor
        {
            m_view.updateRequestList(reqInfo);
        }
        public void DisplayUserAdds(List<string> userAdds)//hila
        {
            m_view.displayUserAds(userAdds);
        }
        public void ShowUserAds(string userName)//hila
        {
            m_model.ShowUserAds(userName);
        }
        public void AddNewPayment(string userName, string adId, string paymentType, string amount, string wayOfPayment, string lastDate)//hila
        {
            m_model.AddNewPayment(userName, adId, paymentType, amount, wayOfPayment, lastDate);
        }

        public void addNewPartner(string userName)
        {
            m_model.addNewPartner(userName);
        }//adi
        public void addPartnerToAd(string userName)
        {
            m_view.addPartnerToAd(userName);
        }//adi

        public void createNewAd(AdCategory category, Dictionary<string, string> adData, Dictionary<string, ComboBox> comboBox, CheckBox cb_smoke, CheckBox cb_elvator, ListBox tb_partnersList, List<BitmapImage> imgList)
        {
            m_model.createNewAd(category, adData, comboBox, cb_smoke, cb_elvator, tb_partnersList, imgList);
        }//adi
    }
}
