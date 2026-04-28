---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetRelativeLocalPlacementOffsetTransform(Autodesk.Revit.DB.IFC.IFCAnyHandle,Autodesk.Revit.DB.IFC.IFCAnyHandle)
source: html/996ef37e-50a6-0572-a4cd-505e389de16d.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetRelativeLocalPlacementOffsetTransform Method

Obtains the relative transform between two IfcLocalPlacement handles.

## Syntax (C#)
```csharp
public static Transform GetRelativeLocalPlacementOffsetTransform(
	IFCAnyHandle originalPlacement,
	IFCAnyHandle relativePlacement
)
```

## Parameters
- **originalPlacement** (`Autodesk.Revit.DB.IFC.IFCAnyHandle`) - The original placement from which the result transforms coordinates and directions.
- **relativePlacement** (`Autodesk.Revit.DB.IFC.IFCAnyHandle`) - The relative placement to which the result transforms coordinates and directions.

## Returns
The transform from the original placement to the new placement.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

