using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IOTManagementApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using IOTManagementApp.Data;
using Microsoft.EntityFrameworkCore;

namespace IOTManagementApp.Controllers
{
    [Authorize]
    public class OverviewController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<OverviewController> _logger;

       
        
        public OverviewController(ILogger<OverviewController> logger, UserManager<User> userManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        public string index()
        {
            return "Hej";
        }

        public IActionResult Index2()
        {
            return View(SeedData.devices);
        }

        public IActionResult ConnectToggle(int? id)
        {
            if (id is null) return NotFound();

            var userId =  _userManager.GetUserId(User);

            var device = SeedData.devices.FirstOrDefault(d => d.Id == id && d.UserId == userId);

            if (device != null)
            {
                if (device.IsConnected)
                {
                    device.IsConnected = false;
                }
                else
                {
                    device.IsConnected = true;
                }
            }
            return RedirectToAction(nameof(Index));
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
