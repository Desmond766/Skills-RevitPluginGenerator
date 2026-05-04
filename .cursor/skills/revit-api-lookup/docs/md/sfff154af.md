---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.CreateFromCurves(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Structure.RebarStyle,Autodesk.Revit.DB.Structure.RebarBarType,Autodesk.Revit.DB.Structure.RebarHookType,Autodesk.Revit.DB.Structure.RebarHookType,Autodesk.Revit.DB.Element,Autodesk.Revit.DB.XYZ,System.Collections.Generic.IList{Autodesk.Revit.DB.Curve},Autodesk.Revit.DB.Structure.RebarHookOrientation,Autodesk.Revit.DB.Structure.RebarHookOrientation,System.Double,System.Double,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,System.Boolean,System.Boolean)
zh: 钢筋、配筋
source: html/bc5349d8-fc03-6223-be02-601c4aaa7782.htm
---
# Autodesk.Revit.DB.Structure.Rebar.CreateFromCurves Method

**中文**: 钢筋、配筋

Creates a new instance of a shape driven Rebar element within the project.

## Syntax (C#)
```csharp
public static Rebar CreateFromCurves(
	Document doc,
	RebarStyle style,
	RebarBarType barType,
	RebarHookType startHook,
	RebarHookType endHook,
	Element host,
	XYZ norm,
	IList<Curve> curves,
	RebarHookOrientation startHookOrient,
	RebarHookOrientation endHookOrient,
	double hookRotationAngleAtStart,
	double hookRotationAngleAtEnd,
	ElementId endTreatmentTypeIdAtStart,
	ElementId endTreatmentTypeIdAtEnd,
	bool useExistingShapeIfPossible,
	bool createNewShape
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - A document.
- **style** (`Autodesk.Revit.DB.Structure.RebarStyle`) - The usage of the bar, "standard" or "stirrup/tie".
- **barType** (`Autodesk.Revit.DB.Structure.RebarBarType`) - A RebarBarType element that defines bar diameter, bend radius and material of the rebar.
- **startHook** (`Autodesk.Revit.DB.Structure.RebarHookType`) - A RebarHookType element that defines the hook for the start of the bar.
 If this parameter is Nothing nullptr a null reference ( Nothing in Visual Basic) , it means to create a rebar with no hook.
- **endHook** (`Autodesk.Revit.DB.Structure.RebarHookType`) - A RebarHookType element that defines the hook for the end of the bar.
 If this parameter is Nothing nullptr a null reference ( Nothing in Visual Basic) , it means to create a rebar with no hook.
- **host** (`Autodesk.Revit.DB.Element`) - The element to which the rebar belongs. The element must support rebar hosting;
 [!:Autodesk::Revit::DB::Structure::RebarHostData] .
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
- **hookRotationAngleAtStart** (`System.Double`) - The out of plane hook rotation angle at the start of the bar.
- **hookRotationAngleAtEnd** (`System.Double`) - The out of plane hook rotation angle at the end of the bar.
- **endTreatmentTypeIdAtStart** (`Autodesk.Revit.DB.ElementId`) - The end treatment type id at the start of the bar.
- **endTreatmentTypeIdAtEnd** (`Autodesk.Revit.DB.ElementId`) - The end treatment type id at the end of the bar.
- **useExistingShapeIfPossible** (`System.Boolean`) - Attempts to assign a RebarShape from those existing in the document. If no shape matches, this function returns Nothing nullptr a null reference ( Nothing in Visual Basic) if createNewShape is false or it will create a new shape if createNewShape is true.
 When both parameters are "true", the behavior is the same as sketching rebar in the UI. At least one of these parameters must be "true".
 If the RebarShapeDefinesHooks flag in ReinforcementSettings has been set to false, and a RebarShape cannot be found with both matching curves and hooks,
 then this method will perform a second search, ignoring hook information.
- **createNewShape** (`System.Boolean`) - Creates a shape in the document to match the curves, hooks, and style specified, and assigns it to the new rebar instance.
 Shape creation will not succeed unless one or more other shapes already exist in the document, and these shapes
 have enough shape parameters to define a shape for these curves.

## Returns
The newly created Rebar instance, or Nothing nullptr a null reference ( Nothing in Visual Basic) if the operation fails.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element host was not found in the given document.
 -or-
 host is not a valid rebar host.
 -or-
 The input curves is empty.
 -or-
 The input curves contains at least one curve which is not a bound Line or bound Arc
 and is not supported for this operation.
 -or-
 curves do not form a valid CurveLoop.
 -or-
 The input curves contains at least one helical curve and is not supported for this operation.
 -or-
 the parameter endTreatmentTypeIdAtStart is not an EndTreatmentType element.
 -or-
 the parameter endTreatmentTypeIdAtEnd is not an EndTreatmentType element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - norm has zero length.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - Both useExistingShapeIfPossible and createNewShape are false.
 -or-
 curves contains non-fillet arcs with radii that are less than the
 minimum bend radius for the RebarBarType and bar style.

