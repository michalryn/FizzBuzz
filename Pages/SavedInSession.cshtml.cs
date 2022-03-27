using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FizzBuzzWeb2.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace FizzBuzzWeb2.Pages
{
    public class SavedInSessionModel : PageModel
    {
        public List<FizzBuzz>? FizzBuzzes { get; set; }

        public void OnGet()
        {
            var Data = HttpContext.Session.GetString("Data");
            
            if (Data != null)
                FizzBuzzes = JsonConvert.DeserializeObject<List<FizzBuzz>>(Data);

        }
    }
}
