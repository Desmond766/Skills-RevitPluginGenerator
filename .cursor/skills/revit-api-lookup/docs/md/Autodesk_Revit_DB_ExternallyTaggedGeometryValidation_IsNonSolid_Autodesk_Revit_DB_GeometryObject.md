---
kind: method
id: M:Autodesk.Revit.DB.ExternallyTaggedGeometryValidation.IsNonSolid(Autodesk.Revit.DB.GeometryObject)
source: html/73901181-dc33-8d85-c2ae-f05afc7402bf.htm
---
# Autodesk.Revit.DB.ExternallyTaggedGeometryValidation.IsNonSolid Method

Makes sure that the input geometry object is not a Solid.

## Syntax (C#)
```csharp
public static bool IsNonSolid(
	GeometryObject geometry
)
```

## Parameters
- **geometry** (`Autodesk.Revit.DB.GeometryObject`) - Geometry object to be validated.

## Returns
True if the supplied geometry object is not a Solid.

## Remarks
This validation is different than negating IsSolid().

