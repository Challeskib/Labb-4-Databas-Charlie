using Labb_4_Databas_Charlie.Models;

namespace Labb_4_Databas_Charlie
{
    internal class Program
    {
        static void Main(string[] args)
        {

            NewSchoolDbContext context = new NewSchoolDbContext();

            var allClasses = context.Classes
                .Where(p => p.ClassId > 0)
                .OrderBy(p => p.ClassId);



            //Skriver ut all existerande klasser på skolan
            Console.WriteLine("Existing Classes:");
            foreach (Class item in allClasses)
            {
                Console.WriteLine(item.ClassName);
            }
        }
    }
    
}