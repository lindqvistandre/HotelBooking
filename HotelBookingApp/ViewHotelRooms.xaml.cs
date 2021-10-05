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
    /// Interaction logic for ViewHotelRooms.xaml
    /// </summary>
    public partial class ViewHotelRooms : Window
    {
        public ViewHotelRooms(int hotelId)
        {
            InitializeComponent();
            this.DataContext = new HotelViewModel(hotelId);
        }

        private void Book_Room(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((HotelViewModel)this.DataContext).CreateBooking(); }
        }
    }
}
