# UserViewer
This is a tiny app built in a complex way in order to demonstrate best practices and patterns that are followed in enterprise applications.
It follows the MVVM architecture where the View is a WPF project (UserViewer.UI), the ViewModel is a class library (UserViewer.Presentation)
and the Model is also a class library (UserViewer.Common). The repository pattern is implemented as a class library (UserViewer.Service)
which connects to a Web API to fetch data (UserViewer.API). This app demonstrates the usage of dependency injection through Autofac, caching
using the standard .NET classes and testing with MS Test projects.
