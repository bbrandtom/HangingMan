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
            for (int i = 0; i < guess.Length; i++)
            {
                g += guess[i];
            }
            if (word.word ==g)
                win = "won";
            return win;
        }
        public void Turn(char guessed_char)//ביצוע תור 
        {
            bool correct_guess = false;
            // Go over the word and check if the guessed character matches a character from the word
            for (int i=0; i < word.word.Length; i++)
            {
                if (guessed_char==word.word[i])
                {
                    guess[i] = guessed_char;
                    correct_guess = true;
                }
            }

            if (!correct_guess)
            {
                errors+=1;
                if (errors == 6)
                {
                    win = "lost";
                }
            }
        }
    }
}