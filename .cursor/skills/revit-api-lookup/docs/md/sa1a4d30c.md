---
kind: property
id: P:Autodesk.Revit.DB.ColorWithTransparency.IsValidObject
source: html/6960f314-a4a1-d908-8929-d01985ae948b.htm
---
# Autodesk.Revit.DB.ColorWithTransparency.IsValidObject Property

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

