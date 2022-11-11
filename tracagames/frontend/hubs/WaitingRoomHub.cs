using System.IO.Pipes;
using System.Net.WebSockets;
using Microsoft.AspNetCore.SignalR;

namespace frontend.hubs;

public class WaitingRoomHub: Hub {
    
    public async Task NewUser(string userName, string email) {
       await Clients.All.SendAsync("NewAvailableUser", userName, email);
    }    

    public async Task RemoveUser(string userName, string email) {
        await Clients.All.SendAsync("RemovedUser", userName, email);
    }
}

public record NewAvailableUser(string userName, string email, bool logged, string password);