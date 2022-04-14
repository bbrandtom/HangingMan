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
    [Activity(Label = "OverActivity")]
    public class OverActivity : Activity
    {
        TextView t;
        string text;
        Button re;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.GameOver);
            text = Intent.GetStringExtra("text") ?? "text not avalible";
            base.OnCreate(savedInstanceState);
            re = FindViewById<Button>(Resource.Id.restart);
            t = FindViewById<TextView>(Resource.Id.tv);
            re.Click += OnClick;
            t.Click +=OnClick;
            // Create your application here
        }

        private void T_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnClick(object sender, EventArgs e)
        {
            t.Text = text;
            Button btn = (Button)sender;
            if (btn == re)
            {
                Intent intent = new Intent(this, typeof(HomeActivity));
                StartActivity(intent);
            }
        }
    }
}