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
    [Activity(Label = "HomeActivity",MainLauncher =true)]

    public class HomeActivity : Activity
    {
        Button s1, s2, s3, s4,add;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HomeScr);
            Words.InitDb();
            s1 = FindViewById<Button>(Resource.Id.sub1);
            s2 = FindViewById<Button>(Resource.Id.sub2);
            s3 = FindViewById<Button>(Resource.Id.sub3);
            s4 = FindViewById<Button>(Resource.Id.sub4);
            add = FindViewById<Button>(Resource.Id.add);
            s1.Click += OnClick;
            s2.Click += OnClick;
            s3.Click += OnClick;
            s4.Click += OnClick;
            add.Click += OnClick;
            // Create your application here
        }

        private void OnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn == s1)
            {
                Intent intent = new Intent(this, typeof(GameActivity));
                intent.PutExtra("category", s1.Text);
                StartActivity(intent);

            }
            else if (btn == s2)
            {
                Intent intent = new Intent(this, typeof(GameActivity));
                intent.PutExtra("category", s2.Text);
                StartActivity(intent);

            }
            else if (btn == s3)
            {
                Intent intent = new Intent(this, typeof(GameActivity));
                intent.PutExtra("category", s3.Text);
                StartActivity(intent);

            }
            else if (btn == s4)
            {
                Intent intent = new Intent(this, typeof(GameActivity));
                intent.PutExtra("category", s4.Text);
                StartActivity(intent);

            }
            else if (btn == add)
            {
                Intent intent = new Intent(this, typeof(AddActivity));
                StartActivity(intent);

            }
        }
    }
}