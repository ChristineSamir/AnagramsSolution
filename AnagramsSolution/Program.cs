using AnagramsSolution;

var dictionary = new List<string> { "Listen", "HEART", "Ear", "Silent", "Face", "Earth", "slime", "limes", " Farm ", "miles", "Are ", "Cafe", "Smile", "Break", "Music", "  baker", " Brake ", "dinosaur", "Door", "HATER", "Angel", "Below", "Bowel", "angle", "angels", "elbow" };

var anagram = new Anagram(dictionary);

while (true)
{
    Console.WriteLine("Please Enter a word.");
    var input = Console.ReadLine();

    List<string> anagramList = anagram.GetAnagram(input ?? string.Empty);

    if (anagramList.Count == 0)
    {
        Console.WriteLine($"Word {input} doesn't have an anagram match.");
    }
    else
    {
        Console.WriteLine($"Anagram list are: {string.Join(", ", anagramList)}");
    }
}
