using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace HangingMan
{
    public class PhraseDB
    {
        public const string dbName = "HangingManDB.db";  //Name of All DB that contains all tables
        public const string tabName = "Phrase";   //Name of table - same as class
        // Name of folder in smartphone where the DB is created
        public string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        //this function createsx the DB if it is not already exist
        public bool CreateDatabase<T>()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, dbName)))
                {
                    connection.CreateTable<T>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {  // if the DB was not created for some rerason a message is logged and the function returns false;
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        //Add or Insert Operation  - operaters insert qsql query 
        // data = relevant record without id column.
        public bool InsertIntoTable<T>(T data)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, dbName)))
                {
                    connection.Insert(data);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        // This function returns a list od all Mission Data acoording SQL to statement
        // The statement should be modified according to your app needs.
        public List<Phrase> SelectTableData()
        {
            List<Phrase> listall = new List<Phrase>();
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, dbName)))
                {
                    //Modify the  sql statement to retrieve the releveant data.
                    listall = connection.Query<Phrase>("SELECT * FROM " + tabName + " order by missionName").ToList();
                    return listall;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }
        //Example of fetching relevant data by name
        public List<Phrase> SelectByName(string name)
        {
            List<Phrase> listbyname = new List<Phrase>();
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, dbName)))
                {
                    listbyname = connection.Query<Phrase>("SELECT * FROM " + tabName + " Where missionName=?", name).ToList();
                    return listbyname;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }
        //Activate update statment on DB - must send full mission record with id.
        public bool UpdateTable(Phrase mis)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, dbName)))
                {
                    connection.Update(mis);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        //activate delet sql statement according to id
        public bool DeleteRow(long id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, dbName)))
                {
                    connection.Query<Phrase>("Delete from " + tabName + " Where Id=?", id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
    }
}