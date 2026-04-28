---
kind: method
id: M:Autodesk.Revit.DB.CurveElementFilter.#ctor(Autodesk.Revit.DB.CurveElementType,System.Boolean)
source: html/b38b796e-fbae-c29d-747e-0b49e9fc4258.htm
---
# Autodesk.Revit.DB.CurveElementFilter.#ctor Method

Constructs a new instance of a filter to match specific types of curve elements,
 with the option to match all curves which are not of the given curve type.

## Syntax (C#)
```csharp
public CurveElementFilter(
	CurveElementType curveElementType,
	bool inverted
)
```

## Parameters
- **curveElementType** (`Autodesk.Revit.DB.CurveElementType`) - The curve element type to match.
- **inverted** (`System.Boolean`) - True if the filter should match all curves which are not of the given curve type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

