using AndroidX.RecyclerView.Widget;
using MvvmCross.DroidX.RecyclerView;

namespace AppointmentPlanner.Droid
{
    public class LinkerPleaseInclude
    {
        public void Include(RecyclerView.ViewHolder vh, MvxRecyclerView list)
        {
            vh.ItemView.Click += (sender, args) => { };
            vh.ItemView.LongClick += (sender, args) => { };
            list.ItemsSource = null;
            list.Click += (sender, args) => { };
        }
    }
}