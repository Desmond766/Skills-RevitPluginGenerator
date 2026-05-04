---
kind: method
id: M:Autodesk.Revit.DB.Architecture.NonContinuousRailStructure.AddNonContinuousRail(System.String,System.Double,System.Double)
source: html/91ed215d-bf6d-5398-4082-49e35a470785.htm
---
# Autodesk.Revit.DB.Architecture.NonContinuousRailStructure.AddNonContinuousRail Method

Creates and appends a new Non-Continuous Rail to the Rail Structure.
 The new Non-Continuous Rail will have the given name, height and offset.
 It will have default profile and material ElementIds.

## Syntax (C#)
```csharp
public NonContinuousRailInfo AddNonContinuousRail(
	string name,
	double height,
	double offset
)
```

## Parameters
- **name** (`System.String`) - The name of the non-continuous rail.
- **height** (`System.Double`) - The height on which the non-continuous rail will be placed.
- **offset** (`System.Double`) - The offset of the non-continuous rail from a [!:Autodesk::Revit::DB::Architecture::Railing] center.

## Returns
Handle to the new Non-Continuous Rail.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - name is an empty string or contains only whitespace.
 -or-
 name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 The name is a duplicate of an existing non-continuous rail.
 -or-
 The height height is not valid for the non-continuous rail because
 it is greater than the height of the RailingType to which it belongs.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for height must be no more than 30000 feet in absolute value.
 -or-
 The given value for offset must be no more than 30000 feet in absolute value.

