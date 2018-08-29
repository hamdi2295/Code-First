using System;
using News.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Controllers
{
    class Category_Controller
    {
        BaseContext _context = new BaseContext();

        public void menu_category()
        {
            int input;
            BaseContext _context = new BaseContext();
            Program call = new Program();

            Console.Clear();
            Console.WriteLine("======================================================");
            Console.WriteLine("|                 Category  Page                     |");
            Console.WriteLine("======================================================");
            Console.WriteLine("| 1. View All                                        |");
            Console.WriteLine("| 2. Insert                                          |");
            Console.WriteLine("| 3. Update                                          |");
            Console.WriteLine("| 4. Delete                                          |");
            Console.WriteLine("======================================================");
            Console.WriteLine("\n");
            Console.Write("Silahkan Pilih : "); int pil = Convert.ToInt32(Console.ReadLine());


            switch (pil)
            {
                case 1:
                    ViewAll();
                    break;
                case 2:
                    insert();
                    break;
                case 3:
                    Console.Write("Masukkan Id yang akan di Update : "); input = Convert.ToInt32(Console.ReadLine());
                    update(input);
                    break;
                case 4:
                    break;
                default:
                    break;
            }
        }
        public void insert()
        {
            Console.Write("Inputkan ID                 : "); int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Inputkan Category Name      : "); string catname = Console.ReadLine();

            category call = new category()
            {
                id = id,
                cat_name = catname
            };
            try
            {
                _context.category.Add(call);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException);
                Console.Write(ex.Message);
                Console.Write(ex.StackTrace);
            }
        }

        public List<category> ViewAll()
        {
            var getall = _context.category.ToList();
            foreach (category call in getall)
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Id                : " + call.id);
                Console.WriteLine("Category Name     : " + call.cat_name);
                Console.WriteLine("----------------------------------------------");

            }
            Console.ReadKey(true);
            return getall;
        }

        public int update(int input)
        {
            Console.Write("Inputkan Category Name    : "); string catname = Console.ReadLine();

            category call = GetById(input);
            call.cat_name = catname;

            _context.Entry(call).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return input;
        }

        public category GetById(int input)
        {
            category call = _context.category.Find(input);
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
                var x = (from y in ctx.category where y.id == input select y).FirstOrDefault();
                ctx.category.Remove(x);
                ctx.SaveChanges();
            }
            return input;
        }
    }
}
