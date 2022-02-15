using AutoMapper;
using BusinessLogicLayer;
using DataLayer.Product;
using hand_out.Models.ViewModels.Message;
using hand_out.Models.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            List<RecentChatViewModel> recentChatViewModels = new();
            ActiveChatViewModel activeChatViewModel = new();
            
            if (id != 0)
            {
                MessageProductDTO messageProductDTO = _unitOfWork.ProductService.GetById<MessageProductDTO>(id);
                activeChatViewModel.ProductMessageViewModel = _mapper.Map(messageProductDTO, new MessageProductViewModel(messageProductDTO.PhotoURL));
            }

            ChatViewModel chatViewModel = new(
                recentChatViewModels: recentChatViewModels,
                activeChatViewModel: activeChatViewModel
                );

            return View(chatViewModel);
        }
    }
}