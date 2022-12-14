using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kovacs_Adela_lab02.Data;
using Kovacs_Adela_lab02.Models;

namespace Kovacs_Adela_lab02.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private readonly Kovacs_Adela_lab02.Data.Kovacs_Adela_lab02Context _context;

        public IndexModel(Kovacs_Adela_lab02.Data.Kovacs_Adela_lab02Context context)
        {
            _context = context;
        }

        public IList<Author> Author { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Author != null)
            {
                Author = await _context.Author.ToListAsync();
            }
        }
    }
}
