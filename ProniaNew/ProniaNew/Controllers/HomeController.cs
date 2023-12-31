﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProniaNew.ExtensionServices.Interfaces;
using ProniaNew.Models;
using ProniaNew.Services.Interfaces;
using ProniaNew.ViewModels.BasketVMs;
using ProniaNew.ViewModels.HomeVMs;

namespace ProniaNew.Controllers;
public class HomeController : Controller
{
    private readonly ISliderService _sliderService;
    private readonly IProductService _productService;
    private readonly IEmailService _emailService;
    public HomeController(ISliderService sliderService, IProductService productService, IEmailService emailService)
    {
        _sliderService = sliderService;
        _productService = productService;
        _emailService = emailService;
    }

    public async Task<IActionResult> Index()
    {
        HomeVm vm = new HomeVm
        {
            Sliders = await _sliderService.GetAll(),
            Products = await _productService.GetTable.Take(4).ToListAsync()
        };
        ViewBag.ProductCount = await _productService.GetTable.CountAsync();
        return View(vm);
    }
    public async Task<IActionResult> LoadMore(int skip, int take)
    {
        return PartialView("_ProductPartial", await _productService.GetTable.Skip(skip).Take(4).ToListAsync());
    }
    public IActionResult SendEmail()
    {
        _emailService.Send("nicatmuxtarov12@gmail.com", "Welcome To Pronia, Please Verofy Email Adress", "<head>\r\n  <title></title>\r\n  <!--[if !mso]><!-- -->\r\n  <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n  <!--<![endif]-->\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">\r\n<style type=\"text/css\">\r\n  #outlook a { padding: 0; }\r\n  .ReadMsgBody { width: 100%; }\r\n  .ExternalClass { width: 100%; }\r\n  .ExternalClass * { line-height:100%; }\r\n  body { margin: 0; padding: 0; -webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; }\r\n  table, td { border-collapse:collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; }\r\n  img { border: 0; height: auto; line-height: 100%; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; }\r\n  p { display: block; margin: 13px 0; }\r\n</style>\r\n<!--[if !mso]><!-->\r\n<style type=\"text/css\">\r\n  @media only screen and (max-width:480px) {\r\n    @-ms-viewport { width:320px; }\r\n    @viewport { width:320px; }\r\n  }\r\n</style>\r\n<!--<![endif]-->\r\n<!--[if mso]>\r\n<xml>\r\n  <o:OfficeDocumentSettings>\r\n    <o:AllowPNG/>\r\n    <o:PixelsPerInch>96</o:PixelsPerInch>\r\n  </o:OfficeDocumentSettings>\r\n</xml>\r\n<![endif]-->\r\n<!--[if lte mso 11]>\r\n<style type=\"text/css\">\r\n  .outlook-group-fix {\r\n    width:100% !important;\r\n  }\r\n</style>\r\n<![endif]-->\r\n\r\n<!--[if !mso]><!-->\r\n    <link href=\"https://fonts.googleapis.com/css?family=Ubuntu:300,400,500,700\" rel=\"stylesheet\" type=\"text/css\">\r\n    <style type=\"text/css\">\r\n\r\n        @import url(https://fonts.googleapis.com/css?family=Ubuntu:300,400,500,700);\r\n\r\n    </style>\r\n  <!--<![endif]--><style type=\"text/css\">\r\n  @media only screen and (min-width:480px) {\r\n    .mj-column-per-100, * [aria-labelledby=\"mj-column-per-100\"] { width:100%!important; }\r\n  }\r\n</style>\r\n</head>\r\n<body style=\"background: #F9F9F9;\">\r\n  <div style=\"background-color:#F9F9F9;\"><!--[if mso | IE]>\r\n      <table role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"640\" align=\"center\" style=\"width:640px;\">\r\n        <tr>\r\n          <td style=\"line-height:0px;font-size:0px;mso-line-height-rule:exactly;\">\r\n      <![endif]-->\r\n  <style type=\"text/css\">\r\n    html, body, * {\r\n      -webkit-text-size-adjust: none;\r\n      text-size-adjust: none;\r\n    }\r\n    a {\r\n      color:#1EB0F4;\r\n      text-decoration:none;\r\n    }\r\n    a:hover {\r\n      text-decoration:underline;\r\n    }\r\n  </style>\r\n<div style=\"margin:0px auto;max-width:640px;background:transparent;\"><table role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" style=\"font-size:0px;width:100%;background:transparent;\" align=\"center\" border=\"0\"><tbody><tr><td style=\"text-align:center;vertical-align:top;direction:ltr;font-size:0px;padding:40px 0px;\"><!--[if mso | IE]>\r\n      <table role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr><td style=\"vertical-align:top;width:640px;\">\r\n      <![endif]--><div aria-labelledby=\"mj-column-per-100\" class=\"mj-column-per-100 outlook-group-fix\" style=\"vertical-align:top;display:inline-block;direction:ltr;font-size:13px;text-align:left;width:100%;\"><table role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\"><tbody><tr><td style=\"word-break:break-word;font-size:0px;padding:0px;\" align=\"center\"><table role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" style=\"border-collapse:collapse;border-spacing:0px;\" align=\"center\" border=\"0\"><tbody><tr><td style=\"width:138px;\"><a href=\"https://discordapp.com/\" target=\"_blank\"><img alt=\"\" title=\"\" height=\"38px\" src=\"https://cdn.discordapp.com/email_assets/2ec94ed90b8e95d764f2a1c96f33139e.png\" style=\"border:none;border-radius:;display:block;outline:none;text-decoration:none;width:100%;height:38px;\" width=\"138\"></a></td></tr></tbody></table></td></tr></tbody></table></div><!--[if mso | IE]>\r\n      </td></tr></table>\r\n      <![endif]--></td></tr></tbody></table></div><!--[if mso | IE]>\r\n      </td></tr></table>\r\n      <![endif]-->\r\n      <!--[if mso | IE]>\r\n      <table role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"640\" align=\"center\" style=\"width:640px;\">\r\n        <tr>\r\n          <td style=\"line-height:0px;font-size:0px;mso-line-height-rule:exactly;\">\r\n      <![endif]--><div style=\"max-width:640px;margin:0 auto;box-shadow:0px 1px 5px rgba(0,0,0,0.1);border-radius:4px;overflow:hidden\"><div style=\"margin:0px auto;max-width:640px;background:#7289DA url(https://cdn.discordapp.com/email_assets/f0a4cc6d7aaa7bdf2a3c15a193c6d224.png) top center / cover no-repeat;\"><!--[if mso | IE]>\r\n      <v:rect xmlns:v=\"urn:schemas-microsoft-com:vml\" fill=\"true\" stroke=\"false\" style=\"width:640px;\">\r\n        <v:fill origin=\"0.5, 0\" position=\"0.5,0\" type=\"tile\" src=\"https://cdn.discordapp.com/email_assets/f0a4cc6d7aaa7bdf2a3c15a193c6d224.png\" />\r\n        <v:textbox style=\"mso-fit-shape-to-text:true\" inset=\"0,0,0,0\">\r\n      <![endif]--><table role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" style=\"font-size:0px;width:100%;background:#7289DA url(https://cdn.discordapp.com/email_assets/f0a4cc6d7aaa7bdf2a3c15a193c6d224.png) top center / cover no-repeat;\" align=\"center\" border=\"0\" background=\"https://cdn.discordapp.com/email_assets/f0a4cc6d7aaa7bdf2a3c15a193c6d224.png\"><tbody><tr><td style=\"text-align:center;vertical-align:top;direction:ltr;font-size:0px;padding:57px;\"><!--[if mso | IE]>\r\n      <table role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr><td style=\"vertical-align:undefined;width:640px;\">\r\n      <![endif]--><div style=\"cursor:auto;color:white;font-family:Whitney, Helvetica Neue, Helvetica, Arial, Lucida Grande, sans-serif;font-size:36px;font-weight:600;line-height:36px;text-align:center;\">Welcome to Discord!</div><!--[if mso | IE]>\r\n      </td></tr></table>\r\n      <![endif]--></td></tr></tbody></table><!--[if mso | IE]>\r\n        </v:textbox>\r\n      </v:rect>\r\n      <![endif]--></div><!--[if mso | IE]>\r\n      </td></tr></table>\r\n      <![endif]-->\r\n      <!--[if mso | IE]>\r\n      <table role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"640\" align=\"center\" style=\"width:640px;\">\r\n        <tr>\r\n          <td style=\"line-height:0px;font-size:0px;mso-line-height-rule:exactly;\">\r\n      <![endif]--><div style=\"margin:0px auto;max-width:640px;background:#ffffff;\"><table role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" style=\"font-size:0px;width:100%;background:#ffffff;\" align=\"center\" border=\"0\"><tbody><tr><td style=\"text-align:center;vertical-align:top;direction:ltr;font-size:0px;padding:40px 70px;\"><!--[if mso | IE]>\r\n      <table role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr><td style=\"vertical-align:top;width:640px;\">\r\n      <![endif]--><div aria-labelledby=\"mj-column-per-100\" class=\"mj-column-per-100 outlook-group-fix\" style=\"vertical-align:top;display:inline-block;direction:ltr;font-size:13px;text-align:left;width:100%;\"><table role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\"><tbody><tr><td style=\"word-break:break-word;font-size:0px;padding:0px 0px 20px;\" align=\"left\"><div style=\"cursor:auto;color:#737F8D;font-family:Whitney, Helvetica Neue, Helvetica, Arial, Lucida Grande, sans-serif;font-size:16px;line-height:24px;text-align:left;\">\r\n            <p><img src=\"https://cdn.discordapp.com/email_assets/127c95bbea39cd4bc1ad87d1500ae27d.png\" alt=\"Party Wumpus\" title=\"None\" width=\"500\" style=\"height: auto;\"></p>\r\n\r\n  <h2 style=\"font-family: Whitney, Helvetica Neue, Helvetica, Arial, Lucida Grande, sans-serif;font-weight: 500;font-size: 20px;color: #4F545C;letter-spacing: 0.27px;\">Hey SmilesDavis,</h2>\r\n<p>Wowwee! Thanks for registering an account with Discord! You're the coolest person in all the land (and I've met a lot of really cool people).</p>\r\n<p>Before we get started, we'll need to verify your email.</p>\r\n\r\n          </div></td></tr><tr><td style=\"word-break:break-word;font-size:0px;padding:10px 25px;\" align=\"center\"><table role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" style=\"border-collapse:separate;\" align=\"center\" border=\"0\"><tbody><tr><td style=\"border:none;border-radius:3px;color:white;cursor:auto;padding:15px 19px;\" align=\"center\" valign=\"middle\" bgcolor=\"#7289DA\"><a href=\"#\" style=\"text-decoration:none;line-height:100%;background:#7289DA;color:white;font-family:Ubuntu, Helvetica, Arial, sans-serif;font-size:15px;font-weight:normal;text-transform:none;margin:0px;\" target=\"_blank\">\r\n            Verify Email\r\n          </a></td></tr></tbody></table></td></tr></tbody></table></div><!--[if mso | IE]>\r\n      </td></tr></table>\r\n      <![endif]--></td></tr></tbody></table></div><!--[if mso | IE]>\r\n      </td></tr></table>\r\n      <![endif]-->\r\n      <!--[if mso | IE]>\r\n      <table role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"640\" align=\"center\" style=\"width:640px;\">\r\n        <tr>\r\n          <td style=\"line-height:0px;font-size:0px;mso-line-height-rule:exactly;\">\r\n      <![endif]--></div><div style=\"margin:0px auto;max-width:640px;background:transparent;\"><table role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" style=\"font-size:0px;width:100%;background:transparent;\" align=\"center\" border=\"0\"><tbody><tr><td style=\"text-align:center;vertical-align:top;direction:ltr;font-size:0px;padding:0px;\"><!--[if mso | IE]>\r\n      <table role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr><td style=\"vertical-align:top;width:640px;\">\r\n      <![endif]--><div aria-labelledby=\"mj-column-per-100\" class=\"mj-column-per-100 outlook-group-fix\" style=\"vertical-align:top;display:inline-block;direction:ltr;font-size:13px;text-align:left;width:100%;\"><table role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\"><tbody><tr><td style=\"word-break:break-word;font-size:0px;\"><div style=\"font-size:1px;line-height:12px;\">&nbsp;</div></td></tr></tbody></table></div><!--[if mso | IE]>\r\n      </td></tr></table>\r\n      <![endif]--></td></tr></tbody></table></div><!--[if mso | IE]>\r\n      </td></tr></table>\r\n      <![endif]-->\r\n      <!--[if mso | IE]>\r\n      <table role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"640\" align=\"center\" style=\"width:640px;\">\r\n        <tr>\r\n          <td style=\"line-height:0px;font-size:0px;mso-line-height-rule:exactly;\">\r\n      <![endif]--><div style=\"margin:0 auto;max-width:640px;background:#ffffff;box-shadow:0px 1px 5px rgba(0,0,0,0.1);border-radius:4px;overflow:hidden;\"><table cellpadding=\"0\" cellspacing=\"0\" style=\"font-size:0px;width:100%;background:#ffffff;\" align=\"center\" border=\"0\"><tbody><tr><td style=\"text-align:center;vertical-align:top;font-size:0px;padding:0px;\"><!--[if mso | IE]>\r\n      <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr><td style=\"vertical-align:top;width:640px;\">\r\n      <![endif]--><div aria-labelledby=\"mj-column-per-100\" class=\"mj-column-per-100 outlook-group-fix\" style=\"vertical-align:top;display:inline-block;direction:ltr;font-size:13px;text-align:left;width:100%;\"><table role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\"><tbody><tr><td style=\"word-break:break-word;font-size:0px;padding:30px 70px 0px 70px;\" align=\"center\"><div style=\"cursor:auto;color:#43B581;font-family:Whitney, Helvetica Neue, Helvetica, Arial, Lucida Grande, sans-serif;font-size:18px;font-weight:bold;line-height:16px;text-align:center;\">FUN FACT #16</div></td></tr><tr><td style=\"word-break:break-word;font-size:0px;padding:14px 70px 30px 70px;\" align=\"center\"><div style=\"cursor:auto;color:#737F8D;font-family:Whitney, Helvetica Neue, Helvetica, Arial, Lucida Grande, sans-serif;font-size:16px;line-height:22px;text-align:center;\">\r\n      In Hearthstone, using the Hunter card Animal Companion against Kel'Thuzad will summon his cat Mr. Bigglesworth rather than the usual beasts.\r\n    </div></td></tr></tbody></table></div><!--[if mso | IE]>\r\n      </td></tr></table>\r\n      <![endif]--></td></tr></tbody></table></div><!--[if mso | IE]>\r\n      </td></tr></table>\r\n      <![endif]-->\r\n      <!--[if mso | IE]>\r\n      <table role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"640\" align=\"center\" style=\"width:640px;\">\r\n        <tr>\r\n          <td style=\"line-height:0px;font-size:0px;mso-line-height-rule:exactly;\">\r\n      <![endif]--><div style=\"margin:0px auto;max-width:640px;background:transparent;\"><table role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" style=\"font-size:0px;width:100%;background:transparent;\" align=\"center\" border=\"0\"><tbody><tr><td style=\"text-align:center;vertical-align:top;direction:ltr;font-size:0px;padding:20px 0px;\"><!--[if mso | IE]>\r\n      <table role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr><td style=\"vertical-align:top;width:640px;\">\r\n      <![endif]--><div aria-labelledby=\"mj-column-per-100\" class=\"mj-column-per-100 outlook-group-fix\" style=\"vertical-align:top;display:inline-block;direction:ltr;font-size:13px;text-align:left;width:100%;\"><table role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\"><tbody><tr><td style=\"word-break:break-word;font-size:0px;padding:0px;\" align=\"center\"><div style=\"cursor:auto;color:#99AAB5;font-family:Whitney, Helvetica Neue, Helvetica, Arial, Lucida Grande, sans-serif;font-size:12px;line-height:24px;text-align:center;\">\r\n      Sent by Discord • <a href=\"https://blog.discordapp.com/\" style=\"color:#1EB0F4;text-decoration:none;\" target=\"_blank\">check our blog</a> • <a href=\"https://twitter.com/discordapp\" style=\"color:#1EB0F4;text-decoration:none;\" target=\"_blank\">@discordapp</a>\r\n    </div></td></tr><tr><td style=\"word-break:break-word;font-size:0px;padding:0px;\" align=\"center\"><div style=\"cursor:auto;color:#99AAB5;font-family:Whitney, Helvetica Neue, Helvetica, Arial, Lucida Grande, sans-serif;font-size:12px;line-height:24px;text-align:center;\">\r\n      444 De Haro Street, Suite 200, San Francisco, CA 94107\r\n    </div></td></tr></tbody></table></div><!--[if mso | IE]>\r\n      </td></tr></table>\r\n      <![endif]--></td></tr></tbody></table></div><!--[if mso | IE]>\r\n      </td></tr></table>\r\n      <![endif]--></div>\r\n\r\n</body>");
        return Ok();
    }
    //public string SessionGet(string? key) 
    //{
    //   return HttpContext.Session.GetString(key??"")??"";
    //}
    //public void SessionSet(string key, string value)
    //{
    //    HttpContext.Session.SetString(key,value);
    //}
    //public string GetCookie(string key)
    //{
    //    string a = HttpContext.Request.Cookies[key];
    //    return a;
    //}
    //public void SetCookie(string key, string value)
    //{
    //    HttpContext.Response.Cookies.Append(key, value, new CookieOptions
    //    {
    //        MaxAge = TimeSpan.FromSeconds(30)
    //        //Expires = DateTime.UtcNow.AddDays(2)
    //    }); ; ;
    //}

    public async Task<IActionResult> AddBasket(int? id)
    {
        if (id == null && id <= 0) return BadRequest();
        //var model = await _productService.GetById(id);
        if (!await _productService.GetTable.AnyAsync(p => p.Id == id)) return NotFound();
        var basket = HttpContext.Request.Cookies["basket"];
        List<BasketItemVM> items = basket == null ? new List<BasketItemVM>() :
            JsonConvert.DeserializeObject<List<BasketItemVM>>(basket);
        var item = items.SingleOrDefault(i => i.Id == id);
        if (item == null)
        {
            item = new BasketItemVM
            {
                Id = (int)id,
                Count = 1
            };
            items.Add(item);
        }
        else
        {
            item.Count++;
        }
        HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(items));
        return Ok();
    }
    public async Task<IActionResult> GetBasket()
    {
        var basket = JsonConvert.DeserializeObject<List<BasketItemVM>>(HttpContext.Request.Cookies["basket"]);
        List<BasketItemProductVM> vm = new List<BasketItemProductVM>();
        foreach (var item in basket)
        {
            vm.Add(new BasketItemProductVM
            {
                Count = item.Count,
                Product = await _productService.GetById(item.Id)
            }); ;
        }
        return PartialView("_BasketPartial", vm);
    }

}