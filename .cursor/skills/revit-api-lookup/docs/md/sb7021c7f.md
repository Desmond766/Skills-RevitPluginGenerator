---
kind: property
id: P:Autodesk.Revit.DB.ExportLineweightKey.IsValidObject
source: html/2e2c9b3e-1c6a-43ef-d5e8-ab9aa88419c4.htm
---
# Autodesk.Revit.DB.ExportLineweightKey.IsValidObject Property

Specifies whether the .NET object represents a valid Revit entity.

## Syntax (C#)
```csharp
public bool IsValidObject { get; }
```

## Returns
True if the API object holds a valid Revit native object, false otherwise.

## Remarks
If the corresponding Revit native object is destroyed, or creation of the corresponding object is undone,
 a managed API object containing it is no longer valid. API methods cannot be called on invalidated wrapper objects.

