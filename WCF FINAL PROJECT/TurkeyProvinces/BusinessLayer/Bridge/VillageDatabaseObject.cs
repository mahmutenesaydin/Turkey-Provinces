using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Bridge
{
    public class VillageDatabaseObject : IDatabaseObject<Village>
    {

        private TurkeyProvincesEntitie3 db = new TurkeyProvincesEntitie3();
        private List<Village> _village;
        private int _current = 0;

        public VillageDatabaseObject()
        {
            _village = db.Villages.ToList();
        }

        public Village Next
        {
            get
            {
                if (_current < _village.Count - 1)
                    _current++;
                return _village[_current];
            }
        }

        public Village Prior
        {
            get
            {
                if (_current > 0)
                    _current--;
                return _village[_current];
            }
        }

        public List<Village> ShowAll()
        {
            return _village;
        }
    }

    public class VillageBase
    {
        public IDatabaseObject<Village> DataObject { get; set; }
        public Village Prior { get { return DataObject.Prior; } }
        public Village Next { get { return DataObject.Next; } }
        public List<Village> ShowAll() { return DataObject.ShowAll(); }
    }
}
