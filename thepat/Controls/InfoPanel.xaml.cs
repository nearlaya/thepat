using BusinessLogic.Models;
using System.Windows;
using System.Windows.Controls;

namespace thepat.Controls
{
    /// <summary>
    /// Interaction logic for InfoPanel.xaml
    /// </summary>
    public partial class InfoPanel : UserControl
    {
        #region ctor

        public InfoPanel()
        {
            InitializeComponent();
        }

        #endregion

        #region Source property

        public DisplayGroupedData Source
        {
            get { return (DisplayGroupedData)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register(nameof(Source), typeof(DisplayGroupedData), typeof(InfoPanel), new PropertyMetadata(null, SourcePropertyChanged));

        #endregion

        #region private methods

        private static void SourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as InfoPanel;
            if (control is null)
            {
                return;
            }

            var value = e.NewValue as DisplayGroupedData;
            if (value is null)
            {
                return;
            }

            control.TitleTextBlock.Text = value.TitleValue != null ? value.TitleValue.ToUpper() : null;
            control.ItemsControl.ItemsSource = value.ListValues;
        }

        #endregion
    }
}
