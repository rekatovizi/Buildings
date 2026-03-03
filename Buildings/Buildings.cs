using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings
{
    public class Building
    {
        // ==== Private adattagok ====
        private BuildingType type;
        private string name;

        private int x;
        private int y;

        private decimal buildingCost;
        private decimal maintenanceCost;
        private int taxIncome;

        private int maxHealth;
        private int currentHealth;

        private bool isPowered;
        private bool isConnectedToWater;

        private int capacity;
        private int currentOccupancy;

        private int happinessImpact;

        private int electricityConsumption;
        private int waterConsumption;

        // ==== Public property-k ====

        public BuildingType Type { get => type; set => type = value; }
        public string Name { get => name; set => name = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public decimal BuildingCost { get => buildingCost; set => buildingCost = value; }
        public decimal MaintenanceCost { get => maintenanceCost; set => maintenanceCost = value; }
        public int TaxIncome { get => taxIncome; set => taxIncome = value; }
        public int MaxHealth { get => maxHealth; set => maxHealth = value; }
        public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
        public bool IsPowered { get => isPowered; set => isPowered = value; }
        public bool IsConnectedToWater { get => isConnectedToWater; set => isConnectedToWater = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public int CurrentOccupancy { get => currentOccupancy; set => currentOccupancy = value; }
        public int HappinessImpact { get => happinessImpact; set => happinessImpact = value; }
        public int ElectricityConsumption { get => electricityConsumption; set => electricityConsumption = value; }
        public int WaterConsumption { get => waterConsumption; set => waterConsumption = value; }

        /// <summary>
        /// Adds a building to the supplied collection if it does not conflict with an existing building.
        /// Conflicts are checked by reference and by coordinate (X,Y).
        /// </summary>
        /// <param name="collection">Target collection to add into.</param>
        /// <param name="building">Building to add.</param>
        /// <returns>True if added; false if a conflict prevented adding.</returns>
        /// <exception cref="ArgumentNullException">Thrown when collection or building is null.</exception>
        public static bool Add(ICollection<Building> collection, Building building)
        {
            if (collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (building is null)
            {
                throw new ArgumentNullException(nameof(building));
            }

            // Prevent adding the exact same reference twice
            if (collection.Contains(building))
            {
                return false;
            }

            // Prevent adding a building at coordinates already occupied
            if (collection.OfType<Building>().Any(b => b.X == building.X && b.Y == building.Y))
            {
                return false;
            }

            collection.Add(building);
            return true;
        }

        /// <summary>
        /// Deletes a building from the supplied collection.
        /// Attempts to remove by reference first, then by matching Name and coordinates.
        /// </summary>
        /// <param name="collection">Collection to remove from.</param>
        /// <param name="building">Building to remove or a building with matching identity.</param>
        /// <returns>True if a building was removed; otherwise false.</returns>
        /// <exception cref="ArgumentNullException">Thrown when collection or building is null.</exception>
        public static bool Delete(ICollection<Building> collection, Building building)
        {
            if (collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (building is null)
            {
                throw new ArgumentNullException(nameof(building));
            }

            // Try remove by reference
            if (collection.Remove(building))
            {
                return true;
            }

            // Fallback: find by Name and coordinates and remove the first match
            var match = collection.FirstOrDefault(b =>
                string.Equals(b.Name, building.Name, StringComparison.Ordinal) &&
                b.X == building.X &&
                b.Y == building.Y);

            if (match is not null)
            {
                return collection.Remove(match);
            }

            return false;
        }
    }
}
