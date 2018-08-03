using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace CS4642_TF_IDF_Questions
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
                var _word = word.ToLower();
                if (WordsDic.ContainsKey(_word))
                {
                    if (dic.ContainsKey(_word))
                    {
                        var count = dic[_word];
                        dic[_word] = count + 1;
                    }
                    else
                    {
                        dic[_word] = 1;
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
