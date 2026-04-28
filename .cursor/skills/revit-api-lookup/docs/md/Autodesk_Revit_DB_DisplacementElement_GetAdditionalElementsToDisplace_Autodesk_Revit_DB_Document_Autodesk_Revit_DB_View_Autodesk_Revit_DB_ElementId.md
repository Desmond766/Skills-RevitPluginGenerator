---
kind: method
id: M:Autodesk.Revit.DB.DisplacementElement.GetAdditionalElementsToDisplace(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.View,Autodesk.Revit.DB.ElementId)
source: html/97d02f11-7308-579c-031a-5102dc40ae4f.htm
---
# Autodesk.Revit.DB.DisplacementElement.GetAdditionalElementsToDisplace Method

Identify a set of elements that potentially should be displaced along with a given element.

## Syntax (C#)
```csharp
public static ICollection<ElementId> GetAdditionalElementsToDisplace(
	Document document,
	View view,
	ElementId idToDisplace
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - the document
- **view** (`Autodesk.Revit.DB.View`) - the view
- **idToDisplace** (`Autodesk.Revit.DB.ElementId`) - element id of element to displace

## Remarks
For example, when a wall is displaced, any inserts or hosted elements should
 also be displaced.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

