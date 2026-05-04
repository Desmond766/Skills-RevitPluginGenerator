---
kind: property
id: P:Autodesk.Revit.DB.DuplicateTypeNamesHandlerArgs.IsValidObject
source: html/77ab6680-ae2b-e994-9c65-3b4b9d11d243.htm
---
# Autodesk.Revit.DB.DuplicateTypeNamesHandlerArgs.IsValidObject Property

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

