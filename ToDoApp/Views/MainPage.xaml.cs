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
using ToDoApp.Views.ContentDialogs;
using ToDoApp.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ToDoApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to add task frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MainPageViewModel viewModel;
        public MainPage()
        {
            this.InitializeComponent();

            viewModel = new MainPageViewModel();
        }

        public MainPageViewModel ViewModel
        {
            get { return viewModel; }
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddToDoTaskDialog addDialog = new AddToDoTaskDialog();

            ContentDialogResult addDialogResult = await addDialog.ShowAsync();

            //If user pressed button Add then we create new ToDoTask and pass it to ViewModel
            if (addDialogResult == ContentDialogResult.Primary)
            {
                ToDoTask toDoTask = new ToDoTask()
                {
                    Description = addDialog.Description
                };

                ViewModel.AddToDoTask(toDoTask);
            }
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton toggleButton = (ToggleButton)sender;

            if ((bool)toggleButton.IsChecked) toggleButton.Content = "Completed";
            else toggleButton.Content = "Uncompleted";
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (TasksLV.SelectedItems.Count == 0) return;

            viewModel.DeleteToDoTasks(TasksLV.SelectedItems);
        }
    }
}
