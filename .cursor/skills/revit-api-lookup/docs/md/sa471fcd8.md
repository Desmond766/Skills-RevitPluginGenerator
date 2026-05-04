---
kind: property
id: P:Autodesk.Revit.DB.KeyBasedTreeEntriesIterator.IsValidObject
source: html/59637b76-e450-a569-054b-2f83b09490fb.htm
---
# Autodesk.Revit.DB.KeyBasedTreeEntriesIterator.IsValidObject Property

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

