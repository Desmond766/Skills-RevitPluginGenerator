---
kind: property
id: P:Autodesk.Revit.DB.CurveByPointsUtils.IsValidObject
source: html/ad138805-d5e2-990b-6938-f1e55da18c42.htm
---
# Autodesk.Revit.DB.CurveByPointsUtils.IsValidObject Property

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

