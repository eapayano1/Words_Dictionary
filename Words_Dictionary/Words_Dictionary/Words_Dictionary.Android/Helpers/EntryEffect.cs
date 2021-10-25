using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordsDictionary.Droid.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("MyCompany")]
[assembly: ExportEffect(typeof(WordsDictionary.Droid.Helpers.EntryEffect), nameof(EntryEffect))]
namespace WordsDictionary.Droid.Helpers
{
    public class EntryEffect : PlatformEffect
    {
        Android.Graphics.Color originalBackgroundColor = new Android.Graphics.Color(0, 0, 0, 0);
        Android.Graphics.Color backgroundColor;

        protected override void OnAttached()
        {
            if (this.Control != null)
            {
                try
                {
                    backgroundColor = Android.Graphics.Color.LightGray;
                    Control.SetBackgroundColor(backgroundColor);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
                }
            }
            
        }
        protected override void OnDetached()
        {
           
        }
        protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
            try
            {
                if (args.PropertyName == "IsFocused")
                {
                    if (((Android.Graphics.Drawables.ColorDrawable)Control.Background).Color == backgroundColor)
                    {
                        Control.SetBackgroundColor(originalBackgroundColor);
                    }
                    else
                    {
                        Control.SetBackgroundColor(backgroundColor);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

    }
}