﻿using System;
using System.Runtime.CompilerServices;
using Manatee.Json.Schema;
using Manatee.Json.Serialization;

[assembly: InternalsVisibleTo("Manatee.Json.DynamicTypes")]

namespace Manatee.Json.Tests.FrameworkConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			var json = new JsonObject
				{
					["test1"] = 1,
					["test2"] = "hello"
				};
			var serializer = new JsonSerializer();
			var obj = serializer.Deserialize<ITest>(json);

			Console.WriteLine(obj.Test1);
			Console.WriteLine(obj.Test2);

			var schema04json = MetaSchemas.Draft04.ToJson(serializer);
			var schema04 = new JsonSchema();
			schema04.FromJson(schema04json, serializer);

			Console.ReadLine();
		}
	}

	internal interface ITest
	{
		[JsonMapTo("test1")]
		int Test1 { get; set; }
		[JsonMapTo("test2")]
		string Test2 { get; set; }

		event EventHandler SomethingHappened;

		void Action(object withParameter);
		int Function(string withParameter);
	}
}
