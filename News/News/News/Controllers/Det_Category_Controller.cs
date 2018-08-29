using System;
using News.Models;
using News.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Controllers
{
    class Det_Category_Controller
    {
        BaseContext _context = new BaseContext();
        int input;
        public void menu_det_cat()
        {

            BaseContext _context = new BaseContext();
            Program call = new Program();

            Console.Clear();
            Console.WriteLine("======================================================");
            Console.WriteLine("|                 Det Tag Page                       |");
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
                    insert();
                    break;
                default:
                    break;
            }
        }
        public void insert()
        {

            Console.Write("Inputkan ID                    : "); int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Inputkan Detail Category Name  : "); string detcatname = Console.ReadLine();
            Console.Write("Inputkan Category Name         : "); int c_id = Convert.ToInt32(Console.ReadLine());
            det_cat called = new det_cat()
            {
                id = id,
                det_name = detcatname,
                categoryid = c_id

            };
            try
            {
                _context.det_cat.Add(called);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException);
                Console.Write(ex.Message);
                Console.Write(ex.StackTrace);
            }
        }

        public List<det_cat> ViewAll()
        {
            var getall = _context.det_cat.ToList();
            foreach (det_cat call in getall)
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Id                    : " + call.id);
                Console.WriteLine("Detail Category Name  : " + call.det_name);
                Console.WriteLine("Category ID           : " + call.categoryid);
                Console.WriteLine("----------------------------------------------");

            }
            Console.ReadKey(true);
            return getall;
        }

        public int update(int input)
        {
            Program panggilvoid = new Program();
            Console.Write("Inputkan Detail Category Name      : "); string detcatname = Console.ReadLine();
            Console.Write("Inputkan Category Id               : "); int catid = Convert.ToInt32(Console.ReadLine());

            det_cat call = GetById(input);
            call.det_name = detcatname;
            call.categoryid = catid;

            _context.Entry(call).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return input;
        }

        public det_cat GetById(int input)
        {
            det_cat call = _context.det_cat.Find(input);
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
                var x = (from y in ctx.det_cat where y.id == input select y).FirstOrDefault();
                ctx.det_cat.Remove(x);
                ctx.SaveChanges();
            }
            return input;
        }
    }
}
