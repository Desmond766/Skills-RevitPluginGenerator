---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricSheet.SetUnobscuredInView(Autodesk.Revit.DB.View,System.Boolean)
source: html/6df4a862-4a9b-1844-28d6-76076b8a8cdf.htm
---
# Autodesk.Revit.DB.Structure.FabricSheet.SetUnobscuredInView Method

Sets this fabric sheet to be shown unobscured in a view.

## Syntax (C#)
```csharp
public void SetUnobscuredInView(
	View view,
	bool unobscured
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view element
- **unobscured** (`System.Boolean`) - True if fabric sheet is shown unobscured, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This fabric sheet doesn't have valid visibility data.

