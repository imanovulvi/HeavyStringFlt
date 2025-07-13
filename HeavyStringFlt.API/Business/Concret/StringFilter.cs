using HeavyStringFlt.API.Business.Abstraction;

namespace HeavyStringFlt.API.Business.Concret
{
    public class StringFilter : IStringFilter
    {


        private readonly List<string> _filterWords;
        private readonly double _similarityThreshold; // 0.8 = 80%

        public StringFilter(List<string> filterWords, double similarityThreshold = 0.8)
        {
            _filterWords = filterWords;
            _similarityThreshold = similarityThreshold;
        }

        public string Filter(string input)
        {
            var words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            var result = new List<string>();

            foreach (var word in words)
            {
                bool isSimilar = _filterWords.Any(filterWord =>
                    CalculateJaroWinklerSimilarity(word, filterWord) >= _similarityThreshold
                );

                if (!isSimilar)
                {
                    result.Add(word);
                }
            }

            return string.Join(' ', result);
        }


        private double CalculateJaroWinklerSimilarity(string s1, string s2)
        {
            return JaroWinkler.GetSimilarity(s1, s2);
        }
    }
}