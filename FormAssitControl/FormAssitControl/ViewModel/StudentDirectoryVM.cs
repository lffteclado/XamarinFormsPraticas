using FormAssitControl.Model.Entities;
using FormAssitControl.Model.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormAssitControl.ViewModel
{
    public class StudentDirectoryVM:ObservableBaseObject
    {
        public ObservableCollection<Student> Students { get; set; }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        public Command LoadDirectoryCommand
        {
            get;
            set;
        }

        public StudentDirectoryVM()
        {
            Students = new ObservableCollection<Student>();
            IsBusy = false;
            LoadDirectoryCommand = new Command((obj) => LoadDirectory());
        }

        async void LoadDirectory()
        {
            if (!IsBusy)
            {
                IsBusy = true;

                await Task.Delay(10000);

                var loadedDirectory = StudentDirectoryService.LoadStudentDirectory();

                foreach (var student in loadedDirectory.Students)
                {
                    Students.Add(student);
                }

                IsBusy = false;
            }
        }
    }
}
