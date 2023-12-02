namespace AdventOfCode2023;

public record GameListing(ImmutableList<Game> Games)
{
    public static GameListing Parse(string input)
    {
        var parser = new GameListingParser(input);
        return parser.Parse();
    }

    public IEnumerable<Game> PossibleGames(int r, int g, int b)
    {
        return Games.Where(x => x.IsPossible(r, g, b));
    }
}

public record Game(int Id, ImmutableList<GamePlay> Set)
{
    internal bool IsPossible(int r, int g, int b)
    {
        return Set.All(x => x.IsPossible(r, g, b));
    }
}

public record GamePlay(int R, int G, int B)
{
    public bool IsPossible(int r, int g, int b)
    {
        return r >= R && g >= G && b >= B;
    }
}

public class GameListingParser(string input)
{
    private readonly string _input = input;

    public GameListing Parse()
    {
        var games =
            from line in _input.Split(Environment.NewLine)
            let game = ParseLine(line)
            select game;

        return new([.. games]);
    }

    private static Game ParseLine(string line)
    {
        var parts = line.Split(": ");

        var id = ParseGameId(parts[0]);
        var set = ParseGameSet(parts[1]);

        return new(id, set);
    }

    private static int ParseGameId(string s)
        => int.Parse(s[5..]);

    private static ImmutableList<GamePlay> ParseGameSet(string s)
    {
        var parts = s.Split("; ");
        return parts.Select(ParseGamePlay).ToImmutableList();
    }

    private static GamePlay ParseGamePlay(string s)
    {
        var r = 0;
        var g = 0;
        var b = 0;

        var parts = s.Split(", ");
        foreach (var p in parts)
        {
            if (p.EndsWith("red"))
            {
                r = ParseNumber(p);
            }

            if (p.EndsWith("green"))
            {
                g = ParseNumber(p);
            }

            if (p.EndsWith("blue"))
            {
                b = ParseNumber(p);
            }
        }

        return new(r, g, b);
    }

    private static int ParseNumber(string s)
    {
        return int.Parse(s[..s.IndexOf(' ')]);
    }
}