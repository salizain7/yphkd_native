using System;

using System.Reflection;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;

namespace yphkd.Droid
{
    [Activity(ScreenOrientation = ScreenOrientation.Portrait, WindowSoftInputMode = SoftInput.AdjustPan)]
    public abstract class BaseActivity : AppCompatActivity
    {
        private ProgressDialog progressDialog;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetTheme(Resource.Style.DarkTheme);
            base.OnCreate(savedInstanceState);
            SetContentView(SetBaseContent());
            Init();
        }
      
        protected abstract int SetBaseContent();

        protected abstract void Init();
        public override void OnBackPressed()
        {
            base.OverridePendingTransition(Resource.Animation.exit_to_right, Resource.Animation.exit_to_left);
            base.OnBackPressed();
        }
        public void NavigateToActivity(Activity currentActivity, System.Type nextActivity, Bundle bundle, bool needFinish)
        {
            Intent intent = new Intent(currentActivity, nextActivity);
            if (bundle != null)
            {
                intent.PutExtra("DATA", bundle);
            }
            currentActivity.OverridePendingTransition(Resource.Animation.enter_from_right, Resource.Animation.exit_to_left);
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.left_in, Resource.Animation.left_out);
            if (needFinish)
            {
                currentActivity.Finish();
            }
        }
        public ViewGroup.LayoutParams SetAspectRatio(ViewGroup.LayoutParams layoutParams)
        {
            var metrics = Resources.DisplayMetrics;
            var height = (int)(metrics.WidthPixels / 16 * 9);
            layoutParams.Height = height;
            return layoutParams;
        }

        public void InflateFragment(int containerId, global::Android.Support.V4.App.Fragment fragment, Bundle bundle)
        {
            if (fragment == null)
            {
                throw new System.ArgumentNullException(nameof(fragment));
            }

            if (bundle != null)
            {
                fragment.Arguments = bundle;
            }
            global::Android.Support.V4.App.FragmentTransaction ft = SupportFragmentManager.BeginTransaction();
            ft.SetCustomAnimations(Resource.Animation.enter_from_right, Resource.Animation.exit_to_left);
            ft.Replace(containerId, fragment, fragment.Class.Name)
              .AddToBackStack(fragment.Class.SimpleName).Commit();
        }

        public void ReplaceFragment(int containerId, global::Android.Support.V4.App.Fragment fragment, bool IsFadeInOutAnim = false, bool IsBackStackRequired = false)
        {
            global::Android.Support.V4.App.FragmentTransaction fragmentTransaction = SupportFragmentManager.BeginTransaction();
            if (IsFadeInOutAnim)
                fragmentTransaction.SetCustomAnimations(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out);
            if (IsBackStackRequired)
                fragmentTransaction.AddToBackStack(null);
            fragmentTransaction.Replace(containerId, fragment).CommitAllowingStateLoss();

        }

        public void ShowLongToastMessage(string message)
        {
            Toast.MakeText(this, message, ToastLength.Long).Show();
        }

        public void ShowToastMessage(string message)
        {
            Toast.MakeText(this, message, ToastLength.Short).Show();
        }

        public void ShowLoader(bool isCancelable)
        {
            try
            {

                Dialog mDialog = new Dialog(this);
                mDialog.SetContentView(Resource.Layout.loader);
                mDialog.SetCancelable(false);
                mDialog.SetCanceledOnTouchOutside(false);
                mDialog.Show();
                var x = mDialog.FindViewById<ImageView>(Resource.Id.loaderImg);
                Animation animation = AnimationUtils.LoadAnimation(ApplicationContext, Resource.Animation.rotateVerticle);
                
                x.StartAnimation(animation);
            }
            catch (Exception ex)
            {
               
            }
        }

        public void HideLoader()
        {
            try
            {
                if (progressDialog != null && progressDialog.IsShowing)
                {
                    progressDialog.Dismiss();
                    progressDialog = null;
                }
            }
            catch (Exception ex)
            {
                
            }
        }

    }
}