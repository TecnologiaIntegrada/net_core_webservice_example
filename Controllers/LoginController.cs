using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace web_api.Controllers
{
    [Route("api/[controller]")]
    public class pLogin : ControllerBase
    {

        public pLogin(AppDb db)
        {
            Db = db;
        }

        // GET /api/API => Description
        [HttpGet]
        public async Task<IActionResult> GetLatest()
        {
            await Db.Connection.OpenAsync();
            var query = new LoginQuery(Db);
            var result = await query.GetInstructions();
            return new OkObjectResult(result);
        }

        // GET /api/plogin/number
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new LoginQuery(Db);
            var result = await query.Auth_User("","");
            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // POST api/plogin/json
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Login getLogin)
        {
            //Getting => User and Passwd
            string login = getLogin.mylogin;
            string password = getLogin.mypassword;

            //DB => Asking DB for user Auth
            await Db.Connection.OpenAsync();
            var query = new LoginQuery(Db);

            var result = await query.Auth_User(login, password);
            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        public AppDb Db { get; } 
    }
}
