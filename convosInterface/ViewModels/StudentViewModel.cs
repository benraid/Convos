using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Library.Convos.Models;
using Library.Convos.Services;

namespace MAUI.Convos.ViewModels;

internal class StudentViewModel : INotifyPropertyChanged
{
    private StudentService studentService;
    public event PropertyChangedEventHandler? PropertyChanged;

    public Person SelectedStudent { get; set; }

    public string Query { get; set; }

    public ObservableCollection<Person> Students //display students of current student service
    {
        get
        {
            return new ObservableCollection<Person>(studentService.Students);
        }
    }

    public ObservableCollection<Person> SearchResults //display students of search
    {
        get 
        {
            int query = int.Parse(Query);
            if (query > 0)
            {
                List<Person> results = studentService.FindPeople(query);
                return new ObservableCollection<Person>(results);
            }
            else
                return new ObservableCollection<Person>();
        }
    }

    private void NotifyPropertyChanged([CallerMemberName] String property = "") // refresh page when property changed
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }

    public void Refresh() { NotifyPropertyChanged(nameof(SearchResults)); NotifyPropertyChanged(nameof(Students)); } // refresh the View


    public StudentViewModel()
    {
        if (SelectedStudent == null)
            SelectedStudent = new Person();
        if (Query == null)
            Query = "0";
        studentService = StudentService.Current;
        Refresh();
    }
}