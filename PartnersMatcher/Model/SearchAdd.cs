using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnersMatcher.Model
{
    public static class SearchAdd
    {       
        public static List<string> updateCityList(ref OleDbConnection connection, string search_category)
        {
            List<string> city = new List<string>();
            connection.Open();
            OleDbDataReader reader = null;
           
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select table_name from categories Where category_name = @s_category";
            cmd.Parameters.Add("@s_category", search_category);

            reader = cmd.ExecuteReader();
            reader.Read();

            search_category = reader["table_name"].ToString();

            cmd = new OleDbCommand("SELECT DISTINCT " + "[מיקום]" + " FROM " + search_category, connection);
            reader = cmd.ExecuteReader();
            string city_name;
            city.Add("");
            while (reader.Read())
            {
                city_name = (reader["מיקום"].ToString());
                city.Add(city_name);
            }
            connection.Close();
            reader.Close();
            return city;
        }
        public static List<List<string>> search(ref OleDbConnection connection, string search_category, string search_city)
        {
            connection.Open();
            OleDbDataReader reader = null;
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select table_name from categories Where category_name = @s_category";
            cmd.Parameters.Add("@s_category", search_category);

            reader = cmd.ExecuteReader();
            reader.Read();

            search_category = reader["table_name"].ToString();
            if (search_city != null && search_city != "")
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "select * from " + search_category + " Where [מיקום] = @s_city";
                cmd.Parameters.Add("@s_city", search_city);
                reader = cmd.ExecuteReader();
            }
            else
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "select * from " + search_category + "";
                reader = cmd.ExecuteReader();
            }

            int count = reader.FieldCount;
            int rowCounter = 0;
            List<List<string>> dataReader=new List<List<string>>();
            dataReader.Add(new List<string>());
            for (int i = 0; i < count; i++)
            {
                dataReader[rowCounter].Add(reader.GetName(i));
            }
            rowCounter++;
            while (reader.Read())
            {
                if (int.Parse(reader["מספר שותפים נדרשים"].ToString()) == 0)
                    continue;
                dataReader.Add(new List<string>());
                for (int i = 0; i < count; i++)
                {                  
                    if (reader.GetName(i) != "תאריך" && reader.GetName(i) != "תאריך התחלה" && reader.GetName(i) != "תאריך סיום" && reader.GetName(i) != "תאריך פרסום המודעה")
                    {
                        dataReader[rowCounter].Add(reader.GetValue(i).ToString());
                    }
                    else
                    {
                        dataReader[rowCounter].Add((reader.GetValue(i).ToString()).Substring(0, 10));
                    }            
                }
                rowCounter++;
            }
            reader.Close();
            connection.Close();
            return dataReader;
        }
    }
}
