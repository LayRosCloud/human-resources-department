using HumanResourcesDesktop.Models;
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
    /// Логика взаимодействия для EditPeoplePage.xaml
    /// </summary>
    public partial class EditPeoplePage : Page
    {
        private RoleRepository roleRepository = new RoleRepository();
        private PersonRepository peopleRepository = new PersonRepository();
        private PersonEntity entity;
        public EditPeoplePage(PersonEntity entity)
        {
            InitializeComponent();
            this.entity = entity;
            Init();
        }

        private async void Init()
        {
            var roles = await roleRepository.FindAll();
            Role.ItemsSource = roles;
            DataContext = entity;
            Password.Password = entity.password;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                entity.password = Password.Password;
                await peopleRepository.Update(entity);
                AppConnect.Hub.Navigate(new PeoplePage());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Sex_Checked(object sender, RoutedEventArgs e)
        {
            Sex.Content = "Мужской";
        }

        private void Military_Checked(object sender, RoutedEventArgs e)
        {
            Military.Content = "Военообязаный";
        }

        private void Sex_Unchecked(object sender, RoutedEventArgs e)
        {
            Sex.Content = "Женский";
        }

        private void Military_Unchecked(object sender, RoutedEventArgs e)
        {
            Military.Content = "Невоенообязаный";
        }
    }
}
