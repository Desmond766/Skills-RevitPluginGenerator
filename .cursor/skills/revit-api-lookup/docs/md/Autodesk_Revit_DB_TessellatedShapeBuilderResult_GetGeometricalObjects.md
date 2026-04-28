---
kind: method
id: M:Autodesk.Revit.DB.TessellatedShapeBuilderResult.GetGeometricalObjects
source: html/3c5c4efb-8960-869f-76c0-338979e5a484.htm
---
# Autodesk.Revit.DB.TessellatedShapeBuilderResult.GetGeometricalObjects Method

When called the first time, returns geometrical objects which were built.
 Later calls will throw exceptions.

## Syntax (C#)
```csharp
public IList<GeometryObject> GetGeometricalObjects()
```

## Returns
Geometrical object which were built.

## Remarks
Normally an array contains a single geometrical object
 corresponding to either 'target' or 'fallback' type', but if
 multiple face sets are being built with target/fallback of "AnyGeometry/Mesh",
 then a two-element array with both geometry as the 1st element and mesh
 as the 2nd can be returned. It happens if some of the face sets require a
 fallback processing and some do not.

