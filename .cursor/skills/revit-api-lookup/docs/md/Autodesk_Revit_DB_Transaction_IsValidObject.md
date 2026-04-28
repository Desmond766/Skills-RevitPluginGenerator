---
kind: property
id: P:Autodesk.Revit.DB.Transaction.IsValidObject
zh: 事务
source: html/80f24fab-a66b-7bf9-949c-1fbaa360c79d.htm
---
# Autodesk.Revit.DB.Transaction.IsValidObject Property

**中文**: 事务

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

