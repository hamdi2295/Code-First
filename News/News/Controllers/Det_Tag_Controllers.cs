using System;
using News.Models;
using News.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Controllers
{
    class Det_Tag_Controllers
    {
        /* Function untuk proses input pilihan CRUD
       1. Varible input digunakan untuk menyimpan nomor pilihan
           */

        BaseContext _context = new BaseContext();
        int input;
        public void menu_det_tag()
        {
            
            Controllers.Det_Tag_Controllers panggil = new Controllers.Det_Tag_Controllers();
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


            /*
            Kondisi apabila pilihan 1 maka akan memanggil function viewAll() dan seterunya
    */

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
            
           Console.Write("Inputkan ID                   : "); int id = Convert.ToInt32(Console.ReadLine());            
           Console.Write("Inputkan Detail Tag Name      : "); string dettagname = Console.ReadLine();
           Console.Write("Inputkan Tag ID               : "); int t_id = Convert.ToInt32(Console.ReadLine());
           det_tag called = new det_tag()
            {
                id = id,
                det_tag_name = dettagname,
                tagid = t_id
        
            };
            try
            {
                _context.det_tag.Add(called);
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
        public List<det_tag> ViewAll()
        {
            var getall = _context.det_tag.ToList();
            foreach (det_tag call in getall)
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Id                  : " + call.id);
                Console.WriteLine("Detail Tag Name     : " + call.det_tag_name);
                Console.WriteLine("Tag ID              : " + call.tagid);
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
            Console.Write("Inputkan Detail Tag Name      : "); string dettagname = Console.ReadLine();
            Console.Write("Inputkan Tag Id               : "); int taggid =Convert.ToInt32(Console.ReadLine());

            det_tag call = GetById(input);
            call.det_tag_name = dettagname;
            call.tagid = taggid;

            _context.Entry(call).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return input;
        }
        /*
        1. Function GetById digunakan untuk cek id table yang diinputkan. apabila id sesuai dengan databse makan akan di simpan
        kedalam objek call.
        2. nilai parameter input yang telak dimasukkan kedalam objek call akan dikembalikan nilainya (return value)
    */
        public det_tag GetById(int input)
        {
            det_tag call = _context.det_tag.Find(input);
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
                var x = (from y in ctx.det_tag where y.id == input select y).FirstOrDefault();
                ctx.det_tag.Remove(x);
                ctx.SaveChanges();
            }
            return input;
        }

    }
}
