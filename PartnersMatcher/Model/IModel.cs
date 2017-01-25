using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PartnersMatcher.Model
{
    public interface IModel
    {
        void connect(string password, string userName);
        void createNewUser(Dictionary<string, string> userData, Dictionary<string, ComboBox> comboBox, CheckBox isSmoking);
        void updateCategoryList(CurrentWindow window);
        void updateCityList(string search_category);
        void search(string search_category, string search_city);
        void openRequest(int adID, string userName);//mor
        void sendRequest(int m_adId, string m_userName, string content);//mor
        void requestManagemntWindowLists(string userName);//mor
        void approveRequest(int adID, string userName, string partnerName);//mor
        void rejectRequest(int adID, string userName, string partnerName);//mor
        void ShowUserAds(string userName);//hila
        void AddNewPayment(string userName, string adId, string paymentType, string amount, string wayOfPayment, string lastDate);//hila
        bool isPaymentExsist(string adId, string paymentType, string lastDate);//hila
        void addNewPartner(string userName);//adi
        void createNewAd(AdCategory category, Dictionary<string, string> adData, Dictionary<string, ComboBox> comboBox, CheckBox cb_smoke, CheckBox cb_elvator, ListBox tb_partnersList, List<BitmapImage> imgList);//adi

    }
}
