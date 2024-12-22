using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using product_category_api.DAL;
using product_category_api.DTOs.ProductDtos;
using product_category_api.Models;

namespace product_category_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ProductController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetProductDto>> GetProduct(int id)
    {
        var product = await _context.Products.Include(c => c.Category).FirstOrDefaultAsync(c => c.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        var productDto = _mapper.Map<GetProductDto>(product);
        return Ok(productDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var product = await _context.Products.Include(c => c.Category).ToListAsync();
        var productDtos = _mapper.Map<List<GetAllProductDto>>(product);
        return Ok(productDtos);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto createProductDto)
    {
        var product = _mapper.Map<Product>(createProductDto);
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return StatusCode(201, product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
    {
        var productToUpdate = await _context.Products.AsNoTracking().Include(c => c.Category).FirstOrDefaultAsync(c => c.Id == updateProductDto.Id);
        if (productToUpdate == null)
        {
            return NotFound();
        }

        _mapper.Map(updateProductDto, productToUpdate);
        _context.Products.Update(productToUpdate);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _context.Products.Include(c => c.Category).FirstOrDefaultAsync(c => c.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}