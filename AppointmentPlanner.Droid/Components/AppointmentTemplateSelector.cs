﻿using MvvmCross.DroidX.RecyclerView.ItemTemplates;
using MvvmCross.ExpandableRecyclerView.Core;
using MvvmCross.ExpandableRecyclerView.DroidX;

namespace AppointmentPlanner.Droid.Components
{
    public class AppointmentTemplateSelector : MvxTemplateSelector<ITaskItem>
    {
        public override int GetItemLayoutId(int fromViewType)
        {
            return fromViewType switch
            {
                1 => Resource.Layout.TaskHeader,
                _ => Resource.Layout.PersonItem,
            };
        }

        protected override int SelectItemViewType(ITaskItem forItemObject)
        {
            return forItemObject switch
            {
                ITaskHeader _ => 1,
                _ => -1,
            };
        }
    }
}