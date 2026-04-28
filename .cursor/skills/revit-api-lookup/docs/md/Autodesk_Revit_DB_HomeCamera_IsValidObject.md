---
kind: property
id: P:Autodesk.Revit.DB.HomeCamera.IsValidObject
source: html/c7a1e7ed-6c22-6bc2-0fb2-82300ca31ee0.htm
---
# Autodesk.Revit.DB.HomeCamera.IsValidObject Property

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

