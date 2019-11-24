using Core.Services;
using System;
using API.Services;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.UI.WebControls;
using Data.Services;
using API.Models.InputFriend;

namespace API.Controllers
{
    [Authorize]
    [RoutePrefix("api/friend")]
    public class FriendController : ApiController
    {
        private IFriend FriendService = ServiceLocator.GetInstanceOf<FriendRepository>();


        [HttpPost]
        [Route("create")]
        [AllowAnonymous]
        public IHttpActionResult Create(InputFriendBindingModel input)
        {
            var friend = new InputFriendBindingModel().TransformInputIntoFriend(input);

            var friendCreated = FriendService.Create(friend);
            return Ok();
        }
       
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult Index()
        {
            var friends = FriendService.Friends();
            return Ok(friends);
        }
    }
}