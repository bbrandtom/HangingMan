using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using Android.Views;
using Android.Graphics;
using Android.Content;
using System;

namespace HangingMan
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class GameActivity : AppCompatActivity
    {
        //המספרים שמופיעים לאחר האות בי מייצגים את הגימטריה ששיכת לאותה האות שהכפתור מייצג
        Button b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b20, b30, b40, b50, b60, b70, b80, b90, b100, b200, b300, b400;
        List<EditText> lines = new List<EditText>();
        LinearLayout l1;
        Word w1;
        GameManager g1;
        private BatteryReciver br;
        private ReciverHandler recHandler;
        string category;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.Game);
            recHandler = new ReciverHandler(this); //(,player) 
            //Register Battery Event 
            br = new BatteryReciver(recHandler);
            IntentFilter intF = new IntentFilter();
            intF.AddAction(Intent.ActionBatteryOkay);
            intF.AddAction(Intent.ActionBatteryLow);
            RegisterReceiver(br, intF);
            category = Intent.GetStringExtra("category") ?? "category not avalible";
            l1 = FindViewById<LinearLayout>(Resource.Id.lines);
            b1 = FindViewById<Button>(Resource.Id.l1);
            b2 = FindViewById<Button>(Resource.Id.l2);
            b3 = FindViewById<Button>(Resource.Id.l3);
            b4 = FindViewById<Button>(Resource.Id.l4);
            b5 = FindViewById<Button>(Resource.Id.l5);
            b6 = FindViewById<Button>(Resource.Id.l6);
            b7 = FindViewById<Button>(Resource.Id.l7);
            b8 = FindViewById<Button>(Resource.Id.l8);
            b9 = FindViewById<Button>(Resource.Id.l9);
            b10 = FindViewById<Button>(Resource.Id.l10);
            b20 = FindViewById<Button>(Resource.Id.l20);
            b30 = FindViewById<Button>(Resource.Id.l30);
            b40 = FindViewById<Button>(Resource.Id.l40);
            b50 = FindViewById<Button>(Resource.Id.l50);
            b60 = FindViewById<Button>(Resource.Id.l60);
            b70 = FindViewById<Button>(Resource.Id.l70);
            b80 = FindViewById<Button>(Resource.Id.l80);
            b90 = FindViewById<Button>(Resource.Id.l90);
            b100 = FindViewById<Button>(Resource.Id.l100);
            b200 = FindViewById<Button>(Resource.Id.l200);
            b300 = FindViewById<Button>(Resource.Id.l300);
            b400 = FindViewById<Button>(Resource.Id.l400);
            Words.GetAllData(category);
            w1 = Words.Get();
            AddText(w1);
            b1.Click += OnClick;
            b2.Click += OnClick;
            b3.Click += OnClick;
            b4.Click += OnClick;
            b5.Click += OnClick;
            b6.Click += OnClick;
            b7.Click += OnClick;
            b8.Click += OnClick;
            b9.Click += OnClick;
            b10.Click += OnClick;
            b20.Click += OnClick;
            b30.Click += OnClick;
            b40.Click += OnClick;
            b50.Click += OnClick;
            b60.Click += OnClick;
            b70.Click += OnClick;
            b80.Click += OnClick;
            b90.Click += OnClick;
            b100.Click += OnClick;
            b200.Click += OnClick;
            b300.Click += OnClick;
            b400.Click += OnClick;

        }


        private void AddText(Word w1)
        {
            LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(200, 80);
            layoutParams.LeftMargin = 20;
            layoutParams.Gravity = GravityFlags.CenterHorizontal;

            for (int i = 0; i < w1.letters; i++)
            { //Display list of lines
                EditText et = new EditText(this);
                et.LayoutParameters = layoutParams;
                et.SetTextSize(Android.Util.ComplexUnitType.Px, 1);
               // et.TextSize = 0;
                et.Gravity = GravityFlags.Center;
                l1.AddView(et);
                lines.Add(et);
            }
        }

            protected override void OnResume()
        {
            base.OnResume();
            IntentFilter intF = new IntentFilter();
            intF.AddAction(Intent.ActionBatteryOkay);
            intF.AddAction(Intent.ActionBatteryLow);
            RegisterReceiver(br, intF);
        }

        protected override void OnDestroy()
        {
            UnregisterReceiver(br);
            base.OnDestroy();
        }

        private void OnClick(object sender, System.EventArgs e)
        {
            g1 = new GameManager(w1);
            Button btn = (Button)sender;
            if (btn == b1)
            {
                b1.SetBackgroundResource(Resource.Drawable.white);
                b1.Enabled = false;
                g1.Turn('א');
                g1.CheckWin();
                if ((g1.GetWin()=="win")|| (g1.GetWin() == "lost"))
                {
                    Intent intent = new Intent(this, typeof(OverActivity));
                    intent.PutExtra("text", g1.GetWin());
                    StartActivity(intent);
                }
                for (int i = 0; i < g1.GetWord().letters; i++)
                {
                    lines[i].Text = g1.GetGuess()[i].ToString();
                }
            }
            else if (btn==b2)
            {
                b2.SetBackgroundResource(Resource.Drawable.white);
                b2.Enabled = false;
                g1.Turn('ב');
                g1.CheckWin();
                if ((g1.GetWin() == "win") || (g1.GetWin() == "lost"))
                {
                    Intent intent = new Intent(this, typeof(OverActivity));
                    intent.PutExtra("text", g1.GetWin());
                    StartActivity(intent);
                }
                for (int i = 0; i < g1.GetWord().letters; i++)
                {
                    lines[i].Text = g1.GetGuess()[i].ToString();
                }
            }
            else if (btn == b3)
            {
                b3.SetBackgroundResource(Resource.Drawable.white);
                b3.Enabled = false;
                g1.Turn('ג');
                g1.CheckWin();
                if ((g1.GetWin() == "win") || (g1.GetWin() == "lost"))
                {
                    Intent intent = new Intent(this, typeof(OverActivity));
                    intent.PutExtra("text", g1.GetWin());
                    StartActivity(intent);
                }
                for (int i = 0; i < g1.GetWord().letters; i++)
                {
                    lines[i].Text = g1.GetGuess()[i].ToString();
                }
            }
            else if (btn == b4)
            {
                b4.SetBackgroundResource(Resource.Drawable.white);
                b4.Enabled = false;
                g1.Turn('ד');
                g1.CheckWin();
                if ((g1.GetWin() == "win") || (g1.GetWin() == "lost"))
                {
                    Intent intent = new Intent(this, typeof(OverActivity));
                    intent.PutExtra("text", g1.GetWin());
                    StartActivity(intent);
                }
                for (int i = 0; i < g1.GetWord().letters; i++)
                {
                    lines[i].Text = g1.GetGuess()[i].ToString();
                }
            }
            else if (btn == b5)
            {
                b5.SetBackgroundResource(Resource.Drawable.white);
                b5.Enabled = false;
                g1.Turn('ה');
                g1.CheckWin();
                if ((g1.GetWin() == "win") || (g1.GetWin() == "lost"))
                {
                    Intent intent = new Intent(this, typeof(OverActivity));
                    intent.PutExtra("text", g1.GetWin());
                    StartActivity(intent);
                }
                for (int i = 0; i < g1.GetWord().letters; i++)
                {
                    lines[i].Text = g1.GetGuess()[i].ToString();
                }
            }
            else if (btn == b6)
            {
                b6.SetBackgroundResource(Resource.Drawable.white);
                b6.Enabled = false;
                g1.Turn('ו');
                g1.CheckWin();
                if ((g1.GetWin() == "win") || (g1.GetWin() == "lost"))
                {
                    Intent intent = new Intent(this, typeof(OverActivity));
                    intent.PutExtra("text", g1.GetWin());
                    StartActivity(intent);
                }
                for (int i = 0; i < g1.GetWord().letters; i++)
                {
                    lines[i].Text = g1.GetGuess()[i].ToString();
                }
            }
            else if (btn == b7)
            {
                b7.SetBackgroundResource(Resource.Drawable.white);
                b7.Enabled = false;
                g1.Turn('ז');
                g1.CheckWin();
                if ((g1.GetWin() == "win") || (g1.GetWin() == "lost"))
                {
                    Intent intent = new Intent(this, typeof(OverActivity));
                    intent.PutExtra("text", g1.GetWin());
                    StartActivity(intent);
                }
                for (int i = 0; i < g1.GetWord().letters; i++)
                {
                    lines[i].Text = g1.GetGuess()[i].ToString();
                }
            }
            else if (btn == b8)
            {
                b8.SetBackgroundResource(Resource.Drawable.white);
                b8.Enabled = false;
                g1.Turn('ח');
                g1.CheckWin();
                if ((g1.GetWin() == "win") || (g1.GetWin() == "lost"))
                {
                    Intent intent = new Intent(this, typeof(OverActivity));
                    intent.PutExtra("text", g1.GetWin());
                    StartActivity(intent);
                }
                for (int i = 0; i < g1.GetWord().letters; i++)
                {
                    lines[i].Text = g1.GetGuess()[i].ToString();
                }
            }
            else if (btn == b9)
            {
                b9.SetBackgroundResource(Resource.Drawable.white);
                b9.Enabled = false;
                g1.Turn('ט');
                g1.CheckWin();
                if ((g1.GetWin() == "win") || (g1.GetWin() == "lost"))
                {
                    Intent intent = new Intent(this, typeof(OverActivity));
                    intent.PutExtra("text", g1.GetWin());
                    StartActivity(intent);
                }
                for (int i = 0; i < g1.GetWord().letters; i++)
                {
                    lines[i].Text = g1.GetGuess()[i].ToString();
                }
            }
            else if (btn == b10)
            {
                b10.SetBackgroundResource(Resource.Drawable.white);
                b10.Enabled = false;
                g1.Turn('י');
                g1.CheckWin();
                if ((g1.GetWin() == "win") || (g1.GetWin() == "lost"))
                {
                    Intent intent = new Intent(this, typeof(OverActivity));
                    intent.PutExtra("text", g1.GetWin());
                    StartActivity(intent);
                }
                for (int i = 0; i < g1.GetWord().letters; i++)
                {
                    lines[i].Text = g1.GetGuess()[i].ToString();
                }
            }
            else if (btn == b20)
            {
                b20.SetBackgroundResource(Resource.Drawable.white);
                b20.Enabled = false;
                g1.Turn('כ');
                g1.CheckWin();
                if ((g1.GetWin() == "win") || (g1.GetWin() == "lost"))
                {
                    Intent intent = new Intent(this, typeof(OverActivity));
                    intent.PutExtra("text", g1.GetWin());
                    StartActivity(intent);
                }
                for (int i = 0; i < g1.GetWord().letters; i++)
                {
                    lines[i].Text = g1.GetGuess()[i].ToString();
                }
            }
            else if (btn == b30)
            {
                b30.SetBackgroundResource(Resource.Drawable.white);
                b30.Enabled = false;
                g1.Turn('ל');
                g1.CheckWin();
                if ((g1.GetWin() == "win") || (g1.GetWin() == "lost"))
                {
                    Intent intent = new Intent(this, typeof(OverActivity));
                    intent.PutExtra("text", g1.GetWin());
                    StartActivity(intent);
                }
                for (int i = 0; i < g1.GetWord().letters; i++)
                {
                    lines[i].Text = g1.GetGuess()[i].ToString();
                }
            }
            else if (btn == b40)
            {
                b40.SetBackgroundResource(Resource.Drawable.white);
                b40.Enabled = false;
                g1.Turn('מ');
                g1.CheckWin();
                if ((g1.GetWin() == "win") || (g1.GetWin() == "lost"))
                {
                    Intent intent = new Intent(this, typeof(OverActivity));
                    intent.PutExtra("text", g1.GetWin());
                    StartActivity(intent);
                }
                for (int i = 0; i < g1.GetWord().letters; i++)
                {
                    lines[i].Text = g1.GetGuess()[i].ToString();
                }
            }
            else if (btn == b50)
            {
                b50.SetBackgroundResource(Resource.Drawable.white);
                b50.Enabled = false;
                g1.Turn('נ');
                g1.CheckWin();
                if ((g1.GetWin() == "win") || (g1.GetWin() == "lost"))
                {
                    Intent intent = new Intent(this, typeof(OverActivity));
                    intent.PutExtra("text", g1.GetWin());
                    StartActivity(intent);
                }
                for (int i = 0; i < g1.GetWord().letters; i++)
                {
                    lines[i].Text = g1.GetGuess()[i].ToString();
                }
            }
            else if (btn == b60)
            {
                b60.SetBackgroundResource(Resource.Drawable.white);
                b60.Enabled = false;
                g1.Turn('ס');
                g1.CheckWin();
                if ((g1.GetWin() == "win") || (g1.GetWin() == "lost"))
                {
                    Intent intent = new Intent(this, typeof(OverActivity));
                    intent.PutExtra("text", g1.GetWin());
                    StartActivity(intent);
                }
                for (int i = 0; i < g1.GetWord().letters; i++)
                {
                    lines[i].Text = g1.GetGuess()[i].ToString();
                }
            }
            else if (btn == b70)
            {
                b70.SetBackgroundResource(Resource.Drawable.white);
                b70.Enabled = false;
                g1.Turn('ע');
                g1.CheckWin();
                if ((g1.GetWin() == "win") || (g1.GetWin() == "lost"))
                {
                    Intent intent = new Intent(this, typeof(OverActivity));
                    intent.PutExtra("text", g1.GetWin());
                    StartActivity(intent);
                }
                for (int i = 0; i < g1.GetWord().letters; i++)
                {
                    lines[i].Text = g1.GetGuess()[i].ToString();
                }
            }
            else if (btn == b80)
            {
                b80.SetBackgroundResource(Resource.Drawable.white);
                b80.Enabled = false;
                g1.Turn('פ');
                g1.CheckWin();
                if ((g1.GetWin() == "win") || (g1.GetWin() == "lost"))
                {
                    Intent intent = new Intent(this, typeof(OverActivity));
                    intent.PutExtra("text", g1.GetWin());
                    StartActivity(intent);
                }
                for (int i = 0; i < g1.GetWord().letters; i++)
                {
                    lines[i].Text = g1.GetGuess()[i].ToString();
                }
            }
            else if (btn == b90)
            {
                b90.SetBackgroundResource(Resource.Drawable.white);
                b90.Enabled = false;
                g1.Turn('צ');
                g1.CheckWin();
                if ((g1.GetWin() == "win") || (g1.GetWin() == "lost"))
                {
                    Intent intent = new Intent(this, typeof(OverActivity));
                    intent.PutExtra("text", g1.GetWin());
                    StartActivity(intent);
                }
                for (int i = 0; i < g1.GetWord().letters; i++)
                {
                    lines[i].Text = g1.GetGuess()[i].ToString();
                }
            }
            else if (btn == b100)
            {
                b100.SetBackgroundResource(Resource.Drawable.white);
                b100.Enabled = false;
                g1.Turn('ק');
                g1.CheckWin();
                if ((g1.GetWin() == "win") || (g1.GetWin() == "lost"))
                {
                    Intent intent = new Intent(this, typeof(OverActivity));
                    intent.PutExtra("text", g1.GetWin());
                    StartActivity(intent);
                }
                for (int i = 0; i < g1.GetWord().letters; i++)
                {
                    lines[i].Text = g1.GetGuess()[i].ToString();
                }
            }
            else if (btn == b200)
            {
                b200.SetBackgroundResource(Resource.Drawable.white);
                b200.Enabled = false;
                g1.Turn('ר');
                g1.CheckWin();
                if ((g1.GetWin() == "win") || (g1.GetWin() == "lost"))
                {
                    Intent intent = new Intent(this, typeof(OverActivity));
                    intent.PutExtra("text", g1.GetWin());
                    StartActivity(intent);
                }
                for (int i = 0; i < g1.GetWord().letters; i++)
                {
                    lines[i].Text = g1.GetGuess()[i].ToString();
                }
            }
            else if (btn == b300)
            {
                b300.SetBackgroundResource(Resource.Drawable.white);
                b300.Enabled = false;
                g1.Turn('ש');
                g1.CheckWin();
                if ((g1.GetWin() == "win") || (g1.GetWin() == "lost"))
                {
                    Intent intent = new Intent(this, typeof(OverActivity));
                    intent.PutExtra("text", g1.GetWin());
                    StartActivity(intent);
                }
                for (int i = 0; i < g1.GetWord().letters; i++)
                {
                    lines[i].Text = g1.GetGuess()[i].ToString();
                }
            }
            else if (btn == b400)
            {
                b400.SetBackgroundResource(Resource.Drawable.white);
                b400.Enabled = false;
                g1.Turn('ת');
                g1.CheckWin();
                if ((g1.GetWin() == "win") || (g1.GetWin() == "lost"))
                {
                    Intent intent = new Intent(this, typeof(OverActivity));
                    intent.PutExtra("text", g1.GetWin());
                    StartActivity(intent);
                }
                for (int i = 0; i < g1.GetWord().letters; i++)
                {
                    lines[i].Text = g1.GetGuess()[i].ToString();
                }
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}