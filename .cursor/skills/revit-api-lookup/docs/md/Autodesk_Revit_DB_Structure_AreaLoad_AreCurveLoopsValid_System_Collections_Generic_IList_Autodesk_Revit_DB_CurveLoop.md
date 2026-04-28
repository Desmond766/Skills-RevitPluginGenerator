---
kind: method
id: M:Autodesk.Revit.DB.Structure.AreaLoad.AreCurveLoopsValid(System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop})
source: html/dcecb068-30b8-215c-98ea-eb873cf1d513.htm
---
# Autodesk.Revit.DB.Structure.AreaLoad.AreCurveLoopsValid Method

Checks if curve loops are valid for creating an area load.

## Syntax (C#)
```csharp
public static bool AreCurveLoopsValid(
	IList<CurveLoop> loops
)
```

## Parameters
- **loops** (`System.Collections.Generic.IList < CurveLoop >`) - The curve loops to be checked.

## Returns
Returns true if curve loops are ok, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

