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
    /// Логика взаимодействия для AddEditPeoplePage.xaml
    /// </summary>
    public partial class AddEditPeoplePage : Page
    {
        private CountryRepository countryRepository = new CountryRepository();
        private RegionRepository regionRepository = new RegionRepository();
        private AreaRepository areaRepository = new AreaRepository();
        private CityRepository cityRepository = new CityRepository();
        private CityStreetRepository cityStreetRepository = new CityStreetRepository();
        private StreetRepository streetRepository = new StreetRepository();
        private AddressRepository addressRepository = new AddressRepository();
        private SeparationRepository separationRepository = new SeparationRepository();
        private PersonRepository personRepository = new PersonRepository();
        private PhoneRepository phoneRepository = new PhoneRepository();
        private RoleRepository roleRepository = new RoleRepository();
        private PassportRepository passportRepository = new PassportRepository();

        public AddEditPeoplePage()
        {
            InitializeComponent();
            Init();
        }

        private async void Init()
        {
            var countries = await countryRepository.FindAll();
            var separations = await separationRepository.FindAll();
            var roles = await roleRepository.FindAll();
            Separation.ItemsSource = separations;

            CountriesAd.ItemsSource = countries;
            CountriesPass.ItemsSource = countries;
            CountriesPass.SelectedIndex = 0;
            CountriesAd.SelectedIndex = 0;
            Role.ItemsSource = roles;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreetEntity streetAdId = StreetAd.SelectedItem as StreetEntity;
                CityEntity cityAdId = CityAd.SelectedItem as CityEntity;
                CityEntity cityPassId = CityPass.SelectedItem as CityEntity;
                StreetEntity streetPassId = StreetPass.SelectedItem as StreetEntity;

                SeparationEntity separation = Separation.SelectedItem as SeparationEntity;
                RoleEntity role = Role.SelectedItem as RoleEntity;

                var cities = await cityStreetRepository.FindAll();

                var cities_streets = cities.FirstOrDefault(x => x.street_id == streetAdId.id && x.city_id == cityAdId.id);

                AddressEntity address = new AddressEntity()
                {
                    city_street_id = cities_streets.id,
                    home_number = Convert.ToInt32(HouseNumberAd.Text),
                    entrance = Convert.ToInt32(EntranceAd.Text),
                    corpus = Convert.ToInt32(CorpusAd.Text),
                    apartment = Convert.ToInt32(ApartmentAd.Text)
                };

                AddressEntity createdAddressForEmployee = await addressRepository.Create(address);

                PersonEntity person = new PersonEntity()
                {
                    last_name = LastName.Text,
                    first_name = FirstName.Text,
                    patronymic = Patronymic.Text,
                    role_id = role.id,
                    login = Login.Text,
                    password = Password.Password,
                    millitary_duty = Military.IsChecked.Value,
                    sex = Sex.IsChecked,
                    address_id = createdAddressForEmployee.id
                };
                PersonEntity created = await personRepository.Create(person);
                cities_streets = cities.FirstOrDefault(x => x.city_id == cityPassId.id && x.street_id == streetPassId.id);
                AddressEntity addressForPass = new AddressEntity()
                {
                    city_street_id = cities_streets.id,
                    home_number = Convert.ToInt32(HouseNumberPass.Text),
                    entrance = Convert.ToInt32(EntrancePass.Text),
                    corpus = Convert.ToInt32(CorpusPass.Text),
                    apartment = Convert.ToInt32(ApartmentPass.Text)
                };

                AddressEntity createdAddressForPass = await addressRepository.Create(addressForPass);
                PassportEntity passport = new PassportEntity()
                {
                    employee_id = created.id,
                    seria = Convert.ToInt32(Seria.Text),
                    number = Convert.ToInt32(Number.Text),
                    address_registration_id = createdAddressForPass.id,
                    separation_id = separation.id,
                    date = Date.SelectedDate.Value,
                    birthday = Date.SelectedDate.Value,
                };
                await passportRepository.Create(passport);
                string phoneText = WorkPhone.Text.Trim();
                if (!String.IsNullOrWhiteSpace(phoneText))
                {
                    PhoneEntity phone = new PhoneEntity()
                    {
                        employee_id = created.id,
                        number = phoneText,
                        phone_type_id = 1
                    };
                    await phoneRepository.Create(phone);
                }
                phoneText = HomePhone.Text.Trim();
                if (!String.IsNullOrWhiteSpace(phoneText))
                {
                    PhoneEntity phone = new PhoneEntity()
                    {
                        employee_id = created.id,
                        number = phoneText,
                        phone_type_id = 2
                    };
                    await phoneRepository.Create(phone);
                }
                MessageBox.Show("Данные сохранены!");
                AppConnect.Hub.Navigate(new PeoplePage());
            }catch(Exception)
            {
                MessageBox.Show("Выберите все поля!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private async void CountriesPass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var country = CountriesPass.SelectedItem as CountryEntity;
            var regions = (await regionRepository.FindAll()).Where(x=>x.country_id == country.id);
            RegionsPass.ItemsSource = regions;
            RegionsPass.SelectedIndex = 0;
        }

        private async void AreaPass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var area = AreaPass.SelectedItem as AreaEntity;
            var cities = (await cityRepository.FindAll()).Where(x => x.area_id == area.id);
            CityPass.ItemsSource = cities;
            CityPass.SelectedIndex = 0;
        }

        private async void RegionsPass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var region = RegionsPass.SelectedItem as RegionEntity;
            var regions = (await areaRepository.FindAll()).Where(x => x.region_id == region.id);
            AreaPass.ItemsSource = regions;
            AreaPass.SelectedIndex = 0;
        }

        private async void CityPass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var city = CityPass.SelectedItem as CityEntity;
            var cities = (await cityStreetRepository.FindAll()).Where(x => x.city_id == city.id);
            var streets = await streetRepository.FindAll();
            List<StreetEntity> res = new List<StreetEntity>();
            foreach(var street in streets)
            {
                foreach(var item in cities)
                {
                    if(item.street_id == street.id)
                    {
                        res.Add(street); break;
                    }
                }
            }
            StreetPass.ItemsSource = res;
            StreetPass.SelectedIndex = 0;
        }

        private void Sex_Checked(object sender, RoutedEventArgs e)
        {
            Sex.Content = "Мужской";
        }

        private void Military_Checked(object sender, RoutedEventArgs e)
        {
            Military.Content = "Военообязаный";
        }

        private async void CountriesAd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var country = CountriesAd.SelectedItem as CountryEntity;
            var regions = (await regionRepository.FindAll()).Where(x => x.country_id == country.id);
            RegionsAd.ItemsSource = regions;
            RegionsAd.SelectedIndex = 0;
        }

        private async void RegionsAd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var region = RegionsAd.SelectedItem as RegionEntity;
            var regions = (await areaRepository.FindAll()).Where(x => x.region_id == region.id);
            AreaAd.ItemsSource = regions;
            AreaAd.SelectedIndex =0;
        }

        private async void AreaAd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var area = AreaAd.SelectedItem as AreaEntity;
            var cities = (await cityRepository.FindAll()).Where(x => x.area_id == area.id);
            CityAd.ItemsSource = cities;
            CityAd.SelectedIndex = 0;
        }

        private async void CityAd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var city = CityAd.SelectedItem as CityEntity;
            var cities = (await cityStreetRepository.FindAll()).Where(x => x.city_id == city.id);
            var streets = await streetRepository.FindAll();
            List<StreetEntity> res = new List<StreetEntity>();
            foreach (var street in streets)
            {
                foreach (var item in cities)
                {
                    if (item.street_id == street.id)
                    {
                        res.Add(street); break;
                    }
                }
            }
            StreetAd.ItemsSource = res;
            StreetAd.SelectedIndex = 0;
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
