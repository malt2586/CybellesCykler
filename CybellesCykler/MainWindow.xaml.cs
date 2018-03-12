using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Business;
using Entities;

namespace CybellesCykler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataController controller = new DataController(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CybellesCykler.S2Eksamen;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        List<IPersistable> datagridList;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnShowRentees_Click(object sender, RoutedEventArgs e)
        {
            datagridList = controller.GetEntities("Rentee");
            DtgSelected.ItemsSource = datagridList.OfType<Rentee>();
            DtgSelected.Items.Refresh();
        }

        private void BtnShowBikes_Click(object sender, RoutedEventArgs e)
        {
            datagridList = controller.GetEntities("Bike");
            DtgSelected.ItemsSource = datagridList.OfType<Bike>();
            DtgSelected.Items.Refresh();
        }

        private void BtnShowOrders_Click(object sender, RoutedEventArgs e)
        {
            Orders ordersWindow = new Orders
            {
                Owner = this
            };
            if (ordersWindow.ShowDialog() == false)
            {
                
            }
        }
    }
}
