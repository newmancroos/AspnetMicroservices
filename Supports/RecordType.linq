<Query Kind="Program" />

void Main()
{
	var nick = new Person("Newman",new DateOnly(1973, 6, 19));
	var nick2 = new Person("Newman",new DateOnly(1973, 6, 19));
	//Record type are immutable but the property within record type are mutable
		
	Console.WriteLine(nick == nick2); // true - Check the values of the properties
	Console.WriteLine(ReferenceEquals( nick , nick2));
	var nickButOler = nick with {DateOfBirth = new DateOnly(1972, 6, 19)};
	Console.WriteLine(nick);
	Console.WriteLine(nickButOler);
	//nickButOler.DateOfBirth = new DateOnly(1972, 6, 19)  // Can't change becuase it is Init only property
	
	var (Name, _) = nick;
	Console.WriteLine(Name);
	
	
	var person = new PersonClass
	{
	 Name = "Newman", DateOfBirth =  new DateOnly(1973, 6, 19)
	};
	
	var person2 = new PersonClass
	{
	 Name = "Newman", DateOfBirth =  new DateOnly(1973, 6, 19)
	};
	
	
	Console.WriteLine(person == person2); // False - Since it is different memory location
	
	
}

//public record Person(string Name, DateOnly DateOfBirth);
public record Person(string Name, DateOnly DateOfBirth)
{
	protected virtual bool PrintMembers(StringBuilder builder)   //Override so console.write will print these result
	{
		builder.Append($"FullName is {Name}");
		builder.Append($"  Age is {DateOfBirth}");
		return true;
	}
}

public class PersonClass
{
	public string Name{get;init;} = default!;
	public DateOnly DateOfBirth{get;init;} = default!;
}