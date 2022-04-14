using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace HangingMan
{
    [Activity(Label = "AddActivity")]
    public class AddActivity : AppCompatActivity
    {
        EditText cat, wor;
        Button sav;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.Add);
            base.OnCreate(savedInstanceState);
            Words.InitDb();
            sav = FindViewById<Button>(Resource.Id.save);
            cat = FindViewById<EditText>(Resource.Id.category);
            wor = FindViewById<EditText>(Resource.Id.word);
            sav.Click += OnClick;

        }

        private void OnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn == sav)
            {
                Words.Add(new Word(cat.Text, wor.Text, wor.Text.Length));
                Toast.MakeText(this, "המילה הוספה בהצלחה ", ToastLength.Long).Show();
            }
        }
        public override bool OnCreateOptionsMenu(Android.Views.IMenu menu)//יצירת תפריט
        {
            base.MenuInflater.Inflate(Resource.Menu.menu1, menu);
            return true;
        }
        public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)//מה יקרה כאשר נלחץ על אחד הדברים בתפריט
        {
            if (item.ItemId == Resource.Id.add)
            {
                return true;
            }
            else if (item.ItemId == Resource.Id.home)
            {
                Intent x = new Intent(this, typeof(HomeActivity));
                StartActivity(x);
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}