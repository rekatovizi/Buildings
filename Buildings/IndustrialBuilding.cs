using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings
{
	internal class IndustrialBuilding : Building
	{
		public IndustrialBuilding(string name, int x, int y) : base(name, x, y)
		{
			Type = BuildingType.Industrial;
			BuildingCost = 20000;
			MaintenanceCost = 1500;
			TaxIncome = 2000;
			Capacity = 100;
			MaxHealth = 100;
			HappinessImpact = -5;
			ElectricityConsumption = 50;
			WaterConsumption = 50;
		}
	}
}
