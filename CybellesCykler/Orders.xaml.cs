using Business;
using Entities;
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

namespace CybellesCykler
{
    /// <summary>
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders : Window
    {
        DataController controller = new DataController(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CybellesCykler.S2Eksamen;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        List<Order> ordersList;

        public Orders()
        {
            InitializeComponent();
            ordersList = controller.GetEntities("Order").OfType<Order>().ToList();
            lbx_Orders.ItemsSource = ordersList;
            lbx_Orders.Items.Refresh();
        }

        private void lbx_Orders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbl_rentee.Content = "Lejer: " + ordersList[lbx_Orders.SelectedIndex].Rentee.Name;
            lbl_address.Content = "Addresse: " + ordersList[lbx_Orders.SelectedIndex].Rentee.Address;
            lbl_phoneNumber.Content = "Telefon: " + ordersList[lbx_Orders.SelectedIndex].Rentee.PhoneNumber;
            lbl_rentDate.Content = "Udlånsdato: " + ordersList[lbx_Orders.SelectedIndex].RentDate.Date;
            lbl_delivaryDate.Content = "Afleveringsdato: " + ordersList[lbx_Orders.SelectedIndex].DeliveryDate.Date;
            lbl_bike.Content = "Cykel: " + ordersList[lbx_Orders.SelectedIndex].Bike.Kind;
            txb_bikeDescription.Text = "" + ordersList[lbx_Orders.SelectedIndex].Bike.BikeDescription;
        }
    }
}
