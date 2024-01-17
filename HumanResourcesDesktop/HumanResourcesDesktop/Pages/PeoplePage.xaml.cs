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
    public partial class PeoplePage : Page
    {
        public PeoplePage()
        {
            InitializeComponent();
            Init();
        }

        private async void Init()
        {
            var repository = new PersonRepository();
            var list = await repository.FindAll();
            grid.ItemsSource = list;
        }

        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MoreInfo.IsEnabled = true;
            EditBtn.IsEnabled = true;
            DeleteBtn.IsEnabled = true;
        }

        private void MoreInfo_Click(object sender, RoutedEventArgs e)
        {
            var item = (grid.SelectedItem as PersonEntity);
            AppConnect.Hub.Navigate(new MoreInfoPage(item));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AppConnect.Hub.Navigate(new AddEditPeoplePage());
        }

        private async void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if(grid.SelectedItem is PersonEntity person 
                && MessageBox.Show("Вы уверены, что хотите удалить сотрудника", "Вы уверены?", MessageBoxButton.YesNo, MessageBoxImage.Question)==MessageBoxResult.Yes)
            {
                var repository = new PersonRepository();
                await repository.Delete(person.id);
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            PersonEntity person = grid.SelectedItem as PersonEntity;
            AppConnect.Hub.Navigate(new EditPeoplePage(person));
        }
    }
}
