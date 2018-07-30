using System;
using System.Collections.Generic;
using System.IO;

namespace TF_IDF
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Read Input files
            var file1 = File.ReadAllText("../../Files/document1.txt");
            var file2 = File.ReadAllText("../../Files/document2.txt");
            var file3 = File.ReadAllText("../../Files/document3.txt");

            //Create Vocabularies
            Vocabulary vocabulary = new Vocabulary();

            var vocabulary1 = vocabulary.CreateVocabulary(file1);
            var vocabulary2 = vocabulary.CreateVocabulary(file2);
            var vocabulary3 = vocabulary.CreateVocabulary(file3);

            PrintVocabulary(vocabulary3);

            Console.ReadKey();
        }

        private static void PrintVocabulary(SortedDictionary<string,int> vocabulary)
        {
            foreach (KeyValuePair<string, int> kvp in vocabulary)
            {
                Console.WriteLine("{0} : {1}", kvp.Key, kvp.Value);
            }
        }

    }
}
