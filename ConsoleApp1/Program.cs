using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using FluentAssertions;
using NUnit.Framework;


namespace ConsoleApp1
{
    public static class AnyClass
    {
        public static int[] ParseNumbers(IEnumerable<string> lines)
        {
            return lines
                .Where(x => x != "")
                .Select(y => int.Parse(y))
                .ToArray();
        }
    }

    public class StudyClass
    {
        public string[] GetSortedWords(params string[] textLines)
        {
            return textLines.SelectMany(x => Regex.Split(x, @"\W+"))
                .Select(x => x.ToLower())
                .Distinct()
                .OrderBy(y => y)
                .ToArray();
        }

        public List<string> GetUnicString(List<string> strings)
        {
            return strings.Where(s => s.GroupBy(ch => ch).All(x => x.Count() <= 2)).ToList();
        }

        public string GetLongestString(IEnumerable<string> words)
        {
            var result = words.Where(x => x.Length == (words.Max(n => n.Length))).Min();
            return result;
        }

        public List<string> GetSortedWords2(string text)
        {
            return Regex.Split(text, @"\W+")
                .Where(x => x != "")
                .Select(x => x.ToLower())
                .Distinct()
                .Select(x => Tuple.Create(x, x.Length))
                .OrderBy(x => x.Item1)
                .OrderBy(x => x.Item2)
                .Select(x => x.Item1)
                .ToList();
        }
    }


  
    
        [TestFixture]
        public class SomeTests
        {
            private StudyClass studyClass = new StudyClass();

            [Test]
            public void GetLongestString()
            {
                var example = new[] {"azaz", "as", "sdsd"};
                var result = studyClass.GetLongestString(example);
                result.Should().BeEquivalentTo("azaz");
            }

            [Test]
            public void getSortedWords2()
            {
                var sortedWords =
                    studyClass.GetSortedWords2("A box of biscuits, a box of mixed biscuits, and a biscuit mixer.");
                sortedWords[0].Should().Be("a");
                sortedWords.Should().NotContain("A");
                sortedWords.Should().NotContain("");
            }

            [Test]
            public void getSortedWords()
            {
                var vocabulary = studyClass.GetSortedWords(
                    "Hello, hello, hello, how low",
                    "",
                    "With the lights out, it's less dangerous",
                    "Here we are now; entertain us",
                    "I feel stupid and contagious",
                    "Here we are now; entertain us",
                    "A mulatto, an albino, a mosquito, my libido...",
                    "Yeah, hey"
                );
                vocabulary.Should().Contain("mosquito");
            }

        }
    }
