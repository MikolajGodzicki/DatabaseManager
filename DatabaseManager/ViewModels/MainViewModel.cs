using DatabaseManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager.ViewModels {
    internal class MainViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _col;
        public string col {
            get => _col;
            set { 
                _col = value; 
                OnPropertyChanged(); 
            }
        }

        private ObservableCollection<Database> databases;
        public ObservableCollection<Database> Databases { get => databases; }

        public MainViewModel() {
            databases = new ObservableCollection<Database> {
                new Database("DB1"),
                new Database("DB2"),
                new Database("DB3"),
                new Database("DB4")
            };
        }

    }
}
