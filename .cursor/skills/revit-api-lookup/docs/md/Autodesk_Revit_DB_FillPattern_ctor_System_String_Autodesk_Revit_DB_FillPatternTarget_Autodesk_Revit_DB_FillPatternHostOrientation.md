---
kind: method
id: M:Autodesk.Revit.DB.FillPattern.#ctor(System.String,Autodesk.Revit.DB.FillPatternTarget,Autodesk.Revit.DB.FillPatternHostOrientation)
source: html/0b76f862-e80a-391a-fb4b-b71ae42c7d21.htm
---
# Autodesk.Revit.DB.FillPattern.#ctor Method

Creates a fill pattern based on the given name, FillPatternTarget and FillPatternHostOrientation.

## Syntax (C#)
```csharp
public FillPattern(
	string name,
	FillPatternTarget target,
	FillPatternHostOrientation orientation
)
```

## Parameters
- **name** (`System.String`) - The name.
- **target** (`Autodesk.Revit.DB.FillPatternTarget`) - The fill pattern target.
- **orientation** (`Autodesk.Revit.DB.FillPatternHostOrientation`) - The fill pattern orientation.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

