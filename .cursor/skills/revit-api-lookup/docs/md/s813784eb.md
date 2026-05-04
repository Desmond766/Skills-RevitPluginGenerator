---
kind: property
id: P:Autodesk.Revit.DB.ParameterFilterRuleFactory.IsValidObject
source: html/c88fed60-40fe-ced5-79eb-1dbabe7690df.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.IsValidObject Property

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

