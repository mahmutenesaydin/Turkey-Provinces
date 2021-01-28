using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TurkeyProvincesServiceLibrary
{
    [ServiceContract]
    public interface IServiceContract
    {
        //City
        [OperationContract]
        void AddCity(City cty);
        [OperationContract]
        void UpdateCity(City cty);
        [OperationContract]
        void DeleteCity(int id);
        [OperationContract]
        List<City> ListCity();

        //Town
        [OperationContract]
        void AddTown(Town twn);
        [OperationContract]
        void UpdateTown(Town twn);
        [OperationContract]
        void DeleteTown(int id);
        [OperationContract]
        List<Town> ListTown();

        //Village
        [OperationContract]
        void AddVillage(Village vllage);
        [OperationContract]
        void UpdateVillage(Village vllage);
        [OperationContract]
        void DeleteVillage(int id);
        [OperationContract]
        List<Village> ListVillage();

        //Region
        [OperationContract]
        void AddRegion(Region reg);
        [OperationContract]
        void UpdateRegion(Region reg);
        [OperationContract]
        void DeleteRegion(int id);
        [OperationContract]
        List<Region> ListRegion();

        //PlacesToVisit
        [OperationContract]
        void AddPlacesToVisit(PlacesToVisit vst);
        [OperationContract]
        void UpdatePlacesToVisit(PlacesToVisit vst);
        [OperationContract]
        void DeletePlacesToVisit(int id);
        [OperationContract]
        List<PlacesToVisit> ListPlacesToVisit();

        //WhatFamous
        [OperationContract]
        void AddWhatFamou(WhatFamou famou);
        [OperationContract]
        void UpdateWhatFamou(WhatFamou famou);
        [OperationContract]
        void DeleteWhatFamou(int id);
        [OperationContract]
        List<WhatFamou> ListWhatFamou();

        //TransportationService
        [OperationContract]
        void AddTransportationService(TransportationService srvc);
        [OperationContract]
        void UpdateTransportationService(TransportationService srvc);
        [OperationContract]
        void DeleteTransportationService(int id);
        [OperationContract]
        List<TransportationService> ListTransportationService();

        //User
        [OperationContract]
        void AddUser(User usr);
        [OperationContract]
        void UpdateUser(User usr);
        [OperationContract]
        void DeleteUser(int id);
        [OperationContract]
        List<User> ListUser();

        //RulingParty
        [OperationContract]
        void AddRulingParty(RulingParty prty);
        [OperationContract]
        void UpdateRulingParty(RulingParty prty);
        [OperationContract]
        void DeleteRulingParty(int id);
        [OperationContract]
        List<RulingParty> ListRulingParty();

        //Login
        [OperationContract]
        bool Login(string UserName, string Password);
        [OperationContract]
        List<User> ListByBool(bool isactive);
        
    }
}
