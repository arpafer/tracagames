using Microsoft.AspNetCore.SignalR;

using tracagamesApi.users.application.dtos;

namespace tracagamesApi.hubs;

public class WaitingRoomHub: Hub {
    
    public async Task NewUser(User user) => 
       await Clients.All.SendAsync("ReceiveUser", user);
}