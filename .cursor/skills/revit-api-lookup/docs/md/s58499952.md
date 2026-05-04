---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinitionByArc.AddConstraintSagittaLength(Autodesk.Revit.DB.ElementId)
source: html/febb3519-72df-7741-e793-21465f9476b1.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinitionByArc.AddConstraintSagittaLength Method

Specify a parameter to drive the sagittal
 length (the height of the circular segment, measured
 perpendicular to the chord).

## Syntax (C#)
```csharp
public void AddConstraintSagittaLength(
	ElementId paramId
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - Id of a parameter to drive the constraint.
 To obtain the id of a shared parameter,
 call RebarShape.GetElementIdForExternalDefinition().

## Remarks
The sagitta will be measured on the centerline of the bar.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

