using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings
{
    public class ResidentialBuilding : Building
    {
        public ResidentialBuilding(string name, int x, int y): base(name, x, y)
        {
            Type = BuildingType.Residential;
            BuildingCost = 10000;
            MaintenanceCost = 500;
            TaxIncome = 800;
            Capacity = 50;
            MaxHealth = 100;
            HappinessImpact = 5;
            ElectricityConsumption = 10;
            WaterConsumption = 15;
        }

        public override decimal CalculateNetIncome()
        {
            // Lakóépület speciális számítás
            return (TaxIncome * CurrentOccupancy / Capacity) - MaintenanceCost;
        }
    }
}
