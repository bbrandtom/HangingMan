using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Util;
using Android.Widget;
using SQLite;


namespace HangingMan
{
    public class WordDB//היי אופיר - את צריכה לעבור על כל הקוד ולתקן משתנים וכאלה. ולעשות אותו דבר לPHRASEDB 
    {

        public const string dbName = "HangingManDB.db";  //Name of All DB that contains all tables
        public const string tabName = "Word";   //Name of table - same as class
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
        public List<Word> SelectTableData()
        {
            List<Word> listall = new List<Word>();
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, dbName)))
                {
                    //Modify the  sql statement to retrieve the releveant data.
                    listall = connection.Query<Word>("SELECT * FROM " + tabName).ToList();
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
        public List<Word> SelectByName(string name)
        {
            List<Word> listbyname = new List<Word>();
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, dbName)))
                {

                    listbyname = connection.Query<Word>("SELECT * FROM " + tabName + " Where category=?", name).ToList();
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
        public bool UpdateTable(Word mis)
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

                    connection.Query<Word>("Delete from " + tabName + " Where Id=?", id);
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