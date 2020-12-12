using UnityEngine;
using System.Collections.Generic;
using System.Linq;


public static class MyClass
{
    public static int MyCharCount(this string source, char charToFind)
    {
        int count = 0;
        int lastFindedPos = source.IndexOf(charToFind);
        while (lastFindedPos >= 0)
        {
            count++;
            lastFindedPos = source.IndexOf(charToFind, lastFindedPos + 1);
        }
        return count;
    }

    public static Dictionary<T, int> CouctItemInCollection<T>(this ICollection<T> collection)
    {
        var t = collection.GroupBy(p => p).ToDictionary(g => g.Key, g => g.Count());
        return t;
    }


}


public class Lesson5HWMB : MonoBehaviour
{

    private void Start()
    {
        Debug.Log("ЗАДАНИЕ 2");
        string s = "мама мыла раму";
        char c = 'м';
        Debug.Log($"Ищем '{c}' в \"{s}\":");
        Debug.Log(s.MyCharCount(c));


        Debug.Log("============================");
        Debug.Log("ЗАДАНИЕ 3");
        List<int> a = new List<int>();
        a.Add(1);
        a.Add(1);
        a.Add(2);
        a.Add(3);
        a.Add(1);
        a.Add(2);
        a.Add(3);
        var dictionary = a.CouctItemInCollection();
        foreach (int t in dictionary.Keys)
        {
            Debug.Log($"Item: {t} / Count: {dictionary[t]}");
        }


        Debug.Log("============================");
        Debug.Log("ЗАДАНИЕ 4");
        Dictionary<string, int> dict = new Dictionary<string, int>()
        {
            {"four",4 },
            {"two",2 },
            { "one",1 },
            {"three",3 },
        };
        //var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
        var d = dict.OrderBy(i => i.Value);
        foreach (var pair in d)
        {
            Debug.Log($"{pair.Key} - {pair.Value}");
        }

    }
}
