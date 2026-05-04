---
kind: method
id: M:Autodesk.Revit.DB.Analysis.PathOfTravel.CreateMultiple(Autodesk.Revit.DB.View,System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ},System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ})
source: html/ea3cb957-77e1-624f-0d88-7c93c894290f.htm
---
# Autodesk.Revit.DB.Analysis.PathOfTravel.CreateMultiple Method

Creates multiple new paths of travel between same size sets of start and end points.

## Syntax (C#)
```csharp
public static IList<PathOfTravel> CreateMultiple(
	View DBView,
	IList<XYZ> pathStarts,
	IList<XYZ> pathEnds
)
```

## Parameters
- **DBView** (`Autodesk.Revit.DB.View`) - The floor plan view to use when computing the shortest distance.
- **pathStarts** (`System.Collections.Generic.IList < XYZ >`) - The start points of the path. The input Z coordinates are ignored and set to the view's level elevation.
- **pathEnds** (`System.Collections.Generic.IList < XYZ >`) - The end points of the path. The input Z coordinates are ignored and set to the view's level elevation.

## Returns
The array of newly created path of travel elements, or Nothing nullptr a null reference ( Nothing in Visual Basic) if no path between the two points is found.
 The order of elements corresponds to the order of start/end points in the argument arrays.
 There are some additional conditions that are checked and if any condition is true the Nothing nullptr a null reference ( Nothing in Visual Basic) value is returned:
 View has crop box active and start or end point lies outside of the crop Start and end points are too close

## Remarks
InvalidOperationException is thrown if PathOfTravel cannot be created for the following conditions:
 View has crop box active and crop box is split View model outline area is larger than the current limit (2,000,000 sq.ft.) View export contains too much geometry (more than 200,000 lines) 
 ArgumentException exception is thrown if arrays of start and end points are of different size
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

