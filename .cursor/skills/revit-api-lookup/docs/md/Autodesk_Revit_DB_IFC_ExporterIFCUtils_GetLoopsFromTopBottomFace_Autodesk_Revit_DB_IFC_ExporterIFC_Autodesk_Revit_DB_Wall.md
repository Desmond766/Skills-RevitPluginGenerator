---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetLoopsFromTopBottomFace(Autodesk.Revit.DB.IFC.ExporterIFC,Autodesk.Revit.DB.Wall)
source: html/258cf165-0148-2e66-3d06-17669b41a3c6.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetLoopsFromTopBottomFace Method

Gets the curve loop(s) that represent the bottom or top face of the wall, usable to create an extrusion for the wall geometry.

## Syntax (C#)
```csharp
public static IList<CurveLoop> GetLoopsFromTopBottomFace(
	ExporterIFC exporterIFC,
	Wall wall
)
```

## Parameters
- **exporterIFC** (`Autodesk.Revit.DB.IFC.ExporterIFC`) - The exporter.
- **wall** (`Autodesk.Revit.DB.Wall`) - The wall.

## Returns
The curve loops. If the function has failed, this collection will be empty.

## Remarks
This function is intended to help determine if a Revit Wall can be exported as an IfcWallStandardCase. The conditions for
 exporting an IfcWallStandardCase require that the geometry of the wall be described as one profile curve loop extruded in the
 Z direction, with potential clip planes and openings applied to the base geometry. This function will use either the top
 or bottom face to determine the boundary curve loop. Regardless of whether the top or bottom face is used, the curve loop
 will be located on the plane corresponding to the base of the wall.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

