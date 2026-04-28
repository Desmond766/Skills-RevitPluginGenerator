---
kind: method
id: M:Autodesk.Revit.DB.SpatialElement.GetBoundarySegments(Autodesk.Revit.DB.SpatialElementBoundaryOptions)
source: html/8e0919af-6172-9d16-26d2-268e42f7e936.htm
---
# Autodesk.Revit.DB.SpatialElement.GetBoundarySegments Method

Returns the boundary segments.

## Syntax (C#)
```csharp
public IList<IList<BoundarySegment>> GetBoundarySegments(
	SpatialElementBoundaryOptions options
)
```

## Parameters
- **options** (`Autodesk.Revit.DB.SpatialElementBoundaryOptions`) - The SpatialElementBoundaryOptions.

## Remarks
This method is used to retrieve the segments that constitute the boundary of the spatial element.
Each spatial element may have several regions, each of which have several segments hence the data is returned
in the form of an array of boundary segment arrays. See the BoundarySegment object for more
details about the segments that make up the spatial element topology.

