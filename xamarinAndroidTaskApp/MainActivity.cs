using Android.App;
using Android.Widget;
using Android.OS;
using Android.Util;
using Android.Content;
using Android.Support.Constraints;
using System;

namespace xamarinAndroidTaskApp
{
    [Activity(Label = "Task App", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {

        readonly string tag = "LGF";

        //----------------------------------------------------------------------------------------------
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button buttonNewTask = FindViewById<Button>(Resource.Id.buttonNewTask);
            buttonNewTask.Click += (sender, args) =>
            {
                ShowNewTaskForm(sender, args);
            };

            Button buttonShowAll = FindViewById<Button>(Resource.Id.buttonShowAll);
            buttonShowAll.Click += (sender, args) =>
            {
                ShowTaskList(sender, args);
            };
        }

        //----------------------------------------------------------------------------------------------
        public void ShowNewTaskForm(object sender, EventArgs e){
            Log.Debug(tag, "click ButtonNewTask");

            Intent intent = new Intent(this, typeof(NewTaskFormActivity));
            StartActivity(intent);
        }

        //----------------------------------------------------------------------------------------------
        public void ShowTaskList(object sender, EventArgs e)
        {
            Log.Debug(tag, "click ButtonShowAll");

            Intent intent = new Intent(this, typeof(TaskListActivity));
            StartActivity(intent);
        }

        //----------------------------------------------------------------------------------------------

    }
    /*END-ACTIVITY*/
}

