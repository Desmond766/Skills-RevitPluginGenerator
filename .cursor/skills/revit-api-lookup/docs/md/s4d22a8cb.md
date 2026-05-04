---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetUnscaledTransformWithoutFixOfDirection(Autodesk.Revit.DB.IFC.ExporterIFC,Autodesk.Revit.DB.IFC.IFCAnyHandle)
source: html/9472273c-9252-24ef-c37b-902fd5f0c702.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetUnscaledTransformWithoutFixOfDirection Method

Obtains the unscaled transform from an IfcLocalPlacement handle without fix of direction.

## Syntax (C#)
```csharp
public static Transform GetUnscaledTransformWithoutFixOfDirection(
	ExporterIFC exporterIFC,
	IFCAnyHandle placement
)
```

## Parameters
- **exporterIFC** (`Autodesk.Revit.DB.IFC.ExporterIFC`) - The exporter.
- **placement** (`Autodesk.Revit.DB.IFC.IFCAnyHandle`) - The placement handle.

## Returns
The transform.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

