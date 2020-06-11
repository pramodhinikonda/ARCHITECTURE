using System.Web.Mvc;
using Y_SERVICE;
using Y_WEB.Models;
using Y_HELPERS;
using System.Web.Security;
using System.Threading;

namespace Y_WEB.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        UserService userService = new UserService();

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View(model);

            var userResponse = userService.Authenticate(model.Email, model.Password);
            if (userResponse != null && userResponse.User != null)
            {
                if (userResponse.User.ActivationStatus == ActivationStatus.Activated)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                    return RedirectToLocal(returnUrl);
                }
                ModelState.AddModelError("", "Your Account has not been activated");
                return View(model);
            }

            ModelState.AddModelError("", "The email and password you entered don't match.");
            return View(model);
        }

        public ActionResult LogOff()
        {
            TokenService tokenService = new TokenService();
            tokenService.DeleteTokenByUser(Thread.CurrentPrincipal.Identity.Name);
            FormsAuthentication.SignOut();
            return RedirectToAction("Demo", "Home");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult Register(RegisterViewModel model, string returnUrl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        GangaUser gangaUser = new GangaUser();
        //        gangaUser.FirstName = model.FirstName;
        //        gangaUser.Photo = "avatar.jpg";
        //        gangaUser.LastName = model.LastName;
        //        gangaUser.Email = model.Email;
        //        gangaUser.Password = model.Password;
        //        gangaUser.Phone = model.PhoneCode + "*" + model.Phone;
        //        gangaUser.Country = model.Country;
        //        gangaUser.Company = model.Company;

        //        // gangaUser.Id = Guid.NewGuid().ToString();
        //        gangaUser.ActivationStatus = 0;
        //        gangaUser.UserTypeInfo = UserTypeInfo.AccountOwner;
        //        var user = _UserManagerService.Register(gangaUser);


        //        if (user != null)
        //        {
        //            UserAccessPolicy UserAccessDetails = new UserAccessPolicy();
        //            UserAccessDetails.Id = null;
        //            UserAccessDetails.UserId = user.Id;
        //            UserAccessDetails.UserAccessEnv = null;
        //            var userAccessPolicy = _UserManagerService.CreateUserAccessPolicy(UserAccessDetails);
        //            // create customer in charge bee

        //            AzureManagementService ams = new AzureManagementService();

        //            var setting1 = ams.GetSettingsValue("SiteName");
        //            var setting2 = ams.GetSettingsValue("ApiKey");

        //            BillingManager billingManager = new BillingManager(Biller.ChargeeBee, setting1.KeyValue, setting2.KeyValue);

        //            var billCustomer = new BillingCreateCustomerOnly() { FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, Id = user.CustomerId, Company = model.Company, Phone = user.Phone };
        //            billingManager.CreateCustomerOnly(billCustomer);

        //            MailAddress[] to = new MailAddress[] { new MailAddress(user.Email, user.FirstName) };
        //            string subject = "Invitation";
        //            string path = System.Web.HttpContext.Current.Server.MapPath("~/App/ganga/modules/Operations/InviteUser/views/activationMailTemplate.html");
        //            string html = System.IO.File.ReadAllText(path);
        //            var domainName = string.Format("http://biztalk360Staging.azurewebsites.net/Account/Activation?UserName={0}", user.Id);
        //            html = string.Format(html, user.FirstName, domainName);
        //            string text = "";
        //            Task invitemail = EmailManager.SendEmail(to.ToArray(), subject, html, text);

        //            FormsAuthentication.SetAuthCookie(model.Email, false);
        //            return RedirectToLocal(returnUrl);
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Email already Exist");
        //        }
        //    }



        //    ViewBag.Countries = CountryModel.GetCountries();
        //    return View(model);
        //}
    }
}
