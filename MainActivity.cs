using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace XA_Mid2_Lab_Re
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        MySqliteDBRE sq;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            EditText name = FindViewById<EditText>(Resource.Id.name);
            EditText mobile = FindViewById<EditText>(Resource.Id.mobile);
            Button login = FindViewById<Button>(Resource.Id.login);
            Button newContact = FindViewById<Button>(Resource.Id.newContact);

            
            MySqliteDBRE sq = new MySqliteDBRE();

            login.Click += delegate
            {
                if (name.Text != "" && mobile.Text != "")
                {
                    MySqliteDBRE.Contacts contact = sq.GetContact(name.Text, mobile.Text); 

                    if (contact != null)
                    {
                        Intent i = new Intent(this, typeof(ScreenActivity));
                        i.PutExtra("id", contact.Id.ToString());
                        StartActivity(i);
                    }
                    else
                    {
                        Toast.MakeText(this, " UserName or Password is wrong", ToastLength.Short).Show();
                    }
                }
                else
                {
                    Toast.MakeText(this, " Empty ", ToastLength.Short).Show();
                }
            };
            newContact.Click += delegate
            {
                Intent i = new Intent(this, typeof(NewContactActivity));
                StartActivity(i);
            };
        }
    }
}