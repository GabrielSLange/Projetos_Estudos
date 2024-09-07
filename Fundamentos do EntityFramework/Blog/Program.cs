using Blog.Data;
using Blog.Models;


var user = new User
{
   Name = "Gabriel",
   Email = "gabriel@gmail.com",
   Bio = "Bio Generica",
   Image = "URL de imagem",
   PasswordHash = "Senha com Hash",
   Slug = "Slug generico",
   GitHub = "Meu GIT"
};

var _context = new BlogDataContext();

_context.Users?.Add(user);

_context?.SaveChanges();