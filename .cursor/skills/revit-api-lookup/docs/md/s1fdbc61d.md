---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetNumBuildingStoreys(Autodesk.Revit.DB.IFC.ExporterIFC)
source: html/c6bdcbc0-4c99-237b-ea4d-a243d38b819a.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetNumBuildingStoreys Method

Returns the number of non-empty, non-duplicate building stories in the file.

## Syntax (C#)
```csharp
public static int GetNumBuildingStoreys(
	ExporterIFC exporterIFC
)
```

## Parameters
- **exporterIFC** (`Autodesk.Revit.DB.IFC.ExporterIFC`) - The exporter.

## Returns
The number of stories.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

