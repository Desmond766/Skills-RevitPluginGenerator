---
kind: property
id: P:Autodesk.Revit.DB.SolidCurveIntersection.IsValidObject
source: html/b86a385f-61b8-61b1-7bf0-e4885ee7b36c.htm
---
# Autodesk.Revit.DB.SolidCurveIntersection.IsValidObject Property

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

