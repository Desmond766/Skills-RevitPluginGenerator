---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFC.AddBuildingStorey(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.IFC.IFCLevelInfo)
source: html/08c5605c-b66f-baae-5684-d9dc7cf7121a.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFC.AddBuildingStorey Method

Adds building storey to the exporter's internal cache.

## Syntax (C#)
```csharp
public void AddBuildingStorey(
	ElementId id,
	IFCLevelInfo levelInfo
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.ElementId`) - The level id.
- **levelInfo** (`Autodesk.Revit.DB.IFC.IFCLevelInfo`) - The IFCLevelInfo object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

