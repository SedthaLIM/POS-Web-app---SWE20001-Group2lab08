﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoToGre.BackEnd.Repos;
using GoToGre.Common.Models;
using System.IO;
using Microsoft.Net.Http.Headers;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoToGre.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        StorageManager _storageManager;
        GoToGreRepo _repo;
        public ImageController(GoToGreRepo repo, StorageManager storageManager)
        {
            _repo = repo;
            _storageManager = storageManager;
        }
        // GET: api/<ImageController>
        [HttpGet]
        public async Task<List<string>> ReadAll() {
            return await _storageManager.GetAllBlobs();
        
        }

        // GET api/<ImageController>/5
        [HttpGet("{name}")]
        public async Task<FileStreamResult> Get(string name)
        {
            string[] arr = name.Split(".");
            MemoryStream ms = new MemoryStream();
            Stream stream = await _storageManager.GetFile(name, ms);
            stream.Position = 0;
            if (arr.Last() == "jpg")
            {
                return new FileStreamResult(stream, new MediaTypeHeaderValue($"image/jpeg"))
                {
                    FileDownloadName = name
                };
            }
            return new FileStreamResult(stream, new MediaTypeHeaderValue($"image/{arr.Last()}"))
            {
                FileDownloadName = name
            };

        }

        // POST api/<ImageController>
        [HttpPost("members/{id}/{fileExtension}")]
        public async Task<Image> PostMember(int id,string fileExtension)
        {
            Member member = _repo.GetMember(id);

            Image image = new Image()
            {
                Name = $"{Guid.NewGuid()}.{fileExtension}",
                FileType = fileExtension
            };
            _repo.AddImage(image);
            using (MemoryStream ms = new MemoryStream())
            {
                await Request.Body.CopyToAsync(ms);
                ms.Position = 0;
                await _storageManager.UploadFile(ms, image.Name);

            }
            member.ImageURL = $"Image/{image.Name.ToString()}.{image.FileType}";
            _repo.UpdateMember(member);
            return image;

        }
        [HttpPost("products/{id}/{fileExtension}")]
        public async Task<Image> PostProducts(int id,string fileExtension)
        {
            Product product = _repo.GetProductByID(id);
            Image image = new Image()
            {
                Name = $"{Guid.NewGuid()}.{fileExtension}",
                FileType = fileExtension
            };
            _repo.AddImage(image);
            using (MemoryStream ms = new MemoryStream())
            {
                await Request.Body.CopyToAsync(ms);
                ms.Position = 0;
                await _storageManager.UploadFile(ms, image.Name);
            }
            product.ImageURL = $"Image/{image.Name.ToString()}.{image.FileType}";
            _repo.UpdateProduct(product);
            return image;
        }
    }
}
