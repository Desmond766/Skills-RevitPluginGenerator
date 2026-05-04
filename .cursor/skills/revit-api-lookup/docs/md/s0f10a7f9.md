---
kind: method
id: M:Autodesk.Revit.DB.Architecture.StairsRun.CreateSpiralRun(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ,System.Double,System.Double,System.Double,System.Boolean,Autodesk.Revit.DB.Architecture.StairsRunJustification)
source: html/2f31d042-a202-a1a4-42fe-998b02e26a4d.htm
---
# Autodesk.Revit.DB.Architecture.StairsRun.CreateSpiralRun Method

Creates a spiral run in the project document by providing the center, start angle and included angle.

## Syntax (C#)
```csharp
public static StairsRun CreateSpiralRun(
	Document document,
	ElementId stairsId,
	XYZ center,
	double radius,
	double startAngle,
	double includedAngle,
	bool clockwise,
	StairsRunJustification justification
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **stairsId** (`Autodesk.Revit.DB.ElementId`) - The stairs that the new stairs run will belong to.
- **center** (`Autodesk.Revit.DB.XYZ`) - The center of the location arc of the spiral run.
 The Z coordinate of the center is the base elevation for the new run (in model coordinates).
 It must be greater than or equal to the stairs base elevation.
- **radius** (`System.Double`) - The radius of the location arc of the spiral run.
- **startAngle** (`System.Double`) - The start angle of the location arc of the spiral run.
 The angle's coordinate system is world coordinate system which always is XYZ.BasisX and XYZ.BasisY.
- **includedAngle** (`System.Double`) - The total angle covered by the spiral run. Must be a positive value (direction is determined by the clockwise flag).
- **clockwise** (`System.Boolean`) - True if the spiral run will be created along clockwise direction, False otherwise.
- **justification** (`Autodesk.Revit.DB.Architecture.StairsRunJustification`) - The location path justification of the new stairs run.

## Returns
The new stairs run.

## Remarks
The new stairs run and the document will be regenerated.
 This should be run from within an open transaction.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The stairsId is not a valid stairs element.
 -or-
 The given value for startAngle is not finite
 -or-
 The input center is not a valid center for spiral run (probably the Z coordinate doesn't meet the restrictions)
 -or-
 The includedAngle doesn't satisfy riser restriction to generate spiral run (probably it's too small).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for radius must be greater than 0 and no more than 30000 feet.
 -or-
 The given value for includedAngle must be positive.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - The radius is too small to generate a spiral run at the given justification.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The stairs element represented by stairsId is not in an active StairsEditScope.
 New components cannot be added to it.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.
- **Autodesk.Revit.Exceptions.RegenerationFailedException** - The center, radius, startAngle, includedAngle don't satisfy restrictions to generate spiral run.

