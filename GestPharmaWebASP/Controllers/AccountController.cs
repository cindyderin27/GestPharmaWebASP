using GestPharmaWebASP.Models;
using GestPharmaWebASP.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GestPharmaWebASP.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
      
        public ActionResult Login(string returnUrl)
        {
            return View(new LoginModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {

            Connection useCase = new Connection(
               new ConnectionCommand
               (
               model.Email,
               model.Password
               ));
            var user = useCase.Execute();
            if (user == null)
            {
                model.IsError = true;
                model.Message = "L'email ou le mot de passe est invalide  !";
                return View(model);

            }
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket
                (
                    1,
                    user.Email,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(30),
                    false,
                    JsonConvert.SerializeObject
                    (
                        new RegisterModel
                          (
                            user.Email,
                            user.Password,
                            user.Firstname,
                            user.Country,
                            user.DateCreate
                            
                          )
                    ),
                    FormsAuthentication.FormsCookiePath
                );

            Response.Cookies.Add
                (
                    new HttpCookie
                        (
                            FormsAuthentication.FormsCookieName,
                            FormsAuthentication.Encrypt(ticket)
                        )
                );
            FormsAuthentication.SetAuthCookie(user.Email, false);
            if (!string.IsNullOrEmpty(model.ReturnUrl))
                return Redirect(model.ReturnUrl);
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session[nameof(User)] = null;
            return RedirectToAction("Login", "Account");
        }



        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Register useCase = new Register(new RegisterCommand
                    (
                   
                    model.Email,
                    model.Password,
                    model.Firstname,
                    Services.Entities.User.RoleOption.Administrateur,
                    model.DateCreate,
                    model.Country
                    ));
                var user = useCase.ExecuteRegister();
                if (user == null)
                {
                    model.IsError = true;
                    model.Message = "An error occured! try again";
                    return View(model);
                }
                return RedirectToAction("Login","Account");


            }
           
                return View(model);
            
        }


        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordModel model)
        {
            ForgotPassword forgotUser = new ForgotPassword();
            var confirmSend = forgotUser.SendEmail(model.Email);
            //forgotUser.SendEmail(fm.Email);
            if (confirmSend == false)
            {
                return View(model);
            }
            Session[nameof(User)] = new ForgotPasswordModel(model.Email);
            return RedirectToAction("ResetPassword", "Account");
        }

        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            if (Session[nameof(User)] == null)
            {
                return RedirectToAction("ForgotPassword", "Account");
            }
            model.Password = (Session[nameof(User)] as BaseModel).UserModel.Password;
            ResetPassword useCase = new ResetPassword(new ResetCommand(model.Password));
            var use = useCase.Execute();
            if (use == null)
            {
                return View(model);
            }
            return RedirectToAction("Login", "Account");
        }
       
    }
}