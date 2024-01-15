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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HumanResourcesDesktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для HubPage.xaml
    /// </summary>
    public partial class HubPage : Page
    {
        public HubPage()
        {
            InitializeComponent();
            AppConnect.Hub = FrmHub;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrmHub.Navigate(new ProfilePage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrmHub.Navigate(new SessionPage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FrmHub.Navigate(new PeoplePage());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
