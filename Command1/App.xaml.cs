using Command1.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Command1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            View.CommandView person = new View.CommandView();               // Create the view   

            CommandViewModel personViewModel = new CommandViewModel();      // Create the view-model
            person.DataContext = personViewModel;                           // Set the default source for data-bindings for the view to the view-model

            person.Show();                                                  // Launch the view
        }
    }
}
