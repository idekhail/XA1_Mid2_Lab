using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Support.V7.App;
using Java.Lang;
using System;

namespace XA_Mid2_Lab_Re
{
    [Activity(Label = "ShowActivity")]
    public class ScreenActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_screen);   

            var show = FindViewById<TextView>(Resource.Id.show);
            var logout = FindViewById<Button>(Resource.Id.logout);
            var close = FindViewById<Button>(Resource.Id.close);
            var control = FindViewById<Button>(Resource.Id.control);

            var id = Convert.ToInt32(Intent.GetStringExtra("id"));
            var sq = new MySqliteDBRE();
            var contact = sq.GetContactById(id);
          
            show.Text = contact.Id + "\t\t" + contact.Name + "\t\t" + contact.Mobile ;
           
            logout.Click += delegate
            {
                Intent i = new Intent(this, typeof(MainActivity));
                StartActivity(i);
            };

            close.Click += delegate
            {
                JavaSystem.Exit(0);
            };

            control.Click += delegate
            {
                Intent i = new Intent(this, typeof(UpdateActivity));
                i.PutExtra("id", id.ToString());
                StartActivity(i);
            };

        }
    }
}