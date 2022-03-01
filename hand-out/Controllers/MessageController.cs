using AutoMapper;
using BusinessLogicLayer;
using DataLayer.General.Chat;
using DataLayer.General.Message;
using EntityLayer.Concrete;
using hand_out.Models.ViewModels.Chat;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace hand_out.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public static string currentUserId;

        public MessageController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            currentUserId = unitOfWork.UserService.GetCurrentUserId();
        }

        [HttpGet]
        public IActionResult Index(int id = 0)
        {
            ViewBag.ProductId = id;
            return View();
        }

        public List<ListChatViewModel> GetChats()
        {
            List<ChatDTO> chatDTOs = _unitOfWork.ChatService.GetAllWithRelations(
                c => c.GrantorParticipantId == currentUserId
                || c.NeedyParticipantId == currentUserId);

            List<ListChatViewModel> chatlist = new();

            chatDTOs.ForEach(x => chatlist.Add(new ListChatViewModel()
            {
                Id = x.Id,
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductPhotoURL = x.ProductPhotoURL,
                SenderParticipantId = currentUserId,
                ReceiverParticipantId = x.ReceiverParticipantId,
                ReceiverParticipantUserName = x.ReceiverParticipantUserName,
                ReceiverParticipantPhotoURL = x.ReceiverParticipantPhotoURL
            }));

            return chatlist;
        }

        public ChatViewModel GetActiveChatViewModel(int productId = 3)
        {
            Product product = _unitOfWork.ProductService.GetAllWithRelations<Product>(p => p.Id == productId).FirstOrDefault();

            ChatDTO chatDTO = GetChatDTO(productId);

            if (chatDTO != null)
            {
                ChatViewModel chatview = _mapper.Map<ChatViewModel>(chatDTO);
                chatview.Messages.ForEach(x => x.IsYourMessage = x.SenderId == currentUserId);
                return chatview;
            }

            return new()
            {
                ProductId = product.Id,
                ProductName = product.Name,
                ProductPhotoURL = product.PhotoURL,
                ReceiverParticipantId = product.GrantorId,
                ReceiverParticipantUserName = product.Grantor.UserName,
                ReceiverParticipantPhotoURL = product.Grantor.ProfilePhotoURL
            };
        }

        public void SaveMessage(CreateMessageDTO createMessageDTO)
        {
            ChatDTO chatDTO = GetChatDTO(createMessageDTO.ProductId);

            createMessageDTO.ChatId = chatDTO == null
                ? CreateChat(createMessageDTO.ProductId, createMessageDTO.ReceiverId).Id
                : chatDTO.Id;

            _unitOfWork.MessageService.Insert(createMessageDTO);
        }

        private ChatDTO GetChatDTO(int productId)
          => _unitOfWork.ChatService.GetAllWithRelations(
              c => c.ProductId == productId &&
              c.GrantorParticipantId == currentUserId ||
              c.NeedyParticipantId == currentUserId).FirstOrDefault();

        public ChatDTO CreateChat(int productId, string grantorParticipantId)
        {
            CreateChatDTO createChatDTO = new()
            {
                ProductId = productId,
                GrantorParticipantId = grantorParticipantId,
            };

            return _unitOfWork.ChatService.Insert(createChatDTO);
        }
    }
}