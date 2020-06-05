using FoodOrderSolution.Business.Core;
using FoodOrderSolution.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodOrderSolution.Admin.Controllers
{
    [CheckLogin]
    public class VendorController : Controller
    {
        // GET: Vendor
        IVendorBusiness _vendorBusiness;
        IPromotionBusiness _promotionBusiness;
        IVendorLevelBusiness _vendorLevelBusiness;
        IContractBusiness _contractBusiness;
        public VendorController(IVendorBusiness vendorBusiness, IPromotionBusiness promotionBusiness, IVendorLevelBusiness vendorLevelBusiness, IContractBusiness contractBusiness)
        {
            this._vendorBusiness = vendorBusiness;
            this._promotionBusiness = promotionBusiness;
            this._vendorLevelBusiness = vendorLevelBusiness;
            this._contractBusiness = contractBusiness;
        }
        public ActionResult List()
        {
            try
            {
                var result = _vendorBusiness.GetAll();
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult Add()
        {
            try
            {
                var contracts = _contractBusiness.GetAll();
                var levels = _vendorLevelBusiness.GetAll();
                ViewBag.ContractLst = contracts;
                ViewBag.LevelLst = levels;
                return View();
            }
            catch (Exception)
            {

                return View();
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(VendorView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_vendorBusiness.Add(model)!=null)
                    {
                        _vendorBusiness.Save();
                        return Redirect("/Vendor/List");
                    }
                }
                var contracts = _contractBusiness.GetAll();
                var levels = _vendorLevelBusiness.GetAll();
                ViewBag.ContractLst = contracts;
                ViewBag.LevelLst = levels;
                return View(model);
            }
            catch (Exception)
            {
                var contracts = _contractBusiness.GetAll();
                var levels = _vendorLevelBusiness.GetAll();
                ViewBag.ContractLst = contracts;
                ViewBag.LevelLst = levels;
                return View(model);
            }
        }
        public ActionResult Edit(int id)
        {
            try
            {
                var contracts = _contractBusiness.GetAll();
                var levels = _vendorLevelBusiness.GetAll();
                ViewBag.ContractLst = contracts;
                ViewBag.LevelLst = levels;
                var result = _vendorBusiness.GetById(id);
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(VendorView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_vendorBusiness.Add(model) != null)
                    {
                        _vendorBusiness.Save();
                        return Redirect("/Vendor/List");
                    }
                }
                var contracts = _contractBusiness.GetAll();
                var levels = _vendorLevelBusiness.GetAll();
                ViewBag.ContractLst = contracts;
                ViewBag.LevelLst = levels;
                return View(model);
            }
            catch (Exception)
            {
                var contracts = _contractBusiness.GetAll();
                var levels = _vendorLevelBusiness.GetAll();
                ViewBag.ContractLst = contracts;
                ViewBag.LevelLst = levels;
                return View(model);
            }
        }
        public string Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return "Mã không tồn tại!";
                }

                if (_vendorBusiness.StatusDelete(id))
                {
                    _vendorBusiness.Save();
                }
                return "";
            }
            catch (Exception)
            {
                return "Đã xảy ra lỗi!";
            }
        }
        public ActionResult Promotion()
        {
            try
            {
                var result = _promotionBusiness.Gets();
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
        #region Contract
        public ActionResult Contract()
        {
            try
            {
                var result = _contractBusiness.GetAll();
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult ContractAdd()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ContractAdd(ContractView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_contractBusiness.Add(model) != null)
                    {
                        _contractBusiness.Save();
                        return Redirect("/Vendor/Contract");
                    }
                }
                return View(model);
            }
            catch (Exception)
            {

                return View(model);
            }
        }
        public ActionResult ContractEdit(int id)
        {
            try
            {
                var result = _contractBusiness.GetEdit(id);
                return View(result);
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ContractEdit(ContractView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_contractBusiness.Edit(model))
                    {
                        _contractBusiness.Save();
                        return Redirect("/Vendor/Contract");
                    }
                }
                return View(model);
            }
            catch (Exception)
            {

                return View(model);
            }
        }
        public string ContractDelete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return "Mã không tồn tại!";
                }

                if (_contractBusiness.StatusDelete(id))
                {
                    _contractBusiness.Save();
                }
                return "";
            }
            catch (Exception)
            {
                return "Đã xảy ra lỗi!";
            }
        }
        #endregion
        #region Level
        public ActionResult Level()
        {
            try
            {
                var result = _vendorLevelBusiness.GetAll();
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult LevelAdd()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult LevelAdd(VendorLevelView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_vendorLevelBusiness.Add(model) != null)
                    {
                        _vendorLevelBusiness.Save();
                        return Redirect("/Vendor/Level");
                    }
                }
                return View(model);
            }
            catch (Exception)
            {

                return View(model);
            }
        }
        public ActionResult LevelEdit(int id)
        {
            try
            {
                var result = _vendorLevelBusiness.GetEdit(id);
                return View(result);
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult LevelEdit(VendorLevelView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_vendorLevelBusiness.Edit(model))
                    {
                        _vendorLevelBusiness.Save();
                        return Redirect("/Vendor/Level");
                    }
                }
                return View(model);
            }
            catch (Exception)
            {

                return View(model);
            }
        }
        public string LevelDelete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return "Mã không tồn tại!";
                }

                if (_vendorLevelBusiness.StatusDelete(id))
                {
                    _vendorLevelBusiness.Save();
                }
                return "";
            }
            catch (Exception)
            {
                return "Đã xảy ra lỗi!";
            }
        }
        #endregion
    }
}