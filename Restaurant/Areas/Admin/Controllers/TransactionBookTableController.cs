﻿using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Repositories;
using Restaurant.Models;
using Restaurant.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TransactionBookTableController : Controller
    {
        public IRepository<TransactionBookTable> TransactionBookTableRepository { get; }

        public TransactionBookTableController(IRepository<TransactionBookTable> TransactionBookTableRepository)
        {
            this.TransactionBookTableRepository = TransactionBookTableRepository;
        }

        public IActionResult Index()
        {
            IList<TransactionBookTable> dataList = TransactionBookTableRepository.View();
            IList<TransactionBookTableViewModel> dataViewModelList = new List<TransactionBookTableViewModel>();
            foreach (var data in dataList)
            {
                TransactionBookTableViewModel dataViewModel = new TransactionBookTableViewModel()
                {
                    TransactionBookTableId = data.TransactionBookTableId,
                    TransactionBookTableFullName = data.TransactionBookTableFullName,
                    TransactionBookTableEmail = data.TransactionBookTableEmail,
                    TransactionBookTableMobileNumber = data.TransactionBookTableMobileNumber,
                    TransactionBookTableDate = data.TransactionBookTableDate
                };
                dataViewModelList.Add(dataViewModel);
            }
            return View(dataViewModelList);
        }
    }
}
