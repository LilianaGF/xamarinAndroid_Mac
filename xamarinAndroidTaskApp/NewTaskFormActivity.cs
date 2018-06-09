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
        int intPercentage = 0;

        //----------------------------------------------------------------------------------------------
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_new_task_form);

            Log.Debug(tag, "OnCreate() method");

            //                                                       // To register the click for buttons.
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

            TextView textPercentage = FindViewById<TextView>(Resource.Id.textPercentage);

            String srtPercentage = "0%";
            bool boolDone = false;

            SeekBar seekBarPercentage = FindViewById<SeekBar>(Resource.Id.seekBarPercentage);
            seekBarPercentage.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) =>
            {
                intPercentage = e.Progress;
                srtPercentage = intPercentage + "%";
                Log.Debug(tag, "como esta done " + boolDone);
                if (boolDone)
                {
                    textPercentage.Text = string.Format("100%");
                }
                else
                {
                    textPercentage.Text = srtPercentage;
                }
            };

            Switch switchDone = FindViewById<Switch>(Resource.Id.switchDone);
            switchDone.CheckedChange += (object sender, CompoundButton.CheckedChangeEventArgs e) => 
            {
                if (e.IsChecked)
                {
                    boolDone = true;
                    textPercentage.Text = string.Format("100%");
                }
                else{
                    boolDone = false;
                    textPercentage.Text = srtPercentage;
                }
            };


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

            Task task = new Task();

            TextView shortDescription = FindViewById<TextView>(Resource.Id.textShortDescrip);
            task.shortDescription = shortDescription.Text;

            TextView longDescription = FindViewById<TextView>(Resource.Id.textLongDescrip);
            task.longDescription = longDescription.Text;


            task.percentage = this.intPercentage;

            Log.Debug(tag, "TASK: " + task.ToString());

            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }

        //----------------------------------------------------------------------------------------------
    }
    /*END-ACTIVITY*/
}
