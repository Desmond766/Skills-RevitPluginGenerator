---
kind: property
id: P:Autodesk.Revit.DB.FailureMessageKey.IsValidObject
source: html/09f98c70-1005-329f-e7fa-14c8d51ff38f.htm
---
# Autodesk.Revit.DB.FailureMessageKey.IsValidObject Property

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

