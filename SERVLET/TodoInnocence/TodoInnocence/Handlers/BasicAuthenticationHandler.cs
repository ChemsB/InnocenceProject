using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using TodoInnocence.Models;

namespace TodoInnocence.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly TodoContext _context;
        public AppDb Db { get; set; }
        public BasicAuthenticationHandler( AppDb db,
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            TodoContext context) 
            : base(options,logger,encoder,clock)
        {
            _context = context;
            Db = db;
        }


        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {

            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Authorization header was not found");

            try
            {
                var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var bytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
                string[] credentials = Encoding.UTF8.GetString(bytes).Split(":");
                string nick = credentials[0];
                string password = credentials[1];

                await Db.Connection.OpenAsync();
                UserPostQuery query = new UserPostQuery(Db);
                List<TodoUser> users = await query.LatestPostsAsync();

                TodoUser user =users.Where(user => user.Nick == nick && user.Password == password).FirstOrDefault();

                //TodoUser user = _context.TodoUsers.Where(user => user.Nick == nick && user.Password == password).FirstOrDefault();
                if(user == null)
                    AuthenticateResult.Fail("Invalid nick or password");

                else
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, user.Nick) };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
                return AuthenticateResult.Fail("Error has occurred");
            }
            return AuthenticateResult.Fail("");
        }
    }
}
