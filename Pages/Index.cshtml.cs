using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FizzBuzzWeb2.Models;

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

        public IActionResult OnPost()
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