---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFC.SetMaterialIdForCurrentExportState(Autodesk.Revit.DB.ElementId)
source: html/af494e73-5135-bd2b-8d71-389fa5be3ec7.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFC.SetMaterialIdForCurrentExportState Method

This sets the material id that is to be associated with the element in the current export state.

## Syntax (C#)
```csharp
public void SetMaterialIdForCurrentExportState(
	ElementId elementId
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - The material id.

## Remarks
Even though there could be several materials associated with the element (set during PushExportState()),
 unless the element has support for IfcMaterialLayerSet, IFC output will include only this one.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

