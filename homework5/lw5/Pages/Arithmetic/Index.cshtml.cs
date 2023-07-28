using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace lw5.Pages.Arithmetic
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public long Number1 { get; set; }

        [BindProperty]
        public long Number2 { get; set; }

        [BindProperty]
        public string Operator { get; set; }

        public SelectList OperatorList { get; } = new SelectList(new[]
        {
            new { Value = "add", Text = "+" },
            new { Value = "subtract", Text = "-" }
        }, "Value", "Text");

        public string Result { get; private set; }

        public void OnGet()
        {
            // Пустой обработчик для HTTP GET запроса
        }

        public void OnPost()
        {
            if (Operator == "add")
            {
                Result = (Number1 + Number2).ToString();
            }
            else if (Operator == "subtract")
            {
                Result = (Number1 - Number2).ToString();
            }
        }

        public List<int> RememberedValues { get; set; }
        public IndexModel()
        {
            // Инициализируем список RememberedValues
            RememberedValues = new List<int>();
        }
    }
}