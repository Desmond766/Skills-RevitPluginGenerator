---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyDataSettings.OutsideAirChangesRatePerHour
source: html/17496b1f-31b1-55e1-09fe-10da1c84a765.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.OutsideAirChangesRatePerHour Property

The number of times the volume of air interchanges in the room in one hour.

## Syntax (C#)
```csharp
public double OutsideAirChangesRatePerHour { get; set; }
```

## Remarks
Air Changes per hour is "unitless". It is a number.
 It is the number of times the air (the volume) interchanges in the room in one hour.
 This number is a format for expressing the requirement for airflow.
 The "flow" requirement for a room might be expressed, e.g.,
 one room of 100 CF, and 3 Air Changes per Hour (ACH), would compute to 100 CF x 3 ACH / 60 min = 5 CFM.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The outside airChangesRatePerHour does not fall within an appropriate range.

