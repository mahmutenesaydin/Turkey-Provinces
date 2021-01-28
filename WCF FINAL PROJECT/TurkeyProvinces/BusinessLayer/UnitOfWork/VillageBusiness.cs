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
    public class VillageBusiness
    {
        private IRepository<Village> _villageRepository;
        private IUnitOfWork _villageUnitOfWork;
        private DbContext _dbContext;

        public VillageBusiness()
        {
            _dbContext = new TurkeyProvincesEntitie3();
            _villageUnitOfWork = new EFUnitOfWork(_dbContext);
            _villageRepository = _villageUnitOfWork.GetRepository<Village>();
        }

        public List<Village> GetVillages()
        {
            return _villageRepository.GetAll().ToList();
        }

        public void Add(Village _village)
        {
            _villageRepository.Insert(_village);
            _villageUnitOfWork.SaveChanges();
        }

        public void Remove(int id)
        {
            _villageRepository.Delete(id);
            _villageUnitOfWork.SaveChanges();
        }

        public void Edit(Village _village)
        {
            var village = _villageRepository.GetById(_village.VillageID);

            village.VillageName = _village.VillageName;
            village.Population = _village.Population;
            village.PlaceToVisitID = _village.PlaceToVisitID;
            village.WhatFamousID = _village.WhatFamousID;
            village.TownID = _village.TownID;
            _villageRepository.Update(village);
            _villageUnitOfWork.SaveChanges();
        }

        public Village GetVillage(int id)
        {
            return _villageRepository.Get(village => village.VillageID == id);
        }

        private TurkeyProvincesEntitie3 db = new TurkeyProvincesEntitie3();
        public List<Village> ListForComboBox()
        {
            List<Village> list = db.Villages.ToList();
            list.Insert(0, new Village { VillageID = 0, VillageName = "Köy Adı" });
            return list;
        }
        public List<SP_VillageByTown_Result> VillageByTown()
        {
            return db.SP_VillageByTown().ToList();
        }
    }
}
