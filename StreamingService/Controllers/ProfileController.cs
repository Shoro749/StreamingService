using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StreamingService.Context;
using StreamingService.DTO;
using StreamingService.Models;

namespace StreamingService.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ProfileController(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserProfileViewModel model)
        {
            var entity = _mapper.Map<UserProfile>(model);
            _context.UserProfiles.Add(entity);
            _context.SaveChanges();
            return Redirect("/");
        }
    }
}
