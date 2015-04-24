using SymbolExplorer.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SymbolExplorer.Controls
{
    /// <summary>
    /// Interaction logic for EnumText.xaml
    /// </summary>
    public partial class EnumText : UserControl
    {
        public static readonly DependencyProperty EnumValuesProperty = DependencyProperty.Register(
          "Value", typeof(Enum), typeof(EnumText), new PropertyMetadata(null, new PropertyChangedCallback(Value_PropertyChanged)));

        public Enum Value
        {
            get
            {
                return (Enum)GetValue(EnumValuesProperty);
            }
            set
            {
                SetValue(EnumValuesProperty, value);
            }
        }

        public EnumText()
        {
            InitializeComponent();
        }

        private void Value_PropertyChanged()
        {
            Container.Children.Clear();

            if (Value != null)
            {
                Type enumType = Value.GetType();

                var values = Enum.GetValues(enumType);

                foreach (Enum enumVal in values)
                {
                    if (enumVal.IsDisplayable() && Value.HasFlagMasked(enumVal))
                    {
                        if (Container.Children.Count > 0)
                        {
                            Container.Children.Add(new TextBlock() { Text = Properties.LocalisedResources.EnumText_Separator });
                        }

                        var nameAttr = enumVal.GetAttributeOfType<EnumDisplayNameAttribute>();
                        var descAttr = enumVal.GetAttributeOfType<DescriptionAttribute>();

                        Container.Children.Add(new TextBlock() {
                            Text = nameAttr != null ? nameAttr.DisplayName : enumVal.ToString(),
                            ToolTip = descAttr != null ? descAttr.Description : enumVal.ToString()
                        });
                    }
                }
            }
        }

        private static void Value_PropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            ((EnumText)obj).Value_PropertyChanged();
        }
    }
}
