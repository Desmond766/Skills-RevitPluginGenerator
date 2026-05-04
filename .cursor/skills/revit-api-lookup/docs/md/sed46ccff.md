---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.FluidType.GetTemperature(System.Double)
source: html/c9aa98b4-430f-d035-4e32-a0c55392c6f6.htm
---
# Autodesk.Revit.DB.Plumbing.FluidType.GetTemperature Method

Gets a copy of the FluidTemperature object matching a given temperature value.

## Syntax (C#)
```csharp
public FluidTemperature GetTemperature(
	double temperature
)
```

## Parameters
- **temperature** (`System.Double`) - The temperature value.

## Returns
The fluid temperature. Nothing nullptr a null reference ( Nothing in Visual Basic) if not found.

## Remarks
Changes made to this object will not be applied to the FluidType object.
 In order to modify the FluidTemperature settings for a given temperature,
 you should remove the existing FluidTemperature (RemoveTemperature()) and then add the modified value (AddTemperature()).

