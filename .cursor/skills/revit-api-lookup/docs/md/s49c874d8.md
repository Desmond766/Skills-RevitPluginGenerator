---
kind: property
id: P:Autodesk.Revit.DB.CurveLoop.IsValidObject
source: html/32444567-8b25-6cce-f0de-2bedf9f2da2e.htm
---
# Autodesk.Revit.DB.CurveLoop.IsValidObject Property

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

