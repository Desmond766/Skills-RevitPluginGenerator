---
kind: method
id: M:Autodesk.Revit.DB.FabricationServiceSettings.GetFluidTemperature(Autodesk.Revit.DB.FabricationService)
source: html/6bbd6cfd-4876-f23b-fa59-c4a9cf8194d5.htm
---
# Autodesk.Revit.DB.FabricationServiceSettings.GetFluidTemperature Method

Gets the fluid temperature of the specified service.

## Syntax (C#)
```csharp
public double GetFluidTemperature(
	FabricationService service
)
```

## Parameters
- **service** (`Autodesk.Revit.DB.FabricationService`) - The service to lookup.

## Returns
The temperature in Kelvin.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - service is not mapped to a fluid type and temperature.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

