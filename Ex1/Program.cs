using System;

/*
 * Classe Program e classe Piramide estão no mesmo namespace (Ex1),
 * então o modificador "internal" é sufuciente para que elas se "vejam"
 */
namespace Ex1
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            try
            {
                int intTemp = Convert.ToInt32(args[0]);
                Piramide p = new Piramide(intTemp);
                p.Desenha();
            }catch(Piramide.NonPositiveIntegerException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Argumento de linha de comando deve ser um inteiro de até 32 bits.\n{0}", e.Message);
            }
        }
    }
}
