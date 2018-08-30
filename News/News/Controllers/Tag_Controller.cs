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
        /* Function untuk proses input pilihan CRUD
        1. Varible input digunakan untuk menyimpan nomor pilihan
            */
        int input;
        public void menu_tag()
        {
            
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

            /*
            Kondisi apabila pilihan 1 maka akan memanggil function viewAll() dan seterunya
    */

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
                    Console.Write("Masukkan Id yang akan di Delete : "); input = Convert.ToInt32(Console.ReadLine());
                    Delete(input);

                    break;
                default:
                    break;
            }
        }


        /*
        1. Function Insert digunakan untuk menambahkan data category.
        2. try dan catch digunakan untuk mengatasi error runtime yang bukan karena kesalahan penulisan code.
        3. function void, sehingga tidak return value.
    */
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

        /*
        1. Function ViewAll dipakai untuk menampilkan data dari database, karena menggunakan entity framework, programmer tidak perlu melakukan query.
        2. Data dari database akan dilooping dengan foreach selanjutnya disimpan pada variable getall,
        3. Karena non void, maka variable getall akan di return nilainya.
    */
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

        /*
        1. Function update merupakan entity framework yang berfungsi untuk melakukan update data tanpa melakukan proses query
        2. int input merupakan parameter yang digunakan untuk merubah data sesuai dengan nilai yang dimiliki oleh parameter.
        3. karena non void, maka parameter inpu akan di return nilainya.
    */
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

        /*
        1. Function GetById digunakan untuk cek id table yang diinputkan. apabila id sesuai dengan databse makan akan di simpan
        kedalam objek call.
        2. nilai parameter input yang telak dimasukkan kedalam objek call akan dikembalikan nilainya (return value)
    */
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

        /*
        1. Function delete merupkan entity framework yang digunakan untuk menghapus data table tanpa melakukan query
        2. int input merupakan parameter yang berupa data id table.
        3. parameter input akan dikembalikan nilainya karena merupakan void function
    */
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
