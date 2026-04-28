---
kind: property
id: P:Autodesk.Revit.DB.TemporaryGraphicsManager.IsValidObject
source: html/57dd1d67-b10f-579c-27bd-59d2d79bb106.htm
---
# Autodesk.Revit.DB.TemporaryGraphicsManager.IsValidObject Property

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

