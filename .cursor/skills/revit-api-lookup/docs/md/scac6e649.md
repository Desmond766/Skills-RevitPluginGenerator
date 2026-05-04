---
kind: method
id: M:Autodesk.Revit.DB.ExternallyTaggedGeometryValidation.IsSolid(Autodesk.Revit.DB.GeometryObject)
source: html/0390af11-c814-2949-9def-bdc53f3bd7cc.htm
---
# Autodesk.Revit.DB.ExternallyTaggedGeometryValidation.IsSolid Method

Makes sure that the input geometry object is a Solid.

## Syntax (C#)
```csharp
public static bool IsSolid(
	GeometryObject geometry
)
```

## Parameters
- **geometry** (`Autodesk.Revit.DB.GeometryObject`) - Geometry object to be validated.

## Returns
True if the supplied geometry object is a Solid.

## Remarks
This validation is different than negating IsNonSolid().

