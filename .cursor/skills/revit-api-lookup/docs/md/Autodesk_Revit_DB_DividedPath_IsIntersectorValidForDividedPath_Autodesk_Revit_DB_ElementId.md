---
kind: method
id: M:Autodesk.Revit.DB.DividedPath.IsIntersectorValidForDividedPath(Autodesk.Revit.DB.ElementId)
source: html/af6d278b-df1c-40bb-a732-0f763e5da5f5.htm
---
# Autodesk.Revit.DB.DividedPath.IsIntersectorValidForDividedPath Method

This returns true if the intersector is an element that can be used to intersect with the divided path.

## Syntax (C#)
```csharp
public bool IsIntersectorValidForDividedPath(
	ElementId intersector
)
```

## Parameters
- **intersector** (`Autodesk.Revit.DB.ElementId`) - The intersector.

## Returns
True if the reference can be used to create a divided path, false otherwise.

## Remarks
Intersectors can be curve elements, datum planes, or other divided paths.
 Note that divided paths that have this divided path as an intersector
 (either directly, or recursively) are not valid.
 Also, if the nesting of divided path intersectors that have intersectors is more than 5 levels deep
 the divided path intersector is considered invalid as well.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

