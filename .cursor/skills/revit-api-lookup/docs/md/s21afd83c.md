---
kind: method
id: M:Autodesk.Revit.DB.DefaultDivideSettings.SetSurfaceDistance(Autodesk.Revit.DB.UVGridlineType,System.Double)
source: html/d9f9b486-3b4c-7ac6-5e9d-9068960708ac.htm
---
# Autodesk.Revit.DB.DefaultDivideSettings.SetSurfaceDistance Method

Sets the default Divided Surface distance for a fixed, minimum, or maximum distance layout for U or V gridlines.

## Syntax (C#)
```csharp
public void SetSurfaceDistance(
	UVGridlineType gridlines,
	double distance
)
```

## Parameters
- **gridlines** (`Autodesk.Revit.DB.UVGridlineType`) - U-gridlines or V-gridlines.
- **distance** (`System.Double`) - A default distance for a layout.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for distance must be positive.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration

