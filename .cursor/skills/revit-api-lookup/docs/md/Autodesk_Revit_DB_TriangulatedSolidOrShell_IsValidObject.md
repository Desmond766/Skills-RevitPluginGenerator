---
kind: property
id: P:Autodesk.Revit.DB.TriangulatedSolidOrShell.IsValidObject
source: html/a2a325d5-c83c-80c9-d9f9-79d98d0d4916.htm
---
# Autodesk.Revit.DB.TriangulatedSolidOrShell.IsValidObject Property

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

