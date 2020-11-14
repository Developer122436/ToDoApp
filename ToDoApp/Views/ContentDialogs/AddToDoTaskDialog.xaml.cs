using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ToDoApp.ViewModels;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ToDoApp.Views.ContentDialogs
{
    /// <summary>
    /// An frame where can user add a new task.
    /// </summary>
    public sealed partial class AddToDoTaskDialog : ContentDialog
    {
        public AddToDoTaskDialog()
        {
            this.InitializeComponent();
        }

        public string Description { set; get; }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Description = DescriptionTB.Text;
        }
    }
}
