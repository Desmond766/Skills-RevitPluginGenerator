---
kind: method
id: M:Autodesk.Revit.DB.DetailElementOrderUtils.SendBackward(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.View,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/0d971884-a987-7ca9-6e13-e7c9fe030109.htm
---
# Autodesk.Revit.DB.DetailElementOrderUtils.SendBackward Method

Moves the given detail instances one step closer to the back with relation to all other detail
 instances in the view, while keeping the order of the given ones.

## Syntax (C#)
```csharp
public static void SendBackward(
	Document document,
	View view,
	ICollection<ElementId> detailElementIds
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **view** (`Autodesk.Revit.DB.View`) - The view in which the details appear.
- **detailElementIds** (`System.Collections.Generic.ICollection < ElementId >`) - The details to move backward.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The document does not support detail draw order. Only projects and 3d families support draw order. 2d families and in-place families do not support draw order.
 -or-
 detailElementIds is empty or it contains elements that do not participate in detail draw ordering. Details must be visible in the view.
 -or-
 In 3d families, detail draw order can only be adjusted in views that are parallel to the document's X, Y or Z axes.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

