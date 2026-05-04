---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.SetStripedRowsColor(Autodesk.Revit.DB.StripedRowPattern,Autodesk.Revit.DB.Color)
zh: 明细表
source: html/abd4da91-103e-cd08-e03f-1150679ee65a.htm
---
# Autodesk.Revit.DB.ViewSchedule.SetStripedRowsColor Method

**中文**: 明细表

Sets the color applied to part of the pattern for a schedule with striped rows.

## Syntax (C#)
```csharp
public void SetStripedRowsColor(
	StripedRowPattern index,
	Color color
)
```

## Parameters
- **index** (`Autodesk.Revit.DB.StripedRowPattern`) - The part of the striped row pattern.
- **color** (`Autodesk.Revit.DB.Color`) - The color which will be used in striped row pattern.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

