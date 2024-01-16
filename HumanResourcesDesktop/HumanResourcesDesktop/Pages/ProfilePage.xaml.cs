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
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();
            FIO.Text = AppConnect.User.last_name + " " + AppConnect.User.first_name + " " + AppConnect.User.patronymic;
            Init();
        }

        private async void Init()
        {
            var repository = new SessionRepository();
            var list = (await repository.FindAll()).Where(x=>x.employee_id == AppConnect.User.id);
            CountWorkingNumbers.Text = "Количество сделанных дел: " + list.Where(x=>x.type_of_session_id == 1).Count();
            grid.ItemsSource = list;
        }
    }
}
