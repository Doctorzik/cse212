using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE
        var pairList = new List<string>();
        var wordSets = new HashSet<string>(words);
        foreach (var i in wordSets)
        {   //FOr each word in the list of words
            // convert the characters of the word into an array
            char[] charArray = i.ToCharArray();
            // reverse the array
            Array.Reverse(charArray);
            //convert the array to a string once more.
            var revisedWord = new string(charArray);
            // Check to see if the word is in the wordSets
            if (!wordSets.Contains(revisedWord))
            { }
            else
            {
                // Only checked if  reversed word is not equal to the word been checked
                if (revisedWord != i)
                {  // the word and its reersed has been seen, concate them and add them to
                   // thelist of words that have pairs
                    string c = $"{revisedWord} & {i}";
                    // revome both the revised word and the original word fromthe set
                    wordSets.Remove(revisedWord);
                    wordSets.Remove(i);
                    // Add the concatinated word to the found pair
                    pairList.Add(c);
                }

            }
        }
        // return the foundpair lit after it hasthe converted toan array.
        return pairList.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE
            var degree = fields[3];
            var number = int.Parse(fields[4]);
            if (!degrees.ContainsKey(degree))
                degrees[degree] = number / number;
            else
                degrees[degree] += number / number;


        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        var low1 = word1.ToLower().Replace(" ", "");
        var low2 = word2.ToLower().Replace(" ", ""); ;








        //convert the array to a string once more.
        //   var revisedWord = new string(charArray);
        var anagramWord1 = new Dictionary<char, int>();
        var anagramWord2 = new Dictionary<char, int>();

        // TODO Problem 3 - ADD YOUR CODE HERE
        if (low1.Length != low2.Length)
        {
            return false;

        }
        else
        {
            for (int i = 0; i < low1.Length; ++i)
            {
                if (!anagramWord1.ContainsKey(low1[i]))
                    anagramWord1[low1[i]] = 0;
                if (anagramWord1.ContainsKey(low1[i]))
                {
                    anagramWord1[low1[i]] += 1;
                }

            }
            for (int i = 0; i < low2.Length; ++i)
            {
                if (!anagramWord2.ContainsKey(low2[i]))
                    anagramWord2[low2[i]] = 0;
                if (anagramWord1.ContainsKey(low2[i]))
                {
                    anagramWord2[low2[i]] += 1;
                }

            }
        }


        var storedWord1 = anagramWord1.OrderBy(x => x.Key).ToArray();
        var storedWord2 = anagramWord2.OrderBy(x => x.Key).ToArray();

        bool same = storedWord1.SequenceEqual(storedWord2);
        if (same)
        {
            return true;
        }
        else

            return false;







    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()

    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);
        var summaryList = new List<string>();
        var s = featureCollection.Features.GetRange(0, 8);


        foreach (var f in s)
        {


            var place = f.Properties.Place;
            var mag = f.Properties.Mag;
            summaryList.Add($"Place - {place} - Mag {mag}");

        }

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 



        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return summaryList.ToArray();
    }
}