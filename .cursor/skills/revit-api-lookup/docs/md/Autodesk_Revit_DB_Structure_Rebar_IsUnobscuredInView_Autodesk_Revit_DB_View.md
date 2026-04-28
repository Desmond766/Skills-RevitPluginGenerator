---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.IsUnobscuredInView(Autodesk.Revit.DB.View)
zh: 钢筋、配筋
source: html/f52f0fb5-9ab0-4650-62a4-ed9bf68e888f.htm
---
# Autodesk.Revit.DB.Structure.Rebar.IsUnobscuredInView Method

**中文**: 钢筋、配筋

Checks if this rebar element is shown unobscured in a view.

## Syntax (C#)
```csharp
public bool IsUnobscuredInView(
	View view
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view element

## Returns
True if rebar is shown unobscured, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This rebar element doesn't have valid visibility data.

