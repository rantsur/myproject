using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PartnersMatcher.Model
{
    public static class NewAdAccommodation
    {
        public static void createNewAd(ref OleDbConnection connection, Dictionary<string, string> adData, Dictionary<string, ComboBox> comboBox, CheckBox isSmoking, CheckBox isElavator)
        {
            if (adData["Cost"] == "") //cost
                throw new Exception("אנא מלא את מחיר השכירות");
            int num;
            if (!int.TryParse(adData["Cost"], out num)) //cost is integer
                throw new Exception("שדה מחיר השכירות חייב לכלול ערך מספרי");
            if (adData["Rooms Number"] == "")//number of Rooms
                throw new Exception("אנא מלא את מספר החדרים בדירה");
            if (!int.TryParse(adData["Rooms Number"], out num) && num > 0 && num < 10)//number of Partners
                throw new Exception("שדה מספר החדרים חייב לכלול ערך מספרי בין 0 ל10");
            if (adData["Partners Number"] == "")//number of Partners
                throw new Exception("אנא מלא את מספר השותפים בדירה");
            if (!int.TryParse(adData["Partners Number"], out num) && num > 0 && num < 10)//number of Partners
                throw new Exception("שדה מספר השותפים חייב לכלול ערך מספרי בין 0 ל10");
            if (adData["city"] == "") // city
                throw new Exception("אנא מלא את עיר הדירה");
            string new_str = adData["city"].Replace(" ", string.Empty);
            validInput(new_str.Replace("\"", string.Empty));
            if (adData["street"] == "") //street
                throw new Exception("אנא מלא את שדה הרחוב");
            new_str = adData["street"].Replace(" ", string.Empty);
            validInput(new_str.Replace("\"", string.Empty));
            if (adData["size"] == "")//department size
                throw new Exception("אנא מלא את גודל הדירה");
            if (!int.TryParse(adData["size"], out num) && num > 15 && num < 250)//number of Partners
                throw new Exception("שדה מספר השותפים חייב לכלול ערך מספרי בין 15 ל250");
            if (adData["Date"] == "")//date
                throw new Exception("אנא הזן תאריך כניסה לדירה מלא");
            if (comboBox["furniture"].SelectedItem == null) //furniture status
                throw new Exception("אנא בחר את מצב ריהוט");
            if (comboBox["condition"].SelectedItem == null) //condition
                throw new Exception("אנא בחר את מצב הדירה");

            insertData(ref connection, adData, comboBox, isSmoking, isElavator);
        }
        private static void validInput(string str)
        {
            if (Regex.Matches(str, @"[0-9א-ת]").Count != str.Length)
                throw new Exception("אנא מלא את השדות האישיים בשפה העברית בלבד");
        }
        private static void insertData(ref OleDbConnection connection, Dictionary<string, string> adData, Dictionary<string, ComboBox> comboBox, CheckBox smoking, CheckBox elavator)
        {
            connection.Open();
            string isSmoke = "לא";
            if (smoking.IsChecked == true)
                isSmoke = "כן";
            string isElvator = "לא";
            if (elavator.IsChecked == true)
                isElvator = "כן";

            // add the ad data


            string strSql = "INSERT INTO accommodation([מצב הדירה],[ריהוט],[מעשנים],[מעלית],[מספר חדרים],[גודל הדירה],[תיאור כללי],[מספר שותפים נדרשים],[מחיר],[תאריך],[רחוב],[מיקום],[תאריך פרסום המודעה],[שם משתמש],[מזהה מודעה])values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
            using (OleDbCommand cmd2 = new OleDbCommand(strSql, connection))
            {
                cmd2.CommandType = CommandType.Text;

                cmd2.Parameters.AddWithValue("[מצב הדירה]", comboBox["condition"].SelectedItem.ToString());
                cmd2.Parameters.AddWithValue("[ריהוט]", comboBox["furniture"].SelectedItem.ToString());
                cmd2.Parameters.AddWithValue("[מעשנים]", isSmoke);
                cmd2.Parameters.AddWithValue("[מעלית]", isElvator);
                cmd2.Parameters.AddWithValue("[מספר חדרים]", adData["Rooms Number"]);
                cmd2.Parameters.AddWithValue("[גודל הדירה]", adData["size"]);
                cmd2.Parameters.AddWithValue("[תיאור כללי]", adData["discription"]);
                cmd2.Parameters.AddWithValue("[מספר שותפים נדרשים]", adData["Partners Number"]);
                cmd2.Parameters.AddWithValue("[מחיר]", adData["Cost"]);
                cmd2.Parameters.AddWithValue("[תאריך]", adData["Date"]);
                cmd2.Parameters.AddWithValue("[רחוב]", adData["street"]);
                cmd2.Parameters.AddWithValue("[מיקום]", adData["city"]);
                cmd2.Parameters.AddWithValue("[תאריך פרסום המודעה]", DateTime.Now.ToString());
                cmd2.Parameters.AddWithValue("[שם משתמש]", adData["user name"]);
                cmd2.Parameters.AddWithValue("[מזהה מודעה]", adData["Ad Id"]);
                cmd2.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
}
