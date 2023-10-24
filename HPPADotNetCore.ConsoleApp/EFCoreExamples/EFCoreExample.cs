using HPPADotNetCore.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace HPPADotNetCore.ConsoleApp.EFCoreExamples
{
    public class EFCoreExample
    {
        public void Run()
        {
            //Read();
            //Create("U Ba", "Mg Mg", "Aye Aye");
            Edit(2);
            //Update(7, "U Mg", "Banyar", "Yoon");
            //Update(8, "U Hla", null, null);
            //Delete(9);
        }

        private void Read() 
        {
            AppDbContext db = new AppDbContext();
            var lst = db.families.ToList();

            foreach (FamilyDataModel item in lst) 
            {
                Console.WriteLine(item.FamilyId);
                Console.WriteLine(item.ParentName);
                Console.WriteLine(item.SonName);
                Console.WriteLine(item.DaughterName);
                Console.WriteLine("_________________________");

            }
        }

        private void Create(string parent, string son, string daughter)
        {
            FamilyDataModel family = new FamilyDataModel
            {
                ParentName = parent,
                SonName = son,
                DaughterName = daughter
            };
            AppDbContext db = new AppDbContext();
            //db.Add(blog);
            db.families.Add(family);
            var result = db.SaveChanges();

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);
        }
        private void Edit(int id)
        {
            AppDbContext db = new AppDbContext();
            var item = db.families.FirstOrDefault(x => x.FamilyId == id);
            if (item == null)
            {
                Console.WriteLine("No data found. ");
            }

            Console.WriteLine(item.FamilyId);
            Console.WriteLine(item.ParentName);
            Console.WriteLine(item.SonName);
            Console.WriteLine(item.DaughterName);
            Console.WriteLine("_________________________");
        }

        private void Update(int id, string parent, string son, string daughter)
        {
            AppDbContext db = new AppDbContext();
            var item = db.families.FirstOrDefault(x => x.FamilyId == id);
            if (item == null)
            {
                Console.WriteLine("No data found. ");
            }

            if(!string.IsNullOrWhiteSpace(parent))
            {
                item.ParentName = parent;
            }
            if (!string.IsNullOrWhiteSpace(son))
            {
                item.SonName = son;
            }
            if (!string.IsNullOrWhiteSpace(daughter))
            {
                item.DaughterName = daughter;
            }
            var result = db.SaveChanges(); 
            
            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            Console.WriteLine(message);

        }

        private void Delete(int id)
        {
            AppDbContext db = new AppDbContext();
            var item = db.families.FirstOrDefault(x => x.FamilyId == id);
            if (item == null)
            {
                Console.WriteLine("No data found. ");
            }

            db.families.Remove(item);
            var result = db.SaveChanges();

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            Console.WriteLine(message);

        }

    }
}
