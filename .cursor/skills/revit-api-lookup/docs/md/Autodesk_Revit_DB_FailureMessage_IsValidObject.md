---
kind: property
id: P:Autodesk.Revit.DB.FailureMessage.IsValidObject
source: html/a70c53b1-c7e2-2531-2d57-562ae3fb75a6.htm
---
# Autodesk.Revit.DB.FailureMessage.IsValidObject Property

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

