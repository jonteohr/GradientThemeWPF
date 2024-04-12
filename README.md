# WPFGradientApp
A basic example of a WPF app with gradient visuals. Used by me as a template for future projects

## Usage
To use the styles in your own project, make sure to import the correct styles in your `App.xaml`:
```Xaml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="Styles/Colors.xaml" />
            <ResourceDictionary Source="Styles/Controls.xaml" />
            <ResourceDictionary Source="Styles/Window.xaml" />
            <ResourceDictionary Source="Styles/ControlColors.xaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```