---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.ContainsValidArcRadiiForStyleAndBarType(System.Collections.Generic.IList{Autodesk.Revit.DB.Curve},Autodesk.Revit.DB.Structure.RebarStyle,Autodesk.Revit.DB.Structure.RebarBarType)
zh: 钢筋、配筋
source: html/f1db8751-d587-521c-2a5f-77b818d38105.htm
---
# Autodesk.Revit.DB.Structure.Rebar.ContainsValidArcRadiiForStyleAndBarType Method

**中文**: 钢筋、配筋

Checks that all arcs in the chain of curves have radii that are not less than minimum bend radius for bar type and style

## Syntax (C#)
```csharp
public static bool ContainsValidArcRadiiForStyleAndBarType(
	IList<Curve> curves,
	RebarStyle style,
	RebarBarType barType
)
```

## Parameters
- **curves** (`System.Collections.Generic.IList < Curve >`) - An array of curves intended to define the shape of the rebar curves.
 Bends and hooks should not be included in the array of curves.
- **style** (`Autodesk.Revit.DB.Structure.RebarStyle`) - The usage of the bar, "standard" or "stirrup/tie".
- **barType** (`Autodesk.Revit.DB.Structure.RebarBarType`) - A RebarBarType element that defines bar diameter, bend radius and material of the rebar.

## Returns
Returns true if all arc bend radii are not less than minimum bend radius for bar type and style

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

