---
kind: property
id: P:Autodesk.Revit.DB.BoundaryValidation.IsValidObject
source: html/f4be4313-5d88-58ba-5f10-e2e5ca2d1d83.htm
---
# Autodesk.Revit.DB.BoundaryValidation.IsValidObject Property

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

