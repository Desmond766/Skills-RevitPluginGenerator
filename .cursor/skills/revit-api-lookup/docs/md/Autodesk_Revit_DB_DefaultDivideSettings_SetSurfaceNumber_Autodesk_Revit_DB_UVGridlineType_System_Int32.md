---
kind: method
id: M:Autodesk.Revit.DB.DefaultDivideSettings.SetSurfaceNumber(Autodesk.Revit.DB.UVGridlineType,System.Int32)
source: html/3d652d69-084c-3f2b-f966-e95760a6f038.htm
---
# Autodesk.Revit.DB.DefaultDivideSettings.SetSurfaceNumber Method

Sets the default Divided Surface number for a fixed number layout for U or V gridlines.

## Syntax (C#)
```csharp
public void SetSurfaceNumber(
	UVGridlineType gridlines,
	int number
)
```

## Parameters
- **gridlines** (`Autodesk.Revit.DB.UVGridlineType`) - U-gridlines or V-gridlines.
- **number** (`System.Int32`) - A default number for a fixed number layout.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for number is not positive.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration

