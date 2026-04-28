---
kind: property
id: P:Autodesk.Revit.DB.FormulaManager.IsValidObject
source: html/149b97e3-63e7-54de-51aa-24f21177872b.htm
---
# Autodesk.Revit.DB.FormulaManager.IsValidObject Property

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

