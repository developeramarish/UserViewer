# UserViewer
This is a tiny app built in a complex way in order to demonstrate best practices and patterns that are followed in enterprise applications. It follows the MVVM architecture where the View is a WPF project (UserViewer.UI), the ViewModel is a class library (UserViewer.Presentation) and the Model is also a class library (UserViewer.Common). The repository pattern is implemented as a class library (UserViewer.Service) which can connect to a Web API/CSV file/SQLITE db to fetch data. This app demonstrates the usage of dependency injection through Autofac, caching (which implements the decorator pattern) using the standard .NET classes and testing with MS Test projects.

The flow of execution inside the app is like this
UserViewer.UI -> UserViewer.Presentation -> UserViewer.Service -> Data Source

If you run the project as it is, the Sqlite file as the data source by default. To change this go to the ConfigureInjector method of UI project -> App.xaml.cs (this is where dependency injection takes place) and register another data source. The other choices are a csv file and the web api. If you choose the api, before running the UI project, you need to open a command prompt at the folder level of the api project (UserViewer.API) and run the command 'dotnet run'.
