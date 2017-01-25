using PartnersMatcher.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PartnersMatcher.Controller
{
    public interface IController
    {
        IModel Model
        {
            set;
        }
        IView View
        {
            set;
        }
        String UserName
        {
            set;
            get;
        }
        void connect(string password, string userName);
        void message(string msg);
        void privateZone();
        void createNewUser(Dictionary<string, string> userData, Dictionary<string, ComboBox> comboBox, CheckBox isSmoking);
        void displayCategoryList(List<string> categories,CurrentWindow window);
        void updateCategoryList(CurrentWindow window);
        void updateCityList(string search_category);
        void displayCityList(List<string> cityList);
        void search(string search_category, string search_city);
        void sendRequest(int m_adId, string m_userName, string content);
        void displaySearchResult(List<List<string>> reader);
        void openRequest(int adID, string userName);
        void openRequestWindow(int adID, string userName);//mor
        void closeRequestWindow();//mor
        void requestMangmentWindowLists(string userName);//mor
        void OpenRequestManagementWindow(Tuple<List<string>, List<string>> info);//mor
        void approveRequest(int adID, string userName, string partnerName);//mor
        void rejectRequest(int adID, string userName, string partnerName);//mor
        void updateRequestList(Tuple<List<string>, List<string>> tuple);//mor
        void DisplayUserAdds(List<string> userAdds);//hila
        void ShowUserAds(string userName);//hila
        void AddNewPayment(string userName, string adId, string paymentType, string amount, string wayOfPayment, string lastDate);//hila
        void addNewPartner(string userName);//adi
        void addPartnerToAd(string userName);//adi
        void createNewAd(AdCategory category, Dictionary<string, string> adData, Dictionary<string, ComboBox> comboBox, CheckBox cb_smoke, CheckBox cb_elvator, ListBox tb_partnersList, List<BitmapImage> imgList);//adi
    }
}
