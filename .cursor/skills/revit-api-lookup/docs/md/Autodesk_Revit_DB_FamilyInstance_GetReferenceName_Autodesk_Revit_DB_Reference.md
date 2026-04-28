---
kind: method
id: M:Autodesk.Revit.DB.FamilyInstance.GetReferenceName(Autodesk.Revit.DB.Reference)
zh: 族实例
source: html/aaf6b45c-9139-b984-b824-2888ca32a95a.htm
---
# Autodesk.Revit.DB.FamilyInstance.GetReferenceName Method

**中文**: 族实例

Gets the name of the reference plane in the family corresponding to the given family instance reference.

## Syntax (C#)
```csharp
public string GetReferenceName(
	Reference reference
)
```

## Parameters
- **reference** (`Autodesk.Revit.DB.Reference`) - The family instance reference.

## Returns
Returns the name of the reference plane in the family corresponding to the given family instance reference.
 If the reference doesn't correspond to a named reference plane, returns an empty string.

## Remarks
If the given family reference corresponds to a named reference plane in the instance's family, the name of that reference plane will be returned.
 Otherwise, an empty string will be returned.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

