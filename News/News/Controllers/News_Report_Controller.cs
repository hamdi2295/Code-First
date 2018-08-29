using System;
using News.Controllers;
using News.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Controllers
{
    class News_Report_Controller
    {
        BaseContext _context = new BaseContext();

        public void menu_newreport()
        {
            int input;
            BaseContext _context = new BaseContext();
            Program call = new Program();

            Console.Clear();
            Console.WriteLine("======================================================");
            Console.WriteLine("|               News Report Page                     |");
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
            Console.Write("Inputkan ID               : "); int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Inputkan News Date        : "); DateTime newsdate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Inputkan News Title       : "); string newstitle = Console.ReadLine();
            Console.Write("Inputkan News Lead        : "); string newslead = Console.ReadLine();
            Console.Write("Inputkan News Body        : "); string newsbody = Console.ReadLine();
            Console.Write("Inputkan News Image       : "); string newsimage = Console.ReadLine();
            Console.Write("Inputkan Viewer           : "); string viewer = Console.ReadLine();
            Console.Write("Inputkan Salary           : "); int salari = Convert.ToInt32(Console.ReadLine());
            Console.Write("Inputkan Det Tag ID       : "); int dettagid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Inputkan News User ID     : "); int newsuserid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Inputkan Det Category ID  : "); int detcatid = Convert.ToInt32(Console.ReadLine());
            
            news_report call = new news_report()
            {
                id = id,
                news_date = newsdate,
                news_title = newstitle,
                news_lead = newslead,
                news_body = newsbody,
                news_image = newsimage,
                viewer = viewer,
                salary = salari,
                det_tagid = dettagid,
                news_userid = newsuserid,
                det_catid = detcatid
            };
            try
            {
                _context.news_report.Add(call);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException);
                Console.Write(ex.Message);
                Console.Write(ex.StackTrace);
            }
        }

        public List<news_report> ViewAll()
        {
            var getall = _context.news_report.ToList();
            foreach (news_report call in getall)
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Id                : " + call.id);
                Console.WriteLine("News Date         : " + call.news_date);
                Console.WriteLine("News Title        : " + call.news_title);
                Console.WriteLine("News Lead         : " + call.news_lead);
                Console.WriteLine("News Body         : " + call.news_body);
                Console.WriteLine("News Image        : " + call.news_image);
                Console.WriteLine("Viewer            : " + call.viewer);
                Console.WriteLine("Salary            : " + call.salary);
                Console.WriteLine("Det Tag ID        : " + call.det_tagid);
                Console.WriteLine("News User ID      : " + call.news_userid);
                Console.WriteLine("Det Category ID   : " + call.det_catid);
                Console.WriteLine("----------------------------------------------");

            }
            Console.ReadKey(true);
            return getall;
        }

        public int update(int input)
        {
            Program panggilvoid = new Program();
            Console.Write("Inputkan News Date        : "); DateTime newsdate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Inputkan News Title       : "); string newstitle = Console.ReadLine();
            Console.Write("Inputkan News Lead        : "); string newslead = Console.ReadLine();
            Console.Write("Inputkan News Body        : "); string newsbody = Console.ReadLine();
            Console.Write("Inputkan News Image       : "); string newsimage = Console.ReadLine();
            Console.Write("Inputkan Viewer           : "); string viewer = Console.ReadLine();
            Console.Write("Inputkan Salary           : "); int salari = Convert.ToInt32(Console.ReadLine());
            Console.Write("Inputkan Det Tag ID       : "); int dettagid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Inputkan News User ID     : "); int newsuserid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Inputkan Det Category ID  : "); int detcatid = Convert.ToInt32(Console.ReadLine());

            news_report call = GetById(input);
            call.news_date = newsdate;
            call.news_title = newstitle;
            call.news_lead = newslead;
            call.news_body = newsbody;
            call.news_image = newsimage;
            call.viewer = viewer;
            call.salary = salari;
            call.det_tagid = dettagid;
            call.news_userid = newsuserid;
            call.det_catid = detcatid;

            _context.Entry(call).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return input;
        }

        public news_report GetById(int input)
        {
            news_report call = _context.news_report.Find(input);
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
                var x = (from y in ctx.news_report where y.id == input select y).FirstOrDefault();
                ctx.news_report.Remove(x);
                ctx.SaveChanges();
            }
            return input;
        }
    }
}
