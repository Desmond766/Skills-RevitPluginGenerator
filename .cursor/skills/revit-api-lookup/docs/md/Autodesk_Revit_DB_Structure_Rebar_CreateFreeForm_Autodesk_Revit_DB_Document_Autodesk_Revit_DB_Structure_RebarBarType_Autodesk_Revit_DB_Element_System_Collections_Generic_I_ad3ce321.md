---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.CreateFreeForm(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Structure.RebarBarType,Autodesk.Revit.DB.Element,System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop},Autodesk.Revit.DB.Structure.RebarFreeFormValidationResult@)
zh: 钢筋、配筋
source: html/38767c5e-0196-3359-69db-19d728873b19.htm
---
# Autodesk.Revit.DB.Structure.Rebar.CreateFreeForm Method

**中文**: 钢筋、配筋

Creates a free form rebar that will be unconstrained. Constraints can't be added later to this rebar.

## Syntax (C#)
```csharp
public static Rebar CreateFreeForm(
	Document doc,
	RebarBarType barType,
	Element host,
	IList<CurveLoop> curves,
	out RebarFreeFormValidationResult error
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - A document.
- **barType** (`Autodesk.Revit.DB.Structure.RebarBarType`) - A RebarBarType element that defines bar diameter, bend radius and material of the rebar.
- **host** (`Autodesk.Revit.DB.Element`) - The element to which the rebar belongs. The element must support rebar hosting.
- **curves** (`System.Collections.Generic.IList < CurveLoop >`) - Each curve loop represents a bar in the set.
- **error** (`Autodesk.Revit.DB.Structure.RebarFreeFormValidationResult %`) - Will be Success(0) if everything is ok, otherwise the failure reason.

## Returns
The newly created free form Rebar Instance.

## Remarks
This function can fail due to following reasons: The array of CurveLoops is empty. At least one CurveLoop is empty. At least one CurveLoop contains an unbounded curve. A rebar constructed from curves can't be bent according to the bending radius.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - host is not a valid rebar host.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

