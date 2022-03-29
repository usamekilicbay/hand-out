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
        private string _currentUserId;

        public MessageController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _currentUserId = unitOfWork.UserService.GetCurrentUserId();
        }

        [HttpGet]
        public IActionResult Index(int id = 0)
        {
            ViewBag.ProductId = id;
            ViewBag.CurrentUserId = _currentUserId;
            return View();
        }

        public List<ListChatViewModel> GetChats()
        {
            List<ChatDTO> chatDTOs = _unitOfWork.ChatService.GetAllWithRelations(
                c => c.GrantorParticipantId == _currentUserId
                || c.NeedyParticipantId == _currentUserId);

            List<ListChatViewModel> chatlist = new();

            chatDTOs.ForEach(x => chatlist.Add(new ListChatViewModel()
            {
                Id = x.Id,
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductPhotoURL = x.ProductPhotoURL,
                SenderParticipantId = _currentUserId,
                ReceiverParticipantId = x.ReceiverParticipantId,
                ReceiverParticipantUserName = x.ReceiverParticipantUserName,
                ReceiverParticipantPhotoURL = x.ReceiverParticipantPhotoURL,
                LastMessage = x.Messages.OrderByDescending(m => m.DateSent).FirstOrDefault().Context
            })); ;

            return chatlist;
        }

        public ChatViewModel GetActiveChatViewModel(string chatId, int productId)
        {
            ChatViewModel chatViewModel;
            ChatDTO chatDTO;
            if (string.IsNullOrEmpty(chatId))
            {
                Product product = _unitOfWork.ProductService.GetAllWithRelations<Product>(p => p.Id == productId).FirstOrDefault();
                chatDTO = GetChatDTO(productId, product.GrantorId);

                if (chatDTO != null)
                {
                    chatViewModel = _mapper.Map<ChatViewModel>(chatDTO);
                    chatViewModel.Messages.ForEach(x => x.IsYourMessage = x.SenderId == _currentUserId);
                    return chatViewModel;
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

            chatDTO = GetChatDTO(chatId);
            chatViewModel = _mapper.Map<ChatViewModel>(chatDTO);
            chatViewModel.Messages.ForEach(x => x.IsYourMessage = x.SenderId == _currentUserId);
            return chatViewModel;
        }

        public void SaveMessage(CreateMessageDTO createMessageDTO)
        {
            ChatDTO chatDTO = GetChatDTO(createMessageDTO.ProductId, createMessageDTO.ReceiverId);

            createMessageDTO.ChatId = chatDTO == null
                ? CreateChat(createMessageDTO.ProductId, createMessageDTO.ReceiverId).Id
                : chatDTO.Id;

            _unitOfWork.MessageService.Insert(createMessageDTO);
        }

        public JsonResult GetChatId(int productId, string receiverId)
        {
            ChatDTO chatDTO = GetChatDTO(productId, receiverId);

            return new JsonResult(chatDTO == null
                ? ""
                : chatDTO.Id);
        }

        private ChatDTO GetChatDTO(string chatId)
          => _unitOfWork.ChatService.GetAllWithRelations(
              c => c.Id == chatId).FirstOrDefault();

        private ChatDTO GetChatDTO(int productId, string receiverId)
          => _unitOfWork.ChatService.GetAllWithRelations(
              c => c.ProductId == productId &&
              (c.GrantorParticipantId == _currentUserId || c.NeedyParticipantId == _currentUserId) &&
              (c.GrantorParticipantId == receiverId || c.NeedyParticipantId == receiverId))
            .FirstOrDefault();

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