---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetIFCClassName(Autodesk.Revit.DB.Element,Autodesk.Revit.DB.IFC.ExporterIFC)
source: html/5e07799e-4653-46e3-5e0c-ded9c7f812ee.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetIFCClassName Method

Obtains the IFC class name associated to the given element for the current export.

## Syntax (C#)
```csharp
public static string GetIFCClassName(
	Element element,
	ExporterIFC exporterIFC
)
```

## Parameters
- **element** (`Autodesk.Revit.DB.Element`) - The element.
- **exporterIFC** (`Autodesk.Revit.DB.IFC.ExporterIFC`) - The exporter.

## Returns
The IFC class name. This is an empty string if the element should not be exported because it is not
 found in the mapping file.

## Remarks
IFC class names are affected by the user's entries in the mapping file set for a
 given export operation.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

