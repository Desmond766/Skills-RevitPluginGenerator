---
kind: property
id: P:Autodesk.Revit.DB.LineSegment.IsValidObject
source: html/17545bd6-06d9-b18f-ccbf-af6649ffb4bd.htm
---
# Autodesk.Revit.DB.LineSegment.IsValidObject Property

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

