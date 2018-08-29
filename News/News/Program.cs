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
            

            Console.WriteLine("======================================================");
            Console.WriteLine("|                 Menu News Portal                   |");
            Console.WriteLine("======================================================");
            Console.WriteLine("| 1. News User                                       |");
            Console.WriteLine("| 2. News Report                                     |");
            Console.WriteLine("| 3. Category                                        |");
            Console.WriteLine("| 4. Detail Category                                 |");
            Console.WriteLine("| 5. Tag                                             |");
            Console.WriteLine("| 6. Detail Tag                                      |");
            Console.WriteLine("======================================================");
            Console.WriteLine("\n");
            Console.Write("Silahkan Pilih : "); int pil = Convert.ToInt32(Console.ReadLine());
            

            switch (pil)
            {
                case 1:
                    Controllers.News_User_Controller panggil = new Controllers.News_User_Controller();
                    panggil.menu_newsuser();
                    break;
                case 2:
                    Controllers.News_Report_Controller re = new Controllers.News_Report_Controller();
                    re.menu_newreport();
                    break;
                case 3:
                    Controllers.Category_Controller cat = new Controllers.Category_Controller();
                    cat.menu_category();
                    break;
                case 4:
                    Controllers.Det_Category_Controller detc = new Controllers.Det_Category_Controller();
                    detc.menu_det_cat();
                    break;
                case 5:
                    Controllers.Tag_Controller tag = new Controllers.Tag_Controller();
                    tag.menu_tag();
                    break;
                case 6:
                    Controllers.Det_Tag_Controllers det = new Controllers.Det_Tag_Controllers();
                    det.menu_det_tag();
                    break;
                default:
                    break;
            }
        }        
    }
}
