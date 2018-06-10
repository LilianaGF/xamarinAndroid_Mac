using System.IO;
using Android.App;
using Android.Util;
using Android.OS;
using SQLite;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;

namespace xamarinAndroidTaskApp
{
    [Activity(Label = "TaskListActivity")]
    public class TaskListActivity : Activity
    {
        readonly string tag = "LGF";
        //                                          //path string for the database file
        string dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbTest.db");

        //----------------------------------------------------------------------------------------------
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_task_list);

            //                                          //Data for the list.
            var db = new SQLiteConnection(dbpath);
            var tableTask = db.Table<Task>();
            List<Task> listOfTask = new List<Task>();
            foreach (var row in tableTask)
            {
                Task PersistenceTask = new Task(row.shortDescription, row.longDescription, row.percentage);
                listOfTask.Add(PersistenceTask);
                Log.Debug(tag, "FROM THE DB TASK: " + PersistenceTask.ToString());
            }

            var listTaskAdapter = new ListTaskAdapter(listOfTask);
            var taskListView = FindViewById<ListView>(Resource.Id.listViewTaskList);
            taskListView.Adapter = listTaskAdapter;





        }
    }
}
