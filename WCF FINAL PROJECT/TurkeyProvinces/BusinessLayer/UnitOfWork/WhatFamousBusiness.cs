using BusinessLayer.Repository.Abstract;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using BusinessLayer.Repository.Concrete;

namespace BusinessLayer.UnitOfWork
{
    public class WhatFamousBusiness
    {
        private IRepository<WhatFamou> _famousRepository;
        private IUnitOfWork _famousUnitOfWork;
        private DbContext _dbContext;

        public WhatFamousBusiness()
        {
            _dbContext = new TurkeyProvincesEntitie3();
            _famousUnitOfWork = new EFUnitOfWork(_dbContext);
            _famousRepository = _famousUnitOfWork.GetRepository<WhatFamou>();
        }

        public List<WhatFamou> GetFamous()
        {
            return _famousRepository.GetAll().ToList();
        }

        public void Add(WhatFamou _famous)
        {
            _famousRepository.Insert(_famous);
            _famousUnitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            _famousRepository.Delete(id);
            _famousUnitOfWork.SaveChanges();
        }

        public void Edit(WhatFamou _famous)
        {
            var famous = _famousRepository.GetById(_famous.WhatFamousID);

            famous.WhatFamous = _famous.WhatFamous;
            _famousRepository.Update(famous);
            _famousUnitOfWork.SaveChanges();
        }

        public WhatFamou GetFamou(int id)
        {
            return _famousRepository.Get(famous => famous.WhatFamousID == id);
        }

        private TurkeyProvincesEntitie3 db = new TurkeyProvincesEntitie3();
        public List<WhatFamou> ListForComboBox()
        {
            List<WhatFamou> list = db.WhatFamous.ToList();
            list.Insert(0, new WhatFamou { WhatFamousID = 0, WhatFamous = "Neyi Meşhur" });
            return list;
        }
    }
}
