using System;
using Android.Util;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using SQLite;
using System.IO;

namespace xamarinAndroidTaskApp
{
    [Activity(Label = "NewTaskFormActivity")]
    public class NewTaskFormActivity : Activity
    {

        readonly string tag = "LGF";
        int intTaskProgress = 0;
        //                                          //path string for the database file
        string dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbTest.db");

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

            bool boolDone = false;
            int intSeekBarProgress = 0; 


            SeekBar seekBarPercentage = FindViewById<SeekBar>(Resource.Id.seekBarPercentage);
            seekBarPercentage.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) =>
            {
                intSeekBarProgress = e.Progress;
                Log.Debug(tag, "Done: " + boolDone);
                if (boolDone)
                {
                    textPercentage.Text = "100%";
                    intTaskProgress = 100;
                }
                else
                {
                    textPercentage.Text = String.Format("{0}%",intSeekBarProgress);
                    intTaskProgress = intSeekBarProgress;
                }
            };

            Switch switchDone = FindViewById<Switch>(Resource.Id.switchDone);
            switchDone.CheckedChange += (object sender, CompoundButton.CheckedChangeEventArgs e) => 
            {
                if (e.IsChecked)
                {
                    boolDone = true;
                    textPercentage.Text = "100%";
                    intTaskProgress = 100;
                }
                else{
                    boolDone = false;
                    textPercentage.Text = String.Format("{0}%",intSeekBarProgress);
                    intTaskProgress = intSeekBarProgress;
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


            task.percentage = this.intTaskProgress;

            Log.Debug(tag, "TASK: " + task.ToString());


            //                                          //SQLite-net-pcl

            //                                          //setup the db connection
            var db = new SQLiteConnection(dbpath);
            //                                          //setup a table
            db.CreateTable<Task>();
            //                                          //store the task in the table
            db.Insert(task);

            //                                          //acceder a los datos
            var table = db.Table<Task>();
            foreach(var row in table){
                Task PersistenceTask = new Task(row.shortDescription, row.longDescription, row.percentage);
                Log.Debug(tag, "FROM THE DB TASK: " + PersistenceTask.ToString());
            }


              





            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }

        //----------------------------------------------------------------------------------------------
    }
    /*END-ACTIVITY*/
}
