---
kind: property
id: P:Autodesk.Revit.DB.FilteredElementIdIterator.IsValidObject
source: html/3f6d5b54-979e-fe9f-9a8d-c124fd15c411.htm
---
# Autodesk.Revit.DB.FilteredElementIdIterator.IsValidObject Property

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

