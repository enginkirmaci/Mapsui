using System;
using System.IO;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Mapsui.Providers.Wms;
using Mapsui.Samples.Avalonia;
using Mapsui.Samples.Common;
using Mapsui.Samples.Common.Helpers;
using Mapsui.Samples.Common.Maps;
using Mapsui.Samples.CustomWidget;
using Mapsui.Utilities;

namespace Mapsui.UI.Avalonia.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            // Hack to tell the platform independent samples where the files can be found on Android.
            MbTilesSample.MbTilesLocation = MbTilesLocationOnUwp;
            MbTilesHelper.DeployMbTilesFile(s => File.Create(Path.Combine(MbTilesLocationOnUwp, s)));

            MapControl.Map.Layers.Add(OpenStreetMap.CreateTileLayer());
            MapControl.Map.RotationLock = false;
            MapControl.UnSnapRotationDegrees = 30;
            MapControl.ReSnapRotationDegrees = 5;
            MapControl.Renderer.WidgetRenders[typeof(Samples.CustomWidget.CustomWidget)] = new CustomWidgetSkiaRenderer();

            CategoryComboBox.SelectionChanged += CategoryComboBoxSelectionChanged;

            FillComboBoxWithCategories();
            FillListWithSamples();
        }

        private MapControl MapControl => this.FindControl<MapControl>("MapControl");
        private ComboBox CategoryComboBox => this.FindControl<ComboBox>("CategoryComboBox");
        private TextBlock FeatureInfo => this.FindControl<TextBlock>("FeatureInfo");
        private StackPanel SampleList => this.FindControl<StackPanel>("SampleList");
        private Slider RotationSlider => this.FindControl<Slider>("RotationSlider");
        

        private void FillComboBoxWithCategories()
        {
            var categories = AllSamples.GetSamples().Select(s => s.Category).Distinct().OrderBy(c => c);
            ////foreach (var category in categories)
            ////{
            ////    CategoryComboBox.Items?.Add(category);
            ////}

            CategoryComboBox.Items = categories;

            CategoryComboBox.SelectedIndex = 1;
        }

        private void MapOnInfo(object? sender, MapInfoEventArgs args)
        {
            if (args.MapInfo?.Feature != null)
                FeatureInfo.Text = $"Click Info:{Environment.NewLine}{args.MapInfo.Feature.ToDisplayText()}";
        }

        private void FillListWithSamples()
        {
            var selectedCategory = CategoryComboBox.SelectedItem?.ToString() ?? "";
            SampleList.Children.Clear();
            foreach (var sample in AllSamples.GetSamples().Where(s => s.Category == selectedCategory))
                SampleList.Children.Add(CreateRadioButton(sample));
        }
        
        private void CategoryComboBoxSelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            FillListWithSamples();
        }

        private IControl CreateRadioButton(ISample sample)
        {
            var radioButton = new RadioButton
            {
                FontSize = 16,
                Content = sample.Name,
                Margin = new Thickness(4)
            };

            radioButton.Click += (s, a) =>
            {
                MapControl.Map.Layers.Clear();
                MapControl.Info -= MapOnInfo;
                sample.Setup(MapControl);
                MapControl.Info += MapOnInfo;
                MapControl.Refresh();
            };

            return radioButton;
        }

        private static string MbTilesLocationOnUwp => ApplicationData.Current.LocalFolder.Path;

        private void RotationSlider_OnValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            var percent = RotationSlider.Value / (RotationSlider.Maximum - RotationSlider.Minimum);
            MapControl.Navigator.RotateTo(percent * 360);
            MapControl.Refresh();
        }
    }
}