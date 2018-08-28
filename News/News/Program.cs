using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News
{
    class Program
    {
        BaseContext _context = new BaseContext();
        static void Main(string[] args)
        {
            BaseContext _context = new BaseContext();
            Program call = new Program();
            int id;

            Console.WriteLine("======================================================");
            Console.WriteLine("|                 Menu Page                          |");
            Console.WriteLine("======================================================");
            Console.WriteLine("| 1. Get All                                         |");
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
                    break;
                case 2:
                    break;
                case 3:
                    Controllers.News_User_Controller panggil = new Controllers.News_User_Controller();
                    panggil.insert();
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    break;
            }
        }        
    }
}
