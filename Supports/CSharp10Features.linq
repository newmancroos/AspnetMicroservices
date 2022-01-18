<Query Kind="Program" />

void Main()
{
	var names = new []{"Nick", "Mike", "John", "Leyla", "David", "Damian" };
	var result = ChunkBy(names,3);
	
	result.Dump();
	
	//in C#10
	//-------
	
	names.Chunk(3).Dump();
//-----------------------------------------------------------

	var firstSet = new[] {"Nick Chapsas"};
	var secondSet = new[] {"Peter Chasas"};
	var thirdSet = new[] {"Maria Chasas"};
	
	IEnumerable<string> conNames = firstSet.Concat(secondSet).Concat(thirdSet);
	
	var count = conNames.Count();  // Execute the Enumerable
	var orderedNames = conNames.OrderBy(x => x); // Execute the Enumerable second time
	
	//C#10
	
	if(conNames.TryGetNonEnumeratedCount(out var ccount))
	{
		Console.WriteLine(ccount);
	}
	
	//---------------------------------------------------------------
	
	var ages = new[] {28,30,33};
	
	IEnumerable<(string Name, int Age)> zip = names.Zip(ages);
	zip.Dump();
	var sdasd= zip.ToList();
	//sdasd[0].Name.Dump();
	
	//C#10
	var YearsOfExperience= new[] {20,22,24};
	
	IEnumerable<(string Name, int Age, int YOE)> zip1= names.Zip(ages, YearsOfExperience);  // C#10 allowed more than 2 to zip
	zip1.Dump();
	//-----------------------------------------------
	
	var thirdName = names.ElementAt(3);
	thirdName.Dump();
	
	names.Skip(2).Take(2).Dump();
	//C#10
	
	names.ElementAt(^3).Dump();
	var arr = names[1..^3];
	arr.Dump();
	
	names.Take(2..4).Dump();
}

IEnumerable<IEnumerable<T>> ChunkBy<T>(IEnumerable<T> source, int chunkSize)
{
	return source.Select((x,i) => new {Index = i, Value = x})
				.GroupBy(x => x.Index / chunkSize)
				.Select(x => x.Select(v => v.Value));

}

