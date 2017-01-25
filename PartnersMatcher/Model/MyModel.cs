using PartnersMatcher.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PartnersMatcher.Model
{
    public class MyModel : IModel
    {
        private IController m_controller;
        OleDbConnection m_connection;
        public MyModel(IController controller)
        {
            m_controller = controller;
            openConnectionToDataBase();
        }
        public void connect(string password, string userName)
        {
            if (userExist(userName))
            {
                string pass = password;
                OleDbCommand cmd = new OleDbCommand("select * from Users Where [userName] = " + "'" + userName + "'", m_connection);
                OleDbDataReader reader = null;
                m_connection.Open();
                reader = cmd.ExecuteReader();
                reader.Read();

                if (reader["password"].ToString() == pass)
                {
                    m_connection.Close();
                    m_controller.UserName = userName;
                    m_controller.message(("ברוך שובך למערכת " + userName));
                    m_controller.privateZone();
                }
                else
                {
                    m_connection.Close();
                    m_controller.message("סיסמה לא נכונה");
                }
            }
            else
            {
                m_connection.Close();
                m_controller.message("משתמש לא רשום במערכת, יש לבצע רישום טרם ההתחברות");
            }
        }
        private bool userExist(string userName)
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader reader = null;
            m_connection.Open();
            cmd = m_connection.CreateCommand();
            cmd.CommandText = "select [userName] from Users Where [userName] = " + "'" + userName + "'";

            reader = cmd.ExecuteReader();
            reader.Read();
            if (!reader.HasRows)
            {
                m_connection.Close();
                return false;
            }
            m_connection.Close();
            return true;
        }
        private void openConnectionToDataBase()
        {
            try
            {
                m_connection = new OleDbConnection();
                m_connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database.accdb;";
            }
            catch (Exception exp)
            {
                m_controller.message(exp.Message);
            }
        }
        public void createNewUser(Dictionary<string, string> userData, Dictionary<string, ComboBox> comboBox, CheckBox isSmoking)
        {
            try
            {
                UserRegister.createNewUser(ref m_connection, userData, comboBox, isSmoking);
                m_controller.message("הרשמתך למערכת בוצעה בהצלחה");
            }
            catch (Exception exp)
            {
                m_controller.message(exp.Message);
                if (m_connection.State == System.Data.ConnectionState.Open)
                    m_connection.Close();
            }
        }
        public void updateCategoryList(CurrentWindow window)
        {
            m_connection.Open();
            OleDbDataReader reader = null;
            OleDbCommand cmd = new OleDbCommand("select * from categories", m_connection);
            reader = cmd.ExecuteReader();

            List<string> categories = new List<string>();
            string category_name;
            while (reader.Read())
            {
                category_name = (reader["category_name"].ToString());
                categories.Add(category_name);
            }
            m_connection.Close();
            m_controller.displayCategoryList(categories, window);
        }
        public void updateCityList(string search_category)
        {
            m_controller.displayCityList(SearchAdd.updateCityList(ref m_connection, search_category));
        }
        public void search(string search_category, string search_city)
        {
            m_controller.displaySearchResult(SearchAdd.search(ref m_connection, search_category, search_city));
        }
        public bool reqestExist(int adID, string userName)
        {
            openConnectionToDataBase();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader reader = null;
            m_connection.Open();
            cmd = m_connection.CreateCommand();
            cmd.CommandText = "select [adID] from requests Where [adID] = " + "'" + adID + "' AND [userName] = " + "'" + userName + "'";

            reader = cmd.ExecuteReader();
            reader.Read();
            if (!reader.HasRows)
            {
                m_connection.Close();
                return false;
            }
            m_connection.Close();
            return true;
        }//mor
        public void openRequest(int adID, string userName)//mor
        {
            string messege = "";
            if (!userIsAlreadyPartner(adID, userName))
            {
                if (!reqestExist(adID, userName))
                    m_controller.openRequest(adID, userName);
                else
                    messege = "נמצא במערכת כי כבר הוגשה בקשת הצטרפות על ידך למודעה זו, לא ניתן להגיש בקשה זו בשנית";
            }
            else
                messege = "נמצא במערכת כי כבר הינך שותף במודעה זו, לכן לא ניתן להגיש בקשה";

            if (messege != "")
            {
                if (m_connection.State == System.Data.ConnectionState.Open)
                    m_connection.Close();
                m_controller.message(messege);
            }
        }
        private bool userIsAlreadyPartner(int adID, string userName)//mor
        {
            openConnectionToDataBase();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader reader = null;
            m_connection.Open();
            cmd = m_connection.CreateCommand();
            cmd.CommandText = "select [adID] from partnersForAd Where [adID] = " + "'" + adID + "' AND [userName] = " + "'" + userName + "'";

            reader = cmd.ExecuteReader();
            reader.Read();
            if (!reader.HasRows)
            {
                m_connection.Close();
                return false;
            }
            m_connection.Close();
            return true;
        }
        public void sendRequest(int adId, string userName, string content)//mor
        {
            try
            {
                requests.sendRequests(ref m_connection, adId, userName, content);
                m_controller.message("הבקשה הוגשה בהצלחה");
                m_controller.closeRequestWindow();
            }
            catch (Exception e)
            {
                m_controller.message(e.Message);
                if (m_connection.State == System.Data.ConnectionState.Open)
                    m_connection.Close();

            }
        }
        public void requestManagemntWindowLists(string userName)//mor
        {
            try
            {
                Tuple<List<string>, List<string>> info = requests.getRequestsInfo(ref m_connection, userName);
                m_controller.OpenRequestManagementWindow(info);
            }
            catch (Exception e)
            {
                if (m_connection.State == System.Data.ConnectionState.Open)
                    m_connection.Close();
            }
        }
        public void approveRequest(int adID, string userName, string partnerName)//mor
        {
            try
            {
                requests.aproveRequest(ref m_connection, adID, userName, partnerName);
                m_controller.message("התהליך בוצע בהצלחה");
                m_controller.updateRequestList(requests.getRequestsInfo(ref m_connection, m_controller.UserName));
            }
            catch (Exception e)
            {
                m_controller.message(e.Message);
                if (m_connection.State == System.Data.ConnectionState.Open)
                    m_connection.Close();
            }
        }
        public void rejectRequest(int adID, string userName, string partnerName)//mor
        {
            try
            {
                requests.rejectRequest(ref m_connection, adID, userName, partnerName);
                m_controller.message("התהליך בוצע בהצלחה");
                m_controller.updateRequestList(requests.getRequestsInfo(ref m_connection, m_controller.UserName));
            }
            catch (Exception e)
            {
                m_controller.message(e.Message);
                if (m_connection.State == System.Data.ConnectionState.Open)
                    m_connection.Close();
            }
        }
        public void ShowUserAds(string userName)
        {
            string m_userName = userName;

            openConnectionToDataBase();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader reader = null;
            m_connection.Open();
            cmd = m_connection.CreateCommand();
            cmd.CommandText = "select [adID] from partnersForAd Where [userName] = " + "'" + userName + "'" + " AND type = 'm'";

            reader = cmd.ExecuteReader();
            List<string> addsToOwner = new List<string>();
            while (reader.Read())
            {
                string value = (reader["adID"].ToString());
                addsToOwner.Add(value);
            }
            m_connection.Close();
            m_controller.DisplayUserAdds(addsToOwner);

        }//hila
        public void AddNewPayment(string userName, string adId, string paymentType, string amount, string wayOfPayment, string lastDate)
        {
            try
            {
                if (isPaymentExsist(adId, paymentType, lastDate))
                {
                    m_controller.message("!תשלום כבר קיים למודעה זו ולכן לא יתווסף");

                    return;
                }
                m_connection.Open();
                string strSql = "INSERT INTO payment ([userName],[adId],[type],[amount],[way],[lastDate])values(?,?,?,?,?,?)";
                using (OleDbCommand cmd2 = new OleDbCommand(strSql, m_connection))
                {
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Parameters.AddWithValue("[userName]", userName);
                    cmd2.Parameters.AddWithValue("[adId]", adId);
                    cmd2.Parameters.AddWithValue("[type]", paymentType);
                    cmd2.Parameters.AddWithValue("[amount]", amount);
                    cmd2.Parameters.AddWithValue("[way]", wayOfPayment);
                    cmd2.Parameters.AddWithValue("[lastDate]", lastDate);
                    cmd2.ExecuteNonQuery();
                }
                m_connection.Close();
                m_controller.message("התשלום למודעה" + " " + adId + " " + "עודכן בהצלחה");
            }
            catch (Exception exp)
            {
                m_controller.message(exp.Message);
                if (m_connection.State == System.Data.ConnectionState.Open)
                    m_connection.Close();
            }
        }//hila
        public bool isPaymentExsist(string adId, string paymentType, string lastDate)
        {
            openConnectionToDataBase();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader reader = null;
            m_connection.Open();
            cmd = m_connection.CreateCommand();
            cmd.CommandText = "select [adId] from payment Where [adId] = " + "'" + adId + "' AND [type] = " + "'" + paymentType + "' AND [lastDate] = " + "'" + lastDate + "'";

            reader = cmd.ExecuteReader();
            reader.Read();
            if (!reader.HasRows)
            {
                m_connection.Close();
                return false;
            }
            m_connection.Close();
            return true;
        }//hila
        public void addNewPartner(string userName)
        {
            if (userName.Equals(m_controller.UserName))
            {
                m_controller.message("המשתמש מוגדר כבעל המודעה");
            }
            else if (userExist(userName))
            {
                m_controller.addPartnerToAd(userName);
            }
            else
            {
                m_controller.message("השותף אינו רשום במערכת");
            }
        } // adi



        public void createNewAd(AdCategory category, Dictionary<string, string> adData, Dictionary<string, ComboBox> comboBox, CheckBox cb_smoke, CheckBox cb_elvator, ListBox tb_partnersList, List<BitmapImage> imgList)
        {
            try
            {
                switch (category)
                {
                    case AdCategory.accommodation:
                        NewAdAccommodation.createNewAd(ref m_connection, adData, comboBox, cb_smoke, cb_elvator);
                        break;
                    case AdCategory.romantic_Date:
                        NewAdRomanticDate.createNewAd(ref m_connection, adData, comboBox);
                        break;
                    case AdCategory.sport:
                        NewAdSport.createNewAd(ref m_connection, adData, comboBox);
                        break;
                    case AdCategory.trip:
                        NewAdTrip.createNewAd(ref m_connection, adData, comboBox);
                        break;

                }
                AddPhotosToAd(imgList);
                AddPartnersToAd(tb_partnersList, adData["user name"], adData["Ad Id"]);
                View.MainWindow.IDAd++;
                m_controller.message("המודעה נוספה בהצלחה");
            }
            catch (Exception exp)
            {
                m_controller.message(exp.Message);
                if (m_connection.State == System.Data.ConnectionState.Open)
                    m_connection.Close();
            }
        }//adi

        private void AddPartnersToAd(ListBox tb_partnersList, string userName, string AdID)
        {
            m_connection.Open();
            //add the owner of the ad
            string strSql = "INSERT INTO partnersForAd([adID],[userName],[type])values(?,?,?)";
            using (OleDbCommand cmd2 = new OleDbCommand(strSql, m_connection))
            {
                cmd2.CommandType = CommandType.Text;
                cmd2.Parameters.AddWithValue("[adID]", AdID);
                cmd2.Parameters.AddWithValue("[userName]", userName);
                cmd2.Parameters.AddWithValue("[type]", "m");
                cmd2.ExecuteNonQuery();
            }
            // add the partners of the ad
            foreach (string user in tb_partnersList.Items)
            {
                strSql = "INSERT INTO partnersForAd([adID],[userName],[type])values(?,?,?)";
                using (OleDbCommand cmd2 = new OleDbCommand(strSql, m_connection))
                {
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Parameters.AddWithValue("[adID]", AdID);
                    cmd2.Parameters.AddWithValue("[userName]", user);
                    cmd2.Parameters.AddWithValue("[type]", "p");
                    cmd2.ExecuteNonQuery();
                }
            }
            m_connection.Close();
        }  // adi


        public void AddPhotosToAd(List<BitmapImage> imgList)
        {
            if (imgList.Count == 0)
                return;
            DirectoryInfo di = Directory.CreateDirectory(View.MainWindow.IDAd.ToString());
            int index = 1;
            foreach (BitmapImage img in imgList)
            {
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                Guid photoID = System.Guid.NewGuid();
                String photolocation = View.MainWindow.IDAd.ToString() + "/ " + Convert.ToString(index) + ".jpg";  //file name 

                encoder.Frames.Add(BitmapFrame.Create(img));

                using (var filestream = new FileStream(photolocation, FileMode.Create))
                    encoder.Save(filestream);
                index++;
            }
        } // adi

    }
}
