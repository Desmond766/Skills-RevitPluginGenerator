---
kind: method
id: M:Autodesk.Revit.DB.TessellatedShapeBuilder.CreateMeshByExtrusion(System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop},Autodesk.Revit.DB.XYZ,System.Double,Autodesk.Revit.DB.ElementId)
source: html/16bfff9e-b581-94b8-4797-cb880d79e793.htm
---
# Autodesk.Revit.DB.TessellatedShapeBuilder.CreateMeshByExtrusion Method

Builds a mesh by extruding curve loop(s) along extrusion distance.

## Syntax (C#)
```csharp
public static MeshFromGeometryOperationResult CreateMeshByExtrusion(
	IList<CurveLoop> profileLoops,
	XYZ extrusionDirection,
	double extrusionDistance,
	ElementId materialId
)
```

## Parameters
- **profileLoops** (`System.Collections.Generic.IList < CurveLoop >`) - The profile loops to be extruded. The loops will not be modified.
- **extrusionDirection** (`Autodesk.Revit.DB.XYZ`) - Direction of extrusion. The length of this vector is ignored.
- **extrusionDistance** (`System.Double`) - The positive distance by which the loops are extruded in the
 direction of the input extrusionDir.
- **materialId** (`Autodesk.Revit.DB.ElementId`) - Material which should be used by a constructed mesh.

## Returns
Returns a mesh, which was constructed, and some additional
 information.

## Remarks
This function supports creation of a mesh given a collection
 of continuous curve loops, which are processed independently
 from each other. Loops with gaps or with curves with
 wrong flips will be split before processing.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input value cannot be used as thickness for an extrusion,
 or blend, or wall layer, or similar geometric construct.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - extrusionDirection has zero length.

