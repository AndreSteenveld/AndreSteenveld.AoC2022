
var Hand = ( Rock : 1, Paper : 2, Scissor : 3 );
var Outcome = ( Lost : 0, Draw : 3, Win : 6 );

var hand = new Dictionary<string, int>{

    // Elf hand A, B, C - rock, paper, scissor
    // My hand X, Y, Z - rock, paper, scissor
    { "A X", Hand.Rock + Outcome.Draw },
    { "A Y", Hand.Paper + Outcome.Win },
    { "A Z", Hand.Scissor + Outcome.Lost },

    { "B X", Hand.Rock + Outcome.Lost },
    { "B Y", Hand.Paper + Outcome.Draw },
    { "B Z", Hand.Scissor + Outcome.Win },

    { "C X", Hand.Rock + Outcome.Win },
    { "C Y", Hand.Paper + Outcome.Lost },
    { "C Z", Hand.Scissor + Outcome.Draw },

};

var outcome = new Dictionary<string, int>{

    // Elf hand A, B, C - rock, paper, scissor
    // My required outcome X, Y, Z - lose, draw, win
    { "A Y", Hand.Rock + Outcome.Draw },
    { "A Z", Hand.Paper + Outcome.Win },
    { "A X", Hand.Scissor + Outcome.Lost },

    { "B X", Hand.Rock + Outcome.Lost },
    { "B Y", Hand.Paper + Outcome.Draw },
    { "B Z", Hand.Scissor + Outcome.Win },

    { "C Z", Hand.Rock + Outcome.Win },
    { "C X", Hand.Paper + Outcome.Lost },
    { "C Y", Hand.Scissor + Outcome.Draw },

};

(int hand_score, int outcome_score) = Lines(Console.In)
    .Select( g => (hand[g], outcome[g]))
    .Aggregate<(int h, int o), (int h, int o)>(
        (0, 0), 
        ( s, g ) => ( s.h + g.h, s.o + g.o )
    );


Console.WriteLine( $"Total hand score is [ {hand_score} ]");
Console.WriteLine( $"Total outcome score is [ {outcome_score} ]");


IEnumerable<string> Lines(TextReader reader){

    for(var r = reader.ReadLine(); r is not null; r = reader.ReadLine())
        yield return r;

}




