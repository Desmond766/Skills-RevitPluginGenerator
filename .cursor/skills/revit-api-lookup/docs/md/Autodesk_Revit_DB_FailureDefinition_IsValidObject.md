---
kind: property
id: P:Autodesk.Revit.DB.FailureDefinition.IsValidObject
source: html/37f5b25d-ffed-10a0-f77b-8290d3a9c674.htm
---
# Autodesk.Revit.DB.FailureDefinition.IsValidObject Property

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

