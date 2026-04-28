---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.SplitStraight(Autodesk.Revit.DB.XYZ)
source: html/0815006b-c24c-56f7-2781-ac01d1bc6ad6.htm
---
# Autodesk.Revit.DB.FabricationPart.SplitStraight Method

Splits the straight into two at the passed in point.

## Syntax (C#)
```csharp
public ElementId SplitStraight(
	XYZ position
)
```

## Parameters
- **position** (`Autodesk.Revit.DB.XYZ`) - The position to split in the straight.

## Returns
Returns the element identifier of the new straight.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The position is not on the straight.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The part is not a straight.

