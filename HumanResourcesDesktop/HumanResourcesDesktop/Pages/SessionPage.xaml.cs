using HumanResourcesDesktop.Models;
using HumanResourcesDesktop.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Excel = Microsoft.Office.Interop.Excel;

namespace HumanResourcesDesktop.Pages
{
    public partial class SessionPage : Page
    {
        private List<SessionEntity> list = new List<SessionEntity>();

        public SessionPage()
        {
            InitializeComponent();
            Init();
        }

        private async void Init()
        {
            this.list.Clear();
            var repository = new SessionRepository();
            var pRepository = new PersonRepository();
            var tRepository = new TypeOfSessionRepository();

            var list = await repository.FindAll();
            var tList = await tRepository.FindAll();
            var pList = await pRepository.FindAll();

            foreach( var item in list )
            {
                foreach(var t in tList)
                {
                    if(t.id == item.type_of_session_id)
                    {
                        item.type = t;
                    }
                }

                foreach(var p in pList)
                {
                    if (p.id == item.employee_id)
                    {
                        item.person = p;
                    }
                }
            }
            this.list.AddRange(list);
            grid.ItemsSource = list;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppConnect.Hub.Navigate(new AddEditSessionPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var session = grid.SelectedItem as SessionEntity;
            AppConnect.Hub.Navigate(new AddEditSessionPage(session));
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var session = grid.SelectedItem as SessionEntity;
            if(session != null 
                && MessageBox.Show("Вы уверены, что хотите удалить?", "Вы уверены?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                
                var repository = new SessionRepository();
                await repository.Delete(session.id);
                Init();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Excel.Application app = new Excel.Application();
            var workbook = app.Workbooks.Add();
            Excel.Worksheet sheet = app.Worksheets.Add();

            sheet.Name = "Отчет";

            var groupedList = list.GroupBy(x => x.person).ToList();
            int rowIndex = 0;
            foreach(var keyGrouped in groupedList)
            {
                rowIndex++;

                PersonEntity key = keyGrouped.Key;

                sheet.Cells[rowIndex, 1] = key.last_name + " " + key.first_name + " " + key.patronymic;

                rowIndex++;

                sheet.Cells[rowIndex, 1] = "дата начала";
                sheet.Cells[rowIndex, 2] = "дата конца";
                sheet.Cells[rowIndex, 3] = "тип работы";

                foreach(var item in keyGrouped)
                {
                    rowIndex++;

                    sheet.Cells[rowIndex, 1] = item.date_start;
                    sheet.Cells[rowIndex, 2] = item.date_end;
                    sheet.Cells[rowIndex, 3] = item.type.name;
                }

                rowIndex++;
            }

            app.Visible = true;
        }

        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditButton.IsEnabled = true;
            DeleteButton.IsEnabled = true;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = Filter.Text.ToLower().Trim();
            grid.ItemsSource = list.Where(x => x.person.first_name.ToLower().Contains(text) ||
                                                x.person.last_name.ToLower().Contains(text) ||
                                                x.person.patronymic.ToLower().Contains(text)
            );
        }
    }
}
