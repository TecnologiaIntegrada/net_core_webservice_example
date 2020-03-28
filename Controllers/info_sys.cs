using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace web_api.Controllers
{
    [Route("api/[controller]")]
    public class info_sys : ControllerBase
    {

        public info_sys(AppDb db)
        {
            Db = db;
        }

        // GET /api/API => Description
        [HttpGet]
        public async Task<IActionResult> GetLatest()
        {
            await Db.Connection.OpenAsync();
            var query = new sys_info_Query(Db);
            var result = await query.LatestPostsAsync();
            return new OkObjectResult(result);
        }

        public AppDb Db { get; }
    }
}
