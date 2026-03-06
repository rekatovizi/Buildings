Building csoprt munka
Felosztás: 
Réka: 
Vince: 
Viktor: 
Márk: 

1)Core Building Architecture (Alaprendszer)
  Feladata: az egész épületrendszer alapja.
  Ő írja:
  Building abstract class
  közös property-k
  közös metódusok
  alap validációk  

2)Lakossági és szolgáltató épületek
Ő csinálja:
Residential
ResidentialBuilding
Service épületek
School
Hospital
PoliceStation
FireStation
Prison
PostOffice
SwimmingPool
Cinema
Specifikus property-k
School
TeacherCount
StudentCount
EducationLevel
Hospital
DoctorCount
PatientCount
RoomCount
Ő implementálhat:
override CalculateEffect()

3)Gazdasági és ipari épületek
Ő készíti:
Industrial
IndustrialBuilding
PowerPlant
Commercial
CommercialBuilding
Bank
Feladat:
resource production
economy integration
Példa:
PowerOutput
ResourceProduction
EconomicValue
PowerPlant:
EnergyProduction
FuelConsumption


4)Building Management rendszer
Ő írja a logikát ami az épületeket kezeli.
BuildingManager / BuildingService
Feladata:
épület létrehozása
térképre helyezés
épület frissítés tick alatt
állapot romlás
energia ellenőrzés
víz ellenőrzés
