using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

using var _context = new BlogDataContext();

// var user = new User
// {
//    Name = "Gabriel",
//    Email = "gabriel@gmail.com",
//    Bio = "Bio Generica",
//    Image = "URL de imagem",
//    PasswordHash = "Senha com Hash",
//    Slug = "Slug generico",
// };

// var category = new Category
// {
//    Name = "Categoria nova",
//    Slug = "Slug de nova categoria"
// };

// var post = new Post
// {
//    Title = "Titulo do novo post",
//    Author = user,
//    Body = "Corpo do post",
//    Slug = "Slug de post",
//    Category = category,
//    Summary = "Nesse post vamos aprender sobre EFCore",
//    CreateDate = DateTime.Now,
//    LastUpdateDate = DateTime.Now
// };

// _context.Posts.Add(post);

// _context.SaveChanges();


// var posts = _context
//    .Posts
//    .AsNoTracking()
//    .Include(x => x.Author)
//    .Include(x => x.Category)
//    .OrderByDescending(x => x.LastUpdateDate)
//    .ToList();


// foreach (var post in posts) Console.WriteLine($"{post.Title} escrito por {post.Author?.Name} em {post.Category?.Name}");



var posts = _context
   .Posts
   .Include(x => x.Author)
   .Include(x => x.Category)
   .OrderByDescending(x => x.LastUpdateDate)
   .FirstOrDefault();

posts.Author.Name = "Teste";

_context.Posts.Update(posts);

_context.SaveChanges();