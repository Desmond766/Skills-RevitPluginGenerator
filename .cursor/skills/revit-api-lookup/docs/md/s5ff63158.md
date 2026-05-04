---
kind: property
id: P:Autodesk.Revit.DB.EvaluatedParameter.IsValidObject
source: html/8202bf72-a9b4-0db1-5632-5a7ebb5791c5.htm
---
# Autodesk.Revit.DB.EvaluatedParameter.IsValidObject Property

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

