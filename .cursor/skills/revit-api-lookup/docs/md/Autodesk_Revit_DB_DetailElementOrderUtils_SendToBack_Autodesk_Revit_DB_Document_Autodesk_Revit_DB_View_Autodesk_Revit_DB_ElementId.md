---
kind: method
id: M:Autodesk.Revit.DB.DetailElementOrderUtils.SendToBack(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.View,Autodesk.Revit.DB.ElementId)
source: html/28209b7b-e75e-36d9-f916-d1cdaebe051d.htm
---
# Autodesk.Revit.DB.DetailElementOrderUtils.SendToBack Method

Places the given detail instance behind all detail instances in the view.

## Syntax (C#)
```csharp
public static void SendToBack(
	Document document,
	View view,
	ElementId detailElementId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **view** (`Autodesk.Revit.DB.View`) - The view in which the detail appears.
- **detailElementId** (`Autodesk.Revit.DB.ElementId`) - The detail to send to back.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The document does not support detail draw order. Only projects and 3d families support draw order. 2d families and in-place families do not support draw order.
 -or-
 The element detailElementId is not a detail or it does not participate in detail draw ordering. Details must be visible in the view.
 -or-
 In 3d families, detail draw order can only be adjusted in views that are parallel to the document's X, Y or Z axes.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

