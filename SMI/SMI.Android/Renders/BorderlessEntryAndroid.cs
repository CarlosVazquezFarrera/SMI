using SMI.Droid.Renders;
using SMI.UC;
using Xamarin.Forms;
using Android.Content;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(BorderlessEntry), typeof(BorderlessEntryAndroid))]

namespace SMI.Droid.Renders
{

    public class BorderlessEntryAndroid: EntryRenderer
    {
        public BorderlessEntryAndroid(Context context): base(context)
        {
            AutoPackage = false;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Background = null;
            }
        }
    }
}