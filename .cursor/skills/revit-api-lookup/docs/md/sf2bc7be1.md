---
kind: method
id: M:Autodesk.Revit.DB.GeometryObject.op_Inequality(Autodesk.Revit.DB.GeometryObject,Autodesk.Revit.DB.GeometryObject)
source: html/9f3b7a8e-fb41-ec29-ace0-2d6287e3f09d.htm
---
# Autodesk.Revit.DB.GeometryObject.op_Inequality Method

Determines whether two GeometryObjects are different.

## Syntax (C#)
```csharp
public static bool operator !=(
	GeometryObject first,
	GeometryObject second
)
```

## Parameters
- **first** (`Autodesk.Revit.DB.GeometryObject`) - The first GeometryObject.
- **second** (`Autodesk.Revit.DB.GeometryObject`) - The second GeometryObject.

## Returns
True if the GeometryObjects are different; otherwise, false.

## Remarks
This compares the internal identifiers of the geometry, and doesn't compare them geometrically.

