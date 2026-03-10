namespace Buildings
{
	internal class BuildingManager
	{
		int input = 0;
		int XPosition = 0;
		int YPosition = 0;
		Dictionary<string, Building> buildingsBuilt = new Dictionary<string, Building>();
		public void Menu()
		{
			
			Console.WriteLine("Válassz az alábbiak kökzül\n\t1. Residential Building\n\t2. Commertial Building\n\t3. Industrial Building\n\t4. Service\n\t5. Utility\n\t6. Back.");
			int x = int.Parse(Console.ReadLine());
			Console.WriteLine("-------------------------------------------");

			switch (x)
			{
				case 1:
					for (int i = 0; i < Enum.GetValues(typeof(Residential)).Length; i++)
					{
						Console.WriteLine($"{i + 1}. {Enum.GetName(typeof(Residential), i)}");
					}
					zetenyMiatt(typeof(Residential));
					break;
				case 2:
					for (int i = 0; i < Enum.GetValues(typeof(Commercial)).Length; i++)
					{
						Console.WriteLine($"{i + 1}. {Enum.GetName(typeof(Commercial), i)}");
					}
					zetenyMiatt(typeof(Commercial));
					break;
				case 3:
					for (int i = 0; i < Enum.GetValues(typeof(Industrial)).Length; i++)
					{
						Console.WriteLine($"{i + 1}. {Enum.GetName(typeof(Industrial), i)}");
					}
					zetenyMiatt(typeof(Industrial));
					break;
				case 4:
					for (int i = 0; i < Enum.GetValues(typeof(Service)).Length; i++)
					{
						Console.WriteLine($"{i + 1}. {Enum.GetName(typeof(Service), i)}");
					}
					zetenyMiatt(typeof(Service));
					break;
				case 5:
					for (int i = 0; i < Enum.GetValues(typeof(Utility)).Length; i++)
					{
						Console.WriteLine($"{i + 1}. {Enum.GetName(typeof(Utility), i)}");
					}
					zetenyMiatt(typeof(Utility));
					break;
				case 6:
					Console.WriteLine("Vissza a főmenüre");
					break;
			}
		}
		public void zetenyMiatt(Type type) //Szabó Zétény miatt van ez a metódus, hogy ne kelljen minden switch case-ben ugyanazt a kódot írni
		{
			int input = int.Parse(Console.ReadLine());
			Console.WriteLine($"Kiválasztottad a {Enum.GetName(type, input - 1)} épületet.");
			Console.WriteLine("Melyik X és Y értékre szeretnéd ülteti: ");
			int XPosition = int.Parse(Console.ReadLine());
			int YPosition = int.Parse(Console.ReadLine());
			buildingsBuilt.Add($"__{buildingsBuilt.Count + 1}", new ResidentialBuilding(Enum.GetName(type, input - 1), XPosition, YPosition));
			Console.WriteLine("Sikerült :D");
		}
	}
}
