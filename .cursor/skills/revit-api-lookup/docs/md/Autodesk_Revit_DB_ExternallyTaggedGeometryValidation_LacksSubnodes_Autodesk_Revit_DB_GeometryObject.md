---
kind: method
id: M:Autodesk.Revit.DB.ExternallyTaggedGeometryValidation.LacksSubnodes(Autodesk.Revit.DB.GeometryObject)
source: html/50abbc6b-cbed-bedd-b293-1ecbf1613b7f.htm
---
# Autodesk.Revit.DB.ExternallyTaggedGeometryValidation.LacksSubnodes Method

Makes sure that the input geometry object does not have sub-nodes.

## Syntax (C#)
```csharp
public static bool LacksSubnodes(
	GeometryObject geometry
)
```

## Parameters
- **geometry** (`Autodesk.Revit.DB.GeometryObject`) - Geometry object to be validated.

## Returns
True if the supplied geometry object does not have sub-nodes.

