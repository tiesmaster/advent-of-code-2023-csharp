namespace AdventOfCode2023;

public record GameListing(ImmutableList<Game> Games)
{
    public static GameListing Parse(string input)
    {
        var parser = new GameListingParser(input);
        return parser.Parse();
    }

    public IEnumerable<Game> PossibleGames(Cubes givenCubes)
    {
        return Games.Where(g => g.IsPossible(givenCubes));
    }
}

public record Game(int Id, ImmutableList<GamePlay> Set)
{
    public bool IsPossible(Cubes givenCubes)
    {
        return Set.All(p => p.IsPossible(givenCubes));
    }

    public Cubes CalculateMinimumCubesRequiredToPlay()
    {
        return new Cubes(
            Set.Max(g => g.PlayedCubes.R),
            Set.Max(g => g.PlayedCubes.G),
            Set.Max(g => g.PlayedCubes.B));
    }
}

public record GamePlay(Cubes PlayedCubes)
{
    public bool IsPossible(Cubes givenCubes)
    {
        return givenCubes.R >= PlayedCubes.R && givenCubes.G >= PlayedCubes.G && givenCubes.B >= PlayedCubes.B;
    }
}

public record Cubes(int R, int G, int B)
{
    public int Power => R * G * B;
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

        return new(new(r, g, b));
    }

    private static int ParseNumber(string s)
    {
        return int.Parse(s[..s.IndexOf(' ')]);
    }
}