---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainer.IsUnobscuredInView(Autodesk.Revit.DB.View)
source: html/1a9453cc-db8c-bbcf-dd6c-5380b809df09.htm
---
# Autodesk.Revit.DB.Structure.RebarContainer.IsUnobscuredInView Method

Checks if this rebar container element is shown unobscured in a view.

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
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This rebar container element doesn't have valid visibility data.

