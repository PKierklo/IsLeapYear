using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FizzBuzzWeb.Forms
{
    public class FizzBuzzForm
    {
        [Display(Name = "Rok")]
        [Required, Range(1899, 2022, ErrorMessage = "Wymagany rok z zakresu {1} i {2}")]
        public int? Year { get; set; }

        [Display(Name = "Imie")]
        [Required, StringLength(100)]
        public string? Name { get; set; }

        public bool IsLeapYear { get; private set; }

        public string? AlertInfo { get; private set; }
        public string AlertStyle => "alert alert-primary";

        public FizzBuzzForm()
        {
        }

        public void Check()
        {
            string suffix = (char.ToLower(Name[Name.Length - 1]) == 'a') ? "a" : "";
            AlertInfo = $"{Name}{suffix} urodził{(suffix == "" ? " " : "a ")}się w {Year} roku. To";

            bool isLeapYear = (Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0);

            IsLeapYear = isLeapYear;

            if (isLeapYear)
            {
                AlertInfo += " był rok przestępny";
            }
            else
            {
                AlertInfo += " nie był rokiem przestępnym";
            }
        }
    }
}