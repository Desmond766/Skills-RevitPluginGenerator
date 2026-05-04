---
kind: method
id: M:Autodesk.Revit.DB.Analysis.PathOfTravel.SetRevealObstaclesMode(Autodesk.Revit.DB.View,System.Boolean)
source: html/d2a2f84c-a90e-9ef0-28aa-025af61b8be3.htm
---
# Autodesk.Revit.DB.Analysis.PathOfTravel.SetRevealObstaclesMode Method

Sets Reveal Obstacles mode for the given view.

## Syntax (C#)
```csharp
public static PathOfTravelCalculationStatus SetRevealObstaclesMode(
	View DBView,
	bool newState
)
```

## Parameters
- **DBView** (`Autodesk.Revit.DB.View`) - The view to set Reveal Obstacles mode for.
- **newState** (`System.Boolean`) - New state of Reveal Obstacles mode to be set for the view.

## Returns
Result status of the operation.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element "DBView" is in a family document or a document in in-place edit mode.
 -or-
 View is not a floor plan view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The document containing DBView is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The Path of Travel calculation service is not available
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document containing DBView is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document containing DBView is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document containing DBView has no open transaction.

