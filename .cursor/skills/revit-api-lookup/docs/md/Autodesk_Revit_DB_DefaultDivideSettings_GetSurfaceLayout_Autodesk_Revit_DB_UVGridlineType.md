---
kind: method
id: M:Autodesk.Revit.DB.DefaultDivideSettings.GetSurfaceLayout(Autodesk.Revit.DB.UVGridlineType)
source: html/c30c0676-0174-f6b5-5c5b-3b7f9ade3ac6.htm
---
# Autodesk.Revit.DB.DefaultDivideSettings.GetSurfaceLayout Method

Gets the default Divided Surface layout for U or V gridlines.

## Syntax (C#)
```csharp
public SpacingRuleLayout GetSurfaceLayout(
	UVGridlineType gridlines
)
```

## Parameters
- **gridlines** (`Autodesk.Revit.DB.UVGridlineType`) - U-gridlines or V-gridlines.

## Returns
The layout spacing rule.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

