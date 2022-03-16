using BusinessLogicLayer;
using DataLayer.General.Chat;
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
        private string _currentUserId;

        public ChatHub(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _currentUserId = unitOfWork.UserService.GetCurrentUserId();
        }

        public override Task OnConnectedAsync()
        {
            OnlineUsers.Add(_currentUserId, Context.ConnectionId);
            return Clients.All.SendAsync("gg", "");
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            OnlineUsers.Remove(_currentUserId);

            return Clients.All.SendAsync("ff", "");
        }

        public async void SendMessageAsync(ChatSendMessageDTO chatSendMessageDTO, string message)
        {
            if (OnlineUsers.ContainsKey(chatSendMessageDTO.ReceiverId))
                await Clients.Client(OnlineUsers[chatSendMessageDTO.ReceiverId]).SendAsync("receiveMessage", message, chatSendMessageDTO);
        }
    }
}