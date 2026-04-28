---
kind: property
id: P:Autodesk.Revit.DB.Mechanical.DuctFittingAndAccessoryData.IsValidObject
source: html/fd6dd959-097d-38ce-2ce4-7295cb9f03bb.htm
---
# Autodesk.Revit.DB.Mechanical.DuctFittingAndAccessoryData.IsValidObject Property

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

