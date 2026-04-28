---
kind: method
id: M:Autodesk.Revit.DB.ExternallyTaggedGeometryValidation.IsValidGeometry(Autodesk.Revit.DB.GeometryObject)
source: html/63913e9f-7848-7fd3-23d4-5c7b0b3756dd.htm
---
# Autodesk.Revit.DB.ExternallyTaggedGeometryValidation.IsValidGeometry Method

Validates the input geometry to be stored in an externally tagged geometry object.
 Valid types of geometry are: Solid, Mesh, GeometryInstance, Point and Curve.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This method is deprecated in Revit 2024 and may be removed in a later version of Revit. We suggest using validation methods provided by the Element which uses this geometry where available. For example, DirectShape.IsValidShape for a DirectShape should be used for DirectShapes.")]
public static bool IsValidGeometry(
	GeometryObject geometry
)
```

## Parameters
- **geometry** (`Autodesk.Revit.DB.GeometryObject`) - Geometry object to be validated.

## Returns
True if the supplied geometry object passes the validation criteria.

