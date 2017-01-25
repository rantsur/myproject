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
    public static class NewAdRomanticDate
    {
        public static void createNewAd(ref OleDbConnection connection, Dictionary<string, string> adData, Dictionary<string, ComboBox> comboBox)
        {
            if (adData["Cost"] == "") //cost
                throw new Exception("אנא מלא את מחיר הפגישה");
            int num;
            if (!int.TryParse(adData["Cost"], out num)) //cost is integer
                throw new Exception("שדה מחיר השכירות חייב לכלול ערך מספרי");
            if (adData["Partners Number"] == "")//number of Partners
                throw new Exception("אנא מלא את מספר השותפים בדירה");
            if (!int.TryParse(adData["Partners Number"], out num))//number of Partners
                throw new Exception("שדה מספר השותפים חייב לכלול ערך מספרי");
            if (adData["place"] == "") // city
                throw new Exception("אנא מלא את המיקום הרצוי לפגישה");
            string new_str = adData["place"].Replace(" ", string.Empty);
            validInput(new_str.Replace("\"", string.Empty));
            if (adData["Date"] == "")//date
                throw new Exception("אנא הזן תאריך לפגישה");
            if (comboBox["intresrIn"].SelectedItem == null) //intrestedIn
                throw new Exception("אנא בחר במי הינך מעוניין");

            insertData(ref connection, adData, comboBox);
        }
        private static void validInput(string str)
        {
            if (Regex.Matches(str, @"[0-9א-ת]").Count != str.Length)
                throw new Exception("אנא מלא את השדות האישיים בשפה העברית בלבד");
        }
        private static void insertData(ref OleDbConnection connection, Dictionary<string, string> adData, Dictionary<string, ComboBox> comboBox)
        {
            connection.Open();
            // add the ad data
            string strSql = "INSERT INTO romantic_date([מעוניין ב],[תיאור כללי],[מספר שותפים נדרשים],[מחיר],[תאריך],[מיקום],[תאריך פרסום המודעה],[שם משתמש],[מזהה מודעה])values(?,?,?,?,?,?,?,?,?)";
            using (OleDbCommand cmd2 = new OleDbCommand(strSql, connection))
            {
                cmd2.CommandType = CommandType.Text;
                cmd2.Parameters.AddWithValue("[מעוניין ב]", comboBox["intresrIn"].SelectedItem.ToString());
                cmd2.Parameters.AddWithValue("[תיאור כללי]", adData["discription"]);
                cmd2.Parameters.AddWithValue("[מספר שותפים נדרשים]", adData["Partners Number"]);
                cmd2.Parameters.AddWithValue("[מחיר]", adData["Cost"]);
                cmd2.Parameters.AddWithValue("[תאריך]", adData["Date"]);
                cmd2.Parameters.AddWithValue("[מיקום]", adData["place"]);
                cmd2.Parameters.AddWithValue("[תאריך פרסום המודעה]", DateTime.Now.ToString());
                cmd2.Parameters.AddWithValue("[שם משתמש]", adData["user name"]);
                cmd2.Parameters.AddWithValue("[מזהה מודעה]", adData["Ad Id"]);
                cmd2.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

}
