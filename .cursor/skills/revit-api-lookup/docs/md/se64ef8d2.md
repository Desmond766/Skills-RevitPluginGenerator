---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarCoupler.IsUnobscuredInView(Autodesk.Revit.DB.View)
source: html/55abcef4-e64e-4582-2ca3-d10b27102477.htm
---
# Autodesk.Revit.DB.Structure.RebarCoupler.IsUnobscuredInView Method

Checks if this rebar coupler element is shown unobscured in a view.

## Syntax (C#)
```csharp
public bool IsUnobscuredInView(
	View view
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view element

## Returns
True if rebar coupler is shown unobscured, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This rebar coupler element doesn't have valid visibility data

