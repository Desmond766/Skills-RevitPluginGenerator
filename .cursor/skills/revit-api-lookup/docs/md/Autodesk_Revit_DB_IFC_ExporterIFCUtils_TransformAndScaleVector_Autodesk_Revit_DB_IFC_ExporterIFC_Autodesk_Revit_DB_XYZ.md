---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.TransformAndScaleVector(Autodesk.Revit.DB.IFC.ExporterIFC,Autodesk.Revit.DB.XYZ)
source: html/6622bd84-2aa2-6333-9e2b-3b9d9330267b.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.TransformAndScaleVector Method

Converts a vector from global Revit coordinates to current IFC coordinates, including scale.

## Syntax (C#)
```csharp
public static XYZ TransformAndScaleVector(
	ExporterIFC exporterIFC,
	XYZ origVector
)
```

## Parameters
- **exporterIFC** (`Autodesk.Revit.DB.IFC.ExporterIFC`) - The exporter.
- **origVector** (`Autodesk.Revit.DB.XYZ`) - The original vector.

## Returns
The transformed and scaled point.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

