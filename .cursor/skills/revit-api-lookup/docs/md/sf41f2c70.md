---
kind: property
id: P:Autodesk.Revit.DB.WorksetTable.IsValidObject
source: html/1a3e7b93-8d83-ad16-f9a4-6cefb3ea4fcf.htm
---
# Autodesk.Revit.DB.WorksetTable.IsValidObject Property

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

