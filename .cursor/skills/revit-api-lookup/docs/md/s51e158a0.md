---
kind: method
id: M:Autodesk.Revit.DB.DividedPath.IsIntersectorValidForCreation(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/fef969d9-4a6a-5aeb-d492-79eee88f9db5.htm
---
# Autodesk.Revit.DB.DividedPath.IsIntersectorValidForCreation Method

This returns true if the intersector is an element that can be used to intersect with a newly created divided path.

## Syntax (C#)
```csharp
public static bool IsIntersectorValidForCreation(
	Document document,
	ElementId intersector
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **intersector** (`Autodesk.Revit.DB.ElementId`) - The intersector.

## Returns
True if the reference can be used to create a divided path, false otherwise.

## Remarks
Intersectors can be curve elements, datum planes, or divided paths.
This function is should not be used to validate the input to SetIntersectors()
 because it does not check for self intersection of any other circular dependencies between intersectors.
 Use isIntersectorValidForDividedPath() instead.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

