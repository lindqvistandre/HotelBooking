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
    /// Interaction logic for ViewMyBookings.xaml
    /// </summary>
    public partial class ViewMyBookings : Window
    {
        public ViewMyBookings()
        {
            InitializeComponent();
            this.DataContext = new CustomerViewModel();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((CustomerViewModel)this.DataContext).UpdateBooking(); }
        }

        private void Delete_Row(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((CustomerViewModel)this.DataContext).DeleteBooking(); }
        }
    }
}
