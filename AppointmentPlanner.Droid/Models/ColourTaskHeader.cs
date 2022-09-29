using MvvmCross.ExpandableRecyclerView.DroidX;
using System.Drawing;

namespace AppointmentPlanner.Droid.Models
{
    public class ColourTaskHeader<TModel> : SimpleTaskHeader<TModel>
    {
        public ColourTaskHeader(string name, TModel model) 
            : base(name, model)
        { }

        public Color DefaultColour => Color.White;

        public Color StickyHeaderColour => Color.LightBlue;
    }
}