---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.FluidType.AddTemperature(Autodesk.Revit.DB.Plumbing.FluidTemperature)
source: html/b45f6462-c9d6-95c1-8561-a1024020532c.htm
---
# Autodesk.Revit.DB.Plumbing.FluidType.AddTemperature Method

Adds a fluid temperature to the set.

## Syntax (C#)
```csharp
public void AddTemperature(
	FluidTemperature fluidTemperature
)
```

## Parameters
- **fluidTemperature** (`Autodesk.Revit.DB.Plumbing.FluidTemperature`) - The fluid temperature being inserted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the temperature that will be added already exists in the fluid type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

