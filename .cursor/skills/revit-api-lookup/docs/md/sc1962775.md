---
kind: method
id: M:Autodesk.Revit.DB.DefaultDivideSettings.GetSurfaceNumber(Autodesk.Revit.DB.UVGridlineType)
source: html/d31775cf-ad0c-26d3-60b4-1e90f5663d2d.htm
---
# Autodesk.Revit.DB.DefaultDivideSettings.GetSurfaceNumber Method

Gets the default Divided Surface number for a fixed number layout for U or V gridlines.

## Syntax (C#)
```csharp
public int GetSurfaceNumber(
	UVGridlineType gridlines
)
```

## Parameters
- **gridlines** (`Autodesk.Revit.DB.UVGridlineType`) - U-gridlines or V-gridlines.

## Returns
The default number for a fixed number layout.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

