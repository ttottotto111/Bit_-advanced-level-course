using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _1103xml과db연결
{

    class Item
    {
        public int ID { get; private set; }
        public string AlternativeTitle { get; private set; }
        public string CollectionDb { get; private set; }
        public string Creator { get; private set; }
        public string Description { get; private set; }
        public string Language { get; private set; }
        public string RegDate { get; private set; }
        public string SubDescription { get; private set; }
        public string SubjectCategory { get; private set; }
        public string Title { get; private set; }

        private Item(string alternativeTitle,string collectiondb, string creator, string description,string language,string regdate, string subDescription,string subjectCategory,string title)
        {
            AlternativeTitle = alternativeTitle;
            CollectionDb = collectiondb;
            Creator = creator;
            Description = description;
            Language = language;
            RegDate=regdate;
            SubDescription = subDescription;
            SubjectCategory=subjectCategory;
            Title=title;
        }

        //파싱코드
        public static Item MakeItem(XmlReader xr)
        {
            xr.ReadToDescendant("alternativeTitle");
            string alternativeTitle = xr.ReadElementString("alternativeTitle");       //문자열\

            //xr.ReadToDescendant("collectionDb");
            string collectiondb = xr.ReadElementString("collectionDb");       //문자열\

            //xr.ReadToNextSibling("creator");
            string creator = xr.ReadElementString("creator");

           // xr.ReadToNextSibling("description");
            string description = xr.ReadElementString("description");

            //xr.ReadToNextSibling("language");
            string language = xr.ReadElementString("language");///type 문제 해결 필요

           // xr.ReadToNextSibling("regDate");
            string regdate = xr.ReadElementString("regDate");

           // xr.ReadToNextSibling("subDescription");
            string subDescription = xr.ReadElementString("subDescription");
            
            //xr.ReadToNextSibling("subjectCategory");
            string subjectCategory = xr.ReadElementString("subjectCategory");

           // xr.ReadToNextSibling("title");
            string title = xr.ReadElementString("title");

            return new Item(alternativeTitle, collectiondb, creator, description, language, regdate, subDescription, subjectCategory, title);
      
        }
    }
    class WbPaser
    {
        public static List<Item> XmlPaser(string path)
        {
            List<Item> itemlist = new List<Item>();

            XmlReader reader = XmlReader.Create(path);
            while (reader.Read())
            {
                if (reader.IsStartElement("item"))
                {
                    Item item = Item.MakeItem(reader);
                    if (item != null)
                        itemlist.Add(item);
                }
            }

            return itemlist;
        }
    }
}
