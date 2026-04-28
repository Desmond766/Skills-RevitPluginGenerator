---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.FluidType.RemoveTemperature(System.Double)
source: html/91ab315a-b3ba-0fae-1c52-c750037a6fe8.htm
---
# Autodesk.Revit.DB.Plumbing.FluidType.RemoveTemperature Method

Removes a fluid temperature via the temperature value from the set.

## Syntax (C#)
```csharp
public void RemoveTemperature(
	double temperature
)
```

## Parameters
- **temperature** (`System.Double`) - The temperature value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the temperature that will be removed doesn't exist in the fluid type
 or the temperature that will be removed is in use.

