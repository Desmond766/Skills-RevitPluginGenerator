---
kind: method
id: M:Autodesk.Revit.DB.DefaultDivideSettings.SetSurfaceLayout(Autodesk.Revit.DB.UVGridlineType,Autodesk.Revit.DB.SpacingRuleLayout)
source: html/5555599e-ce36-8558-2120-aff759855072.htm
---
# Autodesk.Revit.DB.DefaultDivideSettings.SetSurfaceLayout Method

Sets the default Divided Surface layout for U or V gridlines.

## Syntax (C#)
```csharp
public void SetSurfaceLayout(
	UVGridlineType gridlines,
	SpacingRuleLayout layout
)
```

## Parameters
- **gridlines** (`Autodesk.Revit.DB.UVGridlineType`) - U-gridlines or V-gridlines.
- **layout** (`Autodesk.Revit.DB.SpacingRuleLayout`) - A layout spacing rule.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

