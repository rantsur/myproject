using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnersMatcher.Model
{
    class requests//mor
    {
        public static void sendRequests(ref OleDbConnection connection, int adID, string userName, string content)
        {

            int numberOfPartners = insertReqestRecordToPartners(ref connection, adID, userName);
            string status = "ממתין לאישור שותפים";
            if (numberOfPartners == 0)
            {
                insertReqestRecordToManager(ref connection, adID, userName);
                connection.Close();
                status = "ממתין לאישור מנהל";
            }
            insertReqest(ref connection, adID, userName, content, numberOfPartners, status);


        }
        private static void insertReqestRecordToManager(ref OleDbConnection connection, int adID, string userName)
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader reader = null;
            connection.Open();
            cmd = connection.CreateCommand();
            cmd.CommandText = "select * from partnersForAd Where [adID] = " + "'" + adID + "' AND [type]='m'";

            reader = cmd.ExecuteReader();
            reader.Read();
            string strSql = "INSERT INTO requestManagment([adID],[userName],[partnerName],[status],[type])values(?,?,?,?,?)";
            using (OleDbCommand cmd2 = new OleDbCommand(strSql, connection))
            {
                cmd2.CommandType = CommandType.Text;
                cmd2.Parameters.AddWithValue("[adID]", adID);
                cmd2.Parameters.AddWithValue("[userName]", userName);
                cmd2.Parameters.AddWithValue("[partnerName]", reader.GetValue(1));
                cmd2.Parameters.AddWithValue("[status]", "ממתין לאישור");
                cmd2.Parameters.AddWithValue("[type]", "m");
                cmd2.ExecuteNonQuery();
            }
        }
        private static void insertReqest(ref OleDbConnection connection, int adID, string userName, string content, int numberOfPartners, string status)
        {
            connection.Open();

            string strSql = "INSERT INTO requests([adID],[userName],[content],[status],[counter])values(?,?,?,?,?)";
            using (OleDbCommand cmd2 = new OleDbCommand(strSql, connection))
            {
                cmd2.CommandType = CommandType.Text;
                cmd2.Parameters.AddWithValue("[adID]", adID);
                cmd2.Parameters.AddWithValue("[userName]", userName);
                cmd2.Parameters.AddWithValue("[content]", content);
                cmd2.Parameters.AddWithValue("[status]", status);
                cmd2.Parameters.AddWithValue("[counter]", numberOfPartners);

                cmd2.ExecuteNonQuery();
            }
            connection.Close();
        }
        private static int insertReqestRecordToPartners(ref OleDbConnection connection, int adID, string userName)
        {
            int counter = 0;
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader reader = null;
            connection.Open();
            cmd = connection.CreateCommand();
            cmd.CommandText = "select * from partnersForAd Where [adID] = " + "'" + adID + "'";

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if ((string)reader.GetValue(2) != "m")
                {
                    string strSql = "INSERT INTO requestManagment([adID],[userName],[partnerName],[status],[type])values(?,?,?,?,?)";
                    using (OleDbCommand cmd2 = new OleDbCommand(strSql, connection))
                    {
                        cmd2.CommandType = CommandType.Text;
                        cmd2.Parameters.AddWithValue("[adID]", adID);
                        cmd2.Parameters.AddWithValue("[userName]", userName);
                        cmd2.Parameters.AddWithValue("[partnerName]", reader.GetValue(1));
                        cmd2.Parameters.AddWithValue("[status]", "ממתין לאישור");
                        cmd2.Parameters.AddWithValue("[type]", reader.GetValue(2));
                        cmd2.ExecuteNonQuery();
                    }
                    counter++;
                }
            }
            connection.Close();

            return counter;
        }
        public static Tuple<List<string>, List<string>> getRequestsInfo(ref OleDbConnection connection, string userName)
        {
            List<string> myRequestList = new List<string>();
            List<string> waitToAprovelList = new List<string>();

            string headline = "מזהה מודעה;מגיש הבקשה;תוכן"; // add headline
            waitToAprovelList.Add(headline);

            headline = "מזהה מודעה;סטטוס"; // add headline
            myRequestList.Add(headline);


            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader reader = null;
            connection.Open();
            cmd = connection.CreateCommand();
            cmd.CommandText = "select * from requests Where [userName] = " + "'" + userName + "'";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string s = reader.GetValue(0) + ";" + reader.GetValue(3);
                myRequestList.Add(s);
            }

            OleDbCommand cmd1 = new OleDbCommand();
            reader = null;
            cmd1 = connection.CreateCommand();
            cmd1.CommandText = "select * from requestManagment Where [partnerName] = " + "'" + userName + "' AND [status]='ממתין לאישור'";
            reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                string s = reader.GetValue(0) + ";" + reader.GetValue(1);
                OleDbDataReader reader1 = null;
                OleDbCommand cmd2 = new OleDbCommand();
                reader1 = null;
                cmd2 = connection.CreateCommand();
                cmd2.CommandText = "select * from requests Where [adID] = " + "'" + reader.GetValue(0) + "' AND [userName]='" + reader.GetValue(1) + "'";
                reader1 = cmd2.ExecuteReader();
                reader1.Read();
                s += ";" + reader1.GetValue(2);
                waitToAprovelList.Add(s);
            }
            connection.Close();
            return new Tuple<List<string>, List<string>>(waitToAprovelList, myRequestList);
        }
        public static void aproveRequest(ref OleDbConnection connection, int adID, string userName, string partnerName)
        {
            OleDbDataReader reader = null;
            OleDbCommand cmd1 = new OleDbCommand();
            connection.Open();
            cmd1 = connection.CreateCommand();
            cmd1.CommandText = "select * from requestManagment Where [partnerName] = " + "'" + partnerName + "' AND [userName]='" + userName + "' AND [adID]='" + adID + "'";
            reader = cmd1.ExecuteReader();
            reader.Read();

            OleDbDataReader reader1 = null;
            OleDbCommand cmd = new OleDbCommand();
            cmd = connection.CreateCommand();
            cmd.CommandText = "select * from requests Where [userName]='" + userName + "' AND [adID]='" + adID + "'";
            reader1 = cmd.ExecuteReader();
            reader1.Read();
            int counter = 0;
            counter = int.Parse((string)reader1.GetValue(4));
            string type = (string)reader.GetValue(4);
            string status = "ממתין לאישור שותפים";
            if (type == "p")
            {
                //change record status at requestManagment
                OleDbCommand cmd2 = new OleDbCommand();
                cmd2= connection.CreateCommand(); ;
                cmd2.CommandText = "UPDATE requestManagment SET status = @stat WHERE [partnerName] = " + "'" + partnerName + "' AND [userName]='" + userName + "' AND [adID]='" + adID + "'";
                cmd2.Parameters.AddWithValue("@stat", "אושר");
                cmd2.ExecuteNonQuery();

                if ((counter - 1) == 0)//need to forward to manager aprov
                {
                    connection.Close();
                    insertReqestRecordToManager(ref connection, adID, userName);
                   // connection.Open();
                    status = "ממתין לאישור מנהל";
                }

                //change counter and status at requests
                OleDbCommand cmd3 = new OleDbCommand();
                cmd3 = connection.CreateCommand(); 
                cmd3.CommandText = "UPDATE requests SET [counter] = @count, [status]=@statu WHERE [userName]='" + userName + "' AND [adID]='" + adID + "'";
                cmd3.Parameters.AddWithValue("@count", (counter - 1)+"");
                cmd3.Parameters.AddWithValue("@statu", status);
                cmd3.ExecuteNonQuery();
            }
            else if (type == "m")
            {
                //change record status at requestManagment
                OleDbCommand cmd2 = new OleDbCommand();
                cmd2 = connection.CreateCommand(); ;
                cmd2.CommandText = "UPDATE requestManagment SET status = @stat WHERE [partnerName] = " + "'" + partnerName + "' AND [userName]='" + userName + "' AND [adID]='" + adID + "'";
                cmd2.Parameters.AddWithValue("@stat", "אושר");
                cmd2.ExecuteNonQuery();
                //change counter and status at requests
                OleDbCommand cmd3 = new OleDbCommand();
                cmd3 = connection.CreateCommand(); ;
                cmd3.CommandText = "UPDATE requests SET [counter] = @count, [status]=@statu WHERE [userName]='" + userName + "' AND [adID]='" + adID + "'";
                cmd3.Parameters.AddWithValue("@count", 0+"");
                cmd3.Parameters.AddWithValue("@statu", "הבקשה אושרה");
                cmd3.ExecuteNonQuery();
                //add the new partner
                string strSql = "INSERT INTO partnersForAd([adID],[userName],[type])values(?,?,?)";
                using (OleDbCommand cmd4 = new OleDbCommand(strSql, connection))
                {
                    cmd4.CommandType = CommandType.Text;
                    cmd4.Parameters.AddWithValue("[adID]", adID);
                    cmd4.Parameters.AddWithValue("[userName]", userName);
                    cmd4.Parameters.AddWithValue("[type]", "p");
                    cmd4.ExecuteNonQuery();
                }

                //update the add partner counter
                UpdateAdPartnerCounter(ref connection,adID);
            }
            connection.Close();
        }

        private static void UpdateAdPartnerCounter(ref OleDbConnection connection,int adID)
        {
            List<string> cat_list = new List<string>() { "trip","sport","romantic_date","accommodation" };
            foreach (string cat in cat_list)
            {
                OleDbCommand cmd5 = new OleDbCommand();
                OleDbDataReader reader3 = null;
                cmd5 = connection.CreateCommand();
                cmd5.CommandText = "select * from " + cat + " Where [מזהה מודעה] = " + "'" + adID + "'";
                reader3 = cmd5.ExecuteReader();
                reader3.Read();
                if(reader3.HasRows)
                {
                    int numberPartners = int.Parse(reader3["מספר שותפים נדרשים"].ToString());
                    OleDbCommand cmd2 = new OleDbCommand();
                    cmd2 = connection.CreateCommand(); ;
                    cmd2.CommandText = "UPDATE "+cat+ " SET [מספר שותפים נדרשים] = @number WHERE [מזהה מודעה] = " + "'" + adID + "'";
                    cmd2.Parameters.AddWithValue("@number", (numberPartners-1)+"");
                    cmd2.ExecuteNonQuery();
                    break;
                }
            }
        }

        public static void rejectRequest(ref OleDbConnection connection, int adID, string userName, string partnerName)
        {
            OleDbDataReader reader = null;
            OleDbCommand cmd1 = new OleDbCommand();
            connection.Open();
            cmd1 = connection.CreateCommand();
            cmd1.CommandText = "select * from requestManagment Where [partnerName] = " + "'" + partnerName + "' AND [userName]='" + userName + "' AND [adID]='" + adID + "'";
            reader = cmd1.ExecuteReader();
            reader.Read();
            string type = (string)reader.GetValue(4);

            OleDbCommand cmd2 = new OleDbCommand();
            cmd2 = connection.CreateCommand(); ;
            cmd2.CommandText = "UPDATE requestManagment SET status = @stat WHERE [userName]='" + userName + "' AND [adID]='" + adID + "'";
            cmd2.Parameters.AddWithValue("@stat", "נדחה");
            cmd2.ExecuteNonQuery();

            OleDbCommand cmd3 = new OleDbCommand();
            cmd3 = connection.CreateCommand(); ;
            cmd3.CommandText = "UPDATE requests SET [counter] = @count, [status]=@statu WHERE [userName]='" + userName + "' AND [adID]='" + adID + "'";
            cmd3.Parameters.AddWithValue("@count", 0+"");
            cmd3.Parameters.AddWithValue("@statu", "הבקשה נדחתה");
            cmd3.ExecuteNonQuery();

            connection.Close();

        }
    }
}
