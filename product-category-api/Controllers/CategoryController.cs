using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using product_category_api.DAL;
using product_category_api.DTOs.CategoryDtos;
using product_category_api.Models;

namespace product_category_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CategoryController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetCategoryDto>> GetCategory(int id)
    {
        var category = await _context.Categories.Include(p => p.Products).FirstOrDefaultAsync(p => p.Id == id);
        if (category == null)
        {
            return NotFound();
        }

        var categoryDto = _mapper.Map<GetCategoryDto>(category);
        return Ok(categoryDto);
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllCategoryDto>>> GetAllCategories()
    {
        var categories = await _context.Categories.Include(p => p.Products).ToListAsync();
        var categoryDtos = _mapper.Map<List<GetAllCategoryDto>>(categories);
        return Ok(categoryDtos);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryDto categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return StatusCode(201, category);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);
        if (category == null)
        {
            return NotFound();
        }

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(UpdateCategoryDto categoryDto)
    {
        var categoryToUpdate = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(p => p.Id == categoryDto.Id);
        if (categoryToUpdate is null) return NotFound("Category not found");
        _mapper.Map(categoryDto, categoryToUpdate);
        _context.Categories.Update(categoryToUpdate);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}