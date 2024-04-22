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
    private string m_windowTitle;
    private string m_lastTitle;
    
    private string[] m_titles;
    public string[] Titles
    {
        get => m_titles;
        set
        {
            m_titles = value;
            Content = m_windowTitle = GetRandomTitle();
        }
    }
    
    public TyperLabel()
    {
        var binding = new Binding("m_windowTitle");
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

            m_lastTitle = m_windowTitle;
            
            for (var i = m_windowTitle.Length - 1; i < m_windowTitle.Length; i--)
            {
                if (i < 0)
                    break;
        
                m_windowTitle = m_windowTitle.Remove(i);
                SafeThreadInvoker(() => Content = m_windowTitle);
                Thread.Sleep(TypeSpeed);
            }

            m_windowTitle = GetRandomTitle();

            for (var i = 0; i <= m_windowTitle.Length; i++)
            {
                var tmp = m_windowTitle.Substring(0, i);
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