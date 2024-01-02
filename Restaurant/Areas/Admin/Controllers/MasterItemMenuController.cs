using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using Restaurant.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterItemMenuController : Controller
    {
        public IRepository<MasterItemMenu> MasterItemMenuRepository { get; }
        public IRepository<MasterCategoryMenu> MasterCategoryMenuRepository { get; }
        public IHostingEnvironment HostingEnvironment { get; }

        public MasterItemMenuController(
            IRepository<MasterItemMenu> MasterItemMenuRepository,
            IRepository<MasterCategoryMenu> MasterCategoryMenuRepository,
            IHostingEnvironment HostingEnvironment)
        {
            this.MasterItemMenuRepository = MasterItemMenuRepository;
            this.MasterCategoryMenuRepository = MasterCategoryMenuRepository;
            this.HostingEnvironment = HostingEnvironment;
        }
        public ActionResult Index()
        {
            IList<MasterItemMenu> dataList = MasterItemMenuRepository.View();
            IList<MasterItemMenuViewModel> dataViewModelList = new List<MasterItemMenuViewModel>();
            foreach (var data in dataList)
            {
                MasterItemMenuViewModel dataViewModel = new MasterItemMenuViewModel()
                {
                    MasterItemMenuId = data.MasterItemMenuId,
                    MasterCategoryMenuId = data.MasterCategoryMenuId,
                    MasterItemMenuTitle = data.MasterItemMenuTitle,
                    MasterItemMenuBreif = data.MasterItemMenuBreif,
                    MasterItemMenuDesc = data.MasterItemMenuDesc,
                    MasterItemMenuPrice = data.MasterItemMenuPrice,
                    MasterItemMenuImageUrl = data.MasterItemMenuImageUrl,
                    MasterItemMenuDate = data.MasterItemMenuDate,
                    MasterCategoryMenu = data.MasterCategoryMenu,
                    IsActive = data.IsActive
                };
                dataViewModelList.Add(dataViewModel);
            }
            return View(dataViewModelList);
        }

        public ActionResult Active(int id)
        {
            MasterItemMenuRepository.Active(id, new MasterItemMenu()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            MasterCategoryMenu newData = new MasterCategoryMenu()
            {
                MasterCategoryMenuId = 0,
                MasterCategoryMenuName = "-- Select List --"
            };
            IList<MasterCategoryMenu> dataList = MasterCategoryMenuRepository.View();
            IList<MasterCategoryMenu> newDataList = new List<MasterCategoryMenu>();
            newDataList.Add(newData);
            foreach (var item in dataList)
            {
                newDataList.Add(item);
            }
            ViewBag.MasterCategoryMenuList = newDataList;
            MasterItemMenuViewModel dataViewModel = new MasterItemMenuViewModel();
            return View(dataViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterItemMenuViewModel dataViewModel)
        {
            try
            {
                string imageName = "";
                if (dataViewModel.UploadImage != null)
                {
                    string imagePath = Path.Combine(HostingEnvironment.WebRootPath, "images/item");
                    FileInfo fileInfo = new FileInfo(dataViewModel.UploadImage.FileName);
                    imageName = "masterItemMenuImage" + Guid.NewGuid() + fileInfo.Extension;
                    string fullPath = Path.Combine(imagePath, imageName);
                    dataViewModel.UploadImage.CopyTo(new FileStream(fullPath, FileMode.Create));

                }
                MasterItemMenu data = new MasterItemMenu()
                {
                    MasterCategoryMenuId = (dataViewModel.MasterCategoryMenuId == 0 ? null : dataViewModel.MasterCategoryMenuId),
                    MasterItemMenuTitle = dataViewModel.MasterItemMenuTitle,
                    MasterItemMenuBreif = dataViewModel.MasterItemMenuBreif,
                    MasterItemMenuDesc = dataViewModel.MasterItemMenuDesc,
                    MasterItemMenuPrice = dataViewModel.MasterItemMenuPrice,
                    MasterItemMenuImageUrl = (string.IsNullOrEmpty(imageName) ? null : imageName),
                    MasterItemMenuDate = dataViewModel.MasterItemMenuDate,
                    IsActive = true,
                    IsDelete = false,
                    CreateDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };
                MasterItemMenuRepository.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            MasterCategoryMenu newData = new MasterCategoryMenu()
            {
                MasterCategoryMenuId = 0,
                MasterCategoryMenuName = "-- Select List --"
            };
            IList<MasterCategoryMenu> dataList = MasterCategoryMenuRepository.View();
            IList<MasterCategoryMenu> newDataList = new List<MasterCategoryMenu>();
            newDataList.Add(newData);
            foreach (var item in dataList)
            {
                newDataList.Add(item);
            }
            ViewBag.MasterCategoryMenuList = newDataList;
            MasterItemMenu data = MasterItemMenuRepository.Find(id);
            MasterItemMenuViewModel dataViewModel = new MasterItemMenuViewModel()
            {
                MasterItemMenuId = data.MasterItemMenuId,
                MasterCategoryMenuId = data.MasterCategoryMenuId,
                MasterItemMenuTitle = data.MasterItemMenuTitle,
                MasterItemMenuBreif = data.MasterItemMenuBreif,
                MasterItemMenuDesc = data.MasterItemMenuDesc,
                MasterItemMenuPrice = data.MasterItemMenuPrice,
                MasterItemMenuImageUrl = data.MasterItemMenuImageUrl,
                MasterItemMenuDate = data.MasterItemMenuDate,
                MasterCategoryMenu = data.MasterCategoryMenu
            };
            return View(dataViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterItemMenuViewModel dataViewModel)
        {
            try
            {
                string imageName = dataViewModel.MasterItemMenuImageUrl;
                if (dataViewModel.UploadImage != null)
                {
                    string imagePath = Path.Combine(HostingEnvironment.WebRootPath, "images/item");
                    FileInfo fileInfo = new FileInfo(dataViewModel.UploadImage.FileName);
                    imageName = "masterItemMenuImage" + Guid.NewGuid() + fileInfo.Extension;
                    string fullPath = Path.Combine(imagePath, imageName);
                    dataViewModel.UploadImage.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                MasterItemMenu data = MasterItemMenuRepository.Find(id);

                data.MasterCategoryMenuId = (dataViewModel.MasterCategoryMenuId == 0 ? null : dataViewModel.MasterCategoryMenuId);
                data.MasterItemMenuTitle = dataViewModel.MasterItemMenuTitle;
                data.MasterItemMenuBreif = dataViewModel.MasterItemMenuBreif;
                data.MasterItemMenuDesc = dataViewModel.MasterItemMenuDesc;
                data.MasterItemMenuPrice = dataViewModel.MasterItemMenuPrice;
                data.MasterItemMenuImageUrl = (string.IsNullOrEmpty(imageName) ? null : imageName);
                data.MasterItemMenuDate = dataViewModel.MasterItemMenuDate;
                data.EditDate = DateTime.UtcNow;
                data.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                MasterItemMenuRepository.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            MasterItemMenuRepository.Delete(id, new MasterItemMenu()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }
    }
}
