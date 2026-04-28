---
kind: property
id: P:Autodesk.Revit.DB.KeyBasedTreeEntriesLoadResults.IsValidObject
source: html/0e2f2b47-487f-ecf2-b04e-0bb4b2ffd232.htm
---
# Autodesk.Revit.DB.KeyBasedTreeEntriesLoadResults.IsValidObject Property

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

