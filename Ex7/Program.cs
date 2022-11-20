using System;
using System.Threading.Tasks;

namespace Ex7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Propriedades p = new (args[0]);

            p.AddKey("Vasco", "Da Gama");

            p.GetValue("Vasco", out string _val);

            Console.WriteLine(_val);

            p.UpdateValue("Vasco", "Gigante");

            Console.WriteLine(p.Contains("Vasco"));

            try
            {
                p.AddKey("Vasco", "Exceção");
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                p.UpdateValue("Chave Não Existe", "Exceção");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            p.WriteToFile(args[1]).Wait();
        }
    }
}
