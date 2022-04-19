using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace XA_Mid2_Lab_Re
{
    [Activity(Label = "ControlActivity")]
    public class UpdateActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_update);     

            var cid = FindViewById<TextView>(Resource.Id.id);
            var name = FindViewById<EditText>(Resource.Id.name);
            var mobile = FindViewById<EditText>(Resource.Id.mobile);
            
            var update = FindViewById<Button>(Resource.Id.update);
            var cancel = FindViewById<Button>(Resource.Id.cancel);
            var logout = FindViewById<Button>(Resource.Id.logout);
            
            var id = Convert.ToInt32(Intent.GetStringExtra("id"));
            var sq = new MySqliteDBRE();
            var contact = sq.GetContactById(id);

            cid.Text     = contact.Id.ToString();
            name.Text = contact.Name;
            mobile.Text = contact.Mobile;            

            update.Click += delegate
            {
                contact.Name = name.Text;
                contact.Mobile = mobile.Text;

                sq.Update(contact);
                Intent i = new Intent(this, typeof(ScreenActivity));
                i.PutExtra("id", id.ToString());
                StartActivity(i);
            };

            cancel.Click += delegate
            {
                Intent i = new Intent(this, typeof(ScreenActivity));
                i.PutExtra("id", id.ToString());
                StartActivity(i);
            };
            logout.Click += delegate
            {          
                Intent i = new Intent(this, typeof(MainActivity));
                StartActivity(i);
            };
        }
    }
}