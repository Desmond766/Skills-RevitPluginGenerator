---
kind: method
id: M:Autodesk.Revit.DB.FabricationServiceSettings.SetFluidTypeAndTemperature(Autodesk.Revit.DB.FabricationService,Autodesk.Revit.DB.ElementId,System.Double)
source: html/353cecb8-5a1e-62ca-97db-9e36387ca7a5.htm
---
# Autodesk.Revit.DB.FabricationServiceSettings.SetFluidTypeAndTemperature Method

Sets the fluid type and temperature of the specified service.

## Syntax (C#)
```csharp
public void SetFluidTypeAndTemperature(
	FabricationService service,
	ElementId fluidId,
	double temperature
)
```

## Parameters
- **service** (`Autodesk.Revit.DB.FabricationService`) - The fabrication service to be set.
- **fluidId** (`Autodesk.Revit.DB.ElementId`) - The fluid type id.
- **temperature** (`System.Double`) - The temperature in Kelvin.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - fluidId is not a fluid type.
 -or-
 The temperature is not defined for the fluidId fluid type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

