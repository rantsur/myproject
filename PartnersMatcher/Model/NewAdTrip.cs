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
    public static class NewAdTrip
    {
        public static void createNewAd(ref OleDbConnection connection, Dictionary<string, string> adData, Dictionary<string, ComboBox> comboBox)
        {
            if (adData["Cost"] == "") //cost
                throw new Exception("אנא מלא את המחיר");
            int num;
            if (!int.TryParse(adData["Cost"], out num)) //cost is integer
                throw new Exception("שדה מחיר חייב לכלול ערך מספרי");
            if (adData["Partners Number"] == "")//number of Partners
                throw new Exception("אנא מלא את מספר השותפים");
            if (!int.TryParse(adData["Partners Number"], out num))//number of Partners
                throw new Exception("שדה מספר השותפים חייב לכלול ערך מספרי");
            if (adData["place"] == "") // city
                throw new Exception("אנא מלא את המיקום");
            string new_str = adData["place"].Replace(" ", string.Empty);
            validInput(new_str.Replace("\"", string.Empty));
            if (adData["startDate"] == "")//start date
                throw new Exception(" אנא הזן תאריך התחלה");
            if (adData["finishDate"] == "")//finish date
                throw new Exception(" אנא הזן תאריך סיום");
            if (comboBox["difficultyLevel"].SelectedItem == null) //intrestedIn
                throw new Exception("אנא בחר רמת קושי");

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
            string strSql = "INSERT INTO trip([רמת קושי],[תאריך סיום],[תיאור כללי],[מספר שותפים נדרשים],[מחיר],[תאריך התחלה],[מיקום],[תאריך פרסום המודעה],[שם משתמש],[מזהה מודעה])values(?,?,?,?,?,?,?,?,?,?)";
            using (OleDbCommand cmd2 = new OleDbCommand(strSql, connection))
            {
                cmd2.CommandType = CommandType.Text;
                cmd2.Parameters.AddWithValue("[רמת קושי]", comboBox["difficultyLevel"].SelectedItem.ToString());
                cmd2.Parameters.AddWithValue("[תאריך סיום]", adData["finishDate"]);
                cmd2.Parameters.AddWithValue("[תיאור כללי]", adData["discription"]);
                cmd2.Parameters.AddWithValue("[מספר שותפים נדרשים]", adData["Partners Number"]);
                cmd2.Parameters.AddWithValue("[מחיר]", adData["Cost"]);
                cmd2.Parameters.AddWithValue("[תאריך התחלה]", adData["startDate"]);
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
