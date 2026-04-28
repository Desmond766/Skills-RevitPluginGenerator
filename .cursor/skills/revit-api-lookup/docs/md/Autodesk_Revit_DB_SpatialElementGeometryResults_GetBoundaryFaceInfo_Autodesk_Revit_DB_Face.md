---
kind: method
id: M:Autodesk.Revit.DB.SpatialElementGeometryResults.GetBoundaryFaceInfo(Autodesk.Revit.DB.Face)
source: html/85c61cf8-daa1-8aae-76c3-de8f100e9102.htm
---
# Autodesk.Revit.DB.SpatialElementGeometryResults.GetBoundaryFaceInfo Method

Query the spatial element boundary face information with the given face.

## Syntax (C#)
```csharp
public IList<SpatialElementBoundarySubface> GetBoundaryFaceInfo(
	Face face
)
```

## Parameters
- **face** (`Autodesk.Revit.DB.Face`) - The face from the spatial element's geometry.

## Returns
Sub-faces related to the room bounding elements that define the spatial element face. Returns Nothing nullptr a null reference ( Nothing in Visual Basic) if there is no corresponding boundary information with the given face.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

