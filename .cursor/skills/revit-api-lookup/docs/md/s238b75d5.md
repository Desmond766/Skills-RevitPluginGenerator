---
kind: property
id: P:Autodesk.Revit.DB.StdPostedWarning.IsValidObject
source: html/9f31d96d-434a-7bdc-59d3-3f5deef31681.htm
---
# Autodesk.Revit.DB.StdPostedWarning.IsValidObject Property

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

