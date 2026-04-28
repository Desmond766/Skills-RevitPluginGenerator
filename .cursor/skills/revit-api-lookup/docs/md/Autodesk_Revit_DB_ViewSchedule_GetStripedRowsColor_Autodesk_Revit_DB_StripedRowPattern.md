---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.GetStripedRowsColor(Autodesk.Revit.DB.StripedRowPattern)
zh: 明细表
source: html/f5a5ab45-7989-2504-5d22-a0bf90886364.htm
---
# Autodesk.Revit.DB.ViewSchedule.GetStripedRowsColor Method

**中文**: 明细表

Gets the color applied to part of the pattern for a schedule with striped rows.

## Syntax (C#)
```csharp
public Color GetStripedRowsColor(
	StripedRowPattern index
)
```

## Parameters
- **index** (`Autodesk.Revit.DB.StripedRowPattern`) - The part of the striped row pattern.

## Returns
The applied color of the pattern part.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

