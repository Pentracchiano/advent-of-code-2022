﻿namespace Advent2023;

using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

[Description("Scratchcards")]
class Puzzle04 : PuzzleSolution
{
    private List<(HashSet<int> winning, HashSet<int> mine)> cards = new ();
    private Regex numberMatcher = new (@"(\d+)");
    public void Setup(string input)
    {
        foreach (var line in Iterators.GetLines(input))
        {
            var numbers = line.Split(':')[1];
            var cardValues = numbers.Split('|');

            cards.Add((
                new (numberMatcher.Matches(cardValues[0]).Select(m => int.Parse(m.Value))),
                new (numberMatcher.Matches(cardValues[1]).Select(m => int.Parse(m.Value)))
            ));
        }
    }

    [Description("How many points are they worth in total?")]
    public string SolvePartOne() =>
        cards
        .Select(c => c.winning.Intersect(c.mine))
        .Select(wins => wins.Count())
        .Where(wins => wins > 0)
        .Select(matches => Math.Pow(2, matches - 1))
        .Sum()
        .ToString();
        

    [Description("")]
    public string SolvePartTwo()
    {
        throw new NotImplementedException();
    }
}
