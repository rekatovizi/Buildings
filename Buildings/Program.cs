using CitySimproj;

namespace CitySimproj
{
    internal class Program
    {
        static void Main(string[] args)
        {
			
            Person.NPC();
            Database database = new Database();
            database.NPCAdd(Person.NPC());

            List<Person> list = new List<Person>();
            for (int i = 0; i <6; i+=2)
            {
                list.Add(database.NpcS[i]);
            }

            NPCEvents nPCEvents = new NPCEvents(list);
            nPCEvents.ApplyEffect();
			
			// BUILDINGS TEST
			/*
             BuildingManager manager = new BuildingManager();

			bool running = true;

			while (running)
			{
				Console.WriteLine("\n==== CITY BUILDER ====");
				Console.WriteLine("1. Épület építés");
				Console.WriteLine("2. Térkép megjelenítés");
				Console.WriteLine("3. Épületek listázása");
				Console.WriteLine("4. Kilépés");
				int choice = int.Parse(Console.ReadLine());

				switch (choice)
				{
					case 1:
						manager.Menu();
						break;

					case 2:
						BuildingManager.Draw();
						break;

					case 3:
						BuildingManager.Kiiratas();
						break;

					case 4:
						running = false;
						break;

					default:
						Console.WriteLine("Hibás");
						break;
				}
			}
		*/
      
		}
	}
}
