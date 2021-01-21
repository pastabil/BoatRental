using BoatRental.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BoatRental.Controllers
{
    public class ContactUsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(SendMailToAdmin mailToAdmin)
        {
            if (!ModelState.IsValid) 
                return View();
            string Name = mailToAdmin.Name;
            string Sender = mailToAdmin.Email;
            string Subject = mailToAdmin.Subject;
            string Message = mailToAdmin.Message;
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("email");
            mm.To.Add("email");
            mm.Subject = Subject;
            string content = "Name: " + Name + "\nEmail: " + Sender + "\nMessage:\n" + Message;
            mm.Body = content;
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("email", "password");
            smtp.Send(mm);
            ViewBag.Message="The mail has been sent from " + Sender +" successfully to BoatRentalAdmin";
            return View();
        }
    }
}