# GradientThemeWPF
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
To use the styles in your own project, make sure to import the correct styles in your `App.xaml`:
```Xaml
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

Example of styles for each control is available in the source code.