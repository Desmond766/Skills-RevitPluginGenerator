---
kind: method
id: M:Autodesk.Revit.DB.Architecture.StairsLanding.CreateSketchedLandingWithSlopeData(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,System.Collections.Generic.IList{Autodesk.Revit.DB.SketchedStairsCurveData},System.Double)
source: html/453848e3-2cab-8777-4c46-e94275898425.htm
---
# Autodesk.Revit.DB.Architecture.StairsLanding.CreateSketchedLandingWithSlopeData Method

Creates a customized landing between two runs by providing the closed boundary curves of the landing, specifying slope type and height.

## Syntax (C#)
```csharp
public static StairsLanding CreateSketchedLandingWithSlopeData(
	Document document,
	ElementId stairsId,
	IList<SketchedStairsCurveData> curveLoop,
	double baseElevation
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document that owns the landing.
- **stairsId** (`Autodesk.Revit.DB.ElementId`) - The stairs that the new sketched landing belongs to.
- **curveLoop** (`System.Collections.Generic.IList < SketchedStairsCurveData >`) - The closed boundary curves of the new landing, specifying slope type and height.
- **baseElevation** (`System.Double`) - Base elevation of the new stairs run. The elevation has following restriction:
 The base elevation is relative to the base elevation of the stairs. The base elevation will be rounded automatically to a multiple of the riser height. The base elevation should be equal to or greater than half of the riser height.

## Returns
The new sketched landing.

## Remarks
The new stairs landing and the document will be regenerated.
 This should be run from within an open transaction.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element stairsId does not exist in the document
 -or-
 The stairsId is not a valid stairs element.
 -or-
 The stairs stairsId has no valid landing type.
 -or-
 The curveLoop is not closed.
 The input curveLoop contains at least one curve which is not a bound Line or bound Arc
 and is not supported for this operation.
 -or-
 Failed to create curve element by the curveLoop.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for baseElevation must be no more than 30000 feet in absolute value.
 -or-
 The baseElevation is less than half of the riser height of the stairs.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The stairs element represented by stairsId is not in an active StairsEditScope.
 New components cannot be added to it.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.
- **Autodesk.Revit.Exceptions.RegenerationFailedException** - The curveLoop doesn't satisfy restrictions to generate sketched landing.

