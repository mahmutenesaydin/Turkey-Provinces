using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using BusinessLayer.UnitOfWork;

namespace TurkeyProvincesServiceLibrary
{
    public class ServiceContract : IServiceContract
    {
       
        CityBusiness cityBus = new CityBusiness();
        TownBusiness townBus = new TownBusiness();
        VillageBusiness vilBus = new VillageBusiness();
        RegionBusiness regBus = new RegionBusiness();
        PlaceToVisitBusiness visitBus = new PlaceToVisitBusiness();
        WhatFamousBusiness famBus = new WhatFamousBusiness();
        RulingPartyBusiness partyBus = new RulingPartyBusiness();
        TransportationServiceBusiness serviceBus = new TransportationServiceBusiness();
        UserBusiness userBus = new UserBusiness();


        public void AddCity(City cty)
        {
            cityBus.Add(cty);
        }

        public void DeleteCity(int id)
        {
            cityBus.Remove(id);
        }

        public List<City> ListCity()
        {
            return cityBus.GetCities();
        }

        public void UpdateCity(City cty)
        {
            cityBus.Edit(cty);
        }

        public void AddTown(Town twn)
        {
            townBus.Add(twn);
        }

        public void UpdateTown(Town twn)
        {
            townBus.Edit(twn);
        }

        public void DeleteTown(int id)
        {
            townBus.Remove(id);
        }

        public List<Town> ListTown()
        {
            return townBus.GetTowns();
        }

        public void AddVillage(Village vllage)
        {
            vilBus.Add(vllage);
        }

        public void UpdateVillage(Village vllage)
        {
            vilBus.Edit(vllage);
        }

        public void DeleteVillage(int id)
        {
            vilBus.Remove(id);
        }

        public List<Village> ListVillage()
        {
            return vilBus.GetVillages();
        }

        public void AddRegion(Region reg)
        {
            regBus.Add(reg);
        }

        public void UpdateRegion(Region reg)
        {
            regBus.Edit(reg);
        }

        public void DeleteRegion(int id)
        {
            regBus.Remove(id);
        }

        public List<Region> ListRegion()
        {
            return regBus.GetRegions();
        }

        public void AddPlacesToVisit(PlacesToVisit vst)
        {
            visitBus.Add(vst);
        }

        public void UpdatePlacesToVisit(PlacesToVisit vst)
        {
            visitBus.Edit(vst);
        }

        public void DeletePlacesToVisit(int id)
        {
            visitBus.Delete(id);
        }

        public List<PlacesToVisit> ListPlacesToVisit()
        {
            return visitBus.GetVisits();
        }

        public void AddWhatFamou(WhatFamou famou)
        {
            famBus.Add(famou);
        }

        public void UpdateWhatFamou(WhatFamou famou)
        {
            famBus.Edit(famou);
        }

        public void DeleteWhatFamou(int id)
        {
            famBus.Delete(id);
        }

        public List<WhatFamou> ListWhatFamou()
        {
            return famBus.GetFamous();
        }

        public void AddTransportationService(TransportationService srvc)
        {
            serviceBus.Add(srvc);
        }

        public void UpdateTransportationService(TransportationService srvc)
        {
            serviceBus.Edit(srvc);
        }

        public void DeleteTransportationService(int id)
        {
            serviceBus.Delete(id);
        }

        public List<TransportationService> ListTransportationService()
        {
            return serviceBus.GetServices();
        }

        public void AddUser(User usr)
        {
            userBus.Add(usr);
        }

        public void UpdateUser(User usr)
        {
            userBus.Edit(usr);
        }

        public void DeleteUser(int id)
        {
            userBus.Delete(id);
        }

        public List<User> ListUser()
        {
            return userBus.ListUsers();
        }

        public void AddRulingParty(RulingParty prty)
        {
            partyBus.Add(prty);
        }

        public void UpdateRulingParty(RulingParty prty)
        {
            partyBus.Edit(prty);
        }

        public void DeleteRulingParty(int id)
        {
            partyBus.Delete(id);
        }

        public List<RulingParty> ListRulingParty()
        {
            return partyBus.ListParties();
        }

        public bool Login(string UserName, string Password)
        {
            //var user = db.Users.FirstOrDefault(u => u.UserName == UserName);
            //if (user != null)
            //{
            //    if (user.Password == Password)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //else
            //{
            //    return false;
            //}
            return userBus.Login(UserName, Password);
        }

        public List<User> ListByBool(bool isactive)
        {
            return userBus.ListByBool(isactive);
        }
    }
}
