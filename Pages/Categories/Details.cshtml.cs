using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kovacs_Adela_lab02.Data;
using Kovacs_Adela_lab02.Models;

namespace Kovacs_Adela_lab02.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly Kovacs_Adela_lab02.Data.Kovacs_Adela_lab02Context _context;

        public DetailsModel(Kovacs_Adela_lab02.Data.Kovacs_Adela_lab02Context context)
        {
            _context = context;
        }

      public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Category == null)
            {
                return NotFound();
            }

            var category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);
            if (category == null)
            {
                return NotFound();
            }
            else 
            {
                Category = category;
            }
            return Page();
        }
    }
}
