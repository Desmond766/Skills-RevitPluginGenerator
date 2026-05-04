---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PipingSystemType.ValidateRiseDropSymbolType(Autodesk.Revit.DB.Mechanical.RiseDropSymbol)
source: html/43506db8-5f55-8f67-780e-44ce3dda5cb4.htm
---
# Autodesk.Revit.DB.Plumbing.PipingSystemType.ValidateRiseDropSymbolType Method

Confirms if the parameter is a valid piping rise/drop symbol type.

## Syntax (C#)
```csharp
public bool ValidateRiseDropSymbolType(
	RiseDropSymbol risedropType
)
```

## Parameters
- **risedropType** (`Autodesk.Revit.DB.Mechanical.RiseDropSymbol`) - The type.

## Returns
True if the input is a valid piping rise/drop symbol type, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

