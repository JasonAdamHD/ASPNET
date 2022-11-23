using Microsoft.AspNetCore.Mvc;
using Lab5.Code.DataModels;
using Lab5.Code.Repositories;
using System.Configuration;
using System.Reflection;

namespace Lab5.Controllers
{
    [Route("Blog")]
    public class BlogController : Controller
    {
        private IDataEntityRepository<BlogPost> _dataEntityRepository;

        public BlogController(IConfiguration configuration, IDataEntityRepository<BlogPost> dataEntityRepository) 
        {
            _dataEntityRepository = dataEntityRepository;
        }

        public ActionResult Index()
        {
            BlogPostList blogPost = new BlogPostList(); 
            blogPost.BlogPosts = _dataEntityRepository.GetList(); 
            return View(blogPost);
        }

        [Route("Add")]
        public IActionResult Add() 
        {
            BlogPostModel blogPostModel = new BlogPostModel();
            return View(blogPostModel);
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(BlogPostModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            BlogPost blogPost = new BlogPost();
            blogPost.ID = model.ID;
            blogPost.Author = model.Author;
            blogPost.Title = model.Title;
            blogPost.Content = model.Content;
            blogPost.Timestamp = DateTime.Now;

            _dataEntityRepository.Save(blogPost);

            return RedirectToAction("Index");
        }

        [Route("Edit")]
        public IActionResult Edit(int id)
        {
            BlogPostModel blogPostModel = new BlogPostModel();

            BlogPost blogPost = _dataEntityRepository.Get(id);
            blogPostModel.ID = blogPost.ID;
            blogPostModel.Author = blogPost.Author;
            blogPostModel.Title = blogPost.Title;
            blogPostModel.Content = blogPost.Content;

            return View(blogPostModel);
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit(BlogPostModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            BlogPost blogPost = new BlogPost();
            blogPost.ID = model.ID;
            blogPost.Author = model.Author;
            blogPost.Title = model.Title;
            blogPost.Content = model.Content;
            blogPost.Timestamp = DateTime.Now;
            _dataEntityRepository.Save(blogPost);

            return RedirectToAction("Index");
        }
    }
}
