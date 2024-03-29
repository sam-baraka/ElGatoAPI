﻿using ElGatoAPI.Models;
using ElGatoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElGatoAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BreedsController : ControllerBase
{

    private readonly BreedsService _breedService;

    public BreedsController(BreedsService breedsService)
    {
        _breedService = breedsService;

    }

    [HttpGet]
    public async Task<object> Get()
    {
        try { return await _breedService.GetAsync(); } catch(Exception e) {
            return e.Message;
        }
    }

    [HttpGet("{id:length(4)}")]
    public async Task<ActionResult<Breed>> Get(string id)
    {

        var breed = await _breedService.GetAsync(id);

        if (breed is null)
        {
            return NotFound();
        }

        return breed;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Breed newBreed)
    {
        await _breedService.CreateAsync(newBreed);

        return CreatedAtAction(nameof(Get), new { id = newBreed.Id }, newBreed);
    }

    [HttpPut("{id:length(4)}")]
    public async Task<IActionResult> Update(string id, Breed updatedBreed)
    {
        var breed = await _breedService.GetAsync(id);

        if (breed is null)
        {
            return NotFound();
        }

        updatedBreed.Id = breed.Id;

        await _breedService.UpdateAsync(id, updatedBreed);

        return NoContent();
    }

    [HttpDelete("{id:length(4)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var breed = await _breedService.GetAsync(id);

        if (breed is null)
        {
            return NotFound();
        }

        await _breedService.RemoveAsync(id);

        return NoContent();
    }
}
