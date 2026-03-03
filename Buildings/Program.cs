namespace Buildings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Building> buildings = new List<Building>();
            buildings.Add(new ResidentialBuilding("Lakóház1", 5, 10));
            Console.WriteLine(buildings);
        }
    }
}
