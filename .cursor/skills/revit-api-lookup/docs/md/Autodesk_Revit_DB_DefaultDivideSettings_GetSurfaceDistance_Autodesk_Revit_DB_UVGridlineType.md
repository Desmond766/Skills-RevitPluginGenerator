---
kind: method
id: M:Autodesk.Revit.DB.DefaultDivideSettings.GetSurfaceDistance(Autodesk.Revit.DB.UVGridlineType)
source: html/4eb288d9-3f40-0e3b-7264-358e02dad22e.htm
---
# Autodesk.Revit.DB.DefaultDivideSettings.GetSurfaceDistance Method

Gets the default Divided Surface distance for a fixed, minimum, or maximum distance layout for U or V gridlines.

## Syntax (C#)
```csharp
public double GetSurfaceDistance(
	UVGridlineType gridlines
)
```

## Parameters
- **gridlines** (`Autodesk.Revit.DB.UVGridlineType`) - U-gridlines or V-gridlines.

## Returns
The default distance for the layout.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

