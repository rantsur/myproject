using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace PartnersMatcher
{
    public interface IView
    {
        void message(string msg);
        void displayCategoryList(List<string> categoriesList, CurrentWindow window);
        void displayCityList(List<string> categoriesList);
        void displaySearchResult(List<List<string>> reader);
        void openRequest(int adID, string userName);
        void privateZone();
        void closeRequestWindow();//mor
        void OpenRequestManagementWindow(Tuple<List<string>, List<string>> info);//mor
        void updateRequestList(Tuple<List<string>, List<string>> reqInfo);//mor
        void displayUserAds(List<string> ads);//hila
        void addPartnerToAd(string userName);//adi


    }
}