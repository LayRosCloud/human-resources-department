﻿using HumanResourcesDesktop.Models;
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
    /// Логика взаимодействия для SessionPage.xaml
    /// </summary>
    public partial class SessionPage : Page
    {
        public SessionPage()
        {
            InitializeComponent();
            Init();
        }

        private async void Init()
        {
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

        }

        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditButton.IsEnabled = true;
            DeleteButton.IsEnabled = true;
        }
    }
}