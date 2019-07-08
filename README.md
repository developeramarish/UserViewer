# UserViewer
This is a tiny app built in a complex way in order to demonstrate best practices and patterns that are followed in enterprise applications. It follows the MVVM architecture where the View is a WPF project (UserViewer.UI), the ViewModel is a class library (UserViewer.Presentation) and the Model is also a class library (UserViewer.Common). The repository pattern is implemented as a class library (UserViewer.Service) which connects to a Web API to fetch data (UserViewer.API). This app demonstrates the usage of dependency injection through Autofac, caching (which implements the decorator pattern) using the standard .NET classes and testing with MS Test projects.

To run this project you first need to create a few environment variables in your system
UserViewer.Service.ApiDataService.Url             -> http://localhost:5000/api/user
UserViewer.Service.CacheDataService.CacheDuration -> 0:0:30
UserViewer.Service.CsvDataService.FilePath        -> Csv\\data.csv
UserViewer.Service.SqlDataService.Connection      -> Data Source=user.db

Then you need to choose which datasource will serve data. The choice is between a csv file, a sqlite database and an api. You make this selection in the UI project -> App.xaml.cs, where dependency injection takes place. If you choose the api, before running the UI project, you need to open a command prompt at the folder level of the api project (UserViewer.API) and run the command 'dotnet run'.
