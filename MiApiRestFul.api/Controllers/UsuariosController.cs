﻿using MiApiRestFul.api.Data;
using MiApiRestFul.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiApiRestFul.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly ApiDbContext _context;

    public UsuariosController(ApiDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
    {
        return await _context.Usuarios.ToListAsync();
    }

    // GET api/<UsuariosController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Usuario>> GetUsuario(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);

        if(usuario == null)
        {
            return NotFound();
        }
        return usuario;
    }

    // POST api/<UsuariosController>
    [HttpPost]
    public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
    }

    // PUT api/<UsuariosController>/5
    [HttpPut("{id}")] 
    public async Task<IActionResult> PutUsuario(int id, Usuario usuario) 
    { 
        if (id != usuario.Id){ 
            return BadRequest(); 
        } 
        _context.Entry(usuario).State = EntityState.Modified; 
        await _context.SaveChangesAsync();
        
        return NoContent(); 
    }

    // DELETE api/<UsuariosController>/5
    [HttpDelete("{id}")] 
    public async Task<IActionResult> DeleteUsuario(int id) { 
        var usuario = await _context.Usuarios.FindAsync(id);

        if (usuario == null) { 
            return NotFound(); 
        }

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();

        return NoContent(); 
    }
}
