using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Bridge
{
    public class CityDatabaseObject : IDatabaseObject<City>
    {
        private TurkeyProvincesEntitie3 db = new TurkeyProvincesEntitie3();
        private List<City> _city;
        private int _current = 0;

        public CityDatabaseObject()
        {
            _city = db.Cities.ToList();
        }

        public City Next
        {
            get
            {
                if (_current < _city.Count - 1)
                    _current++;
                return _city[_current];
            }
        }

        public City Prior
        {
            get
            {
                if (_current > 0)
                    _current--;
                return _city[_current];
            }
        }

        public List<City> ShowAll()
        {
            return _city;
        }
    }

    public class CityBase
    {
        public IDatabaseObject<City> DataObject { get; set; }
        public City Prior { get { return DataObject.Prior; } }
        public City Next { get { return DataObject.Next; } }
        public List<City> ShomAll() { return DataObject.ShowAll(); }
    }
}
