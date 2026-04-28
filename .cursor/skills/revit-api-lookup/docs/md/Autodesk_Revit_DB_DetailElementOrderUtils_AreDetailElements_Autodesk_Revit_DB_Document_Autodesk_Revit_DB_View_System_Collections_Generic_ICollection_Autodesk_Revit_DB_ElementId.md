---
kind: method
id: M:Autodesk.Revit.DB.DetailElementOrderUtils.AreDetailElements(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.View,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/950de8f3-daa2-1023-eb83-cd0695ebb565.htm
---
# Autodesk.Revit.DB.DetailElementOrderUtils.AreDetailElements Method

Indicates if the elements are all detail elements that participate in detail draw ordering in the view.

## Syntax (C#)
```csharp
public static bool AreDetailElements(
	Document document,
	View view,
	ICollection<ElementId> detailElementIds
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **view** (`Autodesk.Revit.DB.View`) - The view in which the details appear.
- **detailElementIds** (`System.Collections.Generic.ICollection < ElementId >`) - The details to check.

## Returns
True if the detail elements are orderable in the view, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

