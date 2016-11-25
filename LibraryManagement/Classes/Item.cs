using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.Classes
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemType { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string AuthorName { get; set; }
        public string PublisherName { get; set; }
        public bool IsCompleted { get; set; }
        public string ItemStatus { get; set; }
        public string Link { get; set; }
        public Double ReviewScore { get; set; }
        public DateTime DateItemAdded { get; set; }
        public string IsbnUpc { get; set; }
        public string ItemPlatform { get; set; }
    }
}