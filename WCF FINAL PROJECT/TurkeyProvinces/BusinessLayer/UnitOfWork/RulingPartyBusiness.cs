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
    public class RulingPartyBusiness
    {
        private IRepository<RulingParty> _partyRepository;
        private IUnitOfWork _partyUnitOfWork;
        private DbContext _dbContext;

        public RulingPartyBusiness()
        {
            _dbContext = new TurkeyProvincesEntitie3();
            _partyUnitOfWork = new EFUnitOfWork(_dbContext);
            _partyRepository = _partyUnitOfWork.GetRepository<RulingParty>();
        }

        public List<RulingParty> ListParties()
        {
            return _partyRepository.GetAll().ToList();
        }

        public void Add(RulingParty _party)
        {
            _partyRepository.Insert(_party);
            _partyUnitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            _partyRepository.Delete(id);
            _partyUnitOfWork.SaveChanges();
        }

        public void Edit(RulingParty _party)
        {
            var party = _partyRepository.GetById(_party.PartyID);

            party.Party = _party.Party;
            _partyRepository.Update(party);
            _partyUnitOfWork.SaveChanges();

        }

        public RulingParty GetParty(int id)
        {
            return _partyRepository.Get(party => party.PartyID == id);
        }

        private TurkeyProvincesEntitie3 db = new TurkeyProvincesEntitie3();
        public List<RulingParty> ListForComboBox()
        {
            List<RulingParty> list = db.RulingParties.ToList();
            list.Insert(0, new RulingParty { PartyID = 0, Party = "İktidar Parti" });
            return list;
        }
    }
}
