---
kind: method
id: M:Autodesk.Revit.DB.OverrideGraphicSettings.SetDetailLevel(Autodesk.Revit.DB.ViewDetailLevel)
source: html/ba8a7967-cb85-57fb-ebe9-1fc416e861c3.htm
---
# Autodesk.Revit.DB.OverrideGraphicSettings.SetDetailLevel Method

Sets the detail level.

## Syntax (C#)
```csharp
public OverrideGraphicSettings SetDetailLevel(
	ViewDetailLevel detailLevel
)
```

## Parameters
- **detailLevel** (`Autodesk.Revit.DB.ViewDetailLevel`) - Value of the detail level. ViewDetailLevel.Undefined means no override is set.

## Returns
Reference to the changed object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

