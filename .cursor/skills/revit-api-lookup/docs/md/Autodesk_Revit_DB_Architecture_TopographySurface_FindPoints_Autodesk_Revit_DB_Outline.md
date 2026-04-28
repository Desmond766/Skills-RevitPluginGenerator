---
kind: method
id: M:Autodesk.Revit.DB.Architecture.TopographySurface.FindPoints(Autodesk.Revit.DB.Outline)
source: html/b76317e1-c51f-8c51-28d4-e9488dc468d4.htm
---
# Autodesk.Revit.DB.Architecture.TopographySurface.FindPoints Method

Filters and returns only the points of the topography surface which lie within the input bounding box.

## Syntax (C#)
```csharp
public IList<XYZ> FindPoints(
	Outline boundingBox
)
```

## Parameters
- **boundingBox** (`Autodesk.Revit.DB.Outline`) - The 3D bounding box.

## Returns
The result points within the 3D bounding box

## Remarks
This applies to TopographySurface, SiteSubRegion, and the topography surface associated with a BuildingPad element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - boundingBox is an empty Outline.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

