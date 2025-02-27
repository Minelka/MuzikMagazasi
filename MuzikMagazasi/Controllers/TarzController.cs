using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuzikMagazasi.Context.Entities;
using MuzikMagazasi.Context;
using MuzikMagazasi.Models;

namespace MuzikMagazasi.Controllers
{
    public class TarzController : Controller
    {

        private IMapper _mapper;
        private MuzikMagazaDbContext _dbContext;

        public TarzController(MuzikMagazaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            List<Tarz> Tarzlar = _dbContext.Tarzlar.Where(c => c.IsDeleted == false).ToList();
            List<TarzViewModel> model = _mapper.Map<List<TarzViewModel>>(Tarzlar);

            return View(model);
        }

        [HttpGet]
        public IActionResult Add(bool isAjaxPage = false)
        {
            TarzViewModel model = new TarzViewModel();

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
        public IActionResult Add(TarzViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Tarz tarz = _mapper.Map<Tarz>(model);

            _dbContext.Tarzlar.Add(tarz);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult AddAjax([FromBody] TarzViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model invalid");

            Tarz tarz = _mapper.Map<Tarz>(model);

            _dbContext.Tarzlar.Add(tarz);
            _dbContext.SaveChanges();

            return Ok(new { Message = "Kayıt Başarıyla tamamlandı" });
        }

        public IActionResult Edit(int id)
        {
            Tarz? tarz = _dbContext.Tarzlar.Where(c => c.Id == id && c.IsDeleted == false).FirstOrDefault();

            if (tarz is null)
            {
                TempData["RecordNotFounded"] = $"Id : {id} li kayıt bulunamadığı için düzenleme yapılamıyor.";
                return RedirectToAction(nameof(Index));
            }

            TarzViewModel model = _mapper.Map<TarzViewModel>(tarz);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TarzViewModel model)
        {
            int id = model.Id;

            if (!ModelState.IsValid)
                return View(model);

            Tarz? orginalTarz = _dbContext.Tarzlar.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();

            if (orginalTarz is null)
            {
                TempData["RecordNotFounded"] = $"Id : {id} li kayıt bulunamadığı için düzenleme yapılamıyor.";
                return RedirectToAction(nameof(Index));
            }

            Tarz tarz = _mapper.Map<Tarz>(model);

            tarz.Created = orginalTarz.Created;
            tarz.Updated = DateTime.Now;

            _dbContext.Tarzlar.Update(tarz);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            Tarz? tarz = _dbContext.Tarzlar.Where(c => c.Id == id && c.IsDeleted == false).FirstOrDefault();

            if (tarz is null)
            {
                TempData["RecordNotFounded"] = $"Id : {id} li kayıt bulunamadığı için düzenleme yapılamıyor.";
                return RedirectToAction(nameof(Index));
            }

            TarzViewModel model = _mapper.Map<TarzViewModel>(tarz);

            return View(model);
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            Tarz? tarz = _dbContext.Tarzlar.AsNoTracking().Where(c => c.Id == id && c.IsDeleted == false).FirstOrDefault();

            if (tarz is null)
            {
                TempData["RecordNotFounded"] = $"Id : {id} kayıt bulunamadığı için kayıt silinemedi.";
                return RedirectToAction(nameof(Index));
            }

            tarz.IsDeleted = true;
            tarz.Deleted = DateTime.Now;

            _dbContext.Tarzlar.Update(tarz); // Bu id başka biri tarafından gözleniyor takip
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult GetActiveTarzList()
        {
            if (Request.Headers["User-Agent"].ToString().Contains("PostmanRuntime"))
                return BadRequest("Postman istekleri kabul edilmiyor");

            List<Tarz> Tarzlar = _dbContext.Tarzlar.Where(c => c.IsActive == true && c.IsDeleted == false).ToList();

            List<TarzViewModel> tarzViewModels = _mapper.Map<List<TarzViewModel>>(Tarzlar);

            return PartialView(tarzViewModels);
        }

        [HttpGet]
        public JsonResult GetActiveTarzListJson()
        {
            List<Tarz> Tarzlar = _dbContext.Tarzlar.Where(c => c.IsActive == true && c.IsDeleted == false).ToList();

            List<TarzViewModel> tarzViewModels = _mapper.Map<List<TarzViewModel>>(Tarzlar);

            return Json(tarzViewModels);
        }

    }
}
