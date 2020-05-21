using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoInnocence.Models;

namespace TodoInnocence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoUsersController : ControllerBase
    {
        public AppDb Db { get; }
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
            return new OkObjectResult(result);
        }

        // GET: api/TodoUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoUser>> GetTodoUser(long id)
        {

            return null;
        }

        // PUT: api/TodoUsers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoUser(long id, TodoUser todoUser)
        {

            return null;
        }

        // POST: api/TodoUsers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TodoUser>> PostTodoUser(TodoUser todoUser)
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
