using System;
using SQLite;
using System.IO;

namespace XA_Mid2_Lab_Re
{
    class MySqliteDBRE
    {
        //database path
        private string dbPath = Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "MyContacts.db3");
        public MySqliteDBRE()
        {
            //Creating database, if it doesn't already exist 
            if (!File.Exists(dbPath))
            {
                var db = new SQLiteConnection(dbPath);
                db.CreateTable<Contacts>();
            }
        }
        //Insert data into DB  
        public void Insert(Contacts contact)
        {
            var db = new SQLiteConnection(dbPath);
            db.Insert(contact);
        }
        //Update data in DB   
        public void Update(Contacts contact)
        {
            var db = new SQLiteConnection(dbPath);          
            db.Update(contact);
        }
        // Return True if data is found othewies return false
        public bool Check(string name)
        {
            var db = new SQLiteConnection(dbPath);
            var table = db.Table<Contacts>().Where(i => i.Name == name).FirstOrDefault();
            if (table == null)
                return true;
            return false;
        }
        //Return Table from DB  
        public Contacts GetContact(string name, string mobile)
        {
            var db = new SQLiteConnection(dbPath);
            return db.Table<Contacts>().Where(i => i.Name == name && i.Mobile == mobile).FirstOrDefault(); ;                      
        }

        public Contacts GetContactById(int id)
        {
            var db = new SQLiteConnection(dbPath);
            return db.Table<Contacts>().Where(i => i.Id == id).FirstOrDefault(); ;
        }

        [Table("Contacts")]
        public class Contacts
        {
            [PrimaryKey, AutoIncrement, Column("_id")]
            public int Id { get; set; }
            public string Name { get; set; }
            public string Mobile { get; set; }
        }
    }
}
