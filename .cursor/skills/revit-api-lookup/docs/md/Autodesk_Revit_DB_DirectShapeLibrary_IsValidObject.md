---
kind: property
id: P:Autodesk.Revit.DB.DirectShapeLibrary.IsValidObject
source: html/8fd1e459-6ca9-eb04-b9a5-c6dcf6478c45.htm
---
# Autodesk.Revit.DB.DirectShapeLibrary.IsValidObject Property

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

