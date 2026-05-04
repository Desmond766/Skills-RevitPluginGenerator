---
kind: property
id: P:Autodesk.Revit.DB.BooleanOperationsUtils.IsValidObject
source: html/05329d00-f876-aec4-13d4-8c1d7aa88333.htm
---
# Autodesk.Revit.DB.BooleanOperationsUtils.IsValidObject Property

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

