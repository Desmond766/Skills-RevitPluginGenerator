---
kind: property
id: P:Autodesk.Revit.DB.Analysis.Polyloop.IsValidObject
source: html/3fee9c42-d6fe-80eb-afb9-a81578f8e184.htm
---
# Autodesk.Revit.DB.Analysis.Polyloop.IsValidObject Property

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

