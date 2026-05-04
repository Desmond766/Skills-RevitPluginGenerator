---
kind: property
id: P:Autodesk.Revit.DB.FailureDefinitionAccessor.IsValidObject
source: html/57b0bc46-4830-b7ba-e3d2-82b88cd2d070.htm
---
# Autodesk.Revit.DB.FailureDefinitionAccessor.IsValidObject Property

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

