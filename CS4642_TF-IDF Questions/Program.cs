using CS4642_TF_IDF_Questions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

            //Calculate TF
            TF_IDFClass tF_IDFClass = new TF_IDFClass();

            var TF_Dic1 = tF_IDFClass.CalculateTF(vocabulary1, VocabularySize(vocabulary1));
            var TF_Dic2 = tF_IDFClass.CalculateTF(vocabulary2, VocabularySize(vocabulary2));
            var TF_Dic3 = tF_IDFClass.CalculateTF(vocabulary3, VocabularySize(vocabulary3));

            //Calculate IDF
            var vocabularyList = new List<SortedDictionary<string, int>>
            {
                vocabulary1,
                vocabulary2,
                vocabulary3
            };

            var IDF_Dic1 = tF_IDFClass.CalculateIDF(vocabulary1, vocabularyList);
            var IDF_Dic2 = tF_IDFClass.CalculateIDF(vocabulary2, vocabularyList);
            var IDF_Dic3 = tF_IDFClass.CalculateIDF(vocabulary3, vocabularyList);

            //Calculate TF-IDF
            var TF_IDF_Dic1 = tF_IDFClass.CalculateTF_IDF(TF_Dic1, IDF_Dic1);
            var TF_IDF_Dic2 = tF_IDFClass.CalculateTF_IDF(TF_Dic2, IDF_Dic2);
            var TF_IDF_Dic3 = tF_IDFClass.CalculateTF_IDF(TF_Dic3, IDF_Dic3);

            //Print Output
            var index = 32;
            Console.WriteLine("index");
            Console.WriteLine("1");
            Console.WriteLine("document1:{0}", VocabularySize(vocabulary1));
            Console.WriteLine("document2:{0}", VocabularySize(vocabulary2));
            Console.WriteLine("document3:{0}\n", VocabularySize(vocabulary3));

            Console.WriteLine("2");
            Console.WriteLine("document1:{0},{1}", TF_Dic1.ElementAt(index).Key, TF_Dic1.ElementAt(index).Value);
            Console.WriteLine("document2:{0},{1}", TF_Dic2.ElementAt(index).Key, TF_Dic2.ElementAt(index).Value);
            Console.WriteLine("document3:{0},{1}\n", TF_Dic3.ElementAt(index).Key, TF_Dic3.ElementAt(index).Value);

            Console.WriteLine("3");
            Console.WriteLine("document1:{0},{1}", IDF_Dic1.ElementAt(index).Key, IDF_Dic1.ElementAt(index).Value);
            Console.WriteLine("document2:{0},{1}", IDF_Dic2.ElementAt(index).Key, IDF_Dic2.ElementAt(index).Value);
            Console.WriteLine("document3:{0},{1}\n", IDF_Dic3.ElementAt(index).Key, IDF_Dic3.ElementAt(index).Value);

            Console.WriteLine("4");
            Console.WriteLine("document1:{0}", GetFirstNElements(TF_IDF_Dic1, 10));
            Console.WriteLine("document2:{0}", GetFirstNElements(TF_IDF_Dic2, 10));
            Console.WriteLine("document3:{0}\n", GetFirstNElements(TF_IDF_Dic3, 10));

            Console.ReadKey();
        }

        private static void PrintVocabulary(SortedDictionary<string,double> vocabulary)
        {
            foreach (KeyValuePair<string, double> kvp in vocabulary)
            {
                Console.WriteLine("{0} : {1}", kvp.Key, kvp.Value);
            }
        }

        private static void PrintTF_IDF(IOrderedEnumerable<KeyValuePair<string, double>> vocabulary)
        {
            foreach (KeyValuePair<string, double> kvp in vocabulary)
            {
                Console.WriteLine("{0} : {1}", kvp.Key, kvp.Value);
            }
        }

        private static int VocabularySize(SortedDictionary<string, int> vocabulary)
        {
            var count = 0;
            foreach (KeyValuePair<string, int> kvp in vocabulary)
            {
                count = count + vocabulary[kvp.Key];
            }
            return count;
        }

        private static string GetFirstNElements(IOrderedEnumerable<KeyValuePair<string, double>> vocabulary, int n)
        {
            string str = string.Empty;
            var count = 0;
            foreach (KeyValuePair<string, double> kvp in vocabulary)
            {
                if (count == 9){ str = str + kvp.Key; break; }
                count++;
                str = str + kvp.Key + ",";
            }
            return str;
        }

    }
}
