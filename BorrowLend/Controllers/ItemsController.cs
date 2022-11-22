using BorrowLend.DataBaseAccess;
using BorrowLend.Entity;
using BorrowLend.Repository;
using BorrowLend.ViewModel.ItemVM;
using BorrowLend.ViewModel.Shared;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BorrowLend.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Index(DisplayVM model)
        {
            model.Pager ??= new PagerVM();
            model.Filter ??= new FilterVM();
            model.Pager.ItemsPerPage = model.Pager.ItemsPerPage <= 0
                                        ? 10
                                        : model.Pager.ItemsPerPage;

            model.Pager.Page = model.Pager.Page <= 0
                                    ? 1
                                    : model.Pager.Page;

            var filter = model.Filter.GetFilter();

            ItemRepository itemRepository = new ItemRepository();
            model.ItemsList = itemRepository.GetAll(filter, model.Pager.Page, model.Pager.ItemsPerPage);
            model.Pager.PagesCount = (int)Math.Ceiling(itemRepository.UsersCount(filter) / (double)model.Pager.ItemsPerPage);

            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateVM item)
        {
            ItemRepository itemRepository = new ItemRepository();
            Item newItem = new Item();

            newItem.Name = item.Name;
            newItem.Borrower = item.Borrower;
            newItem.Lender = item.Lender;
            itemRepository.Add(newItem);
            return RedirectToAction("Index", "Items");
        }
        public IActionResult Delete(int id)
        {
            ItemRepository itemRepository = new ItemRepository();
            itemRepository.Delete(id);
            return RedirectToAction("Index", "Items");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Context context = new Context();
            Item item = context.Items.Find(id);
            EditVM editVM = new EditVM();

            editVM.ID = item.Id;
            editVM.Name = item.Name;
            editVM.Borrower = item.Borrower;
            editVM.Lender = item.Lender;

            return View(editVM);
        }
        [HttpPost]
        public IActionResult Update(EditVM item)
        {
            ItemRepository itemRepository = new ItemRepository();
            Item newItem = new Item();

            newItem.Id = item.ID;
            newItem.Name = item.Name;
            newItem.Borrower = item.Borrower;
            newItem.Lender = item.Lender;

            itemRepository.Update(newItem);

            return RedirectToAction("Index", "Items");
        }
    }
}
