using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public FizzBuzzForm FizzBuzz { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                FizzBuzz.Check();

                string SessionData = "";
                var Data = HttpContext.Session.GetString("Data");
                if (Data != null)
                    SessionData = JsonConvert.DeserializeObject<string>(Data);

                if (!string.IsNullOrEmpty(SessionData))
                {
                    SessionData += Environment.NewLine;
                }

                SessionData += FizzBuzz.Name + ", " + FizzBuzz.Year + " - ";
                if (FizzBuzz.IsLeapYear) SessionData += "rok przestępny";
                else SessionData += "rok zwykły";
                HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(SessionData));
            }
            return Page();
        }
    }
}