namespace AdventOfCode2023;

public class Day04Tests
{
    private int Day04Part1(string input)
    {
        var cards = ParseCards(input);
        return cards.Sum(c => c.Score);
    }

    private int Day04Part2(string input)
    {
        var cards = ParseCards(input).ToArray();

        var N = cards.Length;
        var cardCount = new int[N];

        for (var i = 0; i < N; i++)
        {
            var count = ++cardCount[i];
            var countMatches = cards[i].OwnWinningNumbers.Count();

            for (var j = i + 1; j < N && j < i + countMatches + 1; j++)
            {
                cardCount[j] += count;
            }
        }

        return cardCount.Sum();
    }

    private int Day04Part2_Broken(string input)
    {
        var cards = ParseCards(input).ToArray();

        var N = cards.Length + 1;
        var cardCount = new int[N];

        foreach (var card in cards)
        {
            var i = card.CardNumber;
            var countMatches = card.OwnWinningNumbers.Count();
            if (true)
            {
                var count = ++cardCount[i];
                for (var j = i + 1; j <= countMatches + 1 && j <= N + 1; j++)
                {
                    cardCount[j] += count;
                }
            }
        }

        return cardCount.Sum();
    }

    void Hoi()
    {
        var N = 10;
        for (var i = 0; i < N; i++)
        {

        }

        var j = 0;
        while (j < N)
        {

            j++;
        }
    }

    private static IEnumerable<Card> ParseCards(string input)
    {
        var lines = input.Split(Environment.NewLine);
        foreach (var line in lines)
        {
            yield return ParseCard(line);
        }
    }

    private static Card ParseCard(string line)
    {
        var parts = line.Split(":");
        var cardNumber = ParseCardNumber(parts[0]);
        var (winningNumbers, ownNumbers) = ParseNumberListing(parts[1]);
        return new(cardNumber, winningNumbers, ownNumbers);
    }

    private static int ParseCardNumber(string s)
    {
        return int.Parse(s[4..]);
    }

    private static (HashSet<int>, HashSet<int>) ParseNumberListing(string s)
    {
        var parts = s.Split('|');
        return (ParseNumbers(parts[0]), ParseNumbers(parts[1]));
    }

    private static HashSet<int> ParseNumbers(string s)
    {
        return s
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToHashSet();
    }

    private record Card(int CardNumber, HashSet<int> WinningNumbers, HashSet<int> OwnNumbers)
    {
        public IEnumerable<int> OwnWinningNumbers => WinningNumbers.Intersect(OwnNumbers);

        public int Score
        {
            get
            {
                // 0 -> 0
                // 1 -> 1
                // 2 -> 2
                // 3 -> 4
                // 4 -> 8
                // 5 -> 16

                var count = OwnWinningNumbers.Count();
                return (int)Math.Pow(2, count - 1);
            }
        }
    }

    [Fact]
    public void Day04Part1Sample()
    {
        var input = """
            Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
            Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
            Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
            Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
            Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
            Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11
            """;

        var result = Day04Part1(input);

        result.Should().Be(13);
    }

    [Fact]
    public void Day04Part1RealDeal()
    {
        var input = RealDealValue;

        var result = Day04Part1(input);

        result.Should().Be(25010);
    }

    [Fact]
    public void Day04Part2Sample()
    {
        var input = """
            Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
            Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
            Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
            Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
            Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
            Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11
            """;

        var result = Day04Part2(input);

        result.Should().Be(30);
    }

    [Fact(Skip = "Still at part 2")]
    public void Day04Part2RealDeal()
    {
        var input = RealDealValue;

        var result = Day04Part2(input);

        result.Should().Be(666);
    }

    private static string RealDealValue => """
        Card   1: 13  5 40 15 21 61 74 55 32 56 | 21 57 74 56  7 84 37 47 75 66 68  8 55 22 53 61 40 13 15 41 32 46 95 65  5
        Card   2: 92 97 39 23 25 40 33 70 55 77 | 25 70 23 91 45 60 34 56 82  6  9 62 24  3 67 99 18 58  1 26 50 37 32 14 85
        Card   3: 44 71 17 92 34 98 50 61 89 79 | 57 56 89 98 59 61 44 97 79 18 71 50 34 92 23 63 20 51 64 47 76 17 46 54 62
        Card   4: 87 70 44 19  3 54 81 15 72 46 | 75 70 74 84  1 61 85 14 79 66 26 93 39 73 67 21 91 12  3 86 41 42  6 27 49
        Card   5: 86 63 59 76 89 62 87 20  2 66 | 21 58 72 98 95 14 38 16 35 88 60 55  3 36 65  1 28 56 11 74 15 29 93 50 17
        Card   6: 24 92 61 55 50 51 78  2 60 91 | 55 91 51 56 45 67 13 36 66  8 99 62 78  2 92 49 44 69 42 65 50 34 35 82 60
        Card   7: 91 88 72 26 86 34 14 66 31 20 | 25 24 73 97 72 20 87 26 15 47 90 22 14 86 62 68 61 69 88 91 66 27 31 34 52
        Card   8: 40 66 64 42 52  5 18 49 67 94 | 23  5 66 53 33 24 95 86  2 46 67 87 68 71 83 21 78 41 29 62 70 69 61 60 93
        Card   9: 41 86 83  7 80  3 98 95 94 28 | 78 62 21 65 53  6 75 90 39 70 98 59 37 61 49 43 52 34 23 15 83 48 54 80 93
        Card  10: 50 21 55 47 37  4 29 96 80 54 | 79 68 69 55 51 58 37 95 35 73 70 21 64 87 94 89 53 47 62 29  6 41 24  9 54
        Card  11: 64 12 41 90 30 21 54 40  4 86 |  4 57 10 84 88 30 59 70  5 64 18 65 67 92 12 90 56 39 44 75 86 28  9 54 38
        Card  12: 18 17 83 38 62 89  5 35  6 99 |  6 22 19 44 34 36 57 97 46 28 86 89 60  8 26 74 98 38 39 95 96  1 67 35 17
        Card  13: 86 94 93 19 49 11  8 48 81 39 | 74 54 51 62 79 87 18 69 88 75 22 19 46 36 12 26 11 48 80 45 14 92  1 17 33
        Card  14: 92 83 90 42 44 88 77 24 29 46 | 88 93 12  4 74 31 38 34 59 40 18 97 20  2 95 53 23 32 92 68 56 87 71 69 54
        Card  15: 92 68 17 36 99 15 35 67 60 55 |  1 34 38 55 18 49 52 37 27 66 54 59 71 90 69 80 11 10 97 33 24 95 50 36 93
        Card  16:  6  8 62 88 47 96 46 35 78 33 | 13 72 75 84 45 82 95 59 42 55 29 20 70 52 16  4 80 71 94 85 12 61 50 18 81
        Card  17: 35 51 98 72 99 13 45 92 30 67 | 32 75 71  7 91 37 62 35 70 97 80 89 78 47 41 21 12 42  5 52 83 39 29 27 56
        Card  18:  3 10 38 62 66 33 53 14 34 41 | 47 72 60 57 55 37 48 44  7 43 94 75 91 84 77 74 46  1 28 68 26 27 23 80 71
        Card  19: 98 46 62 91 93 61 65 66 20 43 | 11 62 38 93 81 47 43 65 53 59 69  7 57 10 18 61 15 46 20 44 66 86 91 98 30
        Card  20: 56  1 31 96 46  3 25 40 33 59 | 58 82 66 56 75 49 19  1 25 93 46 87 29 18 40 96 48 86  3 33 91 31 24 59 14
        Card  21: 93 43 29 76 85 88 81 58 13 89 | 81 39 93 41 82 20 70 13  3 12 58 43 26 69 89 49 29 85 30 75 96 97 74 76 16
        Card  22: 99 16 89  6 57 37 95 93 87 33 | 78 22 69 84 60 93 33 57 31 38 92 99 46  6 50 16 95 47 89 25 87 83 67 37 39
        Card  23: 96 64 85 18 82 33 29 17 24 99 | 76 99 53 17 78 38 82 96 18 85  1 73 36 24 11 47 40 64 89 98 20  9 23 84 57
        Card  24: 73 21 29 44 15 91 95 12  6 55 | 63 56 34 55 59 62 94 29 89 95 21 28 91 78 83 12  6  2 84 46 73 81 15 44 20
        Card  25: 15 92 59 63 87 68 61 26 98 97 |  4 59 46 83 68 10 32 15 58 85 78 22 98 77 92 56 42 36 61  7 87 17 26 97 63
        Card  26: 87 71 84 55 92  9 26 10 24 25 | 65  1 34 35 50 59  2 23  6 63 56  5 98 45  7 41 58 93 54 27 44 82 46 47 21
        Card  27: 62 49 39 32 15 77 78 50 34 65 | 78 76 20 60 65 56 82 22 39 99 72 35 33 77 49  1 50 42 62 26 16 23 75 43 95
        Card  28: 30 70 26 71 78 57 14 91 66 25 | 61 36  4 46 81 41 99 14 76 78 71 26  2 66  9 48 91 11 30 70 57 42 25 62 87
        Card  29: 14  6 35  9 21 68 50 63 76 59 |  3 43 58 33 93  1 90 21 78 47 99 16 67 80 84 71 97 38 10 83 70 34 44 46 57
        Card  30: 35 11 67 65 88 86 98 76 79 34 | 37 86 44 99 96 76 14 32 65 47 88 67 12 35 34 39 84 90 49 98 66 79 30 11 82
        Card  31: 71 25  9 26 24 23 66 47 40 67 | 65 28  1  2 81 15 38 40 79 13  8 61 97 87 18  4 98 45 42 72 96 92 30 34 73
        Card  32: 90 93 43  8 31 85 26 32 58 39 | 67 10  6 81 97  4 92 34 73 68 53 51 30 65 23 18 36 71 79 70 96 25 13 43 87
        Card  33: 43 89 29 67 13 18 55  2 79 97 | 43 79 28 67 93 55 18  2 21 94 92 99 51  9 31 70  5 68 84 97 29 74 87 53 26
        Card  34: 48 50  5 28 59 82 33 69  7 49 | 55 67 93 39 24 59 48 64 74 76 85  7 14 28 25  2 34 19 69 80  5 68 38 53 50
        Card  35:  8 86 26 41  2 63  7 70 42 56 | 59 87 33 12 86 26 99 29 31  5 97 19 62 47 73 22 42 15 40 32 83  9 88 70 78
        Card  36: 70 95 69 38 65 29 75 10 21 48 | 12  4 16 39 70 80 59  1 23 85 19 74 95 92 98  5 45 35 72 62 94 22  3 56 10
        Card  37: 90  8 23 65 66 92 97 79 60 61 | 33 53 86 98 65 87 90 42 89 79 10 35 38 43 88 28 63 41 34  8  6 32 78  5 24
        Card  38: 99 12 70 76 17 19 92 49 35  5 | 43  8 62 54 96 25 42 95 13 33 18 11 23 99 63 60 92 21 71 73 29 22 46 89 78
        Card  39: 63 46  6 41 15 14  4 17 49 72 | 13 77 45 62 90 33 38 50 89 21 17 52 39 25 47 41 70 96 93 31 84 81 67  3 43
        Card  40: 54 55 96 61 94 41 37 66 79 58 |  7 95 83 12 60 34 28 76 29 15 32 65 81 31 72 19 43 91  9 59 14 40 97 93 99
        Card  41: 79 32 47  9 23 90 36  1 98 14 | 62  8 70 88 75 68 54 91 37 21  7 20 51 22 84 15 35 29 42 60  6  2 65  3 43
        Card  42: 31 45 24 12 48 69 96 37 68 19 | 65 85 68 13 20 92 38 61 37 48 66 26 80 22 81 18 91 40 77 42 12  5 23 50 57
        Card  43:  9 75 59 56  3 64 22 99 41 97 | 49 64 42 15 34 35 56  9 22 86 30 67 99 95  3 52 41 82 59 73 62 63 94 75 97
        Card  44: 92 73 72 31 23 60 39 49 12 88 | 84 10 39 87 59 34 17 23 76 35 43 95 63 12 72 49 88 37 70 73 60  1 92 31  3
        Card  45: 85 70 61 52 86 12 29 15 74  9 | 21 33  4 45  8 60 38 71 88 80 69 35 90 48 13  1 79 28 85 97 91  9 22 73 40
        Card  46: 83  3 84 14 99 39 96 46 21 29 | 81 19 48 70  9 29 36 21 42 14  7 35 20 26 23 16 99 62 84 55 68  5 32 83 45
        Card  47: 43  5  8 65 76 40  7 85 63  2 | 73 35 75  3 28 21 47 16 95 74 34 80 22 27 42 12 13 70 72 30 20 59 18 54 92
        Card  48: 91 85 39 83 11 63 40 15 76 61 | 59 35 80 40 30 28  1 61 63 72 65 83  7 87 82 76  6 15 70 97 42 91 47 85 11
        Card  49: 16 41 86 46  3 22 56 85 37 11 | 97 47 18 80  8 16 85 86 36 31  5 46 58 64 50 37 41 70 68 17 81 56 48 15 34
        Card  50:  2 32 47 86 59 45 73  1 83 29 | 42  6 83 66 50  1 43  2 21 45 46 40 32 80 29 68 90 53 84 59 63 86 25 36 20
        Card  51: 91 45  3 90 15 95 35 59 63 57 | 79 44 90  5 92 74 22 34 13 54 69 47 96 99 56 45 67 91 68 57 98 87 49 59 55
        Card  52: 22 13 25 64 60 99 35 67 37 93 | 38  1 83 62 88 92 69  2 89 73  7 50 93 96  6 74 15 87 77 19 82 97 41 32 16
        Card  53: 18 54 36 92 72 93 16 35 14 70 | 27 61 21 71 38 11  8 53 14 24 93 54 74 69 12 18 91  1 88 89  9 32 19 85 25
        Card  54: 27 22 56  8 62 50 21 79 73 58 | 50 79 32 97 30 22 62 51 63 44 73 58 68 88 11 95 76 37 31 27  8 13 90 16 21
        Card  55:  7 69 73 49 96 10 41  8 14 13 | 20 57 14 73 69  9 59 10 42 98 13 37 90 41 53  8  7 49 78 38 26  6 77 31  1
        Card  56: 58 76 30 65  5 28 64 82 74 99 | 64 54 98 78 88 48 89 25 60 63 36 81 39 68 87 49 37 93 10 24 28 52  4 61  8
        Card  57: 96 28  1 25 93 58 27 84 72 78 | 20  2 22 75 19 58 13  1  5 66  3 72  7 85 47 27 16 78 18 25 96 74 43 49 77
        Card  58: 18 12 91 22 61 73 20 19 74 92 | 15 69 55 97 62 11  5 85 63 58 80 54 92 42 91 22 71 34 38 13 72 50 41 10 84
        Card  59: 11 30 47 92 29 75 74 95 53 24 | 96 78 37 60 77 63 81 75 93 40 97 27 24 41 30 32 53  4 34 33 31 50 71 69 12
        Card  60: 36 52 41 25 20 12  1 35 76 66 | 33 51 34  2 63 32 79 66 60 12  7 58 38 31 16 54 52 67 99 62 21 22 30 89 43
        Card  61: 82 97  6 12 68 92 10 14 78 21 |  3 87 24 32 42 15 67 68  1 60 99 88 25 54 52 80 36 30 50 79 63 86 64 18 58
        Card  62: 66 75 69 81 29 11 23 91 30 44 | 46 50 48 76 26  1  2 52 43 36 97 80  3  6 42 98  9 60 22 99 53 56 45 88 73
        Card  63: 13 75 88 41 48 78 20 10 29 66 |  6  2 70 77 73 44 18 27 92 48 51 45 31  3 97 71 95 50 61 64 81 47 23 90 83
        Card  64: 45 48 73 14 10 55 90 37 43 99 | 16 64 51 71 65 57 83 36 75 40 76 46 85 53 82 12 50 18 35 17  4 59 30 92 52
        Card  65: 78 31 50 94 61 71 42 63 95 16 | 45 58 38 30 95 27 33 80 22 98  1  7 87 94 15 78 61 50 66 25 31 42 72 13 63
        Card  66: 54 30 27 56 61 67 65 51 87 14 | 62 67 85 75 24 49 97 64 69 38 65 14 57 54 51 56 47 93 87 61 27 36 30 26  3
        Card  67: 59 66 76 30 45 14 46 23 20  9 | 35 99 30  2 46 25 20 76 45 59  4 23 21  5  8 18 26 53 77 14 85 91 88 66  9
        Card  68: 66 51 93 52 88 42 69 73 92 21 | 16 64 46 32  6 48  7 63 75 49 56 20 83 98 76 47 55 79 19  5  4  1 28 53 89
        Card  69: 66 65 37 64 58 44 35 40 79 42 | 85 41 40 71 86 54 44 11 35 42 37 58 72 49 66 79 64 29 65 96 99 55 77 45 47
        Card  70: 70 40 18 82 36 11 85 50 76 63 | 49 83 30 74 52 75 67 62 26 33 10 48 29  3 91 58 57  2 14 17 68 88 94 78 53
        Card  71:  5 10 79 20 29 44  8 23 92 84 | 70 11 41  4 98 73 54 30 56  7 62 14 94 18 72 76 45 16 97 49 57 78 86 64 96
        Card  72: 40 16 13 57 32 21 78 48 71 96 | 70 38 30 53 19  6  9 86 76 92 29 33 25 11 81 15 23 36 65 90 44 63  2 88 91
        Card  73: 97 53 95 87 54 26 34 55 71 65 | 34 60 13 97 52 25 76 36 82 53 54 65 83 48 71 24 26 69 18 17 87  9 55 31 22
        Card  74: 41 13 71 24 93 30 79 23 15 60 | 90 43 49 85 57 79 58 77 53 30 14 63 76 92 47 96 22 93 87 70 27 41 46 97 78
        Card  75: 55 66 68 77  8 14 23 53  9 50 | 79 13 55 77 21 14  5 38 10 92 52 17 22 34 50 80 53  8 23 49  9 78 66 75 15
        Card  76: 27 44 82 99 10 81 83 94 22 64 | 26  9 12 67 73 58 75 29 93 92 72 18 40 54 78 84 74 48 71 11 69 32 25  2 23
        Card  77: 69 62 79  7 43 82 77 32 97 42 | 97 99 21 75 86 56 79 74 32  7 77 91 69 47 68 89 42 43 90  4 62 15 80 82 53
        Card  78: 42 79 50 92 70  9 21 30 51 56 | 31 45 35 80 29 58  2 25 22 67 72 65 55 30 51 12  4 61 94 75 13 52 44 50  5
        Card  79:  9 22 30 32 63 56 10 16 57 43 | 22 51 55 42 84 58 70 62 71 48 52 82 36 43 93 18 96 60 21 89 31 56 30 16 37
        Card  80: 71 64  1 13 76 35 12 82 36 63 | 13 56 76 73 42 59 36 82 28 43 41 60 44 95 19 26 35 12  7 15 48 10 77 92  1
        Card  81: 33 19 11  3 85 88 62 26 98 31 | 74 48 58 87 91  1 16  3 98 33 24 21 42 96 52 39 88 19  6 14  2 35 89 31 62
        Card  82: 33 30 21 20 11 62 53 64 98 96 | 95  9 18 50 20 92 16 91  6 38 32 70 22  1  8 67 59 27  3 11 58 13 44 88 51
        Card  83: 27 11  1 28 17 52 33 89 26 51 | 57 45 65 11 72 82 26 15  6 90 75 46 62 18 10 33  2 37 52 64 60 93 88 73 44
        Card  84: 23 82 12 54 64 80 72 53 67 92 |  6 76 74  8 29 21 73 53 34 50 39 40 31 60 47 42 30 95 94 72 66 99  1 86 18
        Card  85: 52 99 90  3 14 55 45 96  5 71 | 54 16 83 68  3 64 12 82 91 92 51 36 25 76 79  2 70 88 66 44 47 95 31 20 56
        Card  86: 76 68 42 47 75 99 84 80 12 94 | 97  8 41 60 75 32 50 66 26 40 28  3 30 39 48 95 76 25 19 44  2 35 74 98 93
        Card  87: 84  7 26 78  4 69 96 53 49 18 | 31 25 39 22 36 91 40 54 69 99 29  5 86 92 88 56 62 85 45 41 90 35 59 12 21
        Card  88: 50 42 43 71 15 69  2 17 77 91 | 60 34 74 18 13 26 27 65 44  7 32 11 24  4 59 48 70 86 97 85 58 20  8 61 39
        Card  89: 80 28 62 85 86  2 71 57  8 67 | 57 37 20 67 28 21 66 22 64 59 52 16 49 41 14 45 33 51 19 84 17 99 10 92 26
        Card  90: 49 20  2 93 81 32 62 15 54 19 | 91 81 49 66 46 56 33 22  2 32 59 80 77 18 70 54 50 95 62 20 15 13 19 26  5
        Card  91: 76 36 32 77 85 12 81 26 28 37 | 71 72 52 32 35 23 47  1 28 84 92 78 46 90 50  6  8 31 80 37 15 77 17 55 81
        Card  92: 26  4 84 96 92 50 91 11 55 74 | 85 47 12 90 33 59 52 84 22 58 95 74  8  2 55 96 92 62 80 40 86 38 89 56 39
        Card  93: 43 49 31 10 50 75 25 91 57  8 | 92 43  8 97 38 26 37 56 93 31 32 57 77 81 25 44 16 22 72  4 39 30 75 52 73
        Card  94: 37 74 34 85 97 62 11 35 64 40 | 88 13 17 35 96 29 76 62  3 34 59 52  9 74 22 49 12 18 65 85 97 80 26 11  6
        Card  95:  5 25 56  2 46 90 28 40 71 83 |  4 12  2 25 91 72 83 24 34 20 14 94 39 17 54 22 10 78 60 42 65 28 70 84 36
        Card  96: 13 67 17 20 40 81  5 92 69 22 | 39 73 43 50 49  3 13 57 99 85 90 17 61  8 21 27 95 40 55 52 89 41 32 68 51
        Card  97: 86 65 47 38 57 25 19 17 24 69 | 43 96 68 58 25 33 31 10 55 65 62 29 57 90 46 14 17 37 27 34 95 52 38 24 91
        Card  98: 77 25 27 18 47 43 82 94 57 61 | 69  4 29 56 85 90 76 96 30  5 16 78 39 31 17 94 89 21 50 83 62 99 22 64 73
        Card  99: 77 83 18 69  8 63 21 73 55  2 | 76 70 26 43 54 96 61 35 50 78  4 65 93 44 19 41 24 12 10 92 23 52 72 47 49
        Card 100:  8 88 59 58 82 40 63 42 94 35 | 50 99 77 12  4 91 49 35 95 96 84 81 89 14 11 73 80 79 25 27 21 31  1 32 63
        Card 101: 97 91  1 43 86 64 21  6 61 17 | 93 33 27 14 19 31  8 77 49 54  6 47 18 40 75 26  3 67 92 38 99 24 73 35 34
        Card 102: 79  8  9 86 16 71 30 61 51 88 | 35 84 97 89 59 72 37  4 58 68 85 66 78 12 18 71 99 52 53 26 43  1 32 24 10
        Card 103: 29 21 14 92 27 40 61 71 53 36 | 94  8 45 49 62 66 77 34 43 95 38 60 90 55 91 99  9 76 26 19 41 81 75  3 89
        Card 104: 60 51 62 25 36 12 86 77 56 88 | 37 75 22 10 59 79 52 71 66 17 69 56  3 65 31 68 89 46 12 16 67 32  9 34 64
        Card 105: 45 41 77 13 63 22  4 48 35 28 | 77 41 64 95 49 13 17 80 88  3 68 92 81 22 18 96 35  4 63 79 28 48 45 29 69
        Card 106: 87 31 20 75 18 10 19 96 55 12 | 15 70 19 12 59 95 78 22 31 14 75 25  8 73 20 10 87 66  7 18 64 96 54 68 55
        Card 107: 81 32 44 58 34 80  1 43 19 73 | 50 17 67 12 80 57 76 98 23 19 78 32 61 46 44 34 18 29 58 43 41 81 73  1 79
        Card 108:  6 54 97 72 23  8  7 44 60 10 | 14 57 91 75 21 69 99 41 56 73 50  2 45 34 15 90 24 80 59 26 37 92 38 86 87
        Card 109: 30 28 61 86 14  4 29 41 17 11 |  1 11 21 40 29 64 99 85 69 48 35 32 79  4 61 51 20 58 30 17 41 14 86 95 28
        Card 110: 62 59 20 32 39 99 76 93 74 11 | 65 47 58 36  4 39 22 99 97 59 20 45 32 55 57 11 10 93 69 62 12 74 76 30 80
        Card 111: 12 49 13  4 41 61 59  1  3 73 | 61 92 41 96  1 40 38  4 72 19 91 13 49 15  3 12 34 54 48 55 59 46 36 20 73
        Card 112: 20 40 67 44 49 73 84 31 56 29 | 76 34 26 80 58 17 91 74 61 62 81 42 12 51 98  4  1 85 33 55 96  7 16 30 48
        Card 113: 93 52 43 58 80 60  6 79  1 12 | 52 58  2 78 44 43 48 56 39 11 79 72 14 93 59 80 60  1 38 87  6 62 21 12 75
        Card 114: 23  9  5 54 81 68 15  4 94  1 | 17 27 39  3 60  4 12 51 49 75 85 28 14 62 81 90 44 57 22 68 43 63 72 24 69
        Card 115: 92 72 74 54 62 25 76 84 30 40 | 25 57 88 36 96 52 59  3 64 93 34 99 76 50 17  4 84 75 67 30 85 78 95 61 37
        Card 116: 74 87 52 89 16 66  6 86 83 14 | 32 19 76  7 79 78 75 80 54 68 50 31 95 56 12 91 18 11 29 98  8 27 77 51 69
        Card 117: 77 56 33 32 85  1 26 47 65  4 | 46 34  8 54 36 80  9 52 99 48 29 45 35 66 17 43 69  4 22 98 97 20 13 57 11
        Card 118: 33 36  4  6  3 91 51 37 60 57 | 96 52 65 29 79 61 35 51  5 28 24 44 57 47 32 33 46  4 36 14 18 60 37 66 16
        Card 119:  2 88 83 73  9 26  6 67 55 12 | 67 51 83 74 42 53 12 60 99  6 33 88 84 40  5 29 77 18 15 21 75  2 93 47 52
        Card 120: 22 13  2 31 63 50 23 45 89 91 | 96 59 21 79 36 44 87 70 20 29 74 45 82 65  9 12 51 40 64 92 34 17 14 35 66
        Card 121: 52 38 28 33 61 62 49 92 76 66 | 75 66 70 94 55  4 97 18 89 65  7 83 98 38  9 74 69 52 47 43 37 95 57 45 41
        Card 122: 15 64 72 24 91 36 38 25 73 10 | 87 25 33 42 82 54 14 75 39 31 84 93 77 32 92 19 47 78 34 63 44 45 65 67 76
        Card 123: 39 82 94 96 21 13 79 61 64 11 | 95 42 61 33 55 94 86 67 63 53  5 65 14 39 13 45 96 28 36 81 50 16 51 52 76
        Card 124: 41 51  2 89 19 11 15 12 38 65 | 23 91 22  4 60 30 90 49 20 37 31 58 57  8  3  1 17 48 98 55 42 29 80 84 16
        Card 125: 97 80 66 48 21 51 78 59  1 82 | 54  5 30 58 26 71 65 75  9 35 33 43  8 73 29  6 40 15 36 25 55 63 41 24 83
        Card 126: 42  6 95 52 67 80 96 15  4 82 | 85 76 51 35 57 73 41 67 96  7 92 77 99 48 21 81 54 58 75  5 13 93 55 90 53
        Card 127: 81 64 12 61 86 28 30 40 63  4 | 75 25  1 77 65 24 51 87 58 68 91 40 85 36 52 22 21 79 48 57 96 11 84 92 13
        Card 128: 67 79 50 43 92 65 90 55 20 63 | 69  1 46 91 87 52 22 98 68 23 81 74  3 84 33 53  8 49 66 47 72 36 96 64  4
        Card 129: 70 11 14 79 82 48 33 32 41 43 | 50 60 82 98 69 90 44 79 48 11 36 43 84 70 86 12 83 89 14 41 20 55 56 34 87
        Card 130: 82 93 83 33 53  6 38  2 15 22 | 44 30 53  1 26 57  2 75 33 82 15 22 38 42 41 21 65  6 72 16  3 14 93 52  8
        Card 131: 66 84 24 25 21  9 62 27 14 18 | 43 21 92 16 96 18 40 67 99 79 28 66 73 26 47 56  9 62 20 17 14 84 61 54 33
        Card 132: 87  2 55 97  3 36 99 65 61 17 | 99 61 36 30 17 81 97 44 55 56  2 76 91 63 11  3 43 87 46 60 29 16 67 27 65
        Card 133: 74 68 70 30 12 96 92 36 50 38 | 40  4 75 36 51 96 43 50 57 68 52 70 78 20 74 95 92 86 71 26 61 31 58  9 32
        Card 134: 13 24 48  6 28 88 49 27 25 67 | 85 30 79  9 81 28 61 57 67  7 41 43 63 70 50 49 77 88 15 82 42 24 16 13  6
        Card 135:  8 51 92 52 16 96 46 28 87 14 |  2 33  1 84 64 89 30 70 47 90 98 74 80 29 49  3 48 94 59  7 65 77 11 19  5
        Card 136: 72 86 53 71 20 73 28 92 67  4 | 24  9 44 93 13 38  3 97 14 78 23 10 48 63  2 52 50 89 26 68 57 33 43 39  5
        Card 137: 13 16 19 39 62 73 76 35 61 90 | 63 81 42 45 64 25 53 79 84 16 66 90 34 10 51 73 95 89 38 82 55  6 18 24 92
        Card 138: 39  7  5 46 34 93 58 69 64 76 | 56 30 33 68 76 90 31 97 81 64 67 96 36 82 14  9 13 92 45 39 25 80 15 22  7
        Card 139: 89 52 54 45 19 92 30 25 95 33 | 66 41 71 79 94 54 43 75 56 14  5 85 27 96 24 34 20 32 42 49 31 30 11 99 58
        Card 140: 72 75 78 65 89 35 50  5 25 70 | 26 54 81 84 59  2 44 95 27 82 63 97 85 72 46 18 43 83 57 64 24  8 92 56 10
        Card 141: 42 50  4 21 82 73 71 34 55 63 |  8 71 26 70 95 76 33  2 28 56 32 96 48  5 12  6 64 49 13 46 25  7 93 90 22
        Card 142:  7 97 74  8 40 88 19 28 70 72 | 99 46 64 31 30 80 92 91 89 21 12 34 10 78 87 65 79 26 37 60 66 69 63 18 51
        Card 143: 61  4 46 47 76 92  7 99 37 89 | 30 77 21 73 67 20 91 19 80 29 23 39 40 90 64 78  1 43 10 53 88 45 66 41 69
        Card 144: 24  4 35 66 94 98 57 48 13 26 |  6 74 13 47 18 81 54 62 68 44 46 27 48  1 25 90 41 35 38 23 55  4 76 94 92
        Card 145: 22 16 48 81 59 44 23 54 78 28 | 67 81 55 13 20 59 82 29 23 19 74 28 44 48 22 66 16  4 54 46 45 98 62 78 47
        Card 146: 19 51 97 14 49 48 22 99 59 82 |  9 48 14 92 73 51 55 19 39 97 89 59 69 71 49 37 26 99 31 82  5 34 12 22 46
        Card 147: 56 54 74  7 55  8 24 13 42 79 | 55 56 54 11 57  6 27 34 60 74 83 26 19 87 14  7 69 48 94 71 42 62 49 21 77
        Card 148: 75 25  4 34 15 63 13  6 58 73 | 24 75 93 49 39 57 13 21 25 20 58 74 78 94 72 34 73  6 63 86 15 64 43 79  4
        Card 149: 35 76 98 85 25 52 91 15 86 62 | 37 68 95 75 59 21 35 88 23 54 81 42 80 63 29  3 47 15 22 25 86 82 40 31 46
        Card 150: 72 64 14 59 57 38 21 46 82 67 | 24 67 81 73 83 91 30 37 38  9 96 79 54 46 72 13 49 65 47 33 75 93 10 42  1
        Card 151: 25 88 96 54 65 78 27  8 35 95 | 43  9 38 33 96 40 35 49 66 97 93 65 39  6 94 31 95 44 22  7 54  3 32 28 29
        Card 152: 64 92 17 73 58 34 98 61  1 84 | 38  9 76 31 83 39  1  2 72 50 45 15 26 74 84 95 57 23  4 65 60 80 20 11 58
        Card 153: 22 50 13 90 46 27 25 40 29 65 | 46 35 90 48 27 72  7  8 32 65 83  4 99 25  2 60  6 38 13 29 22 50 55 40 82
        Card 154: 99 17 35 69 26 57 54 70 40 16 | 90 51 12 56 15 75 41 70 96 52 74 11  3 48 71 40 42 16 89 21 79  4 93  6 62
        Card 155: 53 79 36 41 69 31 99 16 59 35 | 99 16 63 77 35 50 49 65 87 10 30 48 45 36 59  3 46  8 89 69 58 15 31  1 47
        Card 156: 20  3 73 11 33 16 19 65 99 81 |  3 14 41 57 47 17 44 66 86 60 62 81 63 33 73 11 70 18 20 23 78 58 99 69 72
        Card 157: 33 30 75 56 67 72 10 43 62 57 | 64 80 50 76 54 66 23 82 42 15 67  2 93 13  1 57 78 43 60 37 79 92 61  4 59
        Card 158: 76 67 10 14 64 45 21 77 31 54 |  7 26 95 65 69 40 64 92 41 16 63 94 89 11 33 77 15 91 28 55 34  8  3 20 80
        Card 159:  7 83 77 20 31 72 89 98  9 25 | 24 60 45  2 63 93 52 61 59 51 56 50  8  4 16 12 78 39 43 79 57 96 37 66 92
        Card 160: 32 65 10 31 95 55 27 98 28 44 | 11 38 39 84 50 60 96 15  2  6 28 91 85 88 16  7 63 35 45 29 61  1 90 49 58
        Card 161:  7 23 94 82 76 28 10 71 95 93 |  9 44 48 78 14 47 97 18 37 49 91 56 24 53 40 70  8 72 35 99 88 73 16 55 60
        Card 162:  2 83 80  7 97 10 25 11 38 65 | 45 66 46  4 39 96 15 25 49 43 12 70 14 92 90 63 79  9 86 23 57 36  5 27 31
        Card 163: 66 96 65 22 74 80 56  8 19 85 | 75 89  1 35 62 97  2 34 83 94 30 90 10 91 37 50 61 54 21 44 92 32 69 86 63
        Card 164: 14 80  3  1 51 59 95 77 45 47 | 21 26 80 99 44  9 34 47  2 93 91 86 50 90 37 97 51 16 28 48 32 14 58 38 81
        Card 165: 80 46 90 82 73 25 76 29 23 43 | 23 46 43 81 73 91 21 82 19 94 42 27 29 40 90 41 18 25 85 76 80 86 68 20 58
        Card 166: 60 24 82 14 72  4 32 73 86 16 | 38 32  1 48 23 37 72 16  6 60 24 44  4 64 14 54 18 30 73 82 17 59 86 92 36
        Card 167: 13 99 87 21 26  3 61 40 24 54 | 75 52 47 40 21 90 87 34 60 89 54 69 32 82 43 99 31 72 85 13 28 68 48 61 26
        Card 168: 57 65 72 94 15 32 12 35 85 78 | 74 91 78 65 76 32 72 52 19  3 21 48 85 79 35 94 12 93 30 15 39 77 97 22  9
        Card 169: 20 39 38 91 94  2 64 16 79 45 | 56 93 81 94 96 50 91 70 73 16 45 68 38 64 34 69 79 39 62 55  2 20 77 10 25
        Card 170: 39 92 93 19 25 55 11 15  1 28 | 71 22 55 93 98 60 74 25 21 63 10  1 15 11 28 46 81 39  3 64 89 57 92 19 72
        Card 171: 39 27 12 11  5 64 20 17  6 41 | 20 31 47  6  9 57 97 17 16 27 82 74 64  8 12 95 70  5 11 39 98  2 56 41 65
        Card 172: 54 53 47 30 13 52 73  2 41 76 |  4 36 83 89 80 32 84 91 40 42 99 78 55 31 37 58 19 88 14 48 63 87 44  5 18
        Card 173: 23 50 77 75 90 56 37 71 18 94 | 82 37 93 26 16 41 66 78 70 20 99 63 75 89 23 77 28 17 18 19 76 94  7 73 34
        Card 174: 16 93 51 13 97 18 27 33 72 90 | 15 39 31 34 96 51 17 77 74 79 98 18 44 45  8 29 58 60 87 28 68  5 83 59 81
        Card 175: 62 88 83 57 12 15 33 47 51 61 | 47 76 62 87 72 14 23 33 24 83 20 15  1 13 81 51 88  5  2  3 57 74 11 79 61
        Card 176: 62  2 81 39 92 22 15 38 85 95 | 70 23 16 35 27 12  5  2 67 33 13 85 39 25 17 50 30 77 95 14 92 79 62 54 45
        Card 177: 10 11 31 30 13 50  7 24 67 98 | 37 53 36 90 35 50 27 62 43 11 78 49 29  6 81 40 72 54  3 24 23  9 98 55 79
        Card 178: 59 63 24  5 41 23 90 15 39 95 | 59 25 98 23 47 22 37 49 50 19 28 24 61 76 39 90 41 11 46 91 13 95 15 79 63
        Card 179:  4  5 44 14 82 43 54 90 56  8 |  4 79 56 66 43 63 40  1 33 64 42 93 81 36 14 90  7 15 27 44 72 25  5  6 39
        Card 180: 92 93 47 86 68 53 50  4 81 37 | 34 94 47 81  4 55 11 50 39 78 29 22 63 67 92 40 16 19 86 77 53 37 97 24 70
        Card 181: 75 94 97 30 77 65 70 63 67 53 | 26 78  2 30  3 21 49 20 50 11 31 57 81 24 19 93 97 77 53 39 13 74 65 60 44
        Card 182: 38 24 60 98 20 26 87 57 92 66 | 17 84 98 39 93 57  1 13 23 19 77  7 45 41 21 20 49 31  9 66 65 27 14 56 86
        Card 183: 64  9 89 82 78  6 84 47 86 79 | 66 96  6 75 44 42 49 18 82 11 53 93 17 65 40 48  3 81 16 34 89 69 55 84 12
        Card 184: 61 17 70 29  8 78 80 38 37 35 | 40 55 60 71 43 21 83 33 54 42 92 11 39 90  6 73 35 91 98 23 29 26 17 31 89
        Card 185: 59  2 61 83 86 84 37 52  4 62 | 71 70  7 60 80 33 77 42 61 84 15 25 38 52 19 93 87 16 57 75 53 47 76 12 58
        Card 186: 17 45 50 40 71 38 84 82 22 25 | 23 46 90 16 28 70 78 96 87 11 62  8 44 67 77 48 83 32  4 64 31 97 65 88 86
        Card 187: 41 16 15 10 47 85 28 91  7 25 | 68 36 31 21 72 71 32 59 97 24 90 52 56 46 16 53 12 38 42 94  2 66  4 26 48
        Card 188: 17 85 55 90 45 92 64 71 39  5 | 29 80 27 37 73 82 32 51  2 74 69 79 68 81 54 76 89 10 97 65 43 14 48 58 94
        Card 189:  4 94 66 48 68 18  1 53 58 77 | 13 23 77  1 58 18  5 60 80 74 81 88 68 20  6  8 50 47 94 32 57 34 72 53 87
        Card 190: 41 51 34 86 77 68 63 27 89 58 | 14 24  5 31 84 77 90 34 50 58 27 37 99 21 51 89 86 85 41 83 38 17 60 63 71
        Card 191: 26 12 67  6 51 22 24 32 68 76 |  6 32 22 99 51 57 67 45 13 96 26 14 12 35 24 55 68 85 61 94 80  8 76  4 23
        Card 192: 82  6 69 66 47 80 21 74 55 64 | 15 64 43 79 21 82 91 95 55 40 70  1 38 65 81 50 80 74 88  6 69 47 66 60 41
        Card 193: 29 14 78 84 76 83 43 57  4 34 | 68 93 57 15 16 18 13 82 69 41 79 43 66 97 17 52 39 99 67 27 60 89 72 91 76
        Card 194: 81 10 91 23 16 28 20 54 36 47 | 20 23 90 17 47 32 85 81 36 22 91 73 10 99 95 53 59 16 28 65 74 86 54 98 39
        Card 195: 40 49  4 81 21 61 64 31 17 37 | 98 87 14 54 89 12 61 47 10 94 25 48 17 23 21 49 64  6 40 92 81  5 29 97 55
        Card 196: 85 48 82 24 56 30 26 45 99 64 | 47 89  4 32 43 45 36 67 87 34 83 18 64 50 61 82 75 85 21 55 30 39 40 93 77
        Card 197: 96 21 28  6 41 88 56 51 93 94 | 44 61 91 42  8 34 52  1 18 80  2 72 22 25 33 39 76 45  5 17 46 65 38 41 29
        Card 198:  8 33 36 79  6 94 71 90 61  4 | 76 94 15 50 85  4 79  6 69 89 21 28 26 66 55 10 61 68 45 46 34 36 90  8 33
        Card 199: 17 80 95 41 51 65 39 53 35  2 | 70 78 11 33 16 57  9 23 10 80 12 32 39 47 99 72 26 74 60 76 51 58 45 59 31
        Card 200: 94 13 38 47 28 98 64 91 92 63 | 28 63 87 90 55 82 68 99 92 41 15 43 98 36  4 42 19 51 18 94 45 33 91 25 72
        Card 201:  4 91 59 65 74 64 53 17 45 35 |  4 92 14 48 35 38 65 36 64 77 23 53  7 47 34 17 59 45 41 46 10 91 60  1 90
        Card 202:  8 64 93 13 61 68 97 80 78 33 | 64 90 94 66 43 71 13 74 80 60 25 54 38 61 24 59 77 29 89 15 30 36 22  8 93
        Card 203: 38 29 20 44 92 67 51 73 55 90 |  4 82 24 19  6 36 85 51 55 91 20 54 39 35 53 14 83 11  8 86 42 66 10 59 90
        Card 204: 94  7 45 22 97 49 48  3 79 90 | 52 53 49 39  7 22 48 20 94 38 45 65 97 95 26 66  5 75 77 56 36 14 70  9 90
        Card 205: 82 27 61 83 48 24 44 45  8 65 | 77 79 56 93 33 25 21 73 86 69 80 26 53 49 22 81 12 58 59 98 19  3  4 14 15
        Card 206: 10 60 71 12  7 70 18 63 40 96 |  1 48 83 36 49 21 64 78 91 99 94 56 39 74 45 51 12 32 19 75 15  5 34 79 46
        Card 207: 67 34  1 48 23 11 82 87 64 45 | 26 24 38 14 84 68 65 29 12 83 59  4 36 52 58 80 22 41 91 50  2  7 95 49 92
        Card 208: 40 79 92 66 60 12 64 75 61 87 |  9 25 18  8 37 50 21 92 42 23 82 19 62 31 10 75 93 17 45 85  3 53 20 47 38
        Card 209:  9 71 13 95 60 98 50 28 23 77 | 86 20 75 32 19 24 43 94 25 67 69 27 82 38 40 44 59 30 89 54 91 53 85 18 29
        Card 210: 24 63 54 42 33 82  3 31  6 20 | 37 55  9 74 40 72 97  2 92 95 11 79  4  5 86 89 53 34 27 38 58 78 87 99 24
        Card 211: 79 97 88 40 80 43 41 93 58 70 |  9 36 33 46 66  5 37 13 83 35 86 47 51  1 77 48 22 59 76 81 57 24 42 16  6
        Card 212: 20 42 99 64 58 19 11  8 78  2 | 95 54 44 34 45 18 82 21 80 86 79 47  1 43 69 98  7 26 41 39 88 56  6 10 83
        """;
}