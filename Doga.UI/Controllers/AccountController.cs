using Doga.UI.Entity;
using Doga.UI.İdentity;
using Doga.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doga.UI.Controllers
{
    public class AccountController : Controller
    {
        private DataContext db = new DataContext();
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;
        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        [Authorize]
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var orders = db.Orders.Where(i => i.Username == username).Select(i => new UserOrderModel()
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total
            }).OrderByDescending(i => i.OrderDate).ToList();


            return View(orders);
        }
        [Authorize]
        public ActionResult Details (int id)
        {
            var entity = db.Orders.Where(i => i.Id == id).Select(i => new OrderDetailsModel()
            {
                OrderId = i.Id,
                OrderNumber = i.OrderNumber,
                Total = i.Total,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                AdressBasligi = i.AdressBasligi,
                Adres1 = i.Adres1,
                Sehir = i.Sehir,
                Semt = i.Semt,
                Mahalle = i.Mahalle,
                PostaKodu = i.PostaKodu,
                Orderlines = i.Orderlines.Select(a => new OrderLineModel()
                {
                    ProductId = a.ProductId,
                    ProductName = a.Product.Name,
                    Image= a.Product.Image,
                    Quantity = a.Quantity,
                    Price = a.Price
                }).ToList()
            }).FirstOrDefault();

            return View(entity);
        }
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (!ModelState.IsValid)
            {
                //Kayıt işlemleri
                var user = new ApplicationUser();
                user.Name = model.Name;
                user.SurName = model.SurName;
                user.Email = model.Email;
                user.UserName = model.UserName;
                var result = UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    //kullanıcı oluştu
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");
                    

                }
                else
                {
                    ModelState.AddModelError("RegisterUserError","Kullanıcı Oluşturulamadı");
                }
            }
            return View(model);
        }



        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model,string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
               var user = UserManager.Find(model.UserName, model.Password);
                if (user != null)
                {
                    //varolan kullanıcıyı oluştur
                    //ApplicationCookie Oluşturup sisteme bırak.

                    var authManager = HttpContext.GetOwinContext().Authentication;
                    //oluşturulan kullanıcı cookie içine atıldı
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    //cookie kalıcımı 
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties,identityclaims);

                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                       return Redirect(ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Böyle bir kullanıcı yok.");
                }
            }
            return View(model);
        }


        public ActionResult Logout()
        {
            //oluşturulan cookie sistemden siliniyor
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index", "Home");
            
        }
      

    }
}