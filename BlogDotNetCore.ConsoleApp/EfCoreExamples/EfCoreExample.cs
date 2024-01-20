using BlogDotNetCore.ConsoleApp.Db;
using BlogDotNetCore.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDotNetCore.ConsoleApp.EfCoreExamples
{
    public class EfCoreExample
    {
        private readonly AppDbContext _dbContext = new AppDbContext();

        public void Run()
        {
            //Read();
            //Edit(12);
            //Create("Testing Title", "Testing Author", "Testing Content");
            //Update(15, "Testing Title", "Testing Author", "Testing Content");
            Delete(15);

        }

        public void Read()
        {
            var Lst = _dbContext.Blogs.ToList();
            foreach (var item in Lst)
            {
                Console.WriteLine("Blog Id =>" + item.Blog_Id);
                Console.WriteLine("Blog Author =>" + item.Blog_Author);
                Console.WriteLine("Blog Title =>" + item.Blog_Title);
                Console.WriteLine("Blog Content =>" + item.Blog_Content);
                Console.WriteLine("........................");

            }
        }

        public void Edit(int id)
        {
            var item = _dbContext.Blogs.AsNoTracking().FirstOrDefault(x => x.Blog_Id == id);
            if (item == null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            Console.WriteLine("Blog Id =>" + item.Blog_Id);
            Console.WriteLine("Blog Author =>" + item.Blog_Author);
            Console.WriteLine("Blog Title =>" + item.Blog_Title);
            Console.WriteLine("Blog Content =>" + item.Blog_Content);
            Console.WriteLine("........................");


        }

        public void Create(string title, string author, string content)
        {

            BlogDataModel model = new BlogDataModel()
            {
                Blog_Author = author,
                Blog_Title = title,
                Blog_Content = content
            };
            _dbContext.Blogs.Add(model);
            int result = _dbContext.SaveChanges();
            string message = result > 0 ? "Blog Created Successful " : "Saving Failed";
            Console.WriteLine(message);

        }

        public void Update(int id, string title, string author, string content)
        {
            var item = _dbContext.Blogs.FirstOrDefault(x => x.Blog_Id == id);
            if (item == null)
            {
                Console.WriteLine("No Data Found");
                return;
            }

            item.Blog_Author = author;
            item.Blog_Title = title;
            item.Blog_Content = content;

            int result = _dbContext.SaveChanges();
            string message = result > 0 ? "Blog Updated Successful " : "Updating Failed";
            Console.WriteLine(message);

        }

        public void Delete(int id)
        {
            var item = _dbContext.Blogs.FirstOrDefault(x => x.Blog_Id == id);
            if (item == null)
            {
                Console.WriteLine("No Data Found");
                return;
            }

            _dbContext.Blogs.Remove(item);
            int result = _dbContext.SaveChanges();
            string message = result > 0 ? "Blog Deleted Successful " : "Deleting Failed";
            Console.WriteLine(message);

        }
    }
}
