---
kind: property
id: P:Autodesk.Revit.DB.TriangleInShellComponent.IsValidObject
source: html/0e2825ae-fb2c-3a95-64c4-231ffe2df79c.htm
---
# Autodesk.Revit.DB.TriangleInShellComponent.IsValidObject Property

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

