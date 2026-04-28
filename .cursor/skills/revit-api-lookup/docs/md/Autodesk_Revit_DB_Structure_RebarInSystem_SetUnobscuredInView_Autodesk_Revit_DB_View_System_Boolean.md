---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarInSystem.SetUnobscuredInView(Autodesk.Revit.DB.View,System.Boolean)
source: html/445262e9-8299-eedd-3cf0-2131d8791529.htm
---
# Autodesk.Revit.DB.Structure.RebarInSystem.SetUnobscuredInView Method

Sets RebarInSystem element to be shown unobscured in a view.

## Syntax (C#)
```csharp
public void SetUnobscuredInView(
	View view,
	bool unobscured
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view element
- **unobscured** (`System.Boolean`) - True if RebarInSystem element is shown unobscured, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This element doesn't have valid visibility data.

