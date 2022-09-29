using AppointmentPlanner.Droid.Models;
using MvvmCross.ExpandableRecyclerView.DroidX;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using System;
using System.Collections.Generic;

namespace AppointmentPlanner.Droid.Components
{
    public class AppointmentRecyclerAdapter : MvxExpandableRecyclerAdapter<DateTime?>
    {
        public AppointmentRecyclerAdapter()
        { }

        public AppointmentRecyclerAdapter(IMvxAndroidBindingContext bindingContext) 
            : base(bindingContext)
        { }

        protected override IEnumerable<DateTime?> AddInitialHeaders()
        {
            // You can add headers here, even if there will be no items associated to it initially.
            return new List<DateTime?>
            {
                DateTime.MinValue,
                DateTime.Today,
            };
        }
        protected override ITaskHeader GenerateHeader(DateTime? model)
        {
            // You can define custom logic here to name, collapse and/or set rules to headers when they are generated.

            if (model == null || model == DateTime.MinValue)
            {
                return new ColourTaskHeader<DateTime?>("Unplanned", DateTime.MinValue)
                {
                    // This will show the header as collapsed, instead of expanded, when the view initially loads.
                    IsCollapsed = true,
                    // This adds custom rules for headers to define how the items under them behave.
                    Rules = TaskHeaderRule.SwipeLeftDisabled | TaskHeaderRule.SwipeRightDisabled | TaskHeaderRule.DragInDisabled,
                };
            }

            // This if statement groups items with varying days into one header.
            var twoDaysAfterToday = DateTime.Today.AddDays(2);
            if (model?.Date >= twoDaysAfterToday && model?.Date < DateTime.Today.AddDays(5))
            {
                return new ColourTaskHeader<DateTime?>($"{twoDaysAfterToday.ToShortDateString()} - {DateTime.Today.AddDays(4).ToShortDateString()}", twoDaysAfterToday);
            }

            var header = new ColourTaskHeader<DateTime?>(model?.Date.ToShortDateString(), model);

            // This if statement adds custom header rules to headers with dates that occur 6 days after today.
            if (model?.Date >= DateTime.Today.AddDays(6))
            {
                header.IsCollapsed = true;
                header.Rules = TaskHeaderRule.Temporary;
            }

            return header;
        }
    }
}