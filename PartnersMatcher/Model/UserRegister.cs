using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PartnersMatcher.Model
{
    public static class UserRegister
    {        
        public static void createNewUser(ref OleDbConnection connection, Dictionary<string,string> userData , Dictionary<string, ComboBox> comboBox, CheckBox isSmoking)
        {
            verifyInformation(ref connection,userData["user name"], userData["password"], userData["verify password"]);

            if (userData["first name"] == "") //first name
                throw new Exception("אנא מלא את שמך הפרטי");
            validInput(userData["first name"].Replace(" ", string.Empty));
            if (userData["last name"] == "")//last name
                throw new Exception("אנא מלא את שם משפחתך");
            validInput(userData["last name"].Replace(" ", string.Empty));
            if (userData["city"] == "") // city
                throw new Exception("אנא מלא את עיר מגוריך");
            validInput(userData["city"].Replace(" ", string.Empty));
            if (userData["street"] == "") //street
                throw new Exception("אנא מלא את שדה הרחוב");
            validInput(userData["street"].Replace(" ", string.Empty));

            if (comboBox["gender"].SelectedItem == null) //gender
                throw new Exception("אנא בחר מין");
            if (comboBox["day"].SelectedItem == null || comboBox["month"].SelectedItem == null || comboBox["year"].SelectedItem == null) // birth date
                throw new Exception("אנא הזן תאריך לידה מלא");
            if (comboBox["martial status"].SelectedItem == null) //martial status
                throw new Exception("אנא בחר מצב משפחתי");
            if (comboBox["occupation"].SelectedItem == null) //occupation
                throw new Exception("אנא בחר עיסוק");
            if (comboBox["animals"].SelectedItem == null) //animals
                throw new Exception("אנא בחר אופציה אחת משדה בעל חיים");

            verifyAndSendMail(ref connection, userData ["mail"]);
            insertData(ref connection,userData,comboBox,isSmoking);
        }
        private static void verifyInformation(ref OleDbConnection connection, string userName, string password, string verPassword)
        {
            //verify user Name
            if (userName == "")
                throw new Exception("אנא מלא את שם המשתמש");
            if (isRecordExist(ref connection, "userName", userName))
                throw new Exception("שם המשתמש שבחרת כבר קיים במערכת, אנא בחר שם משתמש חדש");
            //verify password
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(verPassword))
                throw new Exception("אנא מלא את שדה הסיסמה ווידוא הסיסמה");
            if (password != verPassword)
                throw new Exception("שדה הסיסמה ושדה ווידוא הסיסמה לא תואמים");
            if (Regex.Matches(password, @"[a-zA-z]").Count == 0 || Regex.Matches(password, @"[0-9]").Count == 0)
                throw new Exception("הסיסמה חייבת לכלול אותיות בשפה אנגלית ומספרים");
        }
        private static bool isRecordExist(ref OleDbConnection connection, string fieldName, string inputString)
        {
           
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader reader = null;
            connection.Open();
            cmd = connection.CreateCommand();
            cmd.CommandText = "select " + fieldName + " from Users Where " + fieldName + " = " + "'" + inputString + "'";

            reader = cmd.ExecuteReader();
            reader.Read();
            if (!reader.HasRows)
            {
                connection.Close();
                return false;
            }
            connection.Close();
            return true;
        }
        private static void validInput(string str)
        {
            if (Regex.Matches(str, @"[0-9א-ת]").Count != str.Length)
                throw new Exception("אנא מלא את השדות האישיים בשפה העברית בלבד");
        }
        private static void insertData(ref OleDbConnection connection, Dictionary<string, string> userData, Dictionary<string, ComboBox> comboBox , CheckBox smoking)
        {          
            connection.Open();
            string isSmoke = "לא";
            if (smoking.IsChecked == true)
                isSmoke = "כן";
            string date = comboBox["day"].SelectedItem.ToString() + "/" + comboBox["month"].SelectedItem.ToString() + "/" + comboBox["year"].SelectedItem.ToString();

            string strSql = "INSERT INTO Users([userName],[password],[fname],[lname],[gender],[mailAddress],[city],[street],[birthDate],[martialStatus],[profession],[smoke],[animal],[generalDiscription])values(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
            using (OleDbCommand cmd2 = new OleDbCommand(strSql, connection))
            {
                cmd2.CommandType = CommandType.Text;
                cmd2.Parameters.AddWithValue("[userName]", userData["user name"]);
                cmd2.Parameters.AddWithValue("[password]", userData["password"]);
                cmd2.Parameters.AddWithValue("[fname]", userData["first name"]);
                cmd2.Parameters.AddWithValue("[lname]", userData["last name"]);
                cmd2.Parameters.AddWithValue("[gender]", comboBox["gender"].SelectedItem.ToString());
                cmd2.Parameters.AddWithValue("[mailAddress]", userData["mail"]);
                cmd2.Parameters.AddWithValue("[city]", userData["city"]);
                cmd2.Parameters.AddWithValue("[street]", userData["street"]);
                cmd2.Parameters.AddWithValue("[birthDate]", date);
                cmd2.Parameters.AddWithValue("[martialStatus]", comboBox["martial status"].SelectedItem.ToString());
                cmd2.Parameters.AddWithValue("[profession]", comboBox["occupation"].SelectedItem.ToString());
                cmd2.Parameters.AddWithValue("[smoke]", isSmoke);
                cmd2.Parameters.AddWithValue("[animal]", comboBox["animals"].SelectedItem.ToString());
                cmd2.Parameters.AddWithValue("[generalDiscription]", userData["discription"]);
                cmd2.ExecuteNonQuery();
            }
            connection.Close();
        }
        private static void verifyAndSendMail(ref OleDbConnection connection, string mail)
        {
            if (mail == "")
                throw new Exception("אנא מלא את כתובת הדואר האלקטרוני");
            if (isRecordExist(ref connection, "mailAddress", mail))
                throw new Exception("כתובת הדואר האלקטרוני שבחרת כבר קיימת במערכת, אנא בחר כתובת אחרת");

            //extract mail properties          
            string from1 = "partnermatcherltd@gmail.com";
            MailMessage message = new MailMessage();

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("partnermatcherltd@gmail.com", "rmharmha");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            message.From = new MailAddress(from1, "PartnersMatcher");
            message.To.Add(new MailAddress(mail));
            message.Subject = "ברוכים הבאים ל-Partners Mathcer";
            message.Body = string.Format("אנו מודים לך על הרשמתך לאתר, בהצלחה במציאת השותף האולטימטיבי");
            try
            {
                client.Send(message);
            }
            catch (Exception)
            {
                throw new Exception("כתובת המייל שהוזנה שגויה");
            }
        }
    }
}
