---
kind: method
id: M:Autodesk.Revit.DB.DetailElementOrderUtils.GetDrawOrderForDetails(Autodesk.Revit.DB.View,System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId})
source: html/686020d6-9ca3-c51f-47fc-a54438e3f608.htm
---
# Autodesk.Revit.DB.DetailElementOrderUtils.GetDrawOrderForDetails Method

Returns the given detail elements according to the currently specified draw order for the detail elements in a given view.

## Syntax (C#)
```csharp
public static IList<ElementId> GetDrawOrderForDetails(
	View view,
	ISet<ElementId> detailIdsToSort
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view in which the details appear.
- **detailIdsToSort** (`System.Collections.Generic.ISet < ElementId >`) - The detail to be sorted by draw order.

## Returns
The detail ids sorted from back to front, with earlier elements drawing first and appearing under later elements.

## Remarks
The sort order is from back to front, with earlier elements drawing first and appearing under later elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The document does not support detail draw order. Only projects and 3d families support draw order. 2d families and in-place families do not support draw order.
 -or-
 detailIdsToSort is empty or it contains elements are not visible in the view.
 -or-
 detailIdsToSort is empty or it contains elements that do not participate in detail draw ordering. Details must be visible in the view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

