using ElGatoAPI.Models;
using ElGatoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElGatoAPI.Controllers;


[ApiController]
[Route("api/[controller]")]

public class ImagesController : ControllerBase{

    private readonly ImagesService _imageService;

    public ImagesController(ImagesService imagesService)
    {
        _imageService = imagesService;

    }

    [HttpGet]
    public async Task<List<CatImage>> Get() => await _imageService.GetAsync();

    [HttpGet("{id:length(4)}")]
    public async Task<ActionResult<CatImage>> Get(string id)
    {

        var image = await _imageService.GetAsync(id);

        if (image is null)
        {
            return NotFound();
        }

        return image;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CatImage newImage)
    {
        await _imageService.CreateAsync(newImage);

        return CreatedAtAction(nameof(Get), new { id = newImage.Id }, newImage);
    }

    [HttpPut("{id:length(4)}")]
    public async Task<IActionResult> Update(string id, CatImage updatedImage)
    {
        var image = await _imageService.GetAsync(id);

        if (image is null)
        {
            return NotFound();
        }

        updatedImage.Id = image.Id;

        await _imageService.UpdateAsync(id, updatedImage);

        return NoContent();
    }

    [HttpDelete("{id:length(4)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var image = await _imageService.GetAsync(id);

        if (image is null)
        {
            return NotFound();
        }

        await _imageService.RemoveAsync(id);

        return NoContent();
    }

    

}