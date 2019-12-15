using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Curse.Entities;

namespace Curse.Test
{
	class Program
	{
		static HashSet<string> _knownCategories = new HashSet<string>();
		static AddonService _service;

		static void DumpAddon(Addon a)
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.Write($"{a.Name}");//.PadRight(Console.CursorLeft >= 35 ? 0 : 35 - Console.CursorLeft));

			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write(" - ");

			Console.ForegroundColor = ConsoleColor.White;
			Console.Write($"{a.Summary}");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine("\n - Authors:");
			Console.ForegroundColor = ConsoleColor.Yellow;

			foreach (var author in a.Authors)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write($"   {author.Name}");

				Console.ForegroundColor = ConsoleColor.White;
				Console.Write(" ".PadRight(Console.CursorLeft >= 35 ? 0 : 35 - Console.CursorLeft));

				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.Write($"{author.Url}\n");

				Console.ForegroundColor = ConsoleColor.White;
			}

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine("\n - Attachments:");
			Console.ForegroundColor = ConsoleColor.Yellow;

			foreach (var attachment in a.Attachments)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write($"   {attachment.Title}");

				Console.ForegroundColor = ConsoleColor.White;
				Console.Write(" ".PadRight(Console.CursorLeft >= 35 ? 0 : 35 - Console.CursorLeft));

				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.Write($"{attachment.Url}\n");

				Console.ForegroundColor = ConsoleColor.White;
			}

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine("\n - Categories:");
			Console.ForegroundColor = ConsoleColor.White;

			foreach (var category in a.Categories)
			{
				lock (_knownCategories)
					_knownCategories.Add(category.Name);

				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine($"   {category.Name}");
				Console.ForegroundColor = ConsoleColor.White;
			}

			Console.WriteLine($"{new string('_', 255)}\n\n");
		}

		static async Task Main(string[] args)
		{
			Console.Title = "Curse: Addon Service Test";

			_service = new AddonService();

			var chiselAddon = await _service.GetAddonAsync(235279);

			if (chiselAddon != null)
				DumpAddon(chiselAddon);

			var searchResult = await _service.SearchAddonsAsync(GameType.Minecraft, search: "extra", maxResults: 5);

			foreach(var addon in searchResult)
				DumpAddon(addon);

			Console.WriteLine("\t"+string.Join("\n\t", _knownCategories));
			Console.ReadKey();
		}
	}
}
