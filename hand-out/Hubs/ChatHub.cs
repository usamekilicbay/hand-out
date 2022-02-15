using BusinessLogicLayer;
using BusinessLogicLayer.Services.Abstract;
using hand_out.Controllers;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hand_out.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IUserIdProvider _userIdProvider;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public static Hashtable OnlineUsers = new();

        public ChatHub(IUserIdProvider userIdProvider, IUserService userService, IUnitOfWork unitOfWork)
        {
            _userIdProvider = userIdProvider;
            _userService = userService;
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
            await Clients.Client(OnlineUsers[receiverId].ToString()).SendAsync("receiveMessage", message);
            //await Clients.User(receiverId).SendAsync("receiveMessage", receiverId, message);
        }
    }
}