  using BusinessLayer.Repository.Abstract;
using BusinessLayer.Repository.Concrete;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.UnitOfWork
{
    public class CityBusiness
    {
        private IRepository<City> _cityRepository;
        private IUnitOfWork _cityUnitOfWork;
        private DbContext _dbContext;

        public CityBusiness()
        {
            _dbContext = new TurkeyProvincesEntitie3();
            _cityUnitOfWork = new EFUnitOfWork(_dbContext);
            _cityRepository = _cityUnitOfWork.GetRepository<City>();
        }

        public List<City> GetCities()
        {
            return _cityRepository.GetAll().ToList();
        }

        public void Add(City _city)
        {
            _cityRepository.Insert(_city);
            _cityUnitOfWork.SaveChanges();
        }

        public void Remove(int id)
        {
            _cityRepository.Delete(id);
            _cityUnitOfWork.SaveChanges();
        }

        public void Edit(City _city)
        {
            var city = _cityRepository.GetById(_city.CityID);

            city.CityName = _city.CityName;
            city.PartyID = _city.PartyID;
            city.PlaceToVisitID = _city.PlaceToVisitID;
            city.PlateCode = _city.PlateCode;
            city.Population = _city.Population;
            city.Picture = _city.Picture;
            city.TransportationServiceID = _city.TransportationServiceID;
            city.WhatFamousID = _city.WhatFamousID;
            city.RegionID = _city.RegionID;
            _cityRepository.Update(city);
            _cityUnitOfWork.SaveChanges();
        }

        public City GetCity(int id)
        {
            return _cityRepository.Get(city => city.CityID == id);
        }

        private TurkeyProvincesEntitie3 db = new TurkeyProvincesEntitie3();
        public List<City> ListForComboBox()
        {
            List<City> list = db.Cities.ToList();
            list.Insert(0, new City { CityID = 0, CityName = "İl Adı" });
            return list;
        }
    }
}
