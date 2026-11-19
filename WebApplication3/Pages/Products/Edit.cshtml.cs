using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Pages.Products;

public class EditModel(ProductRepository repository) : PageModel
{
    [BindProperty]
    public Product Product { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Product = await repository.GetByIdAsync(id) ?? new Product();
        return Product.Id == 0 ? NotFound() : Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        if (id != Product.Id) return BadRequest();
        if (!ModelState.IsValid) return Page();
        if (await repository.GetByIdAsync(id) is null) return NotFound();
        await repository.UpdateAsync(Product);
        TempData["Success"] = "Product updated successfully.";
        return RedirectToPage("Index");
    }
}
