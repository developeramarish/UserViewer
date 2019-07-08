using Autofac;
using System.Windows;
using UserViewer.Presentation;
using UserViewer.Service;
using UserViewer.Service.Cache;
using UserViewer.Service.Sql;

namespace UserViewer.UI
{
  public partial class App : Application
  {
    private IContainer container;
    private void Application_Startup(object sender, StartupEventArgs e)
    {
      ConfigureInjector();
      Current.MainWindow = container.Resolve<MainWindow>();
      Current.MainWindow.Title = "User Viewer";
      Current.MainWindow.Show();
    }
      
    private void ConfigureInjector()
    {
      var builder = new ContainerBuilder();
      builder.RegisterType<SqlDataService>().Named<IDataService>("dataService").SingleInstance();
      builder.RegisterDecorator<IDataService>((c, inner) => new CacheDataService(inner), fromKey: "dataService");
      builder.RegisterType<UserViewModel>().InstancePerDependency();
      builder.RegisterType<MainWindow>().InstancePerDependency();
      container = builder.Build();
    }
  }
}
