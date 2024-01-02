using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Repositories;
using Restaurant.Models;
using Restaurant.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TransactionNewsletterController : Controller
    {
        public IRepository<TransactionNewsletter> TransactionNewsletterRepository { get; }

        public TransactionNewsletterController(IRepository<TransactionNewsletter> TransactionNewsletterRepository)
        {
            this.TransactionNewsletterRepository = TransactionNewsletterRepository;
        }

        public IActionResult Index()
        {
            IList<TransactionNewsletter> dataList = TransactionNewsletterRepository.View();
            IList<TransactionNewsletterViewModel> dataViewModelList = new List<TransactionNewsletterViewModel>();
            foreach (var data in dataList)
            {
                TransactionNewsletterViewModel dataViewModel = new TransactionNewsletterViewModel()
                {
                    TransactionNewsletterId = data.TransactionNewsletterId,
                    TransactionNewsletterEmail = data.TransactionNewsletterEmail,
                };
                dataViewModelList.Add(dataViewModel);
            }
            return View(dataViewModelList);
        }
    }
}
