﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace FontAwesome.UWP
{
    public class FontAwesome
        : FontIcon
    {
        private static readonly FontFamily FontAwesomeFontFamily = new FontFamily("ms-appx:///FontAwesome.UWP/FontAwesome.otf#FontAwesome");

        public static readonly DependencyProperty IconProperty = 
            DependencyProperty.Register("Icon", typeof(FontAwesomeIcon), typeof(FontAwesome),
                new PropertyMetadata(FontAwesomeIcon.None, Icon_PropertyChangedCallback));

        private static void Icon_PropertyChangedCallback(DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var fontAwesome = (FontAwesome) dependencyObject;

            var fontToSet = FontAwesomeIcon.None;
            
            if (dependencyPropertyChangedEventArgs.NewValue != null)
                fontToSet = (FontAwesomeIcon)dependencyPropertyChangedEventArgs.NewValue;

            fontAwesome.SetValue(FontFamilyProperty, FontAwesomeFontFamily);
            fontAwesome.SetValue(GlyphProperty, char.ConvertFromUtf32((int)fontToSet));
        }

        public FontAwesome()
        {
            FontFamily = FontAwesomeFontFamily;
        }

        public FontAwesomeIcon Icon
        {
            get { return (FontAwesomeIcon)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
    }
}
