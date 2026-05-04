---
kind: method
id: M:Autodesk.Revit.DB.GeometryObject.op_Equality(Autodesk.Revit.DB.GeometryObject,Autodesk.Revit.DB.GeometryObject)
source: html/5987b6a5-17db-af76-398d-e2498a6cf3bc.htm
---
# Autodesk.Revit.DB.GeometryObject.op_Equality Method

Determines whether two GeometryObjects are the same.

## Syntax (C#)
```csharp
public static bool operator ==(
	GeometryObject first,
	GeometryObject second
)
```

## Parameters
- **first** (`Autodesk.Revit.DB.GeometryObject`) - The first GeometryObject.
- **second** (`Autodesk.Revit.DB.GeometryObject`) - The second GeometryObject.

## Returns
True if the GeometryObjects are the same; otherwise, false.

## Remarks
This compares the internal identifiers of the geometry, and doesn't compare them geometrically.

