---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricSheet.IsUnobscuredInView(Autodesk.Revit.DB.View)
source: html/20c69421-426e-2f52-d8e2-0a808c12a036.htm
---
# Autodesk.Revit.DB.Structure.FabricSheet.IsUnobscuredInView Method

Checks if this fabric sheet is shown unobscured in a view.

## Syntax (C#)
```csharp
public bool IsUnobscuredInView(
	View view
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view element

## Returns
True if fabric sheet is shown unobscured, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This fabric sheet doesn't have valid visibility data.

