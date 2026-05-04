---
kind: method
id: M:Autodesk.Revit.DB.Architecture.StairsRun.SetLocationPathForSpiralRun(Autodesk.Revit.DB.Architecture.StairsRun,Autodesk.Revit.DB.XYZ,System.Double,System.Double,System.Double,System.Boolean,Autodesk.Revit.DB.Architecture.StairsRunJustification)
source: html/f8304e58-c7a3-410c-8369-8cd313043a16.htm
---
# Autodesk.Revit.DB.Architecture.StairsRun.SetLocationPathForSpiralRun Method

Set Location path for a spiral run.

## Syntax (C#)
```csharp
public static bool SetLocationPathForSpiralRun(
	StairsRun stairsRun,
	XYZ center,
	double radius,
	double startAngle,
	double includedAngle,
	bool clockwise,
	StairsRunJustification justification
)
```

## Parameters
- **stairsRun** (`Autodesk.Revit.DB.Architecture.StairsRun`) - The run whose location path will be set.
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
Indicate if set is success or not.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for startAngle is not finite
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
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The stairs element represented by stairsRun is not in an active StairsEditScope.
 The run cannot be modified.
- **Autodesk.Revit.Exceptions.RegenerationFailedException** - The center, radius, startAngle, includedAngle don't satisfy restrictions to generate spiral run.

