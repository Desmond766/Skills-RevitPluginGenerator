---
kind: property
id: P:Autodesk.Revit.DB.FaceSecondDerivatives.IsValidObject
source: html/5e20bb4b-adf0-cc84-8d2e-3e3139ea318c.htm
---
# Autodesk.Revit.DB.FaceSecondDerivatives.IsValidObject Property

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

