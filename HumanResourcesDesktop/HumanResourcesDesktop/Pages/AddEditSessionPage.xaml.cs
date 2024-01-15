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
    public partial class AddEditSessionPage : Page
    {
        private SessionEntity entity;

        public AddEditSessionPage() 
            : this(new SessionEntity())
        {

        }

        public AddEditSessionPage(SessionEntity session)
        {
            InitializeComponent();
            entity = session;
            Init();
        }

        private async void Init()
        {
            var repository = new PersonRepository();
            var typeRepository = new TypeOfSessionRepository();
            CbEmployee.ItemsSource = await repository.FindAll();
            CbTypes.ItemsSource = await typeRepository.FindAll();
            DataContext = entity;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var repository = new SessionRepository();
            if(entity.id == 0)
            {
                await repository.Create(entity);
            }
            else
            {
                await repository.Update(entity);
            }

            AppConnect.Hub.Navigate(new SessionPage());
        }
    }
}
