---
kind: property
id: P:Autodesk.Revit.DB.DirectShapeTypeOptions.IsValidObject
source: html/8d072240-03dc-efb4-2f38-1bfa512c6d4e.htm
---
# Autodesk.Revit.DB.DirectShapeTypeOptions.IsValidObject Property

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

