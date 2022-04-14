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
            g1 = new GameManager(w1);
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

        protected override void BtnToHebChar(Button btn)
        {
            if (btn == b1)
            {
                return 'א';
            }
            else if (btn == b2)
            {
                return 'ב';
            }
            else if (btn == b3)
            {
                return 'ג';
            }
            else if (btn == b4)
            {
                return 'ד';
            }
            else if (btn == b5)
            {
                return 'ה';
            }
            else if (btn == b6)
            {
                return 'ו';
            }
            else if (btn == b7)
            {
                return 'ז';
            }
            else if (btn == b8)
            {
                return 'ח';
            }
            else if (btn == b9)
            {
                return 'ט';
            }
            else if (btn == b10)
            {
                return 'י';
            }
            else if (btn == b20)
            {
                return 'כ';
            }
            else if (btn == b30)
            {
                return 'ל';
            }
            else if (btn == b40)
            {
                return 'מ';
            }
            else if (btn == b50)
            {
                return 'נ';
            }
            else if (btn == b60)
            {
                return 'ס';
            }
            else if (btn == b70)
            {
                return 'ע';
            }
            else if (btn ==b80)
            {
                return 'פ';
            }
            else if (btn ==b90)
            {
                return 'צ';
            }
            else if (btn ==b100)
            {
                return 'ק';
            }
            else if (btn ==b200)
            {
                return 'ר';
            }
            else if (btn ==b300)
            {
                return 'ש';
            }
            else if (btn ==b400)
            {
                return 'ת';
            }
        }

        private void OnClick(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            btn.SetBackgroundResource(Resource.Drawable.white);
            btn.Enabled = false;
            g1.Turn(BtnToHebChar(btn));
            g1.CheckWin();
            if ((g1.GetWin()=="win")||(g1.GetWin() == "lost"))
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