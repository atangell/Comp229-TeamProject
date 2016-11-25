using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Security.Principal;
using System.Web.Services.Description;
using System.Web.UI;


namespace LibraryManagement.Classes
{
    public class DbManager
    {
        private SqlConnection con;

        public DbManager()
        {
            con =
                new SqlConnection(
                    ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString);
        }
        public List<Item> GetItems()
        {
            List<Item> items = new List<Item>();
            SqlCommand cmd = new SqlCommand("select * from Items", con);
            using (con)
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Item item = new Item();
                    item.ItemId = Convert.ToInt32(reader["ItemId"]);
                    item.ItemType = Convert.ToString(reader["ItemType"]);
                    item.Name = Convert.ToString(reader["Name"]);
                    item.ShortDesc = Convert.ToString(reader["ShortDesc"]);
                    item.AuthorName = Convert.ToString(reader["AuthorName"]);
                    item.PublisherName = Convert.ToString(reader["PublisherName"]);
                    item.IsCompleted = Convert.ToBoolean(reader["IsCompleted"]);
                    item.ItemStatus = Convert.ToString(reader["ItemStatus"]);
                    item.Link = Convert.ToString(reader["Link"]);
                    item.ReviewScore = !Convert.IsDBNull(reader["ReviewScore"]) ? Convert.ToDouble(reader["ReviewScore"]) : 0;
                    item.DateItemAdded = Convert.ToDateTime(reader["DateItemAdded"]);
                    item.IsbnUpc = Convert.ToString(reader["IsbnUpc"]);
                    item.ItemPlatform = Convert.ToString(reader["ItemPlatform"]);
                    items.Add(item);
                }
            }
            return items;
        }
        public int GetCollectionCount()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Items", con);
            var count = 0;
            using (con)
            {
                con.Open();
                count = (int)cmd.ExecuteScalar();

            }
            return count;
        }
        //public int GetLoanedItemCount()
        //{
        //    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Items where ItemStatus='Loaned'", con);
        //    var count = 0;
        //    using (con)
        //    {
        //        con.Open();
        //        count = (int)cmd.ExecuteScalar();

        //    }
        //    return count;
        //}
        //public Item GetRecentAddition()
        //{
        //    SqlCommand cmd = new SqlCommand("SELECT top 1 ItemId,ItemType,Name FROM Items order by DateItemAdded desc", con);
        //    Item item = new Item();
        //    using (con)
        //    {
        //        con.Open();
        //        var reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {

        //            item.ItemId = Convert.ToInt32(reader["ItemId"]);
        //            item.ItemType = Convert.ToString(reader["ItemType"]);
        //            item.Name = Convert.ToString(reader["Name"]);
        //        }
        //    }
        //    return item;
        //}
    }
}