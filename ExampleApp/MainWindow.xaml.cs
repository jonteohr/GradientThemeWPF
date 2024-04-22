using System.Runtime.InteropServices;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using Timer = System.Timers.Timer;

namespace ExampleApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    
    public const int WM_NCLBUTTONDOWN = 0xA1;
    public const int HT_CAPTION = 0x2;
    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();
    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();

    private int m_typeSpeed = 150;
    private int m_timerspeed = 3;
    private bool m_typing;
    
    public string WindowTitle { get; private set; }
    private string[] Titles = 
        [
            "A nice app",
            "App title",
            "Cool title",
            "Useful stuff!",
            "This title changes",
            "Captivating title",
            "Lorem ipsum"
        ];

    public MainWindow()
    {
        WindowTitle = GetRandomTitle();
        
        InitializeComponent();
        DataContext = this;
        
        var timer = new Timer();
        timer.Interval = m_timerspeed * 1000;
        timer.AutoReset = true;
        timer.Elapsed += TimerOnElapsed;
        timer.Enabled = true;
        timer.Start();
    }

    private void TimerOnElapsed(object? sender, ElapsedEventArgs e)
    {
        while (!m_typing)
        {
            m_typing = true;
            for (var i = WindowTitle.Length - 1; i < WindowTitle.Length; i--)
            {
                if (i < 0)
                    break;
            
                WindowTitle = WindowTitle.Remove(i);
                SafeThreadInvoker(() => TitleLabel.Content = WindowTitle);
                Thread.Sleep(m_typeSpeed);
            }

            WindowTitle = GetRandomTitle();

            for (var i = 0; i <= WindowTitle.Length; i++)
            {
                var tmp = WindowTitle.Substring(0, i);
                SafeThreadInvoker(() => TitleLabel.Content = tmp);
                Thread.Sleep(m_typeSpeed);
            }

            break;
        }
        
        m_typing = false;
    }

    private void CloseBtn_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if(e.LeftButton != MouseButtonState.Pressed)
            return;
        
        ReleaseCapture();
        SendMessage(GetForegroundWindow(), WM_NCLBUTTONDOWN, HT_CAPTION, 0);
    }

    private void MinimizeBtn_OnClick(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void SafeThreadInvoker(Action a)
    {
        if (!CheckAccess())
            Dispatcher.Invoke(a);
        else
            a();
    }

    private string GetRandomTitle()
    {
        var rand = new Random();

        var generated = Titles[rand.Next(0, Titles.Length)];
        while (generated == WindowTitle)
            generated = Titles[rand.Next(0, Titles.Length)];

        return generated;
    }
}