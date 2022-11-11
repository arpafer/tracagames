using Microsoft.AspNetCore.Mvc;
using tracagamesApi.users.application;
using tracagamesApi.users.application.dtos;
using tracagamesApi.users.infraestructure.repositoriesMock;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tracagamesApi.users.infraestructure.controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class WaitingRoomController : ControllerBase
    {
        private WaitingRoomRepo waitingRoomRepo;

        public WaitingRoomController(WaitingRoomRepo waitingRoomRepo) {
           this.waitingRoomRepo = waitingRoomRepo;
        }

        [HttpGet]
        [Route("GetWaitingUsers")]
        public List<tracagamesApi.users.application.dtos.WaitingUser> Get(string gameName)
        {
            return new WaitingRoomApp(this.waitingRoomRepo).loadWaitingUsers(gameName);
        }

        [HttpGet]
        [Route("GetWaitingUser")]
        public tracagamesApi.users.application.dtos.WaitingUser GetWaitingUser(string email, string gameName)
        {           
            return new WaitingRoomApp(this.waitingRoomRepo).GetWaitingUser(email, gameName);
        }

        [HttpPost]
        [Route("addWaitingUser")]
        public tracagamesApi.users.application.dtos.WaitingUser Post(WaitingUser waitingUser)
        //public string Post(string id)
        {
            //return id;
            return new WaitingRoomApp(this.waitingRoomRepo).Add(waitingUser);
        }

        [HttpDelete]
        [Route("deleteWaitingUser")] 
        public tracagamesApi.users.application.dtos.WaitingUser Delete(string info)
        {
            string[] arrInfo = info.Split('|');
            string email = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(arrInfo[0]));
            string gameName = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(arrInfo[1])); 
            return new WaitingRoomApp(this.waitingRoomRepo).Delete(new tracagamesApi.users.application.dtos.WaitingUser() {  email = email, gameName = gameName});
        }
    }
}