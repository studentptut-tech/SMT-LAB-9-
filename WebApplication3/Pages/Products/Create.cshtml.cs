using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Pages.Products;

public class CreateModel(ProductRepository repository) : PageModel
{
    [BindProperty]
    public Product Product { get; set; } = new() { Status = "Active" };

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();
        await repository.CreateAsync(Product);
        TempData["Success"] = "Product created successfully.";
        return RedirectToPage("Index");
    }
}
