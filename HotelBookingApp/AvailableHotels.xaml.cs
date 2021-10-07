using DAL;
using HotelBookingApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HotelBookingApp
{
    /// <summary>
    /// Interaction logic for AvailableHotels.xaml
    /// </summary>
    public partial class AvailableHotels : Window
    {
        public AvailableHotels()
        {
            InitializeComponent();
            this.DataContext = new HotelViewModel(0);
        }

        private void ViewRooms_Click(object sender, RoutedEventArgs e)
        {
            if(dgHotels.SelectedItem != null)
            {
                var hotelID = (dgHotels.SelectedItem as HotelInfo).Id;
                ViewHotelRooms rooms = new ViewHotelRooms(hotelID);
                rooms.ShowDialog();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
