---
kind: property
id: P:Autodesk.Revit.DB.DirectShapeReferenceOptions.IsValidObject
source: html/49b9a88d-2159-79e7-3b8e-44d0df3fbd39.htm
---
# Autodesk.Revit.DB.DirectShapeReferenceOptions.IsValidObject Property

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

