---
kind: method
id: M:Autodesk.Revit.DB.DetailElementOrderUtils.BringToFront(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.View,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/b6cec4f5-c4ef-d4c6-cdb8-1e92997e019c.htm
---
# Autodesk.Revit.DB.DetailElementOrderUtils.BringToFront Method

Places the given detail instances in the front of all other detail instances in the view, while
 keeping the order of the given ones.

## Syntax (C#)
```csharp
public static void BringToFront(
	Document document,
	View view,
	ICollection<ElementId> detailElementIds
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **view** (`Autodesk.Revit.DB.View`) - The view in which the details appear.
- **detailElementIds** (`System.Collections.Generic.ICollection < ElementId >`) - The details to bring to front.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The document does not support detail draw order. Only projects and 3d families support draw order. 2d families and in-place families do not support draw order.
 -or-
 detailElementIds is empty or it contains elements that do not participate in detail draw ordering. Details must be visible in the view.
 -or-
 In 3d families, detail draw order can only be adjusted in views that are parallel to the document's X, Y or Z axes.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

