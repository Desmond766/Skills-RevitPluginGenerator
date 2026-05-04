---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinition.AddParameter(Autodesk.Revit.DB.ElementId,System.Double)
source: html/8e314f3c-3e6c-a3b2-8bd4-68c1fe61b0c4.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinition.AddParameter Method

Add a parameter to the shape definition.

## Syntax (C#)
```csharp
public void AddParameter(
	ElementId paramId,
	double defaultValue
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - The parameter. To obtain the id of a shared parameter,
 call RebarShapeParameters.GetElementIdForExternalDefinition.
- **defaultValue** (`System.Double`) - A default value for this parameter in shapes. The default values
 should be chosen carefully, because they are required to be consistent as a set of constraints.

## Remarks
A shape parameter must be a shared parameter and have value type double.
 A parameter must be added to the definition before it can be used to
 drive the shape in a RebarShapeConstraint object.
 A parameter that does not drive a constraint is legal and will
 simply become an editable parameter on any Rebar that is an instance of this RebarShape.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - paramId is not the id of a shared parameter in the current document,
 or its unit type is not UT_Reinforcement_Length or UT_Angle.
 -or-
 The name of a shared parameter identified by paramId
 was already used by another shared parameter of the element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

