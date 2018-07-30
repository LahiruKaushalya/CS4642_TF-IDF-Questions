using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TF_IDF
{
    public class Vocabulary
    {
        private static Dictionary<string, string> WordsDic;

        public SortedDictionary<string, int> CreateVocabulary(string fileString)
        {
            //Get words dictionary json file 
            var text = File.ReadAllText("../../Files/words_dictionary.json");
            WordsDic = JsonConvert.DeserializeObject<Dictionary<string, string>>(text);

            var temp = FilterLetters(fileString);
            var vocabulary = GetVocabulary(temp);

            return vocabulary;
        }

        private static SortedDictionary<string, int> GetVocabulary(string[] words)
        {
            var dic = new SortedDictionary<string, int>();

            foreach (string word in words)
            {
                if (WordsDic.ContainsKey(word))
                {
                    if (dic.ContainsKey(word))
                    {
                        var count = dic[word];
                        dic[word] = count + 1;
                    }
                    else
                    {
                        dic[word] = 1;
                    }
                }
            }
            return dic;
        }

        private static string[] FilterLetters(string fileString)
        {
            ;
            foreach (char _char in fileString)
            {
                if (!Char.IsLetter(_char) && _char != ' ')
                {
                    fileString = fileString.Replace(_char, ' ');
                }
            }
            return fileString.Split(' ');
        }

    }
}
