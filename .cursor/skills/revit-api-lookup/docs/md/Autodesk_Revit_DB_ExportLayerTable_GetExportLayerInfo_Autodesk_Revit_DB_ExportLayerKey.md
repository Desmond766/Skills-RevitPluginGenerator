---
kind: method
id: M:Autodesk.Revit.DB.ExportLayerTable.GetExportLayerInfo(Autodesk.Revit.DB.ExportLayerKey)
source: html/9f41769c-080a-620e-2d68-828b27aa3565.htm
---
# Autodesk.Revit.DB.ExportLayerTable.GetExportLayerInfo Method

Gets a copy of the layer info associated to the input pattern key.

## Syntax (C#)
```csharp
public ExportLayerInfo GetExportLayerInfo(
	ExportLayerKey exportLayerKey
)
```

## Parameters
- **exportLayerKey** (`Autodesk.Revit.DB.ExportLayerKey`) - The export layer Key.

## Returns
Return the layerInfo for this key.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - An entry with the given key is not present in the table.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

