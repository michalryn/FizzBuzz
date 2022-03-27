using System.ComponentModel.DataAnnotations;

namespace FizzBuzzWeb2.Models
{
    public class FizzBuzz
    {
        [Display(Name = "Twój szczęśliwy numerek")]
        [Required(ErrorMessage = "Pole jest obowiązkowe"),
         Range(1, 1000, ErrorMessage = "Oczekiwana wartość {0} z zakresu {1} i {2}.")]
        public int? Number { get; set; }
        public string? Output { get; set; }
        
        public string? Check()
        {
            string output = "";
            if (Number % 3 == 0)
                output += "Fizz";
            if (Number % 5 == 0)
                output += "Buzz";
            if(output == "")
            {
                Output = $"Liczba: {Number} nie spełnia kryteriów FizzBuzz";
                return $"Liczba: {Number} nie spełnia kryteriów FizzBuzz";
            }
            Output = output;
            return output;
        }
    }
}
