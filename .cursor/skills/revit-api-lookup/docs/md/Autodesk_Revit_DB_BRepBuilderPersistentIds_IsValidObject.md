---
kind: property
id: P:Autodesk.Revit.DB.BRepBuilderPersistentIds.IsValidObject
source: html/e0360a5c-0c10-36fe-c53f-65ec6022a5e8.htm
---
# Autodesk.Revit.DB.BRepBuilderPersistentIds.IsValidObject Property

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

