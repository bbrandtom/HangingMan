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
    [Table("Phrase")]
    public class Phrase :Word
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int numWords { get; set; }

        public Phrase(string c, string w, int n, int l) : base(c, w, l)
        {
            numWords = n;
        }

        public Phrase(long i, string w, string c, int n, int l) : base(i, c, w, l)
        {
            numWords = n;
        }
        public Phrase() : base()
        {
        }

    }
}