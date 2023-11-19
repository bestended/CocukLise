﻿using coreData.data;
using coreModel.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
namespace CocukLise.Controllers
{
    public class CocukController : Controller
    {
        public readonly ApplicationDbContext context;
        public CocukController(ApplicationDbContext context)
        {


            this.context = context;

        }


        public IActionResult Liste()
        {
            var sonuc = context.cocuks.ToList();


            return View(sonuc);
        }


        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ekle(Cocuklar cocuk)
        {
            context.Add(cocuk);
            await context.SaveChangesAsync();
            return RedirectToAction("Liste");



        }

        public async Task<IActionResult> Güncelle(int? id)
        {
            if (id == null)
            {
                RedirectToAction("Liste");

            }
            var sonuc = await context.cocuks.FindAsync(id);
            return View(sonuc);

        }
        [HttpPost]
        public async Task<IActionResult> Güncelle(Cocuklar cocuk)
        {
            context.Update(cocuk);
            await context.SaveChangesAsync();
            return RedirectToAction("Liste");

        }

        public async Task<IActionResult> Sil(int? id)
        {
            if (id == null)
            {
                RedirectToAction("Liste");
            }
            var sonuc = await context.cocuks.FindAsync(id);
            return View(sonuc);

        }

        [HttpPost]
        public async Task<IActionResult> Sil(int id)
        {

            var sonuc = await context.cocuks.FindAsync(id);
            context.cocuks.Remove(sonuc);
            await context.SaveChangesAsync();
            return RedirectToAction("Liste");




        }

    }
}
