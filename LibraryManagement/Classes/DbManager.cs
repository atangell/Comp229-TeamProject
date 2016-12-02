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
        // Add Item to Collection
        public int AddItem(Item item, string conString)
        {
            SqlConnection con = new SqlConnection(conString);
            int id = 0;
            SqlCommand cmd =
                new SqlCommand(
                    "Insert into Items(ItemType,Name,ShortDesc,AuthorName,PublisherName,IsCompleted,ItemStatus,Link,IsbnUpc,ItemPlatform,ReviewScore) values(@ItemType,@Name,@ShortDesc,@AuthorName,@PublisherName,@IsCompleted,@ItemStatus,@Link,@IsbnUpc,@ItemPlatform,@ReviewScore)",
                    con);
            cmd.Parameters.AddWithValue("@ItemType", item.ItemType);
            cmd.Parameters.AddWithValue("@Name", item.Name);
            cmd.Parameters.AddWithValue("@ShortDesc", item.ShortDesc);
            cmd.Parameters.AddWithValue("@AuthorName", item.AuthorName);
            cmd.Parameters.AddWithValue("@PublisherName", item.PublisherName);
            cmd.Parameters.AddWithValue("@IsCompleted", item.IsCompleted);
            cmd.Parameters.AddWithValue("@ItemStatus", item.ItemStatus);
            cmd.Parameters.AddWithValue("@Link", item.Link);
            cmd.Parameters.AddWithValue("@IsbnUpc", item.IsbnUpc);
            cmd.Parameters.AddWithValue("@ItemPlatform", item.ItemPlatform);
            cmd.Parameters.AddWithValue("@ReviewScore", item.ReviewScore);



            using (con)
            {
                con.Open();
                id = cmd.ExecuteNonQuery();

            }
            return id;

        }


        // Get count of loaned items
        public int GetLoanedItemCount(string conString)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Items where ItemStatus='Loaned'", con);
            var count = 0;
            using (con)
            {
                con.Open();
                count = (int)cmd.ExecuteScalar();

            }

            return count;
        }

        //Get items which are recently added. Top 1
        public Item GetRecentAddition(string conString)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand("SELECT top 1 ItemId,ItemType,Name FROM Items order by DateItemAdded desc", con);
            Item item = new Item();
            using (con)
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    item.ItemId = Convert.ToInt32(reader["ItemId"]);
                    item.ItemType = Convert.ToString(reader["ItemType"]);
                    item.Name = Convert.ToString(reader["Name"]);
                }
            }
            return item;
        }
        // Update item in collection
        public int UpdateItem(Item item, int itemId)
        {
            int id = 0;
            SqlCommand cmd =
                new SqlCommand(
                    "Update Items set ItemType=@ItemType, Name=@Name, ShortDesc=@ShortDesc, AuthorName=@AuthorName, PublisherName=@PublisherName, IsCompleted=@IsCompleted, ItemStatus=@ItemStatus, Link=@Link, ReviewScore=@ReviewScore, IsbnUpc=@IsbnUpc, ItemPlatform=@ItemPlatform where ItemId=@ItemId",
                    con);
            cmd.Parameters.AddWithValue("@ItemType", item.ItemType);
            cmd.Parameters.AddWithValue("@Name", item.Name);
            cmd.Parameters.AddWithValue("@ShortDesc", item.ShortDesc);
            cmd.Parameters.AddWithValue("@AuthorName", item.AuthorName);
            cmd.Parameters.AddWithValue("@PublisherName", item.PublisherName);
            cmd.Parameters.AddWithValue("@IsCompleted", item.IsCompleted);
            cmd.Parameters.AddWithValue("@ItemStatus", item.ItemStatus);
            cmd.Parameters.AddWithValue("@Link", item.Link);
            cmd.Parameters.AddWithValue("@ReviewScore", item.ReviewScore);
            cmd.Parameters.AddWithValue("@IsbnUpc", item.IsbnUpc);
            cmd.Parameters.AddWithValue("@ItemPlatform", item.ItemPlatform);
            cmd.Parameters.AddWithValue("@ItemId", itemId);
            using (con)
            {
                con.Open();
                id = cmd.ExecuteNonQuery();
            }
            return id;
        }
        // Delete item from collection
        public int DeleteItem(int itemId)
        {
            int id = 0;
            SqlCommand cmd = new SqlCommand("Delete from Items where ItemId=@ItemId", con);
            cmd.Parameters.AddWithValue("@ItemId", itemId);
            using (con)
            {
                con.Open();
                id = cmd.ExecuteNonQuery();
            }
            return id;
        }


        //Get detail of item
        public Item GetItemDetail(int id)
        {

            SqlCommand cmd = new SqlCommand("Select * from Items where ItemId='" + id + "'", con);
            Item item = new Item();
            using (con)
            {

                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {

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

                }
            }
            return item;
        }


    }
}