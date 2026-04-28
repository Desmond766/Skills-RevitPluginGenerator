---
kind: property
id: P:Autodesk.Revit.DB.OpenOptions.IgnoreExtensibleStorageSchemaConflict
source: html/b6ae0ea0-b55d-ffa8-44a5-b5a5b320d74a.htm
---
# Autodesk.Revit.DB.OpenOptions.IgnoreExtensibleStorageSchemaConflict Property

Specifies whether to ignore the error of schema conflict.

## Syntax (C#)
```csharp
public bool IgnoreExtensibleStorageSchemaConflict { get; set; }
```

## Remarks
The default is false. Setting this to true will ignore the exception of schema conflict while opening the model.
 Data in the existing schema with the same ID will be erased from the model.

