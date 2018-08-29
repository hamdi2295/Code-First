using System;
using News.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Controllers
{
    class Tag_Controller
    {
        BaseContext _context = new BaseContext();

        public void menu_tag()
        {
            int input;
            Controllers.Tag_Controller panggil = new Controllers.Tag_Controller();
            BaseContext _context = new BaseContext();
            Program call = new Program();

            Console.Clear();
            Console.WriteLine("======================================================");
            Console.WriteLine("|                 Tag Page                     |");
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
                    panggil.ViewAll();
                    break;
                case 2:
                    panggil.insert();
                    break;
                case 3:
                    Console.Write("Masukkan Id yang akan di Update : "); input = Convert.ToInt32(Console.ReadLine());
                    panggil.update(input);
                    break;
                case 4:
                    break;
                default:
                    break;
            }
        }
        public void insert()
        {
            Console.Write("Inputkan ID            : "); int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Inputkan Tag Name      : "); string tagname = Console.ReadLine();
            
            tag call = new tag()
            {
                id = id,
                tag_name = tagname
            };
            try
            {
                _context.tag.Add(call);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException);
                Console.Write(ex.Message);
                Console.Write(ex.StackTrace);
            }
        }

        public List<tag> ViewAll()
        {
            var getall = _context.tag.ToList();
            foreach (tag call in getall)
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Id           : " + call.id);
                Console.WriteLine("Tag Name     : " + call.tag_name);
                Console.WriteLine("----------------------------------------------");

            }
            Console.ReadKey(true);
            return getall;
        }

        public int update(int input)
        {
            Program panggilvoid = new Program();
            Console.Write("Inputkan Tag Name      : "); string tagname = Console.ReadLine();
            
            tag call = GetById(input);
            call.tag_name = tagname;

            _context.Entry(call).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return input;
        }

        public tag GetById(int input)
        {
            tag call = _context.tag.Find(input);
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
                var x = (from y in ctx.tag where y.id == input select y).FirstOrDefault();
                ctx.tag.Remove(x);
                ctx.SaveChanges();
            }
            return input;
        }
    }
}
