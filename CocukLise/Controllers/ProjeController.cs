using coreData.data;
using coreModel.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
namespace CocukLise.Controllers
{
    public class ProjeController : Controller
    {
        public readonly ApplicationDbContext context;
        public ProjeController(ApplicationDbContext context)
        {
            this.context = context;
        }


        public IActionResult Liste()
        {
            var sonuc = context.projes.ToList();
            return View(sonuc);
        }


        public IActionResult Ekle()
        {


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Ekle(Projeler projeler)
        {
            context.Add(projeler);
            await context.SaveChangesAsync();
            return RedirectToAction("Liste");



        }

        public async Task<IActionResult> Güncelle(int? id)
        {

            if (id == null)
            {

                return RedirectToAction("Liste");
            }

            var sonuc = await context.projes.FindAsync(id);
            return View(sonuc);


        }

        [HttpPost]
        public async Task<IActionResult> Güncelle(Projeler projeler)
        {
            context.Update(projeler);
            await context.SaveChangesAsync();
            return RedirectToAction("Liste");



        }

        public async Task<IActionResult> Sil(int? id)
        {
            if (id == null)
            {

                return RedirectToAction("Liste");
            }
            var sonuc = await context.projes.FindAsync(id);
            return View(sonuc);
        }

        [HttpPost]

        public async Task<IActionResult> Sil(int id)
        {
            var sonuc = await context.projes.FindAsync(id);
            context.projes.Remove(sonuc);
            await context.SaveChangesAsync();
            return RedirectToAction("Liste");

        }




    }

}
