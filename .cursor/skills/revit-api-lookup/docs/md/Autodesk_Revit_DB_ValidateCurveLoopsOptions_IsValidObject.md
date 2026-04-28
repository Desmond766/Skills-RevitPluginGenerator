---
kind: property
id: P:Autodesk.Revit.DB.ValidateCurveLoopsOptions.IsValidObject
source: html/eb9dec30-96da-37c4-a24f-38f96832f52f.htm
---
# Autodesk.Revit.DB.ValidateCurveLoopsOptions.IsValidObject Property

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

