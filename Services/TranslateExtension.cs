﻿using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace MyKaraoke.Services
{
    [ContentProperty(nameof(Key))]
    public class TranslateExtension : IMarkupExtension
    {
        public string Key { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return LocalizationResourceManager.Instance.GetString(Key);
        }
    }
}
