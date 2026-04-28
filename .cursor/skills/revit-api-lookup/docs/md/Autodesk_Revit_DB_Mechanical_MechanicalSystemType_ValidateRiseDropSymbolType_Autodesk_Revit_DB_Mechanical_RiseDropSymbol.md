---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MechanicalSystemType.ValidateRiseDropSymbolType(Autodesk.Revit.DB.Mechanical.RiseDropSymbol)
source: html/f58462bc-b72d-7ef8-a973-64ff075f7c90.htm
---
# Autodesk.Revit.DB.Mechanical.MechanicalSystemType.ValidateRiseDropSymbolType Method

Confirms if the parameter is a valid HVAC rise/drop symbol type.

## Syntax (C#)
```csharp
public bool ValidateRiseDropSymbolType(
	RiseDropSymbol risedropType
)
```

## Parameters
- **risedropType** (`Autodesk.Revit.DB.Mechanical.RiseDropSymbol`) - The type.

## Returns
True if the input is a valid HVAC rise/drop symbol type, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

