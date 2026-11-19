using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Pages.Products;

public class DeleteModel(ProductRepository repository) : PageModel
{
    public Product Product { get; private set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Product = await repository.GetByIdAsync(id) ?? new Product();
        return Product.Id == 0 ? NotFound() : Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        if (await repository.GetByIdAsync(id) is null) return NotFound();
        await repository.DeleteAsync(id);
        TempData["Success"] = "Product deleted successfully.";
        return RedirectToPage("Index");
    }
}
