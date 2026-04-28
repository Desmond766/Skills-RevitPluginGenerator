---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinition.CheckDefaultParameterValues(System.Double,System.Double)
source: html/12f60994-60cf-edad-41a0-f8a8b233f75c.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinition.CheckDefaultParameterValues Method

Check that the shape can be solved with the default parameter values.

## Syntax (C#)
```csharp
public bool CheckDefaultParameterValues(
	double bendRadius,
	double barDiameter
)
```

## Parameters
- **bendRadius** (`System.Double`) - A value for the Bend Radius parameter. Zero is allowed.
- **barDiameter** (`System.Double`) - A value for the Bar Diameter parameter. Zero is allowed.

## Returns
True if the rebar can be solved with the
 default parameter values and the given bend radius and
 bar diameter; false if it cannot.

## Remarks
This function runs the rebar solver with the
 default parameter values. If it fails (returns false), rebar instances
 of this shape will not work. This may be from the
 default parameters being inconsistent, or from some
 error in the shape definition. The solver requires a
 specific bend radius and bar diameter, and the result
 depends on these values, but in practice they usually
 do not affect the result of this function as long as
 they are small. It is legal to pass 0.0 for both
 arguments. The definition must be Complete in order
 for this function to succeed.

