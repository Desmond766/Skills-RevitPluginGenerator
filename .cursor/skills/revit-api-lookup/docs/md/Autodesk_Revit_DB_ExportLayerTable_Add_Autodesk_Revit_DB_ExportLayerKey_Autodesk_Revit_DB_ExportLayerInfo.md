---
kind: method
id: M:Autodesk.Revit.DB.ExportLayerTable.Add(Autodesk.Revit.DB.ExportLayerKey,Autodesk.Revit.DB.ExportLayerInfo)
source: html/fd422c8b-041f-7cd6-0362-877c13e73a58.htm
---
# Autodesk.Revit.DB.ExportLayerTable.Add Method

Inserts a (key,info) pair into Export layer table.

## Syntax (C#)
```csharp
public void Add(
	ExportLayerKey exportLayerKey,
	ExportLayerInfo exportLayerInfo
)
```

## Parameters
- **exportLayerKey** (`Autodesk.Revit.DB.ExportLayerKey`) - The export layer key to be added.
- **exportLayerInfo** (`Autodesk.Revit.DB.ExportLayerInfo`) - The export layer info to be added.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The key already exists in the table.
 -or-
 The layer info does not contain the Category as a modifier type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

