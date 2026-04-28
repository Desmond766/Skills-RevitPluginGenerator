---
kind: method
id: M:Autodesk.Revit.DB.FamilyInstance.Split(System.Double)
zh: 拆分、打断、分割
source: html/8f32a065-ba3c-79c7-8141-63183b4cdece.htm
---
# Autodesk.Revit.DB.FamilyInstance.Split Method

**中文**: 拆分、打断、分割

Splits the family instance element at a point on its defining curve.

## Syntax (C#)
```csharp
public ElementId Split(
	double param
)
```

## Parameters
- **param** (`System.Double`) - The normalized parameter value along the element (should be greater than 0 and less than 1).

## Returns
The newly created family instance id.

## Remarks
Splitting is permitted for architectural and structural columns, beams and braces. Beams and braces that are not a line or an arc is not permitted. See CanSplit to determine if the family instance is allowed to be split by this method. Splitting modifies this family instance and adds a second family instance to the model.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when parameter is out of range.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the family instance element cannot be split.

