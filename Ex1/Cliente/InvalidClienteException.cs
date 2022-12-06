using Newtonsoft.Json;
using System;

namespace Ex1.ClienteNamespace
{
    public partial class Cliente
    {
        /* 
        * Exceções da forma
        *  Erro => Campo: $campo   Valor: $valor   Mensagem: $mensagem
        */
        public class InvalidClienteException : Exception
        {
            public string Campo { get; set; }
            public object Val { get; set; }
            public string Mensagem { get; set; }


            public InvalidClienteException(string fieldName, object val, string message)
                : base(MakeMessage(fieldName, val, message))
            {
                Campo = fieldName;
                Val = val;
                Mensagem = message;
            
            }

            internal static string MakeMessage(string fieldName, object val, string message)
            {
                return $"Campo: {fieldName} Valor: {(val.ToString().Length == 0 ? "N/A" : val),5} Mensagem: {message}";
            }
        }
    }
}