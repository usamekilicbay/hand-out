using System.Collections.Generic;

namespace hand_out.Models.ViewModels.Message
{
    public class ChatViewModel
    {
        public List<RecentChatViewModel> RecentChatViewModels { get; private set; }
        public ActiveChatViewModel ActiveChatViewModel { get; private set; }

        public ChatViewModel(List<RecentChatViewModel> recentChatViewModels, ActiveChatViewModel activeChatViewModel)
        {
            RecentChatViewModels = recentChatViewModels;
            ActiveChatViewModel = activeChatViewModel;
        }
    }
}
