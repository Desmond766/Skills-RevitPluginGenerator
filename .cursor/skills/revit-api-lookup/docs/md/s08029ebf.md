---
kind: property
id: P:Autodesk.Revit.DB.Plumbing.PipePressureDropData.IsValidObject
source: html/cb69679b-84fa-f7de-b95e-b119df189b5a.htm
---
# Autodesk.Revit.DB.Plumbing.PipePressureDropData.IsValidObject Property

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

