using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings
{
	internal class UtilityBuilding : Building
	{
		public UtilityBuilding(string name, int x, int y) : base(name, x, y)
		{
			Type = BuildingType.Utility;
			BuildingCost = 13000;
			MaintenanceCost = 700;
			TaxIncome = 0;
			Capacity = 20;
			MaxHealth = 100;
			HappinessImpact = 0;
			ElectricityConsumption = 20;
			WaterConsumption = 45;
		}
	}
}
