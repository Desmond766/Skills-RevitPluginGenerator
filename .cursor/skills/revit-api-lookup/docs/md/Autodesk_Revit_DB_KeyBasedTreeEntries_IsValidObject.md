---
kind: property
id: P:Autodesk.Revit.DB.KeyBasedTreeEntries.IsValidObject
source: html/5670a5b6-8538-3bfd-a1c9-2c6f44874939.htm
---
# Autodesk.Revit.DB.KeyBasedTreeEntries.IsValidObject Property

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

