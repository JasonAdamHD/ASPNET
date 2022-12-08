using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab8.Models;
using Lab8.Repositories;
using Lab8.DataObjects;
using System.Collections.Generic;

namespace Lab8.Controllers;
[Route("")]
[Route("Home")]
public class HomeController : Controller
{
    private readonly IImageRepository _ImageRepo;

    public HomeController(IImageRepository imageRepo)
    {
        _ImageRepo = imageRepo;
    }
    [Route("")]
    [HttpGet("Index")]
    public IActionResult Index()
    {
        List<ImageObject> imageObjects = _ImageRepo.GetImages();
        return View(imageObjects);
    }

    [HttpGet]
    [Route("AddImage")]
    public IActionResult AddImage()
    {
        ImageModel imageModel = new ImageModel();
        return View(imageModel);
    }

    [HttpPost]
    [Route("AddImage")]
    public IActionResult AddImage(ImageModel model) 
    {    
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        byte[] fileData;
        using MemoryStream fileStream = new MemoryStream();
        model.file.CopyTo(fileStream);
        fileData = fileStream.ToArray();

        ImageObject imageObject = new ImageObject();
        imageObject.Description = model.description;
        imageObject.FileData = fileData;
        imageObject.FileName = model.file.FileName;
        imageObject.Timestamp = DateTime.Now;
        _ImageRepo.SaveImage(imageObject);

        return RedirectToAction("Index");
    }
    
    [HttpGet("Image/{id}")]
    [ResponseCache(Duration = 1800)]
    public IActionResult GetImage(int id) 
    {
        return File(_ImageRepo.GetImageData(id), "image/jpeg");
    }
}
