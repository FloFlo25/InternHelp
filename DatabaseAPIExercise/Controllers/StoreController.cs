using DatabaseAPIExercise.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseAPIExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreManager _storeManager;

        public StoreController(IStoreManager storeManager)
        {
            _storeManager = storeManager;
        }


    }
}
