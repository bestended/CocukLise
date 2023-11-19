using coreData.data;
using coreModel.listView;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace CocukLise.Controllers
{
    public class CalisanUnvanController : Controller
    {
        public readonly ApplicationDbContext context;
        public CalisanUnvanController(ApplicationDbContext context)
        {
            this.context = context;
        }



        public IActionResult Liste()
        {
            var sonuc = (from c in context.calisans
                         join u in context.unvans
                         on c.unvanID equals u.unvanID
                         select new CalisanUnvan
                         {
                             calisanID = c.calisanID,
                             adSoyad = c.adSoyad,
                             calisanCinsiyet = c.calisanCinsiyet,
                             iseBaslamaTarih = c.iseBaslamaTarih,
                             calisanVardiya = c.calisanVardiya,
                             calisanMaas = c.calisanMaas,
                             calisanPrim = c.calisanPrim,
                             unvanID = u.unvanID,
                             unvanAdi=u.unvanAdi

                         }).ToList();
            return View(sonuc);


        }

    }
}
