---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetUnscaledTransform(Autodesk.Revit.DB.IFC.ExporterIFC,Autodesk.Revit.DB.IFC.IFCAnyHandle)
source: html/7cbf9a51-b675-16a6-bcf8-87ff32f5a1b0.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetUnscaledTransform Method

Obtains the unscaled transform from an IfcLocalPlacement handle.

## Syntax (C#)
```csharp
public static Transform GetUnscaledTransform(
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

