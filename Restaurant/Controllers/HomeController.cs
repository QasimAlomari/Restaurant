using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using Restaurant.UnitWork;
using Restaurant.ViewModels;
using System;
using System.Linq;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public IActionResult Index(string Message)
        {
            ViewBag.message = Message;
            HomeViewModel dataViewModel = new HomeViewModel()
            {
                SystemSetting = (_UnitOfWork.SystemSettingRepository.ViewForClient().ToList().Count == 0 ? null : _UnitOfWork.SystemSettingRepository.ViewForClient().Take(1).OrderByDescending(data => data.SystemSettingId).ToList().ElementAt(0)),
                MasterMenuList = _UnitOfWork.MasterMenuRepository.ViewForClient(),
                MasterSliderList = _UnitOfWork.MasterSliderRepository.ViewForClient(),
                MasterAbout = (_UnitOfWork.MasterAboutRepository.ViewForClient().ToList().Count == 0 ? null : _UnitOfWork.MasterAboutRepository.ViewForClient().Take(1).OrderByDescending(data => data.MasterAboutId).ToList().ElementAt(0)),
                LastFiveMasterItemMenu = _UnitOfWork.MasterItemMenuRepository
                .ViewForClient()
                .OrderByDescending(data => data.MasterCategoryMenuId)
                .Take(5).ToList(),
                MasterOffer = (_UnitOfWork.MasterOfferRepository.ViewForClient().ToList().Count == 0 ? null : _UnitOfWork.MasterOfferRepository.ViewForClient().Take(1).OrderByDescending(data => data.MasterOfferId).ToList().ElementAt(0)),
                MasterPartnerList = _UnitOfWork.MasterPartnerRepository.ViewForClient(),
                MasterSocialMediaList = _UnitOfWork.MasterSocialMediaRepository.ViewForClient(),
                ContactUsFooterList = _UnitOfWork.MasterContactUsInformationRepository.ViewForClient().Where(data => data.MasterContactUsInformationRedirect.ToUpper() == "FOOTER").ToList(),
                MasterWorkingHourList = _UnitOfWork.MasterWorkingHourRepository.ViewForClient(),
            };
            return View(dataViewModel);
        }

        [HttpPost]
        public IActionResult Subscribe(string TransactionNewsletterEmail, string ViewName)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.message = "Failed";
                return RedirectToAction("Index", "Home", new { Message = ViewBag.message });
            }
            ViewBag.message = "Thank You For Subscribe Our Restaurant";
            TransactionNewsletter transactionNewsletter = new TransactionNewsletter()
            {
                TransactionNewsletterEmail = TransactionNewsletterEmail
            };
            _UnitOfWork.TransactionNewsletterRepository.Add(transactionNewsletter);
            return RedirectToAction(ViewName, "Home", new { Message = ViewBag.message });
        }

        [HttpPost]
        public IActionResult BookTable(HomeViewModel data)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.message = "Failed";
                return RedirectToAction("Index", "Home", new { Message = ViewBag.message });
            }
            ViewBag.message = "Thank You For Book At Our Restaurant";
            _UnitOfWork.TransactionBookTableRepository.Add(data.TransactionBookTable);
            return RedirectToAction("Index", "Home", new { Message = ViewBag.message });
        }

        public IActionResult About(string Message)
        {
            ViewBag.message = Message;
            HomeViewModel dataViewModel = new HomeViewModel()
            {
                SystemSetting = (_UnitOfWork.SystemSettingRepository.ViewForClient().ToList().Count == 0 ? null : _UnitOfWork.SystemSettingRepository.ViewForClient().Take(1).OrderByDescending(data => data.SystemSettingId).ToList().ElementAt(0)),
                MasterMenuList = _UnitOfWork.MasterMenuRepository.ViewForClient(),
                MasterAbout = (_UnitOfWork.MasterAboutRepository.ViewForClient().ToList().Count == 0 ? null : _UnitOfWork.MasterAboutRepository.ViewForClient().Take(1).OrderByDescending(data => data.MasterAboutId).ToList().ElementAt(0)),
                MasterServiceList = _UnitOfWork.MasterServiceRepository.ViewForClient(),
                MasterSocialMediaList = _UnitOfWork.MasterSocialMediaRepository.ViewForClient(),
                ContactUsFooterList = _UnitOfWork.MasterContactUsInformationRepository.ViewForClient().Where(data => data.MasterContactUsInformationRedirect.ToUpper() == "FOOTER").ToList(),
                MasterWorkingHourList = _UnitOfWork.MasterWorkingHourRepository.ViewForClient(),
            };
            return View(dataViewModel);
        }

        public IActionResult ContactUs(string Message)
        {
            ViewBag.message = Message;
            HomeViewModel dataViewModel = new HomeViewModel()
            {
                SystemSetting = (_UnitOfWork.SystemSettingRepository.ViewForClient().ToList().Count == 0 ? null : _UnitOfWork.SystemSettingRepository.ViewForClient().Take(1).OrderByDescending(data => data.SystemSettingId).ToList().ElementAt(0)),
                MasterMenuList = _UnitOfWork.MasterMenuRepository.ViewForClient(),
                ContactUsList = _UnitOfWork.MasterContactUsInformationRepository.ViewForClient().Where(data => data.MasterContactUsInformationRedirect.ToUpper() != "FOOTER").ToList(),
                MasterAbout = (_UnitOfWork.MasterAboutRepository.ViewForClient().ToList().Count == 0 ? null : _UnitOfWork.MasterAboutRepository.ViewForClient().Take(1).OrderByDescending(data => data.MasterAboutId).ToList().ElementAt(0)),
                MasterSocialMediaList = _UnitOfWork.MasterSocialMediaRepository.ViewForClient(),
                ContactUsFooterList = _UnitOfWork.MasterContactUsInformationRepository.ViewForClient().Where(data => data.MasterContactUsInformationRedirect.ToUpper() == "FOOTER").ToList(),
                MasterWorkingHourList = _UnitOfWork.MasterWorkingHourRepository.ViewForClient(),
            };
            return View(dataViewModel);
        }

        [HttpPost]
        public IActionResult Message(HomeViewModel data)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.message = "Failed";
                return RedirectToAction("ContactUs", "Home", new { Message = ViewBag.message });
            }
            ViewBag.message = "Your Massage Is Send Successfully";
            _UnitOfWork.TransactionContactUsRepository.Add(data.TransactionContactUs);
            return RedirectToAction("ContactUs", "Home", new { Message = ViewBag.message });
        }

        public IActionResult Menu(string Message)
        {
            ViewBag.message = Message;
            HomeViewModel dataViewModel = new HomeViewModel()
            {
                SystemSetting = (_UnitOfWork.SystemSettingRepository.ViewForClient().ToList().Count == 0 ? null : _UnitOfWork.SystemSettingRepository.ViewForClient().Take(1).OrderByDescending(data => data.SystemSettingId).ToList().ElementAt(0)),
                MasterMenuList = _UnitOfWork.MasterMenuRepository.ViewForClient(),
                MasterCategoryMenuList = _UnitOfWork.MasterCategoryMenuRepository.ViewForClient(),
                MasterItemMenuList = _UnitOfWork.MasterItemMenuRepository.ViewForClient(),
                MasterPartnerList = _UnitOfWork.MasterPartnerRepository.ViewForClient(),
                MasterAbout = (_UnitOfWork.MasterAboutRepository.ViewForClient().ToList().Count == 0 ? null : _UnitOfWork.MasterAboutRepository.ViewForClient().Take(1).OrderByDescending(data => data.MasterAboutId).ToList().ElementAt(0)),
                MasterSocialMediaList = _UnitOfWork.MasterSocialMediaRepository.ViewForClient(),
                ContactUsFooterList = _UnitOfWork.MasterContactUsInformationRepository.ViewForClient().Where(data => data.MasterContactUsInformationRedirect.ToUpper() == "FOOTER").ToList(),
                MasterWorkingHourList = _UnitOfWork.MasterWorkingHourRepository.ViewForClient(),
            };
            return View(dataViewModel);
        }
    }
}
