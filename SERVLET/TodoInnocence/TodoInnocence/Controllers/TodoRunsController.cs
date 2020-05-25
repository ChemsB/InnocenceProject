using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using TodoInnocence.Models;

namespace TodoInnocence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoRunsController : ControllerBase
    {
        public AppDb Db { get; set; }
        public TodoRunsController(AppDb db)
        {
            Db = db;
        }

        // GET: api/TodoRuns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoRun>>> GetTodoRuns()
        {
            await Db.Connection.OpenAsync();
            var query = new RunPostQuery(Db);
            var result = await query.LatestPostsAsync();
            JsonConvert.SerializeObject(result);
            return new OkObjectResult(result);
        }

        // GET: api/TodoRuns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoUser>> GetTodoRuns(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new RunPostQuery(Db);
            var result = await query.FindOneAsync(id);
            JsonConvert.SerializeObject(result);
            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // PUT: api/TodoRuns/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoRuns(int id,[FromQuery]TodoRun todoRun)
        {
            await Db.Connection.OpenAsync();
            var query = new RunPostQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();

            result.Id_run = todoRun.Id_run;
            result.Score = todoRun.Score;
            result.Date = todoRun.Date;
            result.Id_user = todoRun.Id_user;
            result.Id_character = todoRun.Id_character;

            await result.UpdateAsync();
            JsonConvert.SerializeObject(result);
            return new OkObjectResult(result);
        }

    }
}
