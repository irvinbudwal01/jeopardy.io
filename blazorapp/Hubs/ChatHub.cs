using System.Collections.Concurrent;
using Microsoft.AspNetCore.SignalR;
using blazorapp.Models;

namespace blazorapp.Hubs;

public static class UserHandler
{
    public static List<string> ConnectedIds = new List<string>();
}

public class ChatHub : Hub
{

    public async Task SendMessage(string groupName, string user, string msg)
    {
        await Clients.Group(groupName).SendAsync("ReceiveMessage", user, msg);
    }

    public async Task JoinGroup(string groupName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        await Clients.Group(groupName).SendAsync("UpdateGroup", groupName);
    }

    public async Task LeaveGroup(string groupName)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        await Clients.Group(groupName).SendAsync("UpdateGroup", groupName);
    }

    public async Task StartGame(string groupName, string [] gameBoard) {
        await Clients.Group(groupName).SendAsync("StartGame", groupName, gameBoard);
    }

    public async Task SelectPlayer(string groupName, int index) {
        await Clients.Group(groupName).SendAsync("SelectPlayer", groupName, index);
    }

    public async Task SelectQuestion(string groupName, Questions question) {
        await Clients.Group(groupName).SendAsync("SelectQuestion", groupName, question);
    }

    public async Task UpdateTimer(string groupName, int currentTime) {
        await Clients.Group(groupName).SendAsync("UpdateTimer", groupName, currentTime);
    }

    public async Task onSpacebarDown(string groupName, string userInput) {
        await Clients.Group(groupName).SendAsync("onSpacebarDown", groupName, userInput);
    }

    public async Task SetQuestionStatus(string groupName, bool buzzable) {
        await Clients.Group(groupName).SendAsync("SetQuestionStatus", groupName, buzzable);
    }

    public async Task SetPauseStatus(string groupName, bool pauseTimer) {
        await Clients.Group(groupName).SendAsync("SetPauseStatus", groupName, pauseTimer);
    }

    

    // public override Task OnConnectedAsync() {
    //     UserHandler.ConnectedIds.Add(Context.ConnectionId);
    //     Console.WriteLine("connect called");
    //     for(int i = 0; i < UserHandler.ConnectedIds.Count; i++){
    //         Console.WriteLine(i + ": " + UserHandler.ConnectedIds[i]);
    //     }
    //     return base.OnConnectedAsync();
    // }

    // public override Task OnDisconnectedAsync(Exception? exception) {
    //     UserHandler.ConnectedIds.Remove(Context.ConnectionId);
    //     Console.WriteLine("disconnect called");
    //     for(int i = 0; i < UserHandler.ConnectedIds.Count; i++){
    //         Console.WriteLine(i + ": " + UserHandler.ConnectedIds[i]);
    //     }
    //     return base.OnDisconnectedAsync(exception);
    // }
}
