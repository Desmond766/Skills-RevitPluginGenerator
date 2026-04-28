---
kind: property
id: P:Autodesk.Revit.DB.WallSweepInfo.IsValidObject
source: html/32100d37-7fdc-a39d-9799-81d7922b7bd5.htm
---
# Autodesk.Revit.DB.WallSweepInfo.IsValidObject Property

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

