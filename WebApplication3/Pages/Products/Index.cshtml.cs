using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Pages.Products;

public class IndexModel(ProductRepository repository) : PageModel
{
    public List<Product> Products { get; private set; } = [];

    public async Task OnGetAsync() => Products = await repository.GetAllAsync();
}
