using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Kovacs_Adela_lab02.Data;
using Kovacs_Adela_lab02.Models;

namespace Kovacs_Adela_lab02.Pages.Books
{
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Kovacs_Adela_lab02.Data.Kovacs_Adela_lab02Context _context;

        public CreateModel(Kovacs_Adela_lab02.Data.Kovacs_Adela_lab02Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var authorlist = _context.Author.Select(x => new
            {
                x.ID,
                FullName = x.LastName + " " + x.FirstName
            });
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID",
"PublisherName");
            ViewData["AuthorID"] = new SelectList(authorlist, "ID", "FullName");
            var book = new Book();
            book.BookCategories = new List<BookCategory>();
            PopulateAssignedCategoryData(_context, book);
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newBook = Book;
            if (selectedCategories != null)
            {
                newBook.BookCategories = new List<BookCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBook.BookCategories.Add(catToAdd);
                }
            }
           
             _context.Book.Add(newBook);
             await _context.SaveChangesAsync();
             return RedirectToPage("./Index");
            
            PopulateAssignedCategoryData(_context, newBook);
            return Page();
        }
       
    }
}
