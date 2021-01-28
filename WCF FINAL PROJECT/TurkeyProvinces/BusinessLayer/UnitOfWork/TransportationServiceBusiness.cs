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
    public class TransportationServiceBusiness
    {
        private IRepository<TransportationService> _serviceRepository;
        private IUnitOfWork _serviceUnitOfWork;
        private DbContext _dbContext;

        public TransportationServiceBusiness()
        {
            _dbContext = new TurkeyProvincesEntitie3();
            _serviceUnitOfWork = new EFUnitOfWork(_dbContext);
            _serviceRepository = _serviceUnitOfWork.GetRepository<TransportationService>();
        }

        public List<TransportationService> GetServices()
        {
            return _serviceRepository.GetAll().ToList();
        }

        public void Add(TransportationService _service)
        {
            _serviceRepository.Insert(_service);
            _serviceUnitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            _serviceRepository.Delete(id);
            _serviceUnitOfWork.SaveChanges();
        }

        public void Edit(TransportationService _service)
        {
            var service = _serviceRepository.GetById(_service.TransportationServicesID);

            service.TransportationService1 = _service.TransportationService1;
            _serviceRepository.Update(service);
            _serviceUnitOfWork.SaveChanges();
        }

        public TransportationService GetService(int id)
        {
            return _serviceRepository.Get(service => service.TransportationServicesID == id);
        }

        private TurkeyProvincesEntitie3 db = new TurkeyProvincesEntitie3();
        public List<TransportationService> ListForComboBox()
        {
            List<TransportationService> list = db.TransportationServices.ToList();
            list.Insert(0, new TransportationService { TransportationServicesID = 0, TransportationService1 = "Ulaşım Araçı" });
            return list;
        }
    }
}
