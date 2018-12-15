using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


//DEF: tento princip nám říká jaké že každá třída by měla mít pouze jednu zodpovědnost, to znamená že musíme náš kód dělit do mnoha malých částí
namespace TestovaciAlgoritmy.NavrhoveVzory.SOLID_Principles
{
    //---Příklad špatně!!!!!!!----------------------------------------------------------------------------------------------------------    
    //Tato třída je špatně protože řeší hned několik věcí navíc kromě toho že ukládá data do databáze
    //1)Ošetřuje vyjímku
    //2)Řeší logování do souboru
    //3)using řeší spojení s databází    
    class SingleResponsibilityPrincipleSpatne
    {
        public void SaveData(Customer customer)
        {
            using (var mdbc = new MyDbContext())
            {
                try
                {
                    mdbc.Customers.Add(customer);
                    mdbc.SaveChanges();

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText($"logs\\{DateTime.Now:yyyy-mm-dd}.log", DateTime.Now + " : " + e + "\r\n");
                }
            }
        }
    }
    //-----Příklad správně---------------------------------------------------------------------------------------------------------------------
   
    //jenom pomocné třídy
    public class MyDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }    
               
    }
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Prijmetni { get; set; }
    }





}
