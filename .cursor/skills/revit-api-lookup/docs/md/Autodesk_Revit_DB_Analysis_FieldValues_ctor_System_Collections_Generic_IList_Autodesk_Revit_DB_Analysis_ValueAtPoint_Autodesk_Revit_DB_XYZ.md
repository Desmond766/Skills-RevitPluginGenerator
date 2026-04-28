---
kind: method
id: M:Autodesk.Revit.DB.Analysis.FieldValues.#ctor(System.Collections.Generic.IList{Autodesk.Revit.DB.Analysis.ValueAtPoint},Autodesk.Revit.DB.XYZ)
source: html/ab58a81d-73dc-d663-c15c-e3f9bd50414a.htm
---
# Autodesk.Revit.DB.Analysis.FieldValues.#ctor Method

Creates object from an array of domain point values

## Syntax (C#)
```csharp
public FieldValues(
	IList<ValueAtPoint> valueAtPoint,
	XYZ unitDirection
)
```

## Parameters
- **valueAtPoint** (`System.Collections.Generic.IList < ValueAtPoint >`) - Array of values, each corresponding to a domain point
- **unitDirection** (`Autodesk.Revit.DB.XYZ`) - Unit vector that gives the same direction for values (for diagrams)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Members of valueAtPoint contain different numbers of measurements
 -or-
 unitDirection is not a unit vector
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

