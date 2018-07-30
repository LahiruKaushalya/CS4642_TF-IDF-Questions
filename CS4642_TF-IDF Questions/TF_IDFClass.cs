using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS4642_TF_IDF_Questions
{
    public class TF_IDFClass
    {
        public SortedDictionary<string, double> CalculateTF(SortedDictionary<string, int> vocabulary, int vocabularySize)
        {
            var TFDictionary = new SortedDictionary<string, double>();

            foreach (KeyValuePair<string, int> kvp in vocabulary)
            {
                Double val = kvp.Value / (double)vocabularySize;
                TFDictionary[kvp.Key] = Math.Round(val,5);
            }
            return TFDictionary;
        }

        public SortedDictionary<string, double> CalculateIDF(SortedDictionary<string, int> doc ,
                                                             List<SortedDictionary<string, int>> documents)
        {
            var IDFDictionary = new SortedDictionary<string, double>();
            foreach (KeyValuePair<string, int> kvp in doc)
            {
                double noOfDocsContainWord = 0;
                foreach (SortedDictionary<string, int> document in documents)
                {
                    if (document.ContainsKey(kvp.Key))
                    {
                        noOfDocsContainWord = noOfDocsContainWord + 1;
                    }
                }
                var IDFvalue = Math.Log10( documents.Count / noOfDocsContainWord);
                IDFDictionary[kvp.Key] = Math.Round(IDFvalue, 5);
            }
            return IDFDictionary;
        }

        public IOrderedEnumerable<KeyValuePair<string, double>> CalculateTF_IDF(SortedDictionary<string, double> TFvocabulaty,
                                                                                SortedDictionary<string, double> IDFvocabulaty)
        {
            var TF_IDFDictionary = new Dictionary<string, double>();
            foreach (KeyValuePair<string, double> kvp in TFvocabulaty)
            {
                var TF_IDFValue = kvp.Value * IDFvocabulaty[kvp.Key];
                TF_IDFDictionary[kvp.Key] = Math.Round(TF_IDFValue, 5);
            }
            return TF_IDFDictionary.OrderByDescending(kvp => kvp.Value);
        }
    }
}
