using Microsoft.AspNetCore.Mvc;
using Udemy.DataAccess;
using Udemy.DataAccess.Repository.IRepository;
using Udemy.Models;

namespace Udemy.Areas.Admin.Controllers
{
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<CoverType> objCoverTypeList = _unitOfWork.CoverType.GetAll(); // we will bass this information to CoverType Index view
            return View(objCoverTypeList);
        }
        //get
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType obj)
        {
            if (ModelState.IsValid)// this is to verify if our model is valed or no
            {
                _unitOfWork.CoverType.Add(obj);// we are basing the object that we need to add it to CoverType(friction,fantisy,romanc....)
                _unitOfWork.Save();
                TempData["success"] = "CoverType created successfully";
                return RedirectToAction("Index");// if we wanr to redirect to different controler we do as return veiw redirecttoaction("Index" ,the controler name)
            }
            return View(obj);
        }
        //get
        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var CategoryFromDbFirst=_unitOfWork.Categories.Find(id);
            var CovertypeFromDbFirst = _unitOfWork.CoverType.getFirstOrDefault(u => u.Id == id);
            if (CovertypeFromDbFirst == null)
            {
                return NotFound();
            }
            return View(CovertypeFromDbFirst);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "CoverType updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //get
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var CategoryFromDbFirst = _unitOfWork.Categories.Find(id);
            var CovertypeFromDbFirst = _unitOfWork.CoverType.getFirstOrDefault(u => u.Id == id);
            if (CovertypeFromDbFirst == null)
            {
                return NotFound();
            }
            return View(CovertypeFromDbFirst);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            var obj = _unitOfWork.CoverType.getFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.CoverType.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "CoverType deleted successfully";
            return RedirectToAction("Index");


        }
    }
}
