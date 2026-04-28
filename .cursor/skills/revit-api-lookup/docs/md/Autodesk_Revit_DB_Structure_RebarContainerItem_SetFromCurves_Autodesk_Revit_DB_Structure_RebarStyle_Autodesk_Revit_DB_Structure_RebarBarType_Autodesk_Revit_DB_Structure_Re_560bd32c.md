---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerItem.SetFromCurves(Autodesk.Revit.DB.Structure.RebarStyle,Autodesk.Revit.DB.Structure.RebarBarType,Autodesk.Revit.DB.Structure.RebarHookType,Autodesk.Revit.DB.Structure.RebarHookType,Autodesk.Revit.DB.XYZ,System.Collections.Generic.IList{Autodesk.Revit.DB.Curve},Autodesk.Revit.DB.Structure.RebarHookOrientation,Autodesk.Revit.DB.Structure.RebarHookOrientation,System.Boolean,System.Boolean)
source: html/c1c60114-a734-d73e-60db-8376e4110042.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerItem.SetFromCurves Method

Set an instance of a RebarContainerItem element according to the parameters list.

## Syntax (C#)
```csharp
public void SetFromCurves(
	RebarStyle style,
	RebarBarType barType,
	RebarHookType startHook,
	RebarHookType endHook,
	XYZ norm,
	IList<Curve> curves,
	RebarHookOrientation startHookOrient,
	RebarHookOrientation endHookOrient,
	bool useExistingShapeIfPossible,
	bool createNewShape
)
```

## Parameters
- **style** (`Autodesk.Revit.DB.Structure.RebarStyle`) - The usage of the bar, "standard" or "stirrup/tie".
- **barType** (`Autodesk.Revit.DB.Structure.RebarBarType`) - A RebarBarType element that defines bar diameter, bend radius and material of the rebar.
- **startHook** (`Autodesk.Revit.DB.Structure.RebarHookType`) - A RebarHookType element that defines the hook for the start of the bar.
 If this parameter is Nothing nullptr a null reference ( Nothing in Visual Basic) , it means to create a rebar with no hook.
- **endHook** (`Autodesk.Revit.DB.Structure.RebarHookType`) - A RebarHookType element that defines the hook for the end of the bar.
 If this parameter is Nothing nullptr a null reference ( Nothing in Visual Basic) , it means to create a rebar with no hook.
- **norm** (`Autodesk.Revit.DB.XYZ`) - The normal to the plane that the rebar curves lie on.
- **curves** (`System.Collections.Generic.IList < Curve >`) - An array of curves that define the shape of the rebar curves.
 They must belong to the plane defined by the normal and origin.
 Bends and hooks should not be included in the array of curves.
- **startHookOrient** (`Autodesk.Revit.DB.Structure.RebarHookOrientation`) - Defines the orientation of the hook plane at the start of the rebar with respect to the orientation of the first curve and the plane normal.
 Only two values are permitted:
 Value = Right: The hook is on your right as you stand at the end of the bar,
 with the bar behind you, taking the bar's normal as "up."
 Value = Left: The hook is on your left as you stand at the end of the bar,
 with the bar behind you, taking the bar's normal as "up."
- **endHookOrient** (`Autodesk.Revit.DB.Structure.RebarHookOrientation`) - Defines the orientation of the hook plane at the end of the rebar with respect to the orientation of the last curve and the plane normal.
 Only two values are permitted:
 Value = Right: The hook is on your right as you stand at the end of the bar,
 with the bar behind you, taking the bar's normal as "up."
 Value = Left: The hook is on your left as you stand at the end of the bar,
 with the bar behind you, taking the bar's normal as "up."
- **useExistingShapeIfPossible** (`System.Boolean`) - Attempts to assign a RebarShape from those existing in the document. If no shape matches, NewRebar returns or creates a new shape, according to the parameter createNewShape.
 When both parameters are "true", the behavior is the same as sketching rebar in the UI. At least one of these parameters must be "true".
 If the RebarShapeDefinesHooks flag in ReinforcementSettings has been set to false, and a RebarShape cannot be found with both matching curves and hooks,
 then this method will perform a second search, ignoring hook information.
- **createNewShape** (`System.Boolean`) - Creates a shape in the document to match the curves, hooks, and style specified, and assigns it to the new rebar instance.
 Shape creation will not succeed unless one or more other shapes already exist in the document, and these shapes
 have enough shape parameters to define a shape for these curves.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input curves is empty.
 -or-
 The input curves contains at least one curve which is not a bound Line or bound Arc
 and is not supported for this operation.
 -or-
 curves do not form a valid CurveLoop.
 -or-
 The input curves contains at least one helical curve and is not supported for this operation.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - norm has zero length.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - Both useExistingShapeIfPossible and createNewShape are false.
 -or-
 curves contains non-fillet arcs with radii that are less than the
 minimum bend radius for the RebarBarType and bar style.

