---
kind: method
id: M:Autodesk.Revit.DB.Architecture.StairsRun.CreateStraightRun(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Line,Autodesk.Revit.DB.Architecture.StairsRunJustification)
source: html/54fd7462-c16c-41bf-705f-ede3af0bc572.htm
---
# Autodesk.Revit.DB.Architecture.StairsRun.CreateStraightRun Method

Creates a straight run in the project document.

## Syntax (C#)
```csharp
public static StairsRun CreateStraightRun(
	Document document,
	ElementId stairsId,
	Line locationPath,
	StairsRunJustification justification
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **stairsId** (`Autodesk.Revit.DB.ElementId`) - The stairs that the new stairs run will belong to.
- **locationPath** (`Autodesk.Revit.DB.Line`) - The line for location path of the new stairs run. The line has following restriction:
 The line should be bound line which is parallel to the XY plane. The Z coordinate of the line is the base elevation for the new run (in model coordinates).
 It must be greater than or equal to the stairs base elevation. The number of created risers will be calculated by rounding the length of the
 location path to a multiple of the tread depth.
- **justification** (`Autodesk.Revit.DB.Architecture.StairsRunJustification`) - The location path justification of the new stairs run.

## Returns
The new stairs run.

## Remarks
The new stairs run and the document will be regenerated.
 This should be run from within an open transaction.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The stairsId is not a valid stairs element.
 -or-
 The input locationPath is not a bound line.
 -or-
 The input locationPath is not a valid location path line for straight run.
 -or-
 The locationPath is not valid line used as stairs path(probably it's too short).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The stairs element represented by stairsId is not in an active StairsEditScope.
 New components cannot be added to it.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.
- **Autodesk.Revit.Exceptions.RegenerationFailedException** - The locationPath doesn't satisfy restrictions to generate straight run.

