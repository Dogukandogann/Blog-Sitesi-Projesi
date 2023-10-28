using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concrete;

namespace BlogProjesi.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult BlogList(int page=1)
        {
            var blogList = bm.GetAll().ToPagedList(page,6);
            return PartialView(blogList);
        }
        public PartialViewResult FeaturedPost()
        {
            //1. Post
            var postTitle1 = bm.GetAll().OrderByDescending(x=>x.BlogId).Where(y => y.CategoryId == 1).Select(z => z.BlogTitle).FirstOrDefault();
            var postImage1 = bm.GetAll().OrderByDescending(x => x.BlogId).Where(y => y.CategoryId == 1).Select(z => z.BlogImage).FirstOrDefault();
            var blogDate1 = bm.GetAll().OrderByDescending(x => x.BlogId).Where(y => y.CategoryId == 1).Select(z => z.BlogDate).FirstOrDefault();
            
            ViewBag.postTitle1 = postTitle1;
            ViewBag.postImage1 = postImage1;
            ViewBag.blogDate1 = blogDate1;

            //2.Post

            var postTitle2 = bm.GetAll().OrderByDescending(x => x.BlogId).Where(y => y.CategoryId == 2).Select(z => z.BlogTitle).FirstOrDefault();
            var postImage2 = bm.GetAll().OrderByDescending(x => x.BlogId).Where(y => y.CategoryId == 2).Select(z => z.BlogImage).FirstOrDefault();
            var blogDate2 = bm.GetAll().OrderByDescending(x => x.BlogId).Where(y => y.CategoryId == 2).Select(z => z.BlogDate).FirstOrDefault();

            ViewBag.postTitle2 = postTitle2;
            ViewBag.postImage2 = postImage2;
            ViewBag.blogDate2 = blogDate2;

            //3.Post

            var postTitle3 = bm.GetAll().OrderByDescending(x => x.BlogId).Where(y => y.CategoryId == 3).Select(z => z.BlogTitle).FirstOrDefault();
            var postImage3 = bm.GetAll().OrderByDescending(x => x.BlogId).Where(y => y.CategoryId == 3).Select(z => z.BlogImage).FirstOrDefault();
            var blogDate3 = bm.GetAll().OrderByDescending(x => x.BlogId).Where(y => y.CategoryId == 3).Select(z => z.BlogDate).FirstOrDefault();

            ViewBag.postTitle3 = postTitle3;
            ViewBag.postImage3 = postImage3;
            ViewBag.blogDate3 = blogDate3;

            //4.Post

            var postTitle4 = bm.GetAll().OrderByDescending(x => x.BlogId).Where(y => y.CategoryId == 4).Select(z => z.BlogTitle).FirstOrDefault();
            var postImage4 = bm.GetAll().OrderByDescending(x => x.BlogId).Where(y => y.CategoryId == 4).Select(z => z.BlogImage).FirstOrDefault();
            var blogDate4 = bm.GetAll().OrderByDescending(x => x.BlogId).Where(y => y.CategoryId == 4).Select(z => z.BlogDate).FirstOrDefault();

            ViewBag.postTitle4 = postTitle4;
            ViewBag.postImage4 = postImage4;
            ViewBag.blogDate4 = blogDate4;

            //5. post Öne Çıkan Orta
            var postTitle5 = bm.GetAll().OrderByDescending(x => x.BlogId).Where(y => y.CategoryId == 5).Select(z => z.BlogTitle).FirstOrDefault();
            var postImage5 = bm.GetAll().OrderByDescending(x => x.BlogId).Where(y => y.CategoryId == 5).Select(z => z.BlogImage).FirstOrDefault();
            var blogDate5 = bm.GetAll().OrderByDescending(x => x.BlogId).Where(y => y.CategoryId == 5).Select(z => z.BlogDate).FirstOrDefault();

            ViewBag.postTitle5 = postTitle5;
            ViewBag.postImage5 = postImage5;
            ViewBag.blogDate5 = blogDate5;
            return PartialView();
        }
        public PartialViewResult OtherFeaturedPost()
        {
            return PartialView();
        }
        public ActionResult BlogDetails()
        {
            
            return View();
        }
        public PartialViewResult BlogCover(int id)
        {
            var BlogDetailsList = bm.GetBlogByID(id);
            return PartialView(BlogDetailsList);
        }
        public PartialViewResult BlogReadAll(int id)
        {
            var BlogDetailsList = bm.GetBlogByID(id);
            return PartialView(BlogDetailsList);
        }

        public ActionResult BlogByCategory(int id)
        {
            var blotListByCaregory = bm.GetBlogByCategory(id);
            var categoryName = blotListByCaregory.Select(x=>x.Category.Name).FirstOrDefault();
            ViewBag.CategoryName= categoryName;
            var categoryDesc = blotListByCaregory.Select(x => x.Category.CategoryDescription).FirstOrDefault();
            ViewBag.categoryDesc = categoryDesc;
            return View(blotListByCaregory);
        }
        public ActionResult AdminBlogList()
        {
            var bloglist = bm.GetAll();
            return View(bloglist);
        }
        public ActionResult AddNewBlog()
        {
            DataAccessLayer.Concrete.Context c = new DataAccessLayer.Concrete.Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.values= values;
            List<SelectListItem> authors = (from x in c.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text=x.AuthorName, 
                                                Value = x.AuthorId.ToString()
                                            }).ToList();
            ViewBag.authors= authors;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog b)
        {
            bm.BlogAddBl(b);
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult DeleteBlog(int id)
        {
            bm.DeleteBlog(id);
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult UpdateBlog(int id)
        {

            DataAccessLayer.Concrete.Context c = new DataAccessLayer.Concrete.Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.values = values;
            List<SelectListItem> authors = (from x in c.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorId.ToString()
                                            }).ToList();
            ViewBag.authors = authors;
            Blog blog = bm.FindBlog(id);
            return View(blog);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            bm.UpdateBlog(p);
            return RedirectToAction("AdminBlogList");

        }
        public ActionResult GetCommentByBlog(int id)
        {
            CommentManager cm = new CommentManager();
            var commentList = cm.CommentByBlog(id);
            return PartialView(commentList);
        }
        public ActionResult AdminBlogList2()
        {
            var bloglist = bm.GetAll();
            return View(bloglist);
        }

    }
}