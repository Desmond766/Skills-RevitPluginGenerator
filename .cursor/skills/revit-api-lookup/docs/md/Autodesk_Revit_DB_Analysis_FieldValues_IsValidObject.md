---
kind: property
id: P:Autodesk.Revit.DB.Analysis.FieldValues.IsValidObject
source: html/6f6aeba1-11d9-3f47-f505-85832e2689da.htm
---
# Autodesk.Revit.DB.Analysis.FieldValues.IsValidObject Property

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

