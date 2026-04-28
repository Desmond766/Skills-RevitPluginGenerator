---
kind: method
id: M:Autodesk.Revit.DB.Architecture.StairsRun.SetLocationPathForStraightRun(Autodesk.Revit.DB.Architecture.StairsRun,Autodesk.Revit.DB.Line)
source: html/6ff2ff5e-36ad-eb4c-2aef-4f0b5208177d.htm
---
# Autodesk.Revit.DB.Architecture.StairsRun.SetLocationPathForStraightRun Method

Set location path for a straight run by giving a line.

## Syntax (C#)
```csharp
public static bool SetLocationPathForStraightRun(
	StairsRun stairsRun,
	Line locationPath
)
```

## Parameters
- **stairsRun** (`Autodesk.Revit.DB.Architecture.StairsRun`) - The run whose location path will be set.
- **locationPath** (`Autodesk.Revit.DB.Line`) - The location path.

## Returns
Indicate if set is success or not.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input locationPath is not a bound line.
 -or-
 The input locationPath is not a valid location path line for straight run.
 -or-
 The locationPath is not valid line used as stairs path(probably it's too short).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The stairs element represented by stairsRun is not in an active StairsEditScope.
 The run cannot be modified.
- **Autodesk.Revit.Exceptions.RegenerationFailedException** - The locationPath doesn't satisfy restrictions to generate straight run.

