using CRUDHistory.Models.Models;
using Microsoft.AspNetCore.SignalR;

namespace CRUDHistoryWeb.Hubs;


public class ChatHub : Hub{
    public async Task JoinChat(UserConnection con){
        await Clients.All
            .SendAsync("ReceiveMessage", "admin", $"{con.Username} has joined");
    }

    public async Task JoinSpecificRoom(UserConnection con){
        await Groups.AddToGroupAsync(Context.ConnectionId, con.ChatRoom);
        await Clients.Group(con.ChatRoom)
            .SendAsync("JoinSpecificRoom", "admin", $"{con.Username} has joined {con.ChatRoom}");
    }
}   