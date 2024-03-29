﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console
{
    internal class Help
    {
        public void ExibeDocumentacao()
        {
            System.Console.WriteLine("Lista de comandos.");

            System.Console.WriteLine($"adopet help <parametro> ous simplemente adopet help  " +
                    "comando que exibe informações de ajuda dos comandos.");
            System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
            System.Console.WriteLine("Comando possíveis: ");
            System.Console.WriteLine($" adopet import <arquivo> comando que realiza a importação do arquivo de pets.");
            System.Console.WriteLine($" adopet show  <arquivo> comando que exibe no terminal o conteúdo do arquivo importado." + "\n\n\n\n");
            System.Console.WriteLine($"Execute 'adopet.exe help [comando]' para obter mais informações sobre um comando." + "\n\n\n");
            
        }

        public void HelpDoComando(string docComando)
        {
            if (docComando.Equals("import"))
            {
                System.Console.WriteLine($" adopet import <arquivo> " +
                    "comando que realiza a importação do arquivo de pets.");
            }
            if (docComando.Equals("show"))
            {
                System.Console.WriteLine($" adopet show <arquivo>  comando que " +
                    "exibe no terminal o conteúdo do arquivo importado.");
            }
        }

    }
}
