using HumanResourcesDesktop.Models;
using HumanResourcesDesktop.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HumanResourcesDesktop.Pages
{
    public partial class PeoplePage : Page
    {

        private List<PersonEntity> persons = new List<PersonEntity>();
        public PeoplePage()
        {
            InitializeComponent();
            Init();
        }

        private async void Init()
        {
            persons.Clear();
            var repository = new PersonRepository();
            var list = await repository.FindAll();
            persons.AddRange(list);
            grid.ItemsSource = persons;
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
                Init();
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            PersonEntity person = grid.SelectedItem as PersonEntity;
            AppConnect.Hub.Navigate(new EditPeoplePage(person));
        }

        private void Filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = Filter.Text.ToLower().Trim();
            grid.ItemsSource = persons.Where(x => x.first_name.ToLower().Contains(text) ||
                                                x.last_name.ToLower().Contains(text) ||
                                                x.patronymic.ToLower().Contains(text)
            );
        }
    }
}
