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
    public class PlaceToVisitBusiness
    {
        private IRepository<PlacesToVisit> _visitRepository;
        private IUnitOfWork _visitUnitOfWork;
        private DbContext _dbContext;

        public PlaceToVisitBusiness()
        {
            _dbContext = new TurkeyProvincesEntitie3();
            _visitUnitOfWork = new EFUnitOfWork(_dbContext);
            _visitRepository = _visitUnitOfWork.GetRepository<PlacesToVisit>();
        }

        public List<PlacesToVisit> GetVisits()
        {
            return _visitRepository.GetAll().ToList();
        }

        public void Add(PlacesToVisit _visit)
        {
            _visitRepository.Insert(_visit);
            _visitUnitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            _visitRepository.Delete(id);
            _visitUnitOfWork.SaveChanges();
        }

        public void Edit(PlacesToVisit _visit)
        {
            var visit = _visitRepository.GetById(_visit.PlaceToVisitID);

            visit.PlaceToVisit = _visit.PlaceToVisit;
            _visitRepository.Update(visit);
            _visitUnitOfWork.SaveChanges();
        }

        public PlacesToVisit GetVisit(int id)
        {
            return _visitRepository.Get(visit => visit.PlaceToVisitID == id);
        }

        private TurkeyProvincesEntitie3 db = new TurkeyProvincesEntitie3();
        public List<PlacesToVisit> ListForComboBox()
        {
            List<PlacesToVisit> list = db.PlacesToVisits.ToList();
            list.Insert(0, new PlacesToVisit { PlaceToVisitID = 0, PlaceToVisit = "Gezilecek Yerler" });
            return list;
        }

    }
}
