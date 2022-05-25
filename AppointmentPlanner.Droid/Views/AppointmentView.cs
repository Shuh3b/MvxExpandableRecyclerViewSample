using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using AndroidX.RecyclerView.Widget;
using AppointmentPlanner.Core.ViewModels;
using AppointmentPlanner.Droid.Components;
using MvvmCross.ExpandableRecyclerView.DroidX;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views;

namespace AppointmentPlanner.Droid.Views
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class AppointmentView : MvxActivity<AppointmentViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.AppointmentView);

            var expandableRecyclerView = _view.FindViewById<MvxExpandableRecyclerView>(Resource.Id.appointment_recyclerview);
            // Attach our custom adapter.
            expandableRecyclerView.Adapter = new AppointmentRecyclerAdapter((IMvxAndroidBindingContext)BindingContext);
            // Attach our helper class to implement drag and swipe functionality.
            var itemMoveCallback = new ItemTouchHelperCallback(expandableRecyclerView.Adapter);
            var itemTouchHelper = new ItemTouchHelper(itemMoveCallback);
            itemTouchHelper.AttachToRecyclerView(expandableRecyclerView);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}