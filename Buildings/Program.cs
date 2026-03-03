
using System;
using System.Collections.Generic;

    namespace Buildings
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                var buildings = new List<Building>();

                var houseA = new Building
                {
                    Name = "House A",
                    X = 1,
                    Y = 1,
                    Type = BuildingType.Residential,
                    BuildingCost = 1000m
                };

                var houseB = new Building
                {
                    Name = "House B",
                    X = 1, // same coordinates as House A to demonstrate conflict
                    Y = 1,
                    Type = BuildingType.Residential,
                    BuildingCost = 1200m
                };

                // Use the static Add method on Building
                bool addedA = Building.Add(buildings, houseA);
                Console.WriteLine($"Added House A: {addedA} (collection count = {buildings.Count})");

                // Attempt to add a different building at the same coordinates -> should return false
                bool addedB = Building.Add(buildings, houseB);
                Console.WriteLine($"Added House B (same coords): {addedB} (collection count = {buildings.Count})");

                // Delete by reference
                bool removedA = Building.Delete(buildings, houseA);
                Console.WriteLine($"Removed House A by reference: {removedA} (collection count = {buildings.Count})");

                // Re-add houseA then demonstrate Delete fallback by matching Name + coordinates
                Building.Add(buildings, houseA);
                var duplicateHouseA = new Building
                {
                    Name = "House A",
                    X = 1,
                    Y = 1
                };

                // This Delete call provides a building with matching Name+coords
                bool removedByMatch = Building.Delete(buildings, duplicateHouseA);
                Console.WriteLine($"Removed by matching Name+coords: {removedByMatch} (collection count = {buildings.Count})");

                Console.WriteLine("Done.");
            }
        }
    }
