using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PrismSampleApp.CustomControl
{
    public class CustomEntryRenderer : Entry
    {
        public static readonly BindableProperty CornerRadiusProperty =
          BindableProperty.Create("CornerRadius", typeof(int), typeof(CustomEntryRenderer), 0);

        public int EntryCornerRadius
        {
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly BindableProperty BorderColorProperty =
          BindableProperty.Create("BorderThickness", typeof(Color), typeof(CustomEntryRenderer), Color.AliceBlue);

        public Color EntryBorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

    }
}