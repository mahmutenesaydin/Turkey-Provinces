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
    public class RegionBusiness
    {
        private IRepository<Region> _regionRepository;
        private IUnitOfWork _regionUnitOfWork;
        private DbContext _dbContext;

        public RegionBusiness()
        {
            _dbContext = new TurkeyProvincesEntitie3();
            _regionUnitOfWork = new EFUnitOfWork(_dbContext);
            _regionRepository = _regionUnitOfWork.GetRepository<Region>();
        }

        public List<Region> GetRegions()
        {
            return _regionRepository.GetAll().ToList();
        }

        public void Add(Region _region)
        {
            _regionRepository.Insert(_region);
            _regionUnitOfWork.SaveChanges();
        }

        public void Remove(int id)
        {
            _regionRepository.Delete(id);
            _regionUnitOfWork.SaveChanges();
        }

        public void Edit(Region _region)
        {
            var region = _regionRepository.GetById(_region.RegionID);

            region.RegionName = _region.RegionName;
            _regionRepository.Update(region);
            _regionUnitOfWork.SaveChanges();
        }

        public Region GetRegion(int id)
        {
            return _regionRepository.Get(region => region.RegionID == id);
        }

        private TurkeyProvincesEntitie3 db = new TurkeyProvincesEntitie3();
        public List<Region> ListForComboBox()
        {
            List<Region> list = db.Regions.ToList();
            list.Insert(0, new Region { RegionID = 0, RegionName = "Bölge Adı" });
            return list;
        }
    }
}
