---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinition.AddFormulaParameter(Autodesk.Revit.DB.ElementId,System.String)
source: html/669bcf80-e0b7-ee57-30c0-82fdf4184012.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinition.AddFormulaParameter Method

Add a formula-driven parameter to the shape definition.

## Syntax (C#)
```csharp
public void AddFormulaParameter(
	ElementId paramId,
	string formula
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - The parameter. To obtain the id of a shared parameter,
 call RebarShapeParameters.GetElementIdForExternalDefinition.
- **formula** (`System.String`) - The formula expressed as a string. The string is exactly what a user would
 type into the Family Types dialog, e.g. "Total Length*3.14159*(Bar Diameter/2)*(Bar Diameter/2)"

## Remarks
Like AddParameter(), this function introduces a parameter into
 the shape definition, but the parameter's value is driven by a formula.
 Formula parameters cannot be used in constraints to drive the shape.
 The formula is in the same format as in Revit families.
 The formula is allowed to refer to other parameters that are
 already in the definition, plus the builtin parameters REBAR_INSTANCE_BAR_DIAMETER (bar nominal diameter), REBAR_INSTANCE_BAR_MODEL_DIAMETER (bar model diameter),
 REBAR_INSTANCE_BEND_DIAMETER, REBAR_SHAPE_START_HOOK_LENGTH, REBAR_SHAPE_START_HOOK_OFFSET,
 REBAR_SHAPE_PARAM_START_HOOK_TAN_LEN, REBAR_SHAPE_PARAM_END_HOOK_TAN_LEN,
 REBAR_SHAPE_END_HOOK_LENGTH, REBAR_SHAPE_END_HOOK_OFFSET, REBAR_ELEM_LENGTH,
 REBAR_ELEM_TOTAL_LENGTH, and REBAR_ELEM_QUANTITY_OF_BARS.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - paramId is not the id of a shared parameter in the current document,
 or its unit type is not UT_Reinforcement_Length or UT_Angle.
 -or-
 The name of a shared parameter identified by paramId
 was already used by another shared parameter of the element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

