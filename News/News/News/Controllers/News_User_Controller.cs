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

        public void menu_newsuser()
        {
            int input;
            Controllers.News_User_Controller panggil = new Controllers.News_User_Controller();
            BaseContext _context = new BaseContext();
            Program call = new Program();

            Console.Clear();
            Console.WriteLine("======================================================");
            Console.WriteLine("|                 News User Page                     |");
            Console.WriteLine("======================================================");
            Console.WriteLine("| 1. View All                                        |");
            Console.WriteLine("| 2. Get By Id                                       |");
            Console.WriteLine("| 3. Insert                                          |");
            Console.WriteLine("| 4. Update                                          |");
            Console.WriteLine("| 5. Delete                                          |");
            Console.WriteLine("======================================================");
            Console.WriteLine("\n");
            Console.Write("Silahkan Pilih : "); int pil = Convert.ToInt32(Console.ReadLine());


            switch (pil)
            {
                case 1:
                    panggil.ViewAll();
                    break;
                case 2:
                    Console.Write("Masukkan Id yang dicari : "); input = Convert.ToInt32(Console.ReadLine());
                    panggil.GetById(input);
                    break;
                case 3:
                    panggil.insert();
                    break;
                case 4:
                    Console.Write("Masukkan Id yang akan di Update : "); input = Convert.ToInt32(Console.ReadLine());
                    panggil.update(input);
                    break;
                case 5:
                    break;
                default:
                    break;
            }
        }
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

        public List<news_user> ViewAll()
        {
            var getall = _context.news_user.ToList();
            foreach (news_user call in getall)
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Id           : " + call.id);
                Console.WriteLine("Username     : " + call.username);
                Console.WriteLine("Password     : " + call.password);
                Console.WriteLine("First Name   : " + call.first_name);
                Console.WriteLine("Last Name    : " + call.last_name);
                Console.WriteLine("Email        : " + call.email);
                Console.WriteLine("Address      : " + call.address);
                Console.WriteLine("Phone        : " + call.phone);
                Console.WriteLine("Status       : " + call.status);
                Console.WriteLine("Pocket       : " + call.pocket);
                Console.WriteLine("Role         : " + call.role);
                Console.WriteLine("----------------------------------------------");

            }
            Console.ReadKey(true);
            return getall;
        }

        public int update (int input)
        {
            Program panggilvoid = new Program();
            Console.Write("Inputkan Username      : "); string username = Console.ReadLine();
            Console.Write("Inputkan Password      : "); string password = Console.ReadLine();
            Console.Write("Inputkan First Name    : "); string first_name = Console.ReadLine();
            Console.Write("Inputkan Last Name     : "); string last_name = Console.ReadLine();
            Console.Write("Inputkan Email         : "); string email = Console.ReadLine();
            Console.Write("Inputkan Address       : "); string address = Console.ReadLine();
            Console.Write("Inputkan Phone         : "); string phone = Console.ReadLine();
            Console.Write("Inputkan Status        : "); string status = Console.ReadLine();
            Console.Write("Inputkan Pocket        : "); int pocket = Convert.ToInt32(Console.ReadLine());
            Console.Write("Inputkan Role          : "); string role = Console.ReadLine();

            news_user call = GetById(input);
            call.username = username;
            call.password = password;
            call.first_name = first_name;
            call.last_name = last_name;
            call.email = email;
            call.address = address;
            call.phone = phone;
            call.status = status;
            call.pocket = pocket;
            call.role = role;

            _context.Entry(call).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return input;
        }

        public news_user GetById(int input)
        {
            news_user call = _context.news_user.Find(input);
            if (call == null)
            {
                Console.Write("Id " + input + " Tidak Ada");
                Console.Read();
            }
            return call;
        }

        public int Delete(int input)
        {
            using (var ctx = new BaseContext())
            {
                var x = (from y in ctx.news_user where y.id == input select y).FirstOrDefault();
                ctx.news_user.Remove(x);
                ctx.SaveChanges();
            }
            return input;
        }
    }
}
