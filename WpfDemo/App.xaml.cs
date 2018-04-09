using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfDemo
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        
        protected override void OnStartup(StartupEventArgs e)
        {
            IOCService.Instance.RegisterService("DATA_SERVICE", new DataServer());
            IOCService.Instance.RegisterService("WARN_SERVICE", new WarningService());
            base.OnStartup(e);
        }
    }
}
