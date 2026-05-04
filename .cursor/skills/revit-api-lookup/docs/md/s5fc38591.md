---
kind: property
id: P:Autodesk.Revit.DB.DirectShapeOptions.IsValidObject
source: html/e9dceaa3-878e-f221-ff43-66e6cf17a119.htm
---
# Autodesk.Revit.DB.DirectShapeOptions.IsValidObject Property

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

