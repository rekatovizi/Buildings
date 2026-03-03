namespace Buildings
{
    public abstract class Building
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

        public BuildingType Type { get => type; protected set => type = value; }
        public string Name { get => name; set => name = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public decimal BuildingCost { get => buildingCost; protected set => buildingCost = value; }
        public decimal MaintenanceCost { get => maintenanceCost; protected set => maintenanceCost = value; }
        public int TaxIncome { get => taxIncome; protected set => taxIncome = value; }
        public int MaxHealth { get => maxHealth; protected set => maxHealth = value; }
        public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
        public bool IsPowered { get => isPowered; set => isPowered = value; }
        public bool IsConnectedToWater { get => isConnectedToWater; set => isConnectedToWater = value; }
        public int Capacity { get => capacity; protected set => capacity = value; }
        public int CurrentOccupancy { get => currentOccupancy; set => currentOccupancy = value; }
        public int HappinessImpact { get => happinessImpact; protected set => happinessImpact = value; }
        public int ElectricityConsumption { get => electricityConsumption; protected set => electricityConsumption = value; }
        public int WaterConsumption { get => waterConsumption; protected set => waterConsumption = value; }

        // ==== Konstruktor ====
        protected Building(string name, int x, int y)
        {
            Name = name;
            X = x;
            Y = y;
            CurrentHealth = MaxHealth;
        }

        // ==== Példa virtuális metódus ====
        public virtual decimal CalculateNetIncome()
        {
            return TaxIncome - MaintenanceCost;
        }
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
