using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GranShopAPI.Models;
using GranShopAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace GranShopAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CategoriasController(AppDbContext db) : ControllerBase
{
    private readonly AppDbContext _db = db;

    // GET: api/Categorias
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_db.Categorias.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var categoria = _db.Categorias.Find(id);
        if (categoria == null)
        {
            return NotFound();
        }
        return Ok(categoria);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Categoria categoria)
    {
        if (!ModelState.IsValid)
            return BadRequest("Categoria inválida");
        _db.Categorias.Add(categoria);
        _db.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = categoria.Id }, categoria);
    }

    [HttpPut("{id}")]
    public IActionResult Edit(int id, [FromBody] Categoria categoria)
    {
        if (!ModelState.IsValid || id != categoria.Id)
            return BadRequest("Categoria inválida");
        _db.Categorias.Update(categoria);
        _db.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var categoria = _db.Categorias.Find(id);
        if (categoria == null)
        {
            return NotFound();
        }
        _db.Categorias.Remove(categoria);
        _db.SaveChanges();
        return NoContent();
    }

}