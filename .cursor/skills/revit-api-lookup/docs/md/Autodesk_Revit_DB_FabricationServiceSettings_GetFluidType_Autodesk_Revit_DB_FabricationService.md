---
kind: method
id: M:Autodesk.Revit.DB.FabricationServiceSettings.GetFluidType(Autodesk.Revit.DB.FabricationService)
source: html/a68293fe-39d0-207d-e222-a4b49c22b65a.htm
---
# Autodesk.Revit.DB.FabricationServiceSettings.GetFluidType Method

Gets the fluid type of the specified service.

## Syntax (C#)
```csharp
public ElementId GetFluidType(
	FabricationService service
)
```

## Parameters
- **service** (`Autodesk.Revit.DB.FabricationService`) - The service to lookup.

## Returns
The fluid type id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - service is not mapped to a fluid type and temperature.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

