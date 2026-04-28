---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinitionByArc.AddConstraintChordLength(Autodesk.Revit.DB.ElementId)
source: html/0b96af18-bd89-7927-c4e9-012236774f12.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinitionByArc.AddConstraintChordLength Method

Specify a parameter to drive the chord length (the straight-line distance between the endpoints of the arc).

## Syntax (C#)
```csharp
public void AddConstraintChordLength(
	ElementId paramId
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - Id of a parameter to drive the constraint.
 To obtain the id of a shared parameter,
 call RebarShape.GetElementIdForExternalDefinition().

## Remarks
The chord length is measured on the centerline of the bar.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

