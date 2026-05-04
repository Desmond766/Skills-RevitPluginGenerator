---
kind: property
id: P:Autodesk.Revit.DB.RepeaterCoordinates.IsValidObject
source: html/e60e2d41-149b-e901-06f2-614a995c9da5.htm
---
# Autodesk.Revit.DB.RepeaterCoordinates.IsValidObject Property

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

