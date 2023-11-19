using coreData.data;
using coreModel.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
namespace CocukLise.Controllers
{
    public class GorevController : Controller
    {
        public readonly ApplicationDbContext context;
        public GorevController(ApplicationDbContext context)
        {


            this.context = context;

        }


        public IActionResult Liste()
        {
            var sonuc = context.gorevs.ToList();


            return View(sonuc);
        }


        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ekle(Gorevler gorevler)
        {
            context.Add(gorevler);
            await context.SaveChangesAsync();
            return RedirectToAction("Liste");



        }

        public async Task<IActionResult> Güncelle(int? id)
        {
            if (id == null)
            {
                RedirectToAction("Liste");

            }
            var sonuc = await context.gorevs.FindAsync(id);
            return View(sonuc);

        }
        [HttpPost]
        public async Task<IActionResult> Güncelle(Gorevler gorevler)
        {
            context.Update(gorevler);
            await context.SaveChangesAsync();
            return RedirectToAction("Liste");

        }

        public async Task<IActionResult> Sil(int? id)
        {
            if (id == null)
            {
                RedirectToAction("Liste");
            }
            var sonuc = await context.gorevs.FindAsync(id);
            return View(sonuc);

        }

        [HttpPost]
        public async Task<IActionResult> Sil(int id)
        {

            var sonuc = await context.gorevs.FindAsync(id);
            context.gorevs.Remove(sonuc);
            await context.SaveChangesAsync();
            return RedirectToAction("Liste");




        }

    }
}
