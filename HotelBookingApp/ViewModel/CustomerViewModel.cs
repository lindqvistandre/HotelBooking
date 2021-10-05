using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DAL;
using HotelBookingApp.Common;

namespace HotelBookingApp.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        private ICommand _LoginCommand;
        private ICommand _OpenRegisterClick;
        private ICommand _OpenLoginClick;
        private ICommand _AddNewUserClick;
        private ICommand _MainMenuClick;
        private string _username;
        private string _password;
        private string _FullName;
        private string _Gender;
        private string _Contact;
        private string _Email;
        private ObservableCollection<Booking> _Bookings;
        private Booking _SelectedBooking;

        #region Constructor
        public CustomerViewModel()
        {
            LoginCommand = new CommandHandler(new Action<object>(Login));
            OpenRegisterClick = new CommandHandler(new Action<object>(OpenRegisterWindow));
            OpenLoginClick = new CommandHandler(new Action<object>(OpenLoginWindow));
            AddNewUserClick = new CommandHandler(new Action<object>(AddNewUser));
            if (Global.Loggeduser != null)
            {
                LoadBookings();
                MainMenuClick = new CommandHandler(new Action<object>(MainMenuClickClick));
            }
        }
        #endregion

        
        private void LoadBookings()
        {
            string url = API_URIs.Booking + "?userId=" + Global.Loggeduser.Id;
            var response = WebApi.GetCall(url);
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Bookings = response.Result.Content.ReadAsAsync<ObservableCollection<Booking>>().Result;
            }
        }
        #region Public Properties
        public ObservableCollection<Booking> Bookings
        {
            get { return _Bookings; }
            set
            {
                _Bookings = value;
                OnPropertyChanged("Bookings");
            }
        }
        public Booking SelectedBooking
        {
            get { return _SelectedBooking; }
            set
            {
                _SelectedBooking = value;
                OnPropertyChanged("SelectedBooking");
            }
        }
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }
        public string Contact
        {
            get { return _Contact; }
            set
            {
                _Contact = value;
                OnPropertyChanged("Contact");
            }
        }
        public string FullName
        {
            get { return _FullName; }
            set
            {
                _FullName = value;
                OnPropertyChanged("FullName");
            }
        }
        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
                OnPropertyChanged("Email");
            }
        }
        public string Gender
        {
            get { return _Gender; }
            set
            {
                _Gender = value;
                OnPropertyChanged("Gender");
            }
        }

        public ICommand LoginCommand
        {
            get { return _LoginCommand; }
            set
            {
                _LoginCommand = value;
                OnPropertyChanged("LoginCommand");
            }
        }
        public ICommand OpenRegisterClick
        {
            get { return _OpenRegisterClick; }
            set
            {
                _OpenRegisterClick = value;
                OnPropertyChanged("OpenRegisterClick");
            }
        }
        public ICommand OpenLoginClick
        {
            get { return _OpenLoginClick; }
            set
            {
                _OpenLoginClick = value;
                OnPropertyChanged("OpenLoginClick");
            }
        }
        public ICommand AddNewUserClick
        {
            get { return _AddNewUserClick; }
            set
            {
                _AddNewUserClick = value;
                OnPropertyChanged("AddNewUserClick");
            }
        }
        public ICommand MainMenuClick
        {
            get => _MainMenuClick;
            set
            {
                _MainMenuClick = value;
                OnPropertyChanged("MainMenuClick");
            }
        }
        #endregion


        #region Command Method
        private void MainMenuClickClick(object p = null)
        {

            foreach (Window item in Application.Current.Windows)
            {
                if (item.DataContext == this)
                {
                    Window mainWin = new MainMenu();
                    mainWin.Show();

                    item.Close();
                }
            }
        }
        private void AddNewUser(object p = null)
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Gender) ||
                string.IsNullOrEmpty(Contact) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(FullName))
            {
                MessageBox.Show("Please provide all details");
                return;
            }
            else
            {
                var _loggedUser = new Customer();
                _loggedUser.Contact = Contact;
                _loggedUser.FullName = FullName;
                _loggedUser.Email = Email;
                _loggedUser.Gender = Gender;
                _loggedUser.Password = Password;
                _loggedUser.Username = Username;
                var response = WebApi.PostCall(API_URIs.customer, _loggedUser);

                if (response.Result.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    MessageBox.Show("Registered Successfullly!");
                    Global.Loggeduser = _loggedUser;
                    foreach (Window item in Application.Current.Windows)
                    {
                        if (item.DataContext == this)
                        {
                            Window mainWin = new MainWindow();
                            mainWin.Show();

                            item.Close();
                        }
                    }

                }
                else
                {
                }

            }

        }
        private void Login(object p = null)
        {
            string url = API_URIs.customer + "?username=" + Username + "&Password=" + Password;
            var response = WebApi.GetCall(url);
            Customer customer = null;
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                customer = response.Result.Content.ReadAsAsync<Customer>().Result;
            }
            if (customer != null)
            {
                Global.Loggeduser = customer;
                foreach (Window item in Application.Current.Windows)
                {
                    if (item.DataContext == this)
                    {
                        Window mainWin = new MainMenu();
                        mainWin.Show();

                        item.Close();
                    }
                }

            }
            else
            {
                MessageBox.Show("User Not Available");
            }

        }
        private void OpenRegisterWindow(object p = null)
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.DataContext == this)
                {
                    Window mainWin = new Register();
                    mainWin.Show();

                    item.Close();
                }
            }
        }
        private void OpenLoginWindow(object p = null)
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.DataContext == this)
                {
                    Window mainWin = new MainWindow();
                    mainWin.Show();

                    item.Close();
                }
            }
        }
        #endregion
        public void DeleteBooking()
        {
            string url = API_URIs.Booking + "?bookingId=" + SelectedBooking.Id;
            var response = WebApi.DeleteCall(url);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("Booking deleted Successfullly!");
                LoadBookings();
            }
        }

        public void UpdateBooking()
        {
            var response = WebApi.PutCall(API_URIs.Booking , SelectedBooking);
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("Booking Updated Successfullly!");
                LoadBookings();
            }
            else
            {
                MessageBox.Show("Error Updating Booking!");
            }
        }

    }
}
