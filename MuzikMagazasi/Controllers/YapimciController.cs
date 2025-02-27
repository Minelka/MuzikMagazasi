using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MuzikMagazasi.Context.Entities;
using MuzikMagazasi.Context;
using MuzikMagazasi.Models;
using Microsoft.EntityFrameworkCore;

namespace MuzikMagazasi.Controllers
{
    public class YapimciController : Controller
    {
        private IMapper _mapper;
        private MuzikMagazaDbContext _dbContext;

        public YapimciController(MuzikMagazaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            List<Yapimci> Yapimcilar = _dbContext.Yapimcilar.Where(c => c.IsDeleted == false).ToList();
            List<YapimciViewModel> model = _mapper.Map<List<YapimciViewModel>>(Yapimcilar);

            return View(model);
        }

        [HttpGet]
        public IActionResult Add(bool isAjaxPage = false)
        {
            YapimciViewModel model = new YapimciViewModel();

            if (isAjaxPage)
            {
                ViewBag.IsAjaxPage = true;
                return PartialView(model);
            }

            ViewBag.IsAjaxPage = false;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(YapimciViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Yapimci yapimci = _mapper.Map<Yapimci>(model);

            _dbContext.Yapimcilar.Add(yapimci);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult AddAjax([FromBody] YapimciViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model invalid");

            Yapimci yapimci = _mapper.Map<Yapimci>(model);

            _dbContext.Yapimcilar.Add(yapimci);
            _dbContext.SaveChanges();

            return Ok(new { Message = "Kayıt Başarıyla tamamlandı" });
        }

        public IActionResult Edit(int id)
        {
            Yapimci? yapimci = _dbContext.Yapimcilar.Where(c => c.Id == id && c.IsDeleted == false).FirstOrDefault();

            if (yapimci is null)
            {
                TempData["RecordNotFounded"] = $"Id : {id} li kayıt bulunamadığı için düzenleme yapılamıyor.";
                return RedirectToAction(nameof(Index));
            }

            YapimciViewModel model = _mapper.Map<YapimciViewModel>(yapimci);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(YapimciViewModel model)
        {
            int id = model.Id;

            if (!ModelState.IsValid)
                return View(model);

            Yapimci? orginalYapimci = _dbContext.Yapimcilar.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();

            if (orginalYapimci is null)
            {
                TempData["RecordNotFounded"] = $"Id : {id} li kayıt bulunamadığı için düzenleme yapılamıyor.";
                return RedirectToAction(nameof(Index));
            }

            Yapimci yapimci = _mapper.Map<Yapimci>(model);

            yapimci.Created = orginalYapimci.Created;
            yapimci.Updated = DateTime.Now;

            _dbContext.Yapimcilar.Update(yapimci);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            Yapimci? yapimci = _dbContext.Yapimcilar.Where(c => c.Id == id && c.IsDeleted == false).FirstOrDefault();

            if (yapimci is null)
            {
                TempData["RecordNotFounded"] = $"Id : {id} li kayıt bulunamadığı için düzenleme yapılamıyor.";
                return RedirectToAction(nameof(Index));
            }

            YapimciViewModel model = _mapper.Map<YapimciViewModel>(yapimci);

            return View(model);
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            Yapimci? yapimci = _dbContext.Yapimcilar.AsNoTracking().Where(c => c.Id == id && c.IsDeleted == false).FirstOrDefault();

            if (yapimci is null)
            {
                TempData["RecordNotFounded"] = $"Id : {id} kayıt bulunamadığı için kayıt silinemedi.";
                return RedirectToAction(nameof(Index));
            }

            yapimci.IsDeleted = true;
            yapimci.Deleted = DateTime.Now;

            _dbContext.Yapimcilar.Update(yapimci); // Bu id başka biri tarafından gözleniyor takip
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult GetActiveYapimciList()
        {
            if (Request.Headers["User-Agent"].ToString().Contains("PostmanRuntime"))
                return BadRequest("Postman istekleri kabul edilmiyor");

            List<Yapimci> Yapimcilar = _dbContext.Yapimcilar.Where(c => c.IsActive == true && c.IsDeleted == false).ToList();

            List<YapimciViewModel> yapimciViewModels = _mapper.Map<List<YapimciViewModel>>(Yapimcilar);

            return PartialView(yapimciViewModels);
        }

        [HttpGet]
        public JsonResult GetActiveYapimciListJson()
        {
            List<Yapimci> Yapimcilar = _dbContext.Yapimcilar.Where(c => c.IsActive == true && c.IsDeleted == false).ToList();

            List<YapimciViewModel> yapimciViewModels = _mapper.Map<List<YapimciViewModel>>(Yapimcilar);

            return Json(yapimciViewModels);
        }
    }
}
