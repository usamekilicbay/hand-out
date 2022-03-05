using BusinessLogicLayer;
using hand_out.Controllers;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hand_out.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IUnitOfWork _unitOfWork;

        private static Dictionary<string, string> OnlineUsers = new();

        public ChatHub(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override Task OnConnectedAsync()
        {
            OnlineUsers.Add(MessageController.currentUserId, Context.ConnectionId);
            return Clients.All.SendAsync("gg", "");
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            OnlineUsers.Remove(MessageController.currentUserId);

            return Clients.All.SendAsync("ff", "");
        }

        public async void SendMessageAsync(string receiverId, string message)
        {
            if (OnlineUsers.ContainsKey(receiverId))
                await Clients.Client(OnlineUsers[receiverId]).SendAsync("receiveMessage", message);
        }
    }
}