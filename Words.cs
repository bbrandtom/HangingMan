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

namespace HangingMan
{       // ליצור עוד DB הנדלר גם לביטויים
    class Words
    {
        public static List<Word> words { get; set; }
        public static WordDB dbhandler;
        private static Random r;

        public static void InitDb()//אתחול הרשימה ויצירת דטה בייס
        {
            //Create Db Tables - better put 
            dbhandler = new WordDB();
            dbhandler.CreateDatabase<Word>();
            //Init List
            words = new List<Word>();

            r = new Random();
        }
        public static void GetAllData(string category)//הכנסת כל הנתונים מהדטה בייס לרשימה לפי הקטגוריה המתאימה
        {
            words = dbhandler.SelectByName(category);
        }   

        public static void Add(Word w)//הוספת מילה חדשה לרשימה לפי הנושא המתקבל
        {
                if (!words.Contains(w))
                {
                dbhandler.InsertIntoTable(w);
                //Refresh list after row inserted
                GetAllData(w.category);
                }
        }

        public static Word Get ()//בחירת מילה מתוך הנושא הנתון 
        {
            //   int i = r.Next(0, words.Count());
            //  return words[i];
            return (new Word("חיות", "דינוזאור", 8));
        }

    }
}