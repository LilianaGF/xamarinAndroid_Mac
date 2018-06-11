using System.IO;
using Android.App;
using Android.Util;
using Android.OS;
using SQLite;
using System.Collections.Generic;
using Android.Widget;
using System;
using Android.Support.V7.Widget;

namespace xamarinAndroidTaskApp
{
    [Activity(Label = "TaskListActivity")]
    public class TaskListActivity : Activity
    {
        readonly string tag = "LGF";
        //                                          //path string for the database file
        string dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbTest.db");

        RecyclerView.Adapter listTaskAdapter;
        //----------------------------------------------------------------------------------------------
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_task_list);

            //                                                       // To register the click for buttons.
            Button buttonAll = FindViewById<Button>(Resource.Id.buttonAll);
            buttonAll.Click += (sender, args) => ShowAllTask(sender, args);

            Button buttonToDo = FindViewById<Button>(Resource.Id.buttonToDo);
            buttonToDo.Click += (sender, args) => ShowToDoTask(sender, args);


            Button buttonDoing = FindViewById<Button>(Resource.Id.buttonDoing);
            buttonDoing.Click += (sender, args) => ShowDoingTask(sender, args);

            Button buttonDone = FindViewById<Button>(Resource.Id.buttonDone);
            buttonDone.Click += (sender, args) => ShowDoneTask(sender, args);


        }


        //----------------------------------------------------------------------------------------------
        public void ShowAllTask(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(dbpath);
            var tableTask = db.Table<Task>();
            List<Task> listOfTask = new List<Task>();
            foreach (var row in tableTask)
            {
                Task PersistenceTask = new Task(row.shortDescription, row.longDescription, row.percentage);
                listOfTask.Add(PersistenceTask);
                Log.Debug(tag, "FROM THE DB TASK: " + PersistenceTask.ToString());
            }

            RecyclerView recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerViewTaskList);
            this.listTaskAdapter = new ListTaskAdapter(listOfTask);
            recyclerView.SetAdapter(this.listTaskAdapter);
            LinearLayoutManager manager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(manager);

        }


        //----------------------------------------------------------------------------------------------
        public void ShowToDoTask(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(dbpath);
            var queryToDoTask = db.Query<Task>("SELECT * FROM Task WHERE percentage = ? ", 0);
            List<Task> listOfTask = new List<Task>();
            foreach (var row in queryToDoTask)
            {
                Task PersistenceTask = new Task(row.shortDescription, row.longDescription, row.percentage);
                listOfTask.Add(PersistenceTask);
                Log.Debug(tag, "FROM THE DB TASK: " + PersistenceTask.ToString());
            }
            RecyclerView recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerViewTaskList);
            this.listTaskAdapter = new ListTaskAdapter(listOfTask);
            recyclerView.SetAdapter(this.listTaskAdapter);
            LinearLayoutManager manager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(manager);

        }

        //----------------------------------------------------------------------------------------------
        public void ShowDoingTask(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(dbpath);
            var queryToDoTask = db.Query<Task>("SELECT * FROM Task WHERE percentage > ? AND " +
                                               "percentage < ?", 0, 100);
            List<Task> listOfTask = new List<Task>();
            foreach (var row in queryToDoTask)
            {
                Task PersistenceTask = new Task(row.shortDescription, row.longDescription, row.percentage);
                listOfTask.Add(PersistenceTask);
                Log.Debug(tag, "FROM THE DB TASK: " + PersistenceTask.ToString());
            }

            RecyclerView recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerViewTaskList);
            this.listTaskAdapter = new ListTaskAdapter(listOfTask);
            recyclerView.SetAdapter(this.listTaskAdapter);
            LinearLayoutManager manager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(manager);

        }

        //----------------------------------------------------------------------------------------------
        public void ShowDoneTask(object sender, EventArgs e)
        {

            var db = new SQLiteConnection(dbpath);
            var queryToDoTask = db.Query<Task>("SELECT * FROM Task WHERE percentage = ? ", 100);
            List<Task> listOfTask = new List<Task>();
            foreach (var row in queryToDoTask)
            {
                Task PersistenceTask = new Task(row.shortDescription, row.longDescription, row.percentage);
                listOfTask.Add(PersistenceTask);
                Log.Debug(tag, "FROM THE DB TASK: " + PersistenceTask.ToString());
            }

            RecyclerView recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerViewTaskList);
            this.listTaskAdapter = new ListTaskAdapter(listOfTask);
            recyclerView.SetAdapter(this.listTaskAdapter);
            LinearLayoutManager manager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(manager);

        }

        //----------------------------------------------------------------------------------------------

    }
}
