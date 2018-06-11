using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;


namespace xamarinAndroidTaskApp
{
    public class TaskHolder: RecyclerView.ViewHolder
    {
        public TextView textView { get; set; }
        public TaskHolder(View itemView)
            :base(itemView)
        {
            textView = itemView.FindViewById<TextView>(Resource.Id.taskItem);
        }
    }
}
