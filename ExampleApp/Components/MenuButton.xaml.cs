using System.Windows.Media.Imaging;

namespace WPFGradientApp.Components;

public enum Icons
{
    Hamburger,
    Bulb
}

public partial class MenuButton
{
    private Icons m_iconType;
    public Icons IconType
    {
        get => m_iconType;
        set
        {
            switch (value)
            {
                case Icons.Hamburger:
                    IconHolder.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/hamburger.png"));
                    break;
            }

            m_iconType = value;
        }
    }

    public string Header
    {
        get => Header;
        set
        {
            Title.Content = value;
        }
    }

    public MenuButton()
    {
        InitializeComponent();
    }
}