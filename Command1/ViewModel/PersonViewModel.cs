using Command1.Model;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;



// The view-model is an abstraction of the view exposing public properties and commands.
// Instead of the controller of the MVC pattern, or the presenter of the MVP pattern, MVVM has a binder, which automates communication between the view and its bound properties in the view model. 
// The view model has been described as a state of the data in the model.
// The main difference between the view model and the Presenter in the MVP pattern is that the presenter has a reference to a view, whereas the view model does not. 
// Instead, a view directly binds to properties on the view model to send and receive updates. 
// To function efficiently, this requires a binding technology or generating boilerplate code to do the binding.

// The view-model has no dependencies to the view 
//
//  +------+        +------------+
//  | View | -----> | View-Model |
//  +------+    ^   +------------+
//              |
//              +--- Data Binding

namespace Command1.ViewModel
{
    public class CommandViewModel
    {
        public string Name { get; set; }
        private ICommand updater = null;

        public CommandViewModel()
        {
            Name = "Petter";
        }
        
        public ICommand UpdateCommand
        {
            get
            {
                if( updater == null)
                {
                    updater = new Updater();
                }
                    
                return updater;
            }

            set
            {
                updater = value;
            }
        }
    }
    class Updater : ICommand
    {
        #region ICommand Members  

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            //Your Code 
            MessageBox.Show("Command executed:\n" + parameter);
        }
        #endregion
    }
}
