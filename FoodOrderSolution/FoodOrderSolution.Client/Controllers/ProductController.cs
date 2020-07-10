﻿using FoodOrderSolution.Business.Core;
using FoodOrderSolution.Data.ViewModels;
using FoodOrderSolution.Helper.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodOrderSolution.Client.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        IProductBusiness _productBusiness;
        IVendorBusiness _vendorBusiness;
        IMemberReceiptInfoBusiness _memberReceiptInfo;
        IMemberBusiness _memberBusiness;
        IOrderBusiness _orderBusiness;
        IOrderDetailBusiness _orderDetailBusiness;
        public ProductController(IProductBusiness productBusiness, IVendorBusiness vendorBusiness, IMemberReceiptInfoBusiness memberReceiptInfo, IOrderBusiness orderBusiness, IOrderDetailBusiness orderDetailBusiness,IMemberBusiness memberBusiness)
        {
            this._productBusiness = productBusiness;
            this._vendorBusiness = vendorBusiness;
            this._memberReceiptInfo = memberReceiptInfo;
            this._orderBusiness = orderBusiness;
            this._orderDetailBusiness = orderDetailBusiness;
            this._memberBusiness = memberBusiness;
        }
        public ActionResult List(int id)
        {
            try
            {
                var result = _productBusiness.GetByCat(id);

                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult Detail(long id)
        {
            try
            {
                var result = _productBusiness.GetDetail(id);
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
        [HttpPost]
        public JsonResult AddToCart(Cart model)
        {
            try
            {
                if (Session["ListShoppingCart"] != null)
                {
                    List<ListCart> carts = (List<ListCart>)Session["ListShoppingCart"];
                    var lstcart = carts.FirstOrDefault(x => x.ID == model.VendorID);
                    if (lstcart != null && lstcart.ID != 0)
                    {
                        if (lstcart.Carts != null && lstcart.Carts.Count() > 0)
                        {
                            var item = lstcart.Carts.FirstOrDefault(x => x.ID == model.ID);
                            if (item != null && item.ID != 0)
                            {
                                item.Qty += 1;
                                item.Price = model.Price;
                                item.Total = item.Qty * item.Price;
                                item.Name = model.Name;
                                item.VendorID = model.VendorID;
                                Session["ListShoppingCart"] = carts;
                                return Json(new CartUpdateResult { Status = "1", Amount = String.Format("{0:0,00}", item.Total), TotalAmount = String.Format("{0:0,00}", lstcart.Carts.Sum(x => x.Total)) });
                            }
                            else
                            {
                                item = new Cart();
                                item.Qty = model.Qty;
                                item.Price = model.Price;
                                item.Total = item.Qty * item.Price;
                                item.Name = model.Name;
                                item.VendorID = model.VendorID;
                                item.ID = model.ID;
                                item.Avatar = model.Avatar;
                                lstcart.Carts.Add(item);
                                Session["ListShoppingCart"] = carts;
                                return Json(new CartUpdateResult { Status = "1", Amount = String.Format("{0:0,00}", item.Total), TotalAmount = String.Format("{0:0,00}", lstcart.Carts.Sum(x => x.Total)) });
                            }
                        }
                        else
                        {
                            List<Cart> cart = new List<Cart>();
                            Cart item = new Cart();
                            item.Qty = model.Qty;
                            item.Price = model.Price;
                            item.Total = item.Qty * item.Price;
                            item.Name = model.Name;
                            item.VendorID = model.VendorID;
                            item.ID = model.ID;
                            item.Avatar = model.Avatar;
                            cart.Add(item);
                            lstcart.Carts = cart;
                            lstcart.ID = model.VendorID;
                            lstcart.Note = "";
                            lstcart.Name = "";
                            Session["ListShoppingCart"] = carts;
                            return Json(new CartUpdateResult { Status = "1", Amount = String.Format("{0:0,00}", item.Total), TotalAmount = String.Format("{0:0,00}", lstcart.Carts.Sum(x => x.Total)) });
                        }
                    }
                    else
                    {
                        lstcart = new ListCart();
                        List<Cart> cart = new List<Cart>();
                        Cart item = new Cart();
                        item.Qty = model.Qty;
                        item.Price = model.Price;
                        item.Total = item.Qty * item.Price;
                        item.Name = model.Name;
                        item.VendorID = model.VendorID;
                        item.ID = model.ID;
                        item.Avatar = model.Avatar;
                        cart.Add(item);
                        lstcart.Carts = cart;
                        carts.Add(lstcart);
                        lstcart.ID = model.VendorID;
                        lstcart.Note = "";
                        lstcart.Name = "";
                        Session["ListShoppingCart"] = carts;
                        return Json(new CartUpdateResult { Status = "1", Amount = String.Format("{0:0,00}", item.Total), TotalAmount = String.Format("{0:0,00}", lstcart.Carts.Sum(x => x.Total)) });
                    }
                }
                else
                {
                    List<ListCart> lstCarts = new List<ListCart>();
                    ListCart listCart = new ListCart();
                    List<Cart> carts = new List<Cart>();
                    Cart item = new Cart();
                    item.Qty = model.Qty;
                    item.Price = model.Price;
                    item.Total = item.Qty * item.Price;
                    item.Name = model.Name;
                    item.ID = model.ID;
                    item.Avatar = model.Avatar;
                    item.VendorID = model.VendorID;
                    carts.Add(item);
                    listCart.ID = model.VendorID;
                    listCart.Note = "";
                    listCart.Carts = carts;
                    lstCarts.Add(listCart);
                    Session["ListShoppingCart"] = lstCarts;
                    return Json(new CartUpdateResult { Status = "1", Amount = String.Format("{0:0,00}", item.Total), TotalAmount = String.Format("{0:0,00}", listCart.Carts.Sum(x => x.Total)) });
                }
            }
            catch (Exception)
            {
                return Json(new CartUpdateResult { Status = "-1", Amount = "0", TotalAmount = "0" });
            }
        }
        public ActionResult ShoppingCart()
        {
            try
            {
                if (Request.Cookies["MemberLoginCookie"] == null)
                    return Redirect("/dang-nhap.html");
                HttpCookie reqCookies = Request.Cookies["MemberLoginCookie"];
                ResponseMemberLogin login = JsonConvert.DeserializeObject<ResponseMemberLogin>(reqCookies.Value.ToString().UrlDecode());
                if (login == null || login.ID == 0)
                    return Redirect("/dang-nhap.html");
                if (Session["ListShoppingCart"] != null)
                {
                    List<ListCart> carts = (List<ListCart>)Session["ListShoppingCart"];
                    if (carts != null && carts.Count() > 0)
                    {
                        foreach (var item in carts)
                        {
                            var vendor = _vendorBusiness.GetById(item.Carts.FirstOrDefault().VendorID);
                            if (vendor != null && vendor.ID != 0)
                                item.Name = vendor.Name;
                            else
                                item.Name = "#nhacungcap";
                            if (item.Carts != null)
                                item.TotalAmount = item.Carts.Sum(x => x.Total);
                            else item.TotalAmount = 0;
                        }
                        return View(carts);
                    }
                }
                return Redirect("/");
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult PartialCart()
        {
            try
            {
                if (Session["ListShoppingCart"] != null)
                {
                    List<ListCart> carts = (List<ListCart>)Session["ListShoppingCart"];
                    if (carts != null && carts.Count() > 0)
                    {
                        foreach (var item in carts)
                        {
                            var vendor = _vendorBusiness.GetById(item.Carts.FirstOrDefault().VendorID);
                            if (vendor != null && vendor.ID != 0)
                                item.Name = vendor.Name;
                            else
                                item.Name = "#nhacungcap";
                            if (item.Carts != null)
                                item.TotalAmount = item.Carts.Sum(x => x.Total);
                            else item.TotalAmount = 0;
                        }
                        return PartialView(carts);
                    }
                }
                return PartialView();
            }
            catch (Exception)
            {
                return PartialView();
            }
        }
        public ActionResult WidgetCart()
        {
            try
            {
                if (Session["ListShoppingCart"] != null)
                {
                    List<ListCart> carts = (List<ListCart>)Session["ListShoppingCart"];
                    if (carts != null && carts.Count() > 0)
                    {
                        foreach (var item in carts)
                        {
                            var vendor = _vendorBusiness.GetById(item.Carts.FirstOrDefault().VendorID);
                            if (vendor != null && vendor.ID != 0)
                                item.Name = vendor.Name;
                            else
                                item.Name = "#nhacungcap";
                            if (item.Carts != null)
                                item.TotalAmount = item.Carts.Sum(x => x.Total);
                            else item.TotalAmount = 0;
                        }
                        return PartialView(carts);
                    }
                }
                return PartialView();
            }
            catch (Exception)
            {
                return PartialView();
            }
        }
        public ActionResult WidgetSearch()
        {
            return PartialView();
        }
        public ActionResult Search(string key)
        {
            try
            {
                var result = _productBusiness.GetSearch(key);

                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
        public JsonResult UpdateCart(int vid, long id, int action)
        {
            try
            {
                if (Session["ListShoppingCart"] != null)
                {
                    List<ListCart> lstCarts = (List<ListCart>)Session["ListShoppingCart"];
                    if (lstCarts != null && lstCarts.Count() > 0)
                    {
                        var lstCart = lstCarts.FirstOrDefault(x => x.ID == vid);
                        if (lstCart != null && lstCart.Carts != null && lstCart.Carts.Count() > 0)
                        {
                            var cart = lstCart.Carts.FirstOrDefault(x => x.ID == id);
                            if (cart != null && cart.ID != 0)
                            {
                                if (action == 0)
                                    cart.Qty -= 1;
                                else
                                    cart.Qty += 1;
                                if (cart.Qty < 1)
                                    cart.Qty = 1;
                                cart.Total = cart.Qty * cart.Price;
                                lstCart.TotalAmount = lstCart.Carts.Sum(x => x.Total);
                                return Json(new CartUpdateResult { Amount = String.Format("{0:0,00}", cart.Total), Qty = cart.Qty, Status = "1", TotalAmount = String.Format("{0:0,00}", lstCart.TotalAmount) });
                            }
                        }
                    }
                }
                return Json(new CartUpdateResult { Status = "-1", Amount = "0", TotalAmount = "0" });
            }
            catch (Exception)
            {

                return Json(new CartUpdateResult { Status = "-1", Amount = "0", TotalAmount = "0" });
            }
        }
        public JsonResult RemoveCart(int vid, long id, int action)
        {
            try
            {
                if (Session["ListShoppingCart"] != null)
                {
                    List<ListCart> lstCarts = (List<ListCart>)Session["ListShoppingCart"];
                    if (lstCarts != null && lstCarts.Count() > 0)
                    {
                        var lstCart = lstCarts.FirstOrDefault(x => x.ID == vid);
                        if (lstCart != null && lstCart.Carts != null && lstCart.Carts.Count() > 0)
                        {
                            var cart = lstCart.Carts.FirstOrDefault(x => x.ID == id);
                            if (cart != null && cart.ID != 0)
                            {
                                if (action == 0)
                                    lstCart.Carts.Remove(cart);
                                if (lstCart.Carts.Count() <= 0)
                                    lstCarts.Remove(lstCart);
                                Session["ListShoppingCart"] = lstCarts;
                                return Json(new CartUpdateResult { Amount = "0", Status = "1", TotalAmount = "0" });
                            }
                        }
                    }
                }
                return Json(new CartUpdateResult { Status = "-1", Amount = "0", TotalAmount = "0" });
            }
            catch (Exception)
            {

                return Json(new CartUpdateResult { Status = "-1", Amount = "0", TotalAmount = "0" });
            }
        }
        public ActionResult Payment()
        {
            try
            {
                if (Request.Cookies["MemberLoginCookie"] == null)
                    return Redirect("/dang-nhap.html");
                HttpCookie reqCookies = Request.Cookies["MemberLoginCookie"];
                ResponseMemberLogin login = JsonConvert.DeserializeObject<ResponseMemberLogin>(reqCookies.Value.ToString().UrlDecode());
                if (login == null || login.ID == 0)
                    return Redirect("/dang-nhap.html");

                var receipts = _memberReceiptInfo.GetByMember(login.ID);
                if (receipts != null && receipts.Count() > 0)
                    ViewBag.ReceiptInfo = receipts;
                else
                    return Redirect("/dia-diem-giao-hang.html");

                if (Session["ListShoppingCart"] != null)
                {
                    List<ListCart> carts = (List<ListCart>)Session["ListShoppingCart"];
                    if (carts != null && carts.Count() > 0)
                    {
                        foreach (var item in carts)
                        {
                            var vendor = _vendorBusiness.GetById(item.Carts.FirstOrDefault().VendorID);
                            if (vendor != null && vendor.ID != 0)
                                item.Name = vendor.Name;
                            else
                                item.Name = "#nhacungcap";
                            if (item.Carts != null)
                                item.TotalAmount = item.Carts.Sum(x => x.Total);
                            else item.TotalAmount = 0;
                        }
                        return View(carts);
                    }
                }
                return Redirect("/");
            }
            catch (Exception)
            {

                return Redirect("/");
            }
        }
        [HttpPost]
        public ActionResult Payment(PaymentParam model)
        {
            try
            {
                if (model != null)
                {
                    if (Request.Cookies["MemberLoginCookie"] == null)
                        return Json(new PaymentResult { Status = -1, Uri = "" });
                    HttpCookie reqCookies = Request.Cookies["MemberLoginCookie"];
                    ResponseMemberLogin login = JsonConvert.DeserializeObject<ResponseMemberLogin>(reqCookies.Value.ToString().UrlDecode());
                    if (login == null || login.ID == 0)
                        return Json(new PaymentResult { Status = -1, Uri = "" });
                    if (Session["ListShoppingCart"] == null)
                        return Json(new PaymentResult { Status = -1, Uri = "" });
                    List<ListCart> carts = (List<ListCart>)Session["ListShoppingCart"];
                    if (carts == null || carts.Count() <= 0)
                        return Json(new PaymentResult { Status = -1, Uri = "" });

                    List<string> codes = new List<string>();
                    List<string> id = new List<string>();
                    double amount = 0;

                    foreach (var item in carts)
                    {
                        string Code = "";
                        Code += RandomUtils.RandomString(7, 9, true, true, false);
                        if (_orderBusiness.CheckExistsCode(Code))
                            Code = RandomUtils.RandomString(7, 9, true, true, false);
                        Code = Code.ToUpperCase(true);
                        OrderView order = new OrderView();
                        order.Amount = item.TotalAmount;
                        order.Code = Code;
                        order.Date = DateTime.Now;
                        order.Member = login.ID;
                        order.Receipt = model.ReceiptID;
                        //order.Reduce=carts.Sum(x=>x.re)
                        order.StatusOrder = 0;
                        order.StatusPayment = 0;
                        order.Total = item.TotalAmount;
                        order.TypePayment = model.TypePay;
                        order.VendorID = item.ID;
                        if (_orderBusiness.Add(order))
                        {
                            _orderBusiness.Save();

                            foreach (var d in item.Carts)
                            {
                                OrderDetailView detail = new OrderDetailView();
                                detail.Code = Code;
                                detail.Price = d.Price;
                                detail.Product = d.ID;
                                detail.Qty = d.Qty;
                                detail.Reduce = 0;
                                detail.Total = d.Total;
                                if (_orderDetailBusiness.Add(detail))
                                    _orderDetailBusiness.Save();
                            }
                            codes.Add(Code);
                            amount += order.Amount;
                        }

                    }

                    if (model.TypePay == 2)
                    {
                        return Json(new PaymentResult { Status = 1, Uri = $"/xac-nhan-dat-hang.html?code={codes.Aggregate((a, b) => a + "-" + b)}" });
                    }
                    if (model.TypePay == 0)
                    {
                        string uri = CreateRequestPaymentPort((amount * 100).ToString(), codes.Aggregate((a, b) => a + "-" + b), login.Name);
                        return Json(new PaymentResult { Status = 1, Uri = uri });
                    }
                    if (model.TypePay == 1)
                    {
                        string uri = CreateRequestPaymentPortGlobal((amount*100).ToString(), codes.Aggregate((a, b) => a + "-" + b), login.Name);
                        return Json(new PaymentResult { Status = 1, Uri = uri });
                    }
                }
                return Json(new PaymentResult { Status = -1, Uri = "" });
            }
            catch (Exception)
            {

                return Json(new PaymentResult { Status = -1, Uri = "" });
            }
        }
        public ActionResult NoPay(string code)
        {
            try
            {
                Utils.WriteLogToFile("[Date]=[" + DateTime.Now + "]|[code]=[" + code + "]");

                List<OrderView> orders = new List<OrderView>();
                foreach (var item in code.Split('-'))
                {
                    OrderView order = new OrderView();
                    order = _orderBusiness.GetOrder(item);
                    if (order != null)
                        orders.Add(order);
                }
                if (orders != null && orders.Count() > 0)
                {
                    return View(orders);
                }
                return View();
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult Confirm(string vpc_AdditionData, string vpc_Amount, string vpc_Command, string vpc_CurrencyCode, string vpc_Locale, string vpc_MerchTxnRef, string vpc_Merchant, string vpc_OrderInfo,
            string vpc_TransactionNo, string vpc_TxnResponseCode, string vpc_Version, string vpc_SecureHash)
        {
            Utils.WriteLogToFile("[Date]=[" + DateTime.Now + "]|[vpc_AdditionData]=[" + vpc_AdditionData + "]|[vpc_Amount]=[" + vpc_Amount + "]|[vpc_Command]=[" + vpc_Command + "]|[vpc_CurrencyCode]=[" + vpc_CurrencyCode + "]|[vpc_Locale]=[" + vpc_Locale + "]|[vpc_MerchTxnRef]=[" + vpc_MerchTxnRef + "]|[vpc_Merchant]=[" + vpc_Merchant + "]|[vpc_OrderInfo]=[" + vpc_OrderInfo + "]|[vpc_TransactionNo]=[" + vpc_TransactionNo + "]|[vpc_TxnResponseCode]=[" + vpc_TxnResponseCode + "]|[vpc_Version]=[" + vpc_Version + "]|[vpc_SecureHash]=[" + vpc_SecureHash + "]");

            List<OrderView> orders = new List<OrderView>();
            foreach (var item in vpc_OrderInfo.Split('-'))
            {
                OrderView order = new OrderView();
                order = _orderBusiness.GetOrder(item);
                if (order != null)
                    orders.Add(order);
            }
            bool status = false;
            if (orders != null && orders.Count() > 0)
            {
                if (vpc_TxnResponseCode == "0")
                {
                    status = true;
                    foreach (var item in orders)
                    {
                        if (_orderBusiness.UpdatePaymentStatus(item.ID, 1))
                            _orderBusiness.Save();
                        if (_memberBusiness.AddPoint(orders.FirstOrDefault().Member, Convert.ToDouble(vpc_Amount) / 1000))
                            _memberBusiness.Save();
                    }
                }
                else
                {
                    status = false;
                    foreach (var item in orders)
                    {
                        if (_orderBusiness.UpdatePaymentStatus(item.ID, 0))
                            _orderBusiness.Save();
                        if (_orderBusiness.UpdateStatus(item.ID, 5))
                            _orderBusiness.Save();
                    }
                }
            }
            ViewBag.StatusPayment = status;
            return View(orders);
        }
        public ActionResult Confirm_Global(string vpc_OrderInfo, string vpc_3DSECI, string vpc_AVS_Street01, string vpc_Merchant, string vpc_Card, string vpc_AcqResponseCode, string AgainLink, string vpc_AVS_Country,
            string vpc_AuthorizeId, string vpc_3DSenrolled, string vpc_RiskOverallResult, string vpc_ReceiptNo, string vpc_TransactionNo, string vpc_AVS_StateProv, string vpc_Locale, string vpc_TxnResponseCode, string vpc_VerToken,
            string vpc_Amount, string vpc_BatchNo, string vpc_Version, string vpc_AVSResultCode, string vpc_VerStatus, string vpc_Command, string vpc_Message, string Title, string vpc_3DSstatus, string vpc_SecureHash, string vpc_AVS_PostCode,
            string vpc_CSCResultCode, string vpc_MerchTxnRef, string vpc_VerType, string vpc_VerSecurityLevel, string vpc_3DSXID, string vpc_AVS_City)
        {
            string log = "[Date]=[" + DateTime.Now + "]|[vpc_OrderInfo]=[" + vpc_OrderInfo + "]|[vpc_3DSECI]=[" + vpc_3DSECI + "]|[vpc_AVS_Street01]=[" + vpc_AVS_Street01 + "]|[vpc_Merchant]=[" + vpc_Merchant + "]|[vpc_Card]=[" + vpc_Card + "]|[vpc_AcqResponseCode]=[" + vpc_AcqResponseCode + "]|";
            log += "[AgainLink]=[" + AgainLink + "]|[vpc_AVS_Country]=[" + vpc_AVS_Country + "]|[vpc_AuthorizeId]=[" + vpc_AuthorizeId + "]|[vpc_3DSenrolled]=[" + vpc_3DSenrolled + "]|[vpc_RiskOverallResult]=[" + vpc_RiskOverallResult + "]|";
            log += "[vpc_ReceiptNo] =[" + vpc_ReceiptNo + "]|[vpc_TransactionNo]=[" + vpc_TransactionNo + "]|[vpc_TxnResponseCode]=[" + vpc_TxnResponseCode + "]|[vpc_MerchTxnRef]=[" + vpc_MerchTxnRef + "]|[vpc_AVSResultCode]=[" + vpc_AVSResultCode + "]|";
            Utils.WriteLogToFile(log);
            List<OrderView> orders = new List<OrderView>();
            foreach (var item in vpc_OrderInfo.Split('-'))
            {
                OrderView order = new OrderView();
                order = _orderBusiness.GetOrder(item);
                if (order != null)
                    orders.Add(order);
            }
            bool status = false;
            if (orders != null && orders.Count() > 0)
            {
                if (vpc_TxnResponseCode == "0")
                {
                    status = true;
                    foreach (var item in orders)
                    {
                        if (_orderBusiness.UpdatePaymentStatus(item.ID, 1))
                            _orderBusiness.Save();
                        if (_memberBusiness.AddPoint(orders.FirstOrDefault().Member, Convert.ToDouble(vpc_Amount) / 1000))
                            _memberBusiness.Save();
                    }
                }
                else
                {
                    status = false;
                    foreach (var item in orders)
                    {
                        if (_orderBusiness.UpdatePaymentStatus(item.ID, 0))
                            _orderBusiness.Save();
                        if (_orderBusiness.UpdateStatus(item.ID, 5))
                            _orderBusiness.Save();
                    }
                }
            }
            ViewBag.StatusPayment = status;
            return View(orders);
        }
        #region Method
        public string CreateRequestPaymentPort(string amount, string barCode, string phone)
        {
            string SECURE_SECRET = ConfigurationManager.AppSettings["SerectPaymentPort"].ToString();
            // Khoi tao lop thu vien va gan gia tri cac tham so gui sang cong thanh toan
            VPCRequest_VN conn = new VPCRequest_VN(ConfigurationManager.AppSettings["UrlPaymentLocal"].ToString());
            conn.SetSecureSecret(SECURE_SECRET);
            // Add the Digital Order Fields for the functionality you wish to use
            // Core Transaction Fields
            conn.AddDigitalOrderField("Title", "onepay paygate");
            conn.AddDigitalOrderField("vpc_Locale", "vn");//Chon ngon ngu hien thi tren cong thanh toan (vn/en)
            conn.AddDigitalOrderField("vpc_Version", "2");
            conn.AddDigitalOrderField("vpc_Command", "pay");
            conn.AddDigitalOrderField("vpc_Merchant", ConfigurationManager.AppSettings["MerchantPaymentPort"].ToString());
            conn.AddDigitalOrderField("vpc_AccessCode", ConfigurationManager.AppSettings["AccessCodePayMentPort"].ToString());
            conn.AddDigitalOrderField("vpc_MerchTxnRef", barCode.Split('-')[0]);
            conn.AddDigitalOrderField("vpc_OrderInfo", barCode);
            conn.AddDigitalOrderField("vpc_Amount", amount);
            conn.AddDigitalOrderField("vpc_Currency", "VND");
            conn.AddDigitalOrderField("vpc_ReturnURL", "http://localhost:44345/xac-nhan-thanh-toan-noi-dia.html");
            // Thong tin them ve khach hang. De trong neu khong co thong tin
            conn.AddDigitalOrderField("vpc_SHIP_Street01", "");
            conn.AddDigitalOrderField("vpc_SHIP_Provice", "");
            conn.AddDigitalOrderField("vpc_SHIP_City", "");
            conn.AddDigitalOrderField("vpc_SHIP_Country", "");
            conn.AddDigitalOrderField("vpc_Customer_Phone", "");
            conn.AddDigitalOrderField("vpc_Customer_Email", "");
            conn.AddDigitalOrderField("vpc_Customer_Id", "");
            // Dia chi IP cua khach hang
            conn.AddDigitalOrderField("vpc_TicketNo", GetUserIP());
            // Chuyen huong trinh duyet sang cong thanh toan
            String url = conn.Create3PartyQueryString();
            return url;
        }
        public string CreateRequestPaymentPortGlobal(string amount, string barCode, string phone)
        {

            string SECURE_SECRET = ConfigurationManager.AppSettings["SerectPaymentPortGlobal"].ToString();
            // Khoi tao lop thu vien va gan gia tri cac tham so gui sang cong thanh toan
            VPCRequest_Global conn = new VPCRequest_Global(ConfigurationManager.AppSettings["UrlPaymentGlobal"].ToString());
            conn.SetSecureSecret(SECURE_SECRET);
            // Add the Digital Order Fields for the functionality you wish to use
            // Core Transaction Fields

            conn.AddDigitalOrderField("AgainLink", "http://onepay.vn");
            conn.AddDigitalOrderField("Title", "onepay paygate");
            conn.AddDigitalOrderField("vpc_Locale", "vn");//Chon ngon ngu hien thi tren cong thanh toan (vn/en)
            conn.AddDigitalOrderField("vpc_Version", "2");
            conn.AddDigitalOrderField("vpc_Command", "pay");
            conn.AddDigitalOrderField("vpc_Merchant", ConfigurationManager.AppSettings["MerchantPaymentPortGlobal"].ToString());
            conn.AddDigitalOrderField("vpc_AccessCode", ConfigurationManager.AppSettings["AccessCodePayMentPortGlobal"].ToString());
            conn.AddDigitalOrderField("vpc_MerchTxnRef", barCode.Split('-')[0]);
            conn.AddDigitalOrderField("vpc_OrderInfo", barCode);
            conn.AddDigitalOrderField("vpc_Amount", amount);
            conn.AddDigitalOrderField("vpc_ReturnURL", "http://localhost:44345/xac-nhan-thanh-toan-quoc-te.html");
            // Thong tin them ve khach hang. De trong neu khong co thong tin
            conn.AddDigitalOrderField("vpc_SHIP_Street01", " ");
            conn.AddDigitalOrderField("vpc_SHIP_Provice", " ");
            conn.AddDigitalOrderField("vpc_SHIP_City", " ");
            conn.AddDigitalOrderField("vpc_SHIP_Country", " ");
            conn.AddDigitalOrderField("vpc_Customer_Phone", " ");
            conn.AddDigitalOrderField("vpc_Customer_Email", " ");
            conn.AddDigitalOrderField("vpc_Customer_Id", " ");
            // Dia chi IP cua khach hang
            conn.AddDigitalOrderField("vpc_TicketNo", GetUserIP());

            // Chuyen huong trinh duyet sang cong thanh toan
            String url = conn.Create3PartyQueryString();
            return url;
        }
        private string GetUserIP()
        {
            string ipList = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipList))
            {
                return ipList.Split(',')[0];
            }

            return Request.ServerVariables["REMOTE_ADDR"];
        }
        #endregion
    }
}