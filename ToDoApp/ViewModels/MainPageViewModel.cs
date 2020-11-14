using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        ObservableCollection<ToDoTask> _toDoTasks;
        public static MainPageViewModel Instance { private set; get; }
        public ObservableCollection<ToDoTask> ToDoTasks { get { return _toDoTasks; } }

        public MainPageViewModel()
        {
            _toDoTasks = new ObservableCollection<ToDoTask>();
            Instance = this;
        }

        public void AddToDoTask(ToDoTask toDoTask)
        {
            if (_toDoTasks.Count == 0) toDoTask.Index = 1;
            else
            {
                var maxIndex = _toDoTasks.Last().Index; 

                toDoTask.Index = maxIndex + 1;
            }

            _toDoTasks.Add(toDoTask);
        }

        public void DeleteToDoTasks(IList<object> toDoTasks)
        {
            List<ToDoTask> newToDoTaskList = new List<ToDoTask>();

            if (toDoTasks.Count == 1)
            {
                ToDoTask removableToDoTask = (ToDoTask)toDoTasks.First();

                _toDoTasks.Remove(removableToDoTask);

                //This LINQ request creates new list that do not contains removed ToDoTask. Also this LINQ sets new indexes of not deleted tasks
                newToDoTaskList = _toDoTasks.Select(toDoTask =>
                {
                    if (toDoTask.Index > removableToDoTask.Index)
                    {
                        toDoTask.Index--;
                        return toDoTask;
                    }
                    else return toDoTask;
                }).ToList();
            }
            else
            {
                int newIndex = 1;

                //This LINQ request creates new list that do not contains ToDoTasks that need to be removed. Also this LINQ sets new indexes of not deleted tasks
                newToDoTaskList = _toDoTasks.Where(toDoTask => !toDoTasks.Contains(toDoTask)).
                    Select(toDoTask =>
                    {
                        toDoTask.Index = newIndex;

                        newIndex++;

                        return toDoTask;
                    }).ToList();
            }

            _toDoTasks.Clear(); //Clearing current to do task

            //Filling list of task with items that were not deleted(this items are with new indexes)
            foreach (ToDoTask toDoTask in newToDoTaskList)
            {
                _toDoTasks.Add(toDoTask);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
