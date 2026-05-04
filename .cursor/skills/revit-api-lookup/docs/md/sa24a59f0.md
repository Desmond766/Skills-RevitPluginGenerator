---
kind: property
id: P:Autodesk.Revit.DB.LocationCurve.JoinType(System.Int32)
source: html/00b7a1a8-0e12-d02e-7e25-4716baf6dcdc.htm
---
# Autodesk.Revit.DB.LocationCurve.JoinType Property

Get/change the type of the join at the specified end.

## Syntax (C#)
```csharp
public JoinType this[
	int end
] { get; set; }
```

## Parameters
- **end** (`System.Int32`) - The end of the location curve driver under question.

## Remarks
This property allows to get join type of wall and concrete beam and to set wall's join type.
The new join type is expected to be different from the current one for this end.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The element is neither a wall nor a concrete beam when it tries to get the property.
The element is not a wall when it tries to set the property.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - A failure occurred while attempting to set the new type.

