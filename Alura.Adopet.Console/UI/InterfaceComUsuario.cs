﻿using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.UI
{
    internal static class InterfaceComUsuario
    {
        static public void ExibeInformacao(string mensagem)
        {
            System.Console.WriteLine(mensagem);
        }

        private static void ExibeLista<T>(List<T>? lista)
        {
            if (lista is null) return;
            foreach (var item in lista) 
            {
                System.Console.WriteLine(item);
            }
        }

        private static void ExibeInformacao(Ok? resultado)
        {
            if (resultado is null) return;
            if (resultado.Informacao is null) return;

            System.Console.ForegroundColor = ConsoleColor.Green;

            if (resultado.Informacao is List<Pet>)
            {
                ExibeLista(resultado.Informacao as List<Pet>);
                return;
            }

            if (resultado.Informacao is List<string>)
            {
                ExibeLista(resultado.Informacao as List<string>);
                return;
            }

            System.Console.WriteLine(resultado.Informacao.ToString());
        }

        private static void ExibeErro(Erro? resultado)
        {
            if (resultado is null) return;
            
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine(resultado.MensagemErro);            
        }

        public static void ExibeResultado(IResultado resultado)
        {
            try
            {
                if (resultado.Sucesso) ExibeInformacao(resultado as Ok);
                else ExibeErro(resultado as Erro);
            }
            finally
            {
                System.Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
