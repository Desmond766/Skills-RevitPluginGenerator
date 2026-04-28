---
kind: method
id: M:Autodesk.Revit.DB.Analysis.PathOfTravel.CreateMapped(Autodesk.Revit.DB.View,System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ},System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ},System.Collections.Generic.IList{Autodesk.Revit.DB.Analysis.PathOfTravelCalculationStatus}@)
source: html/7832628a-bd44-7b03-2037-e73ee3e3e8a5.htm
---
# Autodesk.Revit.DB.Analysis.PathOfTravel.CreateMapped Method

Creates multiple new paths of travel by mapping each of a set of start points to each of a set of end points and provides creation result statuses.

## Syntax (C#)
```csharp
public static IList<PathOfTravel> CreateMapped(
	View DBView,
	IList<XYZ> pathStarts,
	IList<XYZ> pathEnds,
	out IList<PathOfTravelCalculationStatus> resultStatus
)
```

## Parameters
- **DBView** (`Autodesk.Revit.DB.View`) - The floor plan view to use when computing the shortest distance.
- **pathStarts** (`System.Collections.Generic.IList < XYZ >`) - The start points of the path. The input Z coordinates are ignored and set to the view's level elevation.
- **pathEnds** (`System.Collections.Generic.IList < XYZ >`) - The end points of the path. The input Z coordinates are ignored and set to the view's level elevation.
- **resultStatus** (`System.Collections.Generic.IList < PathOfTravelCalculationStatus > %`) - Result statuses of each path of travel creation.
 The order of statuses corresponds to the order of elements in the array returned by the function.

## Returns
The array of newly created path of travel elements, or Nothing nullptr a null reference ( Nothing in Visual Basic) if no path between the two points is found.
 The number of elements is the number of start points multiplied by the number of end points.
 The order of elements corresponds to the order of end and then start points in the argument arrays:
 s0->e0, s1->e0, ... , s0->e1, s1->e1... etc.
 There are some additional conditions that are checked and if any condition is true the Nothing nullptr a null reference ( Nothing in Visual Basic) value is returned:
 View has crop box active and start or end point lies outside of the crop Start and end points are too close

## Remarks
InvalidOperationException is thrown if PathOfTravel cannot be created for the following conditions:
 View has crop box active and crop box is split View model outline area is larger than the current limit (2,000,000 sq.ft.) View export contains too much geometry (more than 200,000 lines) 
 ArgumentException exception is thrown if arrays of start or end points are of zero size
 or if the total number of paths of travel attempted to be created is more than maximum allowed (50000).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element "DBView" is in a family document or a document in in-place edit mode.
 -or-
 View is not a floor plan view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The document containing DBView is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 This operation cannot be performed while the document is in edit mode.
 -or-
 The Path of Travel calculation service is not available
 -or-
 This functionality is not available in Revit LT.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document containing DBView is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document containing DBView is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document containing DBView has no open transaction.

