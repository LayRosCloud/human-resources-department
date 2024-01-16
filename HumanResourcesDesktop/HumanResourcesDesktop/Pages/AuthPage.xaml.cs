using HumanResourcesDesktop.Repositories;
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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string password = Password.Password;
            string login = Login.Text;

            var repository = new PersonRepository();
            var items =  await repository.FindAll();

            foreach (var item in items)
            {
                if (item.login.ToLower().Trim() == login.ToLower().Trim() && item.password == password)
                {
                    AppConnect.User = item;
                    AppConnect.Main.Navigate(new HubPage());
                    break;
                }
            }

        }
    }
}
