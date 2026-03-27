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
			
			Console.WriteLine("Válassz az alábbiak közül\n\t1. Residential Building\n\t2. Commertial Building\n\t3. Industrial Building\n\t4. Service\n\t5. Utility\n\t6. Back.");
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
	/*public void zetenyMiatt(Type type) //Szabó Zétény miatt van ez a metódus, hogy ne kelljen minden switch case-ben ugyanazt a kódot írni
		{
			Console.WriteLine("-------------------------------------------");
			int input = int.Parse(Console.ReadLine());
			Console.WriteLine($"Kiválasztottad a {Enum.GetName(type, input - 1)} épületet.");
			Console.WriteLine("Melyik X és Y értékre szeretnéd ülteti: ");
			int XPosition = int.Parse(Console.ReadLine());
			int YPosition = int.Parse(Console.ReadLine());
			buildingsBuilt.Add($"__{buildingsBuilt.Count + 1}", new ResidentialBuilding(Enum.GetName(type, input - 1), XPosition, YPosition));
			Console.WriteLine("Sikerült :D");
		}*/
	public void zetenyMiatt(Type type)
		{
			Console.WriteLine("-------------------------------------------");
			int input = int.Parse(Console.ReadLine());

			string name = Enum.GetName(type, input - 1);

			Console.WriteLine($"Kiválasztottad a {name} épületet.");
			Console.WriteLine("Melyik X és Y értékre szeretnéd ülteti: ");

			int x = int.Parse(Console.ReadLine());
			int y = int.Parse(Console.ReadLine());

			Building b;

			if (type == typeof(Residential))
				b = new ResidentialBuilding(name, x, y);

			else if (type == typeof(Commercial))
				b = new CommercialBuilding(name, x, y);

			else if (type == typeof(Industrial))
				b = new IndustrialBuilding(name, x, y);

			else if (type == typeof(Utility))
				b = new UtilityBuilding(name, x, y);

			else if (type == typeof(Service))
			{
				switch ((Service)(input - 1))
				{
					case Service.School: b = new SchoolBuilding(x, y); break;
					case Service.University: b = new UniversityBuilding(x, y); break;
					case Service.Hospital: b = new Hospital(x, y); break;
					case Service.PoliceStation: b = new PoliceStationBuilding(x, y); break;
					case Service.FireStation: b = new FireStationBuilding(x, y); break;
					case Service.PostOffice: b = new PostOfficeBuilding(x, y); break;
					case Service.Library: b = new LibraryBuilding(x, y); break;
					case Service.CityHall: b = new CityHallBuilding(x, y); break;
					case Service.Court: b = new CourtBuilding(x, y); break;
					case Service.Uszoda: b = new UszodaBuilding(x, y); break;

					default: b = new ServiceBuilding(name, x, y); break;
				}
			}
			else
			{
				throw new Exception("Ismeretlen típus");
			}

			// after successfully adding a building
			if (Building.Add(b))
			{
				Console.WriteLine("Sikerült :D");
				Building.Draw(); // <-- call Draw here to see the updated grid immediately
			}
			else
			{
				Console.WriteLine("Nem sikerült (foglalt hely)");
			}
		}
	}
}
