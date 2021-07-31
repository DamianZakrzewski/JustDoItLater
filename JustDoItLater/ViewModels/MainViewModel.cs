using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using JustDoItLater.Model;
using JustDoItLater.UserControls;

namespace JustDoItLater.ViewModels
{
    public sealed class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel(AppDbContext context)
        {
            _context = context;
            CurrentDate = DateTime.Now.Date;

            AddCommand = new Command(() =>
            {
                Selected = null;
                Selected = new TDViewControl(new ToDo() { Date = CurrentDate.Date });
            });

            SaveCommand = new Command(() =>
            {
                if (Selected?.ToDo.Id == 0)
                    _context.ToDos.Add(Selected.ToDo);

                _context.SaveChangesAsync();
                UpdateProperty(nameof(ToDos));
            });

            DeleteCommand = new Command(() =>
            {
                if (Selected == null) return;
                _context.Entry(Selected.ToDo).State = Selected.IsEnabled
                    ? Microsoft.EntityFrameworkCore.EntityState.Deleted
                    : Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                Selected.IsEnabled = !Selected.IsEnabled;
            });
        }

        private AppDbContext _context;
        private DateTime currentDate;
        private TDViewControl selected = null;

        public event PropertyChangedEventHandler PropertyChanged;

        private bool Set<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value)) return false;
            storage = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }

        private void UpdateProperty([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DateTime CurrentDate
        {
            get
            {
                return currentDate;
            }
            set
            {
                if (Set(ref currentDate, value))
                {
                    UpdateProperty(nameof(ToDos));
                }
            }
        }

        public List<TDViewControl> ToDos => _context.ToDos.Where(t => t.Date.Date.Equals(currentDate)).Select(t => new TDViewControl(t)).ToList();

        public TDViewControl Selected
        {
            get { return selected; }
            set { Set(ref selected, value); }
        }

        public ICommand AddCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }
    }
}