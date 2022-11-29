using System;
using System.Text;
using System.Text.Json;

namespace Ex1.Cliente
{
    /* 
    * Exceções da forma
    *  Erro => Campo: $campo   Valor: $valor   Mensagem: $mensagem
    */
    public class InvalidClienteException : Exception
    {
        public InvalidClienteException(string fieldName, object val, string message)
            : base(MakeMessage(fieldName, val, message))
        { }

        internal static string MakeMessage(string fieldName, object val, string message)
        {
            return $"Campo: {fieldName} Valor: {(val.ToString().Length == 0 ? "N/A" : val),5} Mensagem: {message}";
        }
    }
}
