using coreData.data;
using coreModel.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
namespace CocukLise.Controllers
{
    public class BirimController : Controller
    {
        public readonly ApplicationDbContext context;
        public BirimController(ApplicationDbContext context)
        {
            this.context = context;
        }


     
        public IActionResult Liste()
        {

            var sonuc = context.birims.ToList();

            return View(sonuc);
        }


        public IActionResult Ekle()
        {

            return View();


        }

        [HttpPost]
        public async Task<IActionResult> Ekle(Birimler birimler)
        {

            context.Add(birimler);
            await context.SaveChangesAsync();
            return RedirectToAction("Liste");



        }

        public async Task<IActionResult> Güncelle(int? id)
        {

            if (id == null)
            {

                RedirectToAction("Liste");
            }
            var sonuc = await context.birims.FindAsync(id);
            return View(sonuc);

        }

        [HttpPost]
        public async Task<IActionResult> Güncelle(Birimler birimler)
        {


            context.Update(birimler);
            await context.SaveChangesAsync();

            return RedirectToAction("Liste");

        }

        public async Task<IActionResult> Sil(int? id)
        {
            if (id == null)
            {

                return RedirectToAction("Liste");
            }


            var sonuc = await context.birims.FindAsync(id);
            return View(sonuc);


        }
        [HttpPost]
        public async Task<IActionResult> Sil(int id)
        {
            var sonuc = await context.birims.FindAsync(id);
            context.birims.Remove(sonuc);
            await context.SaveChangesAsync();
            return RedirectToAction("Liste");

        }

    }
}
