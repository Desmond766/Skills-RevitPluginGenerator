---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.TransformAndScalePoint(Autodesk.Revit.DB.IFC.ExporterIFC,Autodesk.Revit.DB.XYZ)
source: html/25b84abd-c524-c885-4898-d25d4559685e.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.TransformAndScalePoint Method

Converts a point from global Revit coordinates to current IFC coordinates, including scale.

## Syntax (C#)
```csharp
public static XYZ TransformAndScalePoint(
	ExporterIFC exporterIFC,
	XYZ origPt
)
```

## Parameters
- **exporterIFC** (`Autodesk.Revit.DB.IFC.ExporterIFC`) - The exporter.
- **origPt** (`Autodesk.Revit.DB.XYZ`) - The original point.

## Returns
The transformed and scaled point.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

