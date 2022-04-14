using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;


namespace HangingMan
{
    [Table("Word")]
    public class Word
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public long id { get; set; }
        public int letters { get; set; }
        public string category { get; set; }
        public string word { get; set; }

        public Word(string c, string w, int l)
        {
            word = w;
            letters = l;
            category = c;
        }

        public Word(long i, string c, string w, int l)
        {
            id = i;
            word = w;
            letters = l;
            category = c;
        }
        public Word() : base()
        {
        }
    }
}