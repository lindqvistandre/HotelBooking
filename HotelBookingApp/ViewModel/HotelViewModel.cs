using DAL;
using HotelBookingApp.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelBookingApp.ViewModel
{
    public class HotelViewModel : ViewModelBase
    {
        #region Private fields
        private ICommand _MainMenuClick;
        private DateTime _SelectedStartDate;
        private DateTime _SelectedEndDate;
        private Room _SelectedRoom;
        private Extra _SelectedExtra;
        private HotelInfo _SelectedHotel;
        private ObservableCollection<Extra> _Extras;
        private ObservableCollection<HotelInfo> _Hotels;
        private ObservableCollection<Room> _Rooms;
        #endregion

        #region Constructor
        public HotelViewModel(int hotelId)
        {
            MainMenuClick = new CommandHandler(new Action<object>(MainMenuClickClick));
            if (hotelId != null && hotelId > 0)
                LoadHotelRooms(hotelId);
            else
                LoadHotels();
        }
        #endregion

        #region private methods
        private void LoadHotels()
        {
            string url = API_URIs.hotel;
            var response = WebApi.GetCall(url);
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Hotels = response.Result.Content.ReadAsAsync<ObservableCollection<HotelInfo>>().Result;
            }
        }

        private void LoadHotelRooms(int hotelId)
        {
            string url = API_URIs.Room + "?hotelId=" + hotelId;
            var response = WebApi.GetCall(url);
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Rooms = response.Result.Content.ReadAsAsync<ObservableCollection<Room>>().Result;
            }

            url = API_URIs.Extra;
            response = WebApi.GetCall(url);
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Extras = response.Result.Content.ReadAsAsync<ObservableCollection<Extra>>().Result;
            }

        }
        #endregion

        #region Public Properties
        public ICommand MainMenuClick
        {
            get => _MainMenuClick;
            set
            {
                _MainMenuClick = value;
                OnPropertyChanged("MainMenuClick");
            }
        }
        public ObservableCollection<HotelInfo> Hotels
        {
            get => _Hotels;
            set
            {
                _Hotels = value;
                OnPropertyChanged("Hotels");
            }
        }
        public ObservableCollection<Room> Rooms
        {
            get => _Rooms;
            set
            {
                _Rooms = value;
                OnPropertyChanged("Rooms");
            }
        }
        public DateTime SelectedEndDate
        {
            get => _SelectedEndDate;
            set
            {
                _SelectedEndDate = value;
                OnPropertyChanged("SelectedEndDate");
            }
        }
        public DateTime SelectedStartDate
        {
            get => _SelectedStartDate;
            set
            {
                _SelectedStartDate = value;
                OnPropertyChanged("SelectedStartDate");
            }
        }
        public Room SelectedRoom
        {
            get => _SelectedRoom;
            set
            {
                _SelectedRoom = value;
                OnPropertyChanged("SelectedRoom");
            }
        }
        public Extra SelectedExtra
        {
            get => _SelectedExtra;
            set
            {
                _SelectedExtra = value;
                OnPropertyChanged("SelectedExtra");
            }
        }
        public HotelInfo SelectedHotel
        {
            get => _SelectedHotel;
            set
            {

                _SelectedHotel = value;
                OnPropertyChanged("SelectedHotel");
            }
        }
        public ObservableCollection<Extra> Extras
        {
            get => _Extras;
            set
            {

                _Extras = value;
                OnPropertyChanged("Extras");
            }
        }

        #endregion

        #region Command Methods
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

        public void CreateBooking()
        {
            if (SelectedStartDate < DateTime.Now)
            {
                MessageBox.Show("Please select Valid Start Date");
                return;
            }
            if (SelectedEndDate < DateTime.Now || SelectedEndDate < SelectedStartDate)
            {
                MessageBox.Show("Please select Valid End Date");
                return;
            }

            Booking booking = new Booking();
            booking.RoomId = SelectedRoom.Id;
            booking.HotelId = SelectedRoom.HotelId;
            booking.StartDate = SelectedStartDate;
            booking.EndDate = SelectedEndDate;
            booking.BookingDays = (int)(SelectedEndDate - SelectedStartDate).TotalDays;
            booking.CustomerId = Global.Loggeduser.Id;
            booking.TotalCharges = SelectedRoom.PricePerNight * booking.BookingDays;

            if (SelectedExtra != null)
            {
                booking.TotalCharges += SelectedExtra.Price;
                booking.Extras = SelectedExtra.ExtraDescription;
            }
            var response = WebApi.PostCall(API_URIs.Booking, booking);


            MessageBox.Show("Booking Created Successfullly!");

        }
        #endregion
    }
}

