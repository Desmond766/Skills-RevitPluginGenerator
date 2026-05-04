---
kind: method
id: M:Autodesk.Revit.DB.Element.GetGeneratingElementIds(Autodesk.Revit.DB.GeometryObject)
zh: 构件、图元、元素
source: html/112590d2-de20-dd1f-ae05-df7dfb3b410f.htm
---
# Autodesk.Revit.DB.Element.GetGeneratingElementIds Method

**中文**: 构件、图元、元素

Returns the ids of the element(s) that generated the input geometry object.

## Syntax (C#)
```csharp
public ICollection<ElementId> GetGeneratingElementIds(
	GeometryObject geometryObject
)
```

## Parameters
- **geometryObject** (`Autodesk.Revit.DB.GeometryObject`) - The geometry object whose generating element is requested.

## Returns
The id(s) of the element(s) that generated (or may have generated) the given geometry object. Empty if no generating elements are found. If the set contains just one id, it is the id of the element that generated the geometry object.

## Remarks
This function supports many different types of relationships among elements.
 Most of these relationships will return a single element, for example:
 Window and door cutting walls Openings cutting hosts Face splitting faces Wall sweep or reveal traversing wall 
 A few relationships have the potential for returning multiple elements, including:
 Walls joining to other wall(s) Elements extending to roof(s) 
 If more than one id is returned, one of them (unspecified) is the id of the element that generated the geometry object and the others are ids of related elements. For example, if a wall A is joined to two walls B and C in a way that creates two end faces, and if this function is called for one of the two end faces, it will return the ids of walls B and C.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input geometryObject is invalid and so cannot be used to obtain the generating element ids.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

