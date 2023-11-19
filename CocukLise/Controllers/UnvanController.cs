using coreData.data;
using coreModel.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
namespace CocukLise.Controllers
{
    public class UnvanController : Controller
    {
        public readonly ApplicationDbContext context;
        public UnvanController(ApplicationDbContext context)
        {
            this.context = context;
        }



        public IActionResult Liste()
        {

            var sonuc = context.unvans.ToList();

            return View(sonuc);
        }


        public IActionResult Ekle()
        {

            return View();


        }

        [HttpPost]
        public async Task<IActionResult> Ekle(Unvanlar unvanlar)
        {

            context.Add(unvanlar);
            await context.SaveChangesAsync();
            return RedirectToAction("Liste");



        }

        public async Task<IActionResult> Güncelle(int? id)
        {

            if (id == null)
            {

                RedirectToAction("Liste");
            }
            var sonuc = await context.unvans.FindAsync(id);
            return View(sonuc);

        }

        [HttpPost]
        public async Task<IActionResult> Güncelle(Unvanlar unvanlar)
        {


            context.Update(unvanlar);
            await context.SaveChangesAsync();

            return RedirectToAction("Liste");

        }

        public async Task<IActionResult> Sil(int? id)
        {
            if (id == null)
            {

                return RedirectToAction("Liste");
            }


            var sonuc = await context.unvans.FindAsync(id);
            return View(sonuc);


        }
        [HttpPost]
        public async Task<IActionResult> Sil(int id)
        {
            var sonuc = await context.unvans.FindAsync(id);
            context.unvans.Remove(sonuc);
            await context.SaveChangesAsync();
            return RedirectToAction("Liste");

        }

    }
}
