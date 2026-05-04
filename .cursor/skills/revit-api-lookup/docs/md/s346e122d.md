---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShape.IsSameShapeIgnoringHooks(Autodesk.Revit.DB.Structure.RebarShape)
source: html/5815937c-ac80-2f85-ff5a-4e728336251e.htm
---
# Autodesk.Revit.DB.Structure.RebarShape.IsSameShapeIgnoringHooks Method

Test whether two shapes have equivalent definitions by comparing
 the RebarShapeDefinition and MultiplanarDefinition properties.

## Syntax (C#)
```csharp
public bool IsSameShapeIgnoringHooks(
	RebarShape otherShape
)
```

## Parameters
- **otherShape** (`Autodesk.Revit.DB.Structure.RebarShape`) - Another shape to be compared to this one.

## Returns
True if the shape definitions match, false otherwise.

## Remarks
This method will return true if the definitions are exactly
 equivalent, or if they are equivalent but have the opposite
 start/end orientation.
 Replaces the property RebarShape.SameShapeIgnoringHooks from prior releases.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

