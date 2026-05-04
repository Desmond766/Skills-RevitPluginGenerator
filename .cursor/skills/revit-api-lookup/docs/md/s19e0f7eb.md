---
kind: property
id: P:Autodesk.Revit.DB.FillPattern.IsValidObject
source: html/1810b45b-9f4a-e9c1-cde4-c1a70f03c1c2.htm
---
# Autodesk.Revit.DB.FillPattern.IsValidObject Property

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

