using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Bridge
{
    public class TownDatabaseObject : IDatabaseObject<Town>
    {

        private TurkeyProvincesEntitie3 db = new TurkeyProvincesEntitie3();
        private List<Town> _town;
        private int _current = 0;

        public TownDatabaseObject()
        {
            _town = db.Towns.ToList();
        }

        public Town Next
        {
            get
            {
                if (_current < _town.Count - 1)
                    _current++;
                return _town[_current];
            }
        }

        public Town Prior
        {
            get
            {
                if (_current > 0)
                    _current--;
                return _town[_current];
            }
        }

        public List<Town> ShowAll()
        {
            return _town;
        }
    }

    public class TownBase
    {
        public IDatabaseObject<Town> DataObject { get; set; }
        public Town Prior { get { return DataObject.Prior; } }
        public Town Next { get { return DataObject.Next; } }
        public List<Town> ShowAll() { return DataObject.ShowAll(); }
    }
}
