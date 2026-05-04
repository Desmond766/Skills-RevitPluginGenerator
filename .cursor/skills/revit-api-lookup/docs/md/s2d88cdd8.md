---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetRoomBoundaryAsCurveLoopArray(Autodesk.Revit.DB.SpatialElement,Autodesk.Revit.DB.SpatialElementBoundaryOptions,System.Boolean)
source: html/b460e4ed-62c0-5611-16ba-a1bd9a85625a.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetRoomBoundaryAsCurveLoopArray Method

Obtains the spatial element boundary curves as an array of CurveLoops, needed for processing into IFC-specific
 elements later.

## Syntax (C#)
```csharp
public static IList<CurveLoop> GetRoomBoundaryAsCurveLoopArray(
	SpatialElement spatialElement,
	SpatialElementBoundaryOptions options,
	bool cleanCurves
)
```

## Parameters
- **spatialElement** (`Autodesk.Revit.DB.SpatialElement`) - The spatial element.
- **options** (`Autodesk.Revit.DB.SpatialElementBoundaryOptions`) - The options for extraction of the boundaries.
- **cleanCurves** (`System.Boolean`) - If true, curves will be trimmed to meet their neighbors. If false, no trimming will take place.

## Returns
The list of CurveLoops, which could be empty if the routine is unable to get the boundary curve loops.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Throws an exception if any of the boundary loops are invalid or degenerate.

