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
    public class TodoUsersController : ControllerBase
    {
        public AppDb Db { get; set; }
        public TodoUsersController(AppDb db)
        {
            Db = db;
        }

        // GET: api/TodoUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoUser>>> GetTodoUsers()
        {
            await Db.Connection.OpenAsync();
            var query = new UserPostQuery(Db);
            var result = await query.LatestPostsAsync();
            JsonConvert.SerializeObject(result);
            return new OkObjectResult(result);
        }

        // GET: api/TodoUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoUser>> GetTodoUser(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new UserPostQuery(Db);
            var result = await query.FindOneAsync(id);
            JsonConvert.SerializeObject(result);
            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // PUT: api/TodoUsers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoUser(int id,[FromQuery]TodoUser todoUser)
        {
            await Db.Connection.OpenAsync();
            var query = new UserPostQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            result.Name = todoUser.Name;
            result.Nick = todoUser.Nick;
            await result.UpdateAsync();
            JsonConvert.SerializeObject(result);
            return new OkObjectResult(result);
        }

        // POST: api/TodoUsers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
       // [ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TodoUser>> PostTodoUser([FromQuery]TodoUser todoUser)
        {
            await Db.Connection.OpenAsync();
            todoUser.Db = Db;
            await todoUser.InsertAsync();
            return new OkObjectResult(todoUser);
        }

        // DELETE: api/TodoUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoUser>> DeleteTodoUser(long id)
        {

            return null;
        }

        private bool TodoUserExists(long id)
        {
            return false;
        }
    }
}
