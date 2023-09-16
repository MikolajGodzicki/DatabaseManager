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
using System.Data.SqlClient;
using DatabaseManager.Utils;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Windows.Input;
using DatabaseManager.Commands;
using DatabaseManager.Views;

namespace DatabaseManager.ViewModels {
    internal class MainViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand ShowLoginWindowCommand { get; set; }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _col = String.Empty;
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
            databases = InitDatabases();

            ShowLoginWindowCommand = new RelayCommand(ShowLoginWindow, CanShowLoginWindow);
        }

        private ObservableCollection<Database> InitDatabases() {
            SqlClient sqlClient = new SqlClient();
            ObservableCollection<Database> list = new ObservableCollection<Database>();
            MySqlDataReader reader;

            using (MySqlCommand sqlCommand = new MySqlCommand(Queries.GET_DATABASES_NAMES, sqlClient.connection)) {
                reader = sqlCommand.ExecuteReader();

                while (reader.Read()) {
                    list.Add(new Database(reader.GetValue(0).ToString()));
                }
            }

                
            return list;
        }

        private bool CanShowLoginWindow(object obj) {
            return true;
        }

        private void ShowLoginWindow(object obj) {
            LoginView loginView = new LoginView();
            loginView.Show();
        }

    }
}
