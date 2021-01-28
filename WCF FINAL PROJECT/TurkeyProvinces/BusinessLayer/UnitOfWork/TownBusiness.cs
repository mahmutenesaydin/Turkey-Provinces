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
    public class TownBusiness
    {

        private IRepository<Town> _townRepository;
        private IUnitOfWork _townUnitOfWork;
        private DbContext _dbContext;

        public TownBusiness()
        {
            _dbContext = new TurkeyProvincesEntitie3();
            _townUnitOfWork = new EFUnitOfWork(_dbContext);
            _townRepository = _townUnitOfWork.GetRepository<Town>();
        }

        public List<Town> GetTowns()
        {
            return _townRepository.GetAll().ToList();
        }

        public void Add(Town _town)
        {
            _townRepository.Insert(_town);
            _townUnitOfWork.SaveChanges();
        }

        public void Remove(int id)
        {
            _townRepository.Delete(id);
            _townUnitOfWork.SaveChanges();
        }

        public void Edit(Town _town)
        {
            var town = _townRepository.GetById(_town.TownID);

            town.TownName = _town.TownName;
            town.Population = _town.Population;
            town.Picture = _town.Picture;
            town.PartyID = _town.PartyID;
            town.PlaceToVisitID = _town.PlaceToVisitID;
            town.TransportationServiceID = _town.TransportationServiceID;
            town.WhatFamousID = _town.WhatFamousID;
            town.CityID = _town.CityID;
            _townRepository.Update(town);
            _townUnitOfWork.SaveChanges();
        }

        public Town GetTown(int id)
        {
            return _townRepository.Get(town => town.TownID == id);
        }

        private TurkeyProvincesEntitie3 db = new TurkeyProvincesEntitie3();
        public List<Town> ListForComboBox()
        {
            List<Town> list = db.Towns.ToList();
            list.Insert(0, new Town { TownID = 0, TownName = "İlçe Adı" });
            return list;
        }
        public List<SP_TownByCity_Result> TownByCity()
        {
            return db.SP_TownByCity().ToList();
        }
    }
}
