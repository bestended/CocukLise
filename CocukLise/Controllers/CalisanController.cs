using coreData.data;
using coreModel.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace CocukLise.Controllers
{
    public class CalisanController : Controller
    {
        public readonly ApplicationDbContext context;
        public CalisanController(ApplicationDbContext context)
        {
            this.context = context;
        }



        public IActionResult Liste()
        {

            var sonuc = context.calisans.ToList();

            return View(sonuc);
        }


        public IActionResult Ekle()
        {

            return View();


        }

        [HttpPost]
        public async Task<IActionResult> Ekle(Personeller personeller)
        {

            context.Add(personeller);
            await context.SaveChangesAsync();
            return RedirectToAction("Liste");



        }

        public async Task<IActionResult> Güncelle(int? id)
        {

            if (id == null)
            {

                RedirectToAction("Liste");
            }
            var sonuc = await context.calisans.FindAsync(id);
            return View(sonuc);

        }

        [HttpPost]
        public async Task<IActionResult> Güncelle(Personeller personeller)
        {


            context.Update(personeller);
            await context.SaveChangesAsync();

            return RedirectToAction("Liste");

        }

        public async Task<IActionResult> Sil(int? id)
        {
            if (id == null)
            {

                return RedirectToAction("Liste");
            }


            var sonuc = await context.calisans.FindAsync(id);
            return View(sonuc);


        }
        [HttpPost]
        public async Task<IActionResult> Sil(int id)
        {
            var sonuc = await context.calisans.FindAsync(id);
            context.calisans.Remove(sonuc);
            await context.SaveChangesAsync();
            return RedirectToAction("Liste");

        }
 
        
    }
}
