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
{
    //מתי משתמשים בפרייס? האם צריך ליצור גיים מנגר שונה? האם להוסיף תכונה נוספת? 
    public class GameManager
    {
        private  Word word;//המילה שהמשתמש צריך לנחש
        private string win;//האם המשתמש ניצח או לא או עדיין לא
        private int errors; //סופר את מספר השגיאות. כאשר מגיע לשש - המשתמש נפסל
        private char []  guess;//מערך באורך המילה שהמשתמש צריך לנחש שבכל פעם שמתבצע תור המערך מתעדכן בהתאם

        public GameManager(Word w)//פעולה המאתחלת את כל המשתנים ומקבלת את המילה שהמשתמש צריך לנחש כקלט.
        {
            guess = new char[w.word.Length];
            for (int i = 0; i < guess.Length; i++)
            {
                guess[i] =' ';
            }
            win = "not yet";
            errors = 0;
            word = new Word (w.category, w.word,w.word.Length);
        }
        public string GetWin()
        { return win; }
        
        public Word GetWord ()
        { return word; }

        public char [] GetGuess ()
        { return guess; }
         public string CheckWin()//פעולה הבודקת אם המשתמש ניצח במשחק או לא או עדיין לא
        {
            if (win=="lost")
            {
                return win;
            }
            string g="";
            for (int i = 0; i < guess.Length-1; i++)
            {
                g += guess[i];
            }
            if (word.word ==g)
                win = "won";
            return win;
        }
        public void Turn(char i)//ביצוע תור 
        {
            int count = word.word.Length-1;
         //   while (count == -1)
          //  {
                while (((i != word.word[count]) && (guess[count] != ' '))&& (count != -1))//בדיקה האם קיימת האות במקום ריק במערך
                {
                    count--;
                }
                if (count == -1)//האות לא קיימת באינדקס ריק או בכלל
                {
                    errors++;
                    if (errors == 6)// בדיקה האם המשתמש הפסיד 
                    {
                        win = "lost";
                    }
                }
                else// האות קיימת באינדקס ריק ותוסף למערך במיקום המתאים
                {
                    guess[count] = i;
                }
           // }
        }
    }
}