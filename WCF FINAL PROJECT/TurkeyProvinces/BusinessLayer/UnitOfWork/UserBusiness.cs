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
    public class UserBusiness
    {
        private IRepository<User> _userRepository;
        private IUnitOfWork _userUnitOfWork;
        private DbContext _dbContext;
        TurkeyProvincesEntitie3 db = new TurkeyProvincesEntitie3();

        public UserBusiness()
        {
            _dbContext = new TurkeyProvincesEntitie3();
            _userUnitOfWork = new EFUnitOfWork(_dbContext);
            _userRepository = _userUnitOfWork.GetRepository<User>();
        }

        public List<User> ListUsers()
        {
            return _userRepository.GetAll().ToList();
        }

        public void Add(User _user)
        {
            _userRepository.Insert(_user);
            _userUnitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
            _userUnitOfWork.SaveChanges();
        }

        public void Edit(User _user)
        {
            var user = _userRepository.GetById(_user.UserID);

            user.UserName = _user.UserName;
            user.Password = _user.Password;
            user.IsActive = _user.IsActive;
            _userRepository.Update(user);
            _userUnitOfWork.SaveChanges();
        }

        public User GetUser(int id)
        {
            return _userRepository.Get(user => user.UserID == id);
        }
        public List<User> ListByBool(bool isactive)
        {
            return db.Users.Where(u => u.IsActive == isactive).ToList();
        }
        public bool Login(string username,string password)
        {
            var user = db.Users.FirstOrDefault(u => u.UserName == username);
            if (user != null)
            {
                if (user.Password == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
