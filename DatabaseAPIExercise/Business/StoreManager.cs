using DatabaseAPIExercise.Models;
using DatabaseAPIExercise.Repositories;
using System.Collections.Generic;

namespace DatabaseAPIExercise.Business
{
    public interface IStoreManager
    {
        //Standard methods
        Store CreateStore(Store store);
        Store UpdateStore(Store store);
        Store DeleteStore(Store store);
        List<Store> GetStores();

        //Filtering methods
        Store GetOldestStore(Store store);
        Store UpdateStoreOwner(string owner);
        List<Store> GetStoresByKeyword(string keyword);
        List<Store> GetStoresByCountry(string country);
        List<Store> GetStoresByCity(string city);
        List<Store> GetStoresByMonthlyIncome();
    }

    public class StoreManager : IStoreManager
    {
        private readonly IStoreRepository _storeRepository;

        public StoreManager(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public Store CreateStore(Store store)
        {
            throw new System.NotImplementedException();
        }

        public Store DeleteStore(Store store)
        {
            throw new System.NotImplementedException();
        }

        public Store GetOldestStore(Store store)
        {
            throw new System.NotImplementedException();
        }

        public List<Store> GetStores()
        {
            throw new System.NotImplementedException();
        }

        public List<Store> GetStoresByCity(string city)
        {
            throw new System.NotImplementedException();
        }

        public List<Store> GetStoresByCountry(string country)
        {
            throw new System.NotImplementedException();
        }

        public List<Store> GetStoresByKeyword(string keyword)
        {
            throw new System.NotImplementedException();
        }

        public List<Store> GetStoresByMonthlyIncome()
        {
            throw new System.NotImplementedException();
        }

        public Store UpdateStore(Store store)
        {
            throw new System.NotImplementedException();
        }

        public Store UpdateStoreOwner(string owner)
        {
            throw new System.NotImplementedException();
        }
    }
}
