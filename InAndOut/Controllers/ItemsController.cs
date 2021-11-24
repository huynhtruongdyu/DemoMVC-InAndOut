using InAndOut.Infrastructure.Contexts;
using InAndOut.Models;
using InAndOut.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InAndOut.Controllers
{
    public class ItemsController : Controller
    {
        private readonly AppDbContext _context;

        public ItemsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Items
        [HttpGet]
        public IActionResult Index()
        {
            var items = _context.Items.Include(x=>x.ItemType).ToList();
            return View(items);
        }

        // GET: Items/Create
        [HttpGet]
        public IActionResult Create()
        {
            ItemVM itemVM = new()
            {
                Item = new Item(),
                ItemTypeDropdown = _context.ItemTypes.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };

            return View(itemVM);
        }

        // POST: Items/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ItemVM itemVM)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Add(itemVM.Item);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemVM);
        }

        // GET: Items/Delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var item = _context.Items.Find(id.Value);
                if (item is null)
                    return NotFound();
                return View(item);
            }
            return NotFound();
        }

        // POST: Items/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            if (id.HasValue)
            {
                var item = _context.Items.Find(id.Value);
                if (item is null)
                    return NotFound();
                _context.Items.Remove(item);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        // GET: Items/Update
        [HttpGet]
        public IActionResult Update(int? id)
        {
            ItemVM itemVM = new ItemVM();
            if (id.HasValue)
            {
                var item = _context.Items.Find(id.Value);
                var itemTypeDropdown = _context.ItemTypes.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
                itemVM.Item = item;
                itemVM.ItemTypeDropdown = itemTypeDropdown;
                return View(itemVM);
            }
            return NotFound();
        }

        // POST: Items/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ItemVM itemVM)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Update(itemVM.Item);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemVM);
        }
    }
}