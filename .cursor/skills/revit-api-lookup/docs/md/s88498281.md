---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetOpeningData(Autodesk.Revit.DB.IFC.ExporterIFC,Autodesk.Revit.DB.Element,Autodesk.Revit.DB.Transform,Autodesk.Revit.DB.IFC.IFCRange)
source: html/4059efa7-87bd-5cb3-0b15-106aeb39f8e2.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetOpeningData Method

Gets the openings data from the element.

## Syntax (C#)
```csharp
public static IList<IFCOpeningData> GetOpeningData(
	ExporterIFC exporterIFC,
	Element element,
	Transform lcs,
	IFCRange range
)
```

## Parameters
- **exporterIFC** (`Autodesk.Revit.DB.IFC.ExporterIFC`) - The exporter.
- **element** (`Autodesk.Revit.DB.Element`) - The element.
- **lcs** (`Autodesk.Revit.DB.Transform`) - The local coordinate system for the extrusion.
- **range** (`Autodesk.Revit.DB.IFC.IFCRange`) - The range. This consists of two double values representing the height in Z at the start and the end
 of the range. If the values are identical the entire element is used.

## Returns
The opening data.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

