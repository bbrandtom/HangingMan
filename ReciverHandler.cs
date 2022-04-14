using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
namespace HangingMan
{
    public class ReciverHandler : Handler
    {
        Context con;
        AlertDialog dialog;
        public ReciverHandler(Context con) 
        {
            this.con = con;
        }
        public override void HandleMessage(Message msg)
        {
            //Battery  
            if (msg.What == 0)
            {
                SetMessage("Low Battery", "Warning: Battery Low!!");
            }
            if (msg.What == 1)
            {
                SetMessage("Battery OK", " Battery OK");
            }
        }
        private void SetMessage(string text, string Title)
        {
            if (dialog != null)
                dialog.Dismiss();
            AlertDialog.Builder builder = new AlertDialog.Builder(this.con);
            builder.SetTitle(Title);
            builder.SetMessage(text);
            builder.SetCancelable(true);
            dialog = builder.Create();
            dialog.Show();
        }
    }
} 

