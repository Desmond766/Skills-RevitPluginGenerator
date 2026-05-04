---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.RemoveParameterFromSegment(System.Int32,Autodesk.Revit.DB.ElementId)
source: html/07b27988-4b6c-9449-c2f1-16da13b042ca.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.RemoveParameterFromSegment Method

Remove constraints from a segment.

## Syntax (C#)
```csharp
public void RemoveParameterFromSegment(
	int iSegment,
	ElementId paramId
)
```

## Parameters
- **iSegment** (`System.Int32`) - Index of the segment (0 to NumberOfSegments - 1).
- **paramId** (`Autodesk.Revit.DB.ElementId`) - Id of a parameter driving one or more constraints.

## Remarks
This reverses the effect of any AddConstraint and SetSegmentAs180DegreeBend operations involving the specified segment and parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - iSegment is not between 0 and NumberOfSegments.
 -or-
 paramId is not the id of a shared parameter in the current document,
 or its unit type is not UT_Reinforcement_Length or UT_Angle.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

