---
kind: property
id: P:Autodesk.Revit.DB.ReferenceIntersector.IsValidObject
zh: 射线、射线相交
source: html/4c356722-e215-f7a3-1e4a-728e09229955.htm
---
# Autodesk.Revit.DB.ReferenceIntersector.IsValidObject Property

**中文**: 射线、射线相交

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

