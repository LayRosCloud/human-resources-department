using HumanResourcesDesktop.Models;
using HumanResourcesDesktop.Repositories;
using System;
using System.CodeDom;
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
    public partial class MoreInfoPage : Page
    {
        public MoreInfoPage(PersonEntity entity)
        {
            InitializeComponent();
            LastName.Text = entity.last_name;
            FirstName.Text = entity.first_name;
            Patronymic.Text = entity.patronymic;
            Login.Text = entity.login;
            Init(entity);
        }

        private async void Init(PersonEntity entity)
        {
            var address = await getFullAddress(entity.address_id);
            var phoneRepo = new PhoneRepository();
            var typePhoneRepo = new TypeOfPhoneRepository();
            Address.Text = address.city_street_name;
            var passportRepository = new PassportRepository();
            var passport = (await passportRepository.FindAll()).FirstOrDefault(x=>x.employee_id == entity.id);
            if(passport != null)
            {
                passport.address = await getFullAddress(passport.address_registration_id);
                Passport.Text = $"Серия номер: {passport.seria} {passport.number}\nАдрес: {passport.address.city_street_name}\nДата рождения: {passport.birthday:dd.MM.yyyy}\nДата получения: {passport.date:dd.MM.yyyy}";
            }

            var phones = (await phoneRepo.FindAll()).Where(x => x.employee_id == entity.id).ToList();
            var typeOfPhones = await typePhoneRepo.FindAll();

            foreach(var phone in phones)
            {
                foreach(var type in typeOfPhones)
                {
                    if(phone.phone_type_id == type.id)
                    {
                        phone.Type = type;
                    }
                }

                Phones.Text += $"{phone.number} {phone.Type.name}\n";
            }
            
        }

        private async Task<AddressEntity> getFullAddress(int addressId)
        {
            var addressRepo = new AddressRepository();

            var cityStreetRepository = new CityStreetRepository();
            var cityRepo = new CityRepository();
            var streetRepo = new StreetRepository();
            var areaRepo = new AreaRepository();
            var regionRepo = new RegionRepository();
            var countryRepo = new CountryRepository();

            var address = await addressRepo.Find(addressId);
            address.cityStreetEntity = await cityStreetRepository.Find(address.city_street_id);
            address.cityStreetEntity.street = await streetRepo.Find(address.cityStreetEntity.street_id);
            address.cityStreetEntity.city = await cityRepo.Find(address.cityStreetEntity.city_id);
            address.cityStreetEntity.city.area = await areaRepo.Find(address.cityStreetEntity.city.area_id);
            address.cityStreetEntity.city.area.region = await regionRepo.Find(address.cityStreetEntity.city.area.region_id);
            address.cityStreetEntity.city.area.region.country = await countryRepo.Find(address.cityStreetEntity.city.area.region.country_id);

            return address;
        }
    }
}
