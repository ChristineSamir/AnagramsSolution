namespace AnagramsSolution;

public class Anagram
{
    private readonly Dictionary<string, List<string>> _anagramDictionary = new();
    private readonly Dictionary<char, int> _alphabeticFrequency = new()
    {
        { 'a', 0 },
        { 'b', 0 },
        { 'c', 0 },
        { 'd', 0 },
        { 'e', 0 },
        { 'f', 0 },
        { 'g', 0 },
        { 'h', 0 },
        { 'i', 0 },
        { 'j', 0 },
        { 'k', 0 },
        { 'l', 0 },
        { 'm', 0 },
        { 'n', 0 },
        { 'o', 0 },
        { 'p', 0 },
        { 'q', 0 },
        { 'r', 0 },
        { 's', 0 },
        { 't', 0 },
        { 'u', 0 },
        { 'v', 0 },
        { 'w', 0 },
        { 'x', 0 },
        { 'y', 0 },
        { 'z', 0 }
    };

    public Anagram(List<string> dictionary)
    {
        var startTime = DateTime.Now;

        for (int i = 0; i < dictionary.Count; i++)
        {
            var word = dictionary[i].ToLower().Trim();

            for (int j = i + 1; j < dictionary.Count; j++)
            {
                CalculateFrequency(word, 1);

                var match = dictionary[j].ToLower().Trim();
                CalculateFrequency(match, -1);

                if (CheckAnagram())
                {
                    AddAnagramWords(word, match);
                }

                // Clear previous frequency
                ResetAlphabeticFrequency();
            }
        }

        var endTime = DateTime.Now;

        var processingTime = endTime - startTime;
        Console.WriteLine($"Performance testing: Processing time is {processingTime}");
    }

    public List<string> GetAnagram(string search)
    {
        // return 
        var startTime = DateTime.Now;

        var anagramValues = _anagramDictionary.TryGetValue(search.ToLower().Trim(), out var anagrams) ? anagrams : new List<string>();

        var endTime = DateTime.Now;
        var retrieveTime = endTime - startTime;
        Console.WriteLine($"Performance testing: Time for getting anagram list is {retrieveTime}");

        return anagramValues;
    }


    private void CalculateFrequency(string word, int frequency)
    {
        foreach (var letter in word)
        {
            _alphabeticFrequency[letter] += frequency;
        }
    }

    private void ResetAlphabeticFrequency()
    {
        foreach (var key in _alphabeticFrequency.Keys)
        {
            _alphabeticFrequency[key] = 0;
        }
    }

    private bool CheckAnagram()
    {
        foreach (var key in _alphabeticFrequency.Keys)
        {
            if (_alphabeticFrequency[key] != 0)
                return false;
        }

        return true;
    }

    private void AddAnagramWords(string word, string match)
    {
        if (!_anagramDictionary.ContainsKey(word) && !_anagramDictionary.ContainsKey(match))
        {
            _anagramDictionary[word] = new List<string> { word, match };
            _anagramDictionary[match] = new List<string> { word, match };
        }
        else if (!_anagramDictionary.ContainsKey(word) && _anagramDictionary.ContainsKey(match))
        {
            _anagramDictionary.TryGetValue(match, out var matches);
            matches!.Add(word);
            _anagramDictionary[match] = matches;
            _anagramDictionary[word] = _anagramDictionary[match];
        }
        else if (_anagramDictionary.ContainsKey(word) && !_anagramDictionary.ContainsKey(match))
        {
            _anagramDictionary.TryGetValue(word, out var words);
             words!.Add(match);
            _anagramDictionary[word] = words;
            _anagramDictionary[match] = _anagramDictionary[word];
        }
        else
        {
            _anagramDictionary.TryGetValue(word, out var words);
            _anagramDictionary.TryGetValue(match, out var matches);

            if (matches!.Count > words!.Count)
            {
                _anagramDictionary[word] = matches;
            }
            else if (words.Count > matches.Count)
            {
                _anagramDictionary[match] = words;
            }
        }
    }

}