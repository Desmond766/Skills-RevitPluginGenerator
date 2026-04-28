---
kind: property
id: P:Autodesk.Revit.DB.KeyBasedTreeEntry.IsValidObject
source: html/45dd48e4-2b94-5484-9050-d77a56d25f90.htm
---
# Autodesk.Revit.DB.KeyBasedTreeEntry.IsValidObject Property

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

