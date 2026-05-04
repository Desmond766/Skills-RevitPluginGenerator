---
kind: method
id: M:Autodesk.Revit.DB.FabricationServiceSettings.HasValidFluidSetting(Autodesk.Revit.DB.FabricationService)
source: html/cd2d80d9-7c35-a1a8-e975-909f17733a77.htm
---
# Autodesk.Revit.DB.FabricationServiceSettings.HasValidFluidSetting Method

Is the service associated with a fluid type and temperature?

## Syntax (C#)
```csharp
public bool HasValidFluidSetting(
	FabricationService service
)
```

## Parameters
- **service** (`Autodesk.Revit.DB.FabricationService`) - The service to lookup.

## Returns
True if the service is associated with a fluid type and temperature, otherwise false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

