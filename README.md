# GradientThemeWPF [![Build Status](https://jenkins.jonteohr.xyz/job/GRADIENTTHEMEWPF_TRUNK/badge/icon)](https://jenkins.jonteohr.xyz/job/GRADIENTTHEMEWPF_TRUNK)
**NOTE**: This project is currently under development and is not yet complete. Pre-releases are available for download, but they are not stability tested and should not be used in production. 

A WPF theme library with modern and smooth-looking gradient colors. A base foundation for a modern-looking UI!

## Installation
[Use NuGet](https://www.nuget.org/packages/GradientThemeWPF) to acquire the library to your project:

#### .Net CLI:
```cmd
dotnet add package GradientThemeWPF
```
#### Package Manager
```powershell
NuGet\Install-Package GradientThemeWPF
```

## Usage
### Styles
To use the styles in your own project, make sure to import the correct styles in your `App.xaml`:
```xaml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/GradientTheme;component/Theme/Colors.xaml" />
            <ResourceDictionary Source="pack://application:,,,/GradientTheme;component/Theme/Controls.xaml" />
            <ResourceDictionary Source="pack://application:,,,/GradientTheme;component/Theme/Window.xaml" />
            <ResourceDictionary Source="pack://application:,,,/GradientTheme;component/Theme/ControlColors.xaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```
Later in the window you want to be gradient colored, add the style `GradientWindow` to the window.

Example of styles for each control is available in the [example project](ExampleApp).

### Controls
In order to use the custom controls you need to import the "namespace" in the window header, which is quite simple:
```xaml
xmlns:controls="clr-namespace:GradientTheme.Controls;assembly=GradientTheme"
```
Later on the controls can be instantiated by prefixing `<controls:`, for example:
```xaml
<controls:TyperLabel Style="{DynamicResource TitleStyle}" >
    <!-- Important that we supply at least one title, if not we will crash! -->
    <controls:TyperLabel.Titles>
        <x:Array Type="{x:Type sys:String}">
            <sys:String>One Title</sys:String>
            <sys:String>Another Title</sys:String>
            <sys:String>Great Title</sys:String>
        </x:Array>
    </controls:TyperLabel.Titles>
</controls:TyperLabel>
```