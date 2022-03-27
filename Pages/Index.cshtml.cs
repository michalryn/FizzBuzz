using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FizzBuzzWeb2.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace FizzBuzzWeb2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Name { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnPost(List<FizzBuzz>? FizzBuzzes)
        {
            if (!ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(Name))
                {
                    Name = "User";
                }
                return Page();
            }

            TempData["AlertMessage"] = FizzBuzz.Check();
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";
            }

            if (ModelState.IsValid)
            {
                var Data = HttpContext.Session.GetString("Data");
                if (Data == null)
                {
                    FizzBuzzes = new List<FizzBuzz>();
                    FizzBuzzes.Add(FizzBuzz);
                    HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(FizzBuzzes));
                }
                else
                {
                    FizzBuzzes = JsonConvert.DeserializeObject<List<FizzBuzz>>(Data);
                    FizzBuzzes.Add(FizzBuzz);
                    HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(FizzBuzzes));
                }

                //return RedirectToPage("./SavedInSession");
            }
            return Page();
        }


        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";
            }
        }
    }
}