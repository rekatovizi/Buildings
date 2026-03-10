using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings
{
	internal class CommercialBuilding : Building
	{
		public CommercialBuilding(string name, int x, int y) : base(name, x, y)
		{
			Type = BuildingType.Commercial;
			BuildingCost = 15000;
			MaintenanceCost = 1000;
			TaxIncome = 1000;
			Capacity = 55;
			MaxHealth = 100;
			HappinessImpact = 30;
			ElectricityConsumption = 20;
			WaterConsumption = 25;
		}
	}
}
