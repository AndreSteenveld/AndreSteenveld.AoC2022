
using Array = System.Collections.Immutable.ImmutableArray<int>;
using Stack = System.Collections.Immutable.ImmutableStack<System.Collections.Immutable.ImmutableArray<int>>;


var elves = Lines(Console.In)
    .Aggregate( 
        Stack.Empty.Push(Array.Empty),
        (elves, line) => line switch 
        {
            "" => elves.Push(Array.Empty),
            var l => elves.Pop(out var e).Push(e.Add(Convert.ToInt32(l)))
        }        
    )
    .Select( calories => (sum : calories.Sum(), calories) );

Console.WriteLine( $"The elf with most calories is carrying [{elves.Max( e => e.sum )}] calories");
Console.WriteLine( $"The top 3 elves are carrying [{elves.OrderBy(e => -e.sum).Take(3).Sum(e => e.sum)}] calories");


IEnumerable<string> Lines(TextReader reader){

    for(var r = reader.ReadLine(); r is not null; r = reader.ReadLine())
        yield return r;

}

