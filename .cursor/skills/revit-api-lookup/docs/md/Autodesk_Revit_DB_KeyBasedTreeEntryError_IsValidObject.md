---
kind: property
id: P:Autodesk.Revit.DB.KeyBasedTreeEntryError.IsValidObject
source: html/3ad09fc7-03a8-8720-78f1-9dda95f99128.htm
---
# Autodesk.Revit.DB.KeyBasedTreeEntryError.IsValidObject Property

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

