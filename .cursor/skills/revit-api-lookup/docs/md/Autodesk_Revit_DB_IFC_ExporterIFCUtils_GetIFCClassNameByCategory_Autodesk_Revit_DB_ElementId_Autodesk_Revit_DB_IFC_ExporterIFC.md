---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetIFCClassNameByCategory(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.IFC.ExporterIFC)
source: html/7fff2d3a-4175-f2be-4ccc-2f6c5768b38b.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetIFCClassNameByCategory Method

Obtains the IFC class name associated to a given category id for the current export.

## Syntax (C#)
```csharp
public static string GetIFCClassNameByCategory(
	ElementId catId,
	ExporterIFC exporterIFC
)
```

## Parameters
- **catId** (`Autodesk.Revit.DB.ElementId`) - The category id.
- **exporterIFC** (`Autodesk.Revit.DB.IFC.ExporterIFC`) - The exporter.

## Returns
The IFC class name. This is an empty string if the element should not be exported because it is not
 found in the mapping file.

## Remarks
IFC class names are affected by the user's entries in the mapping file set for a
 given export operation.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

