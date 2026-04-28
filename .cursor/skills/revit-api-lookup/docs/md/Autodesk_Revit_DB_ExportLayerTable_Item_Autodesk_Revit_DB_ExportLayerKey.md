---
kind: property
id: P:Autodesk.Revit.DB.ExportLayerTable.Item(Autodesk.Revit.DB.ExportLayerKey)
source: html/60b9e640-022f-70f5-ae9e-7d970cc77f07.htm
---
# Autodesk.Revit.DB.ExportLayerTable.Item Property

A copy of the ExportLayerInfo item that corresponds to the layer's
 ExportLayerKey .

## Syntax (C#)
```csharp
public ExportLayerInfo this[
	ExportLayerKey layerKey
] { get; set; }
```

## Parameters
- **layerKey** (`Autodesk.Revit.DB.ExportLayerKey`)

## Returns
A copy of the ExportLayerInfo for the layer Key.

## Remarks
When getting this property, it returns a copy of the ExportLayerInfo from the table. In order to
 make changes to the ExportLayerInfo and use those settings during export, set the modified
 ExportLayerInfo back into the table using the same key.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When getting this property:
 An entry with the given key is not present in the table.

