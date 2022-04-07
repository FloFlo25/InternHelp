using DatabaseAPIExercise.Context;
using DatabaseAPIExercise.Models;
using System.Collections.Generic;

namespace DatabaseAPIExercise.Repositories
{
    public interface IStoreRepository
    {
            Store CreateStore(Store store);
            Store UpdateStore(Store store);
            Store DeleteStore(Store store);

            List<Store> GetStores();
    }

    public class StoreRepository : IStoreRepository
    {
        private readonly DatabaseContext _context;

        public StoreRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Store CreateStore(Store store)
        {
            throw new System.NotImplementedException();
        }

        public Store DeleteStore(Store store)
        {
            throw new System.NotImplementedException();
        }

        public List<Store> GetStores()
        {
            throw new System.NotImplementedException();
        }

        public Store UpdateStore(Store store)
        {
            throw new System.NotImplementedException();
        }
    }
}
