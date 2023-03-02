﻿namespace Alura.Adopet.Console
{
    internal class Show
    {
        public void ExibeArquivo(string caminhoArquivo)
        {

            LeitorDeArquivos leitor = new();
            List<Pet> listaDePet = leitor.RealizaLeituraArquivo(caminhoArquivo);
            foreach (Pet pet in listaDePet)
            {
                System.Console.WriteLine(pet);
            }
            System.Console.ReadKey();
        }
    }
}
