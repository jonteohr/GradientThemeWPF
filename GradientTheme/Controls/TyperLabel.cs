using System.Timers;
using Timer = System.Timers.Timer;
using System.Windows.Controls;
using System.Windows.Data;

namespace GradientTheme.Controls;

public class TyperLabel : Label
{
    private const int TypeSpeed = 150;
    private const int TimerSpeed = 3;
    private bool m_typing;
    private string WindowTitle { get; set; }
    private string m_lastTitle;
    
    private string[] m_titles;
    public string[] Titles
    {
        get => m_titles;
        set
        {
            m_titles = value;
            Content = WindowTitle = GetRandomTitle();
        }
    }
    
    public TyperLabel()
    {
        var binding = new Binding("WindowTitle");
        BindingOperations.SetBinding(this, TyperLabel.ContentProperty, binding);
        
        var timer = new Timer();
        timer.Interval = TimerSpeed * 1000;
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

            m_lastTitle = WindowTitle;
            
            for (var i = WindowTitle.Length - 1; i < WindowTitle.Length; i--)
            {
                if (i < 0)
                    break;
        
                WindowTitle = WindowTitle.Remove(i);
                SafeThreadInvoker(() => Content = WindowTitle);
                Thread.Sleep(TypeSpeed);
            }

            WindowTitle = GetRandomTitle();

            for (var i = 0; i <= WindowTitle.Length; i++)
            {
                var tmp = WindowTitle.Substring(0, i);
                SafeThreadInvoker(() => Content = tmp);
                Thread.Sleep(TypeSpeed);
            }

            break;
        }
        
        m_typing = false;
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

        string generated;
        do
        {
            generated = Titles[rand.Next(0, Titles.Length)];
        }
        while (generated == m_lastTitle);

        return generated;
    }
}