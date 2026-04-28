---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFC.GetMaterialIdForCurrentExportState
source: html/ea78908e-959b-dca9-06a2-abce0c4cef70.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFC.GetMaterialIdForCurrentExportState Method

This gets the material id that is associated with the element in the current export state.

## Syntax (C#)
```csharp
public ElementId GetMaterialIdForCurrentExportState()
```

## Returns
The material id.

## Remarks
Even though there could be several materials associated with the element (set during PushExportState()),
 unless the element has support for IfcMaterialLayerSet, IFC output will include only this one.

