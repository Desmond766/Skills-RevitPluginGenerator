---
kind: method
id: M:Autodesk.Revit.DB.Analysis.PathOfTravel.Create(Autodesk.Revit.DB.View,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.Analysis.PathOfTravelCalculationStatus@)
zh: 创建、新建、生成、建立、新增
source: html/f0039a13-f716-0d26-7e92-a0c626b034fe.htm
---
# Autodesk.Revit.DB.Analysis.PathOfTravel.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new path of travel between two points and provides creation result status.

## Syntax (C#)
```csharp
public static PathOfTravel Create(
	View DBView,
	XYZ pathStart,
	XYZ pathEnd,
	out PathOfTravelCalculationStatus resultStatus
)
```

## Parameters
- **DBView** (`Autodesk.Revit.DB.View`) - The floor plan view to use when computing the shortest distance.
- **pathStart** (`Autodesk.Revit.DB.XYZ`) - The start point of the path. The input Z coordinates are ignored and set to the view's level elevation.
- **pathEnd** (`Autodesk.Revit.DB.XYZ`) - The end point of the path. The input Z coordinates are ignored and set to the view's level elevation.
- **resultStatus** (`Autodesk.Revit.DB.Analysis.PathOfTravelCalculationStatus %`) - Result status of path of travel creation.

## Returns
The newly created path of travel element, or Nothing nullptr a null reference ( Nothing in Visual Basic) if no path between the two points is found.

## Remarks
InvalidOperationException is thrown if PathOfTravel cannot be created for the following conditions:
 View has crop box active and crop box is split View has crop box active and start or end point lies outside of the crop View model outline area is larger than the current limit (2,000,000 sq.ft.) View export contains too much geometry (more than 200,000 lines) Start and end points are too close

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element "DBView" is in a family document or a document in in-place edit mode.
 -or-
 View is not a floor plan view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
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

