using System;
using Android.Content;
using Android.Widget;
using Android.Views;
using System.Collections.Generic;
using Android.Provider;
using Android.App;
using Java.Lang;
using Android.Util;


namespace xamarinAndroidTaskApp
{
    public class ListTaskAdapter: BaseAdapter
    {
        List<Task> listOfTask;

        public ListTaskAdapter(List<Task> listOfTask)
        {
            this.listOfTask = listOfTask;
        }

        public override int Count {
            get { return listOfTask.Count; }
        }
        public override long GetItemId(int position)
        {
            throw new NotImplementedException();
        }
        public override Java.Lang.Object GetItem(int position)
        {
            throw new NotImplementedException();
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            var view = inflater.Inflate(Resource.Layout.single_task_item, parent, false);

            var textView = view.FindViewById<TextView>(Resource.Id.taskItem);
            Task task = listOfTask[position];
            textView.Text = task.shortDescription + " " + task.percentage + "%"; 
           
            return view;


        }

    }
}
