using System;
using Android.Util;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace xamarinAndroidTaskApp
{
    [Activity(Label = "NewTaskFormActivity")]
    public class NewTaskFormActivity : Activity
    {

        readonly string tag = "LGF";

        //----------------------------------------------------------------------------------------------
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_new_task_form);

            Button buttonCancel = FindViewById<Button>(Resource.Id.buttonCancel);
            buttonCancel.Click += (sender, args) =>
            {
                CancelNewTask(sender, args);
            };

            Button buttonSave = FindViewById<Button>(Resource.Id.buttonSave);
            buttonSave.Click += (sender, args) =>
            {
                SaveNewTask(sender, args);
            };


            // Create your application here
        }

        //----------------------------------------------------------------------------------------------
        public void CancelNewTask(object sender, EventArgs e)
        {
            Log.Debug(tag, "click ButtonCancel");

            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }

        //----------------------------------------------------------------------------------------------
        public void SaveNewTask(object sender, EventArgs e)
        {
            Log.Debug(tag, "click ButtonSave");

            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }

        //----------------------------------------------------------------------------------------------
    }
    /*END-ACTIVITY*/
}
