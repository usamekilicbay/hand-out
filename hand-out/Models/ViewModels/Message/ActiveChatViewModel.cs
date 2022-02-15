using hand_out.Models.ViewModels.Product;
using System.Collections.Generic;

namespace hand_out.Models.ViewModels.Message
{
    public class ActiveChatViewModel
    {
        public MessageProductViewModel ProductMessageViewModel { get; set; }

        public List<EntityLayer.Concrete.Message> SentMessages { get; set; }
        public List<EntityLayer.Concrete.Message> ReceivedMessages { get; set; }
    }
}