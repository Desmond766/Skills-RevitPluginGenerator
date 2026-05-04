---
kind: property
id: P:Autodesk.Revit.DB.LinkLoadResult.IsValidObject
source: html/e6a52e0e-9511-4286-f722-ab7db64d843d.htm
---
# Autodesk.Revit.DB.LinkLoadResult.IsValidObject Property

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

