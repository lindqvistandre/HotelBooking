using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelBookingApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Private fields
        private ICommand _Logout;
        private ICommand _SeeAvailableHotels;
        private ICommand _SeeMyBookings;
        #endregion

        #region Constructor
        public MainViewModel()
        {

            SeeAvailableHotels = new CommandHandler(new Action<object>(SeeAvailableHotelsClick));
            SeeMyBookings = new CommandHandler(new Action<object>(SeeMyBookingsClick));
            Logout = new CommandHandler(new Action<object>(LogoutClick));
        }
        #endregion

        #region Public Properties
        public ICommand SeeAvailableHotels
        {
            get => _SeeAvailableHotels;
            set
            {
                _SeeAvailableHotels = value;
                OnPropertyChanged("SeeAvailableHotels");
            }
        }
        public ICommand Logout
        {
            get => _Logout;
            set
            {
                _Logout = value;
                OnPropertyChanged("Logout");
            }
        }
        public ICommand SeeMyBookings
        {
            get => _SeeMyBookings;
            set
            {
                _SeeMyBookings = value;
                OnPropertyChanged("SeeMyBookings");
            }
        }

        #endregion

        #region Command Methods
        private void LogoutClick(object p = null)
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
        private void SeeAvailableHotelsClick(object p = null)
        {

            foreach (Window item in Application.Current.Windows)
            {
                if (item.DataContext == this)
                {
                    Window mainWin = new AvailableHotels();
                    mainWin.Show();

                    item.Close();
                }
            }
        }
        private void SeeMyBookingsClick(object p = null)
        {

            foreach (Window item in Application.Current.Windows)
            {
                if (item.DataContext == this)
                {
                    Window mainWin = new ViewMyBookings();
                    mainWin.Show();

                    item.Close();
                }
            }
        }
        #endregion
    }
}
