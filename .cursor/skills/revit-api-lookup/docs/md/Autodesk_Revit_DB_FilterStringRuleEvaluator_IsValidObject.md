---
kind: property
id: P:Autodesk.Revit.DB.FilterStringRuleEvaluator.IsValidObject
source: html/2681c5c1-e859-f664-316a-e3d9d3e6d6b1.htm
---
# Autodesk.Revit.DB.FilterStringRuleEvaluator.IsValidObject Property

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

