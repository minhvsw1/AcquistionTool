using AcquistionTool.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace AcquistionTool;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        // InitializeComponent() is called in the constructor to ensure that the XAML resources are loaded before the application starts.
        // This is important for WPF applications to ensure that styles, templates, and other resources are available.        
    }
    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.DataContext = new MainViewModels();
        mainWindow.Show();
        base.OnStartup(e);
    }
}

