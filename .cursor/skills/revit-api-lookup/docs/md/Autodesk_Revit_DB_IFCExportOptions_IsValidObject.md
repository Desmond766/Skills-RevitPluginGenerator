---
kind: property
id: P:Autodesk.Revit.DB.IFCExportOptions.IsValidObject
source: html/234a6c8a-1be1-61ef-4303-8d8c3c37800d.htm
---
# Autodesk.Revit.DB.IFCExportOptions.IsValidObject Property

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

