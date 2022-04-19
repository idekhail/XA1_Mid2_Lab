using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace XA_Mid2_Lab_Re
{
    [Activity(Label = "NewContactActivity")]
    public class NewContactActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_newcontact);

            MySqliteDBRE sq = new MySqliteDBRE();

            EditText name = FindViewById<EditText>(Resource.Id.name);
            EditText mobile = FindViewById<EditText>(Resource.Id.mobile);

            Button add = FindViewById<Button>(Resource.Id.add);
            Button cancel = FindViewById<Button>(Resource.Id.cancel);

            add.Click += delegate
            {
                if (name.Text != "" && mobile.Text != "")
                {
                    var sq = new MySqliteDBRE();                    
                    var contact = new MySqliteDBRE.Contacts()
                    {
                        Name = name.Text,
                        Mobile = mobile.Text,
                    };                     
                    sq.Insert(contact);
                    Intent i = new Intent(this, typeof(MainActivity));
                    StartActivity(i);                    
                }
                else
                {
                    Toast.MakeText(this, " UserName or Password is empty", ToastLength.Short).Show();
                }
            };

            cancel.Click += delegate
            {
                Intent i = new Intent(this, typeof(MainActivity));
                StartActivity(i);
            };
        }
    }
}