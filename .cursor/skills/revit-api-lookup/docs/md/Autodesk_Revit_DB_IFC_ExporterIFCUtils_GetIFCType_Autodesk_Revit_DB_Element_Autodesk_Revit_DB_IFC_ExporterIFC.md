---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetIFCType(Autodesk.Revit.DB.Element,Autodesk.Revit.DB.IFC.ExporterIFC)
source: html/a54a5913-b63a-0ff1-3c09-40fcc8cbd332.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetIFCType Method

Obtains the IFC type associated to the given element for the current export.

## Syntax (C#)
```csharp
public static string GetIFCType(
	Element element,
	ExporterIFC exporterIFC
)
```

## Parameters
- **element** (`Autodesk.Revit.DB.Element`) - The element.
- **exporterIFC** (`Autodesk.Revit.DB.IFC.ExporterIFC`) - The exporter.

## Returns
The IFC type. This is an empty string if the element should not be exported because it is not
 found in the mapping file.

## Remarks
IFC type names are affected by the user's entries in the mapping file set for a
 given export operation.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

