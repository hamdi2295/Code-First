using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Controllers
{
    public class News_User_Controller
    {
        BaseContext _context = new BaseContext();
        public void insert()
        {
            Console.Write("Inputkan ID            : "); int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Inputkan Username      : "); string username = Console.ReadLine();
            Console.Write("Inputkan Password      : "); string password= Console.ReadLine();
            Console.Write("Inputkan First Name    : "); string first_name = Console.ReadLine();
            Console.Write("Inputkan Last Name     : "); string last_name = Console.ReadLine();
            Console.Write("Inputkan Email         : "); string email = Console.ReadLine();
            Console.Write("Inputkan Address       : "); string address = Console.ReadLine();
            Console.Write("Inputkan Phone         : "); string phone = Console.ReadLine();
            Console.Write("Inputkan Status        : "); string status = Console.ReadLine();
            Console.Write("Inputkan Pocket        : "); int pocket = Convert.ToInt32(Console.ReadLine());
            Console.Write("Inputkan Role          : "); string role = Console.ReadLine();

            news_user call = new news_user()
            {
                id = id,
                username = username,
                password = password,
                first_name = first_name,
                last_name = last_name,
                email = email,
                address = address,
                phone = phone,
                status = status,
                pocket = pocket,
                role = role
            };
            try
            {                
                _context.news_user.Add(call);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException);
                Console.Write(ex.Message);
                Console.Write(ex.StackTrace);
            }
        }
    }
}
