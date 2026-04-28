---
kind: property
id: P:Autodesk.Revit.DB.Outline.IsValidObject
source: html/c11d11e9-7d8d-1966-68b1-f097a46383e4.htm
---
# Autodesk.Revit.DB.Outline.IsValidObject Property

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

