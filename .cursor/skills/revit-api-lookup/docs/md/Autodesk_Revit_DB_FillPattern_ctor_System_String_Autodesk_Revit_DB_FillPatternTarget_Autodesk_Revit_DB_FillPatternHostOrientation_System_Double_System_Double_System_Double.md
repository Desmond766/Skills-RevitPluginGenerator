---
kind: method
id: M:Autodesk.Revit.DB.FillPattern.#ctor(System.String,Autodesk.Revit.DB.FillPatternTarget,Autodesk.Revit.DB.FillPatternHostOrientation,System.Double,System.Double,System.Double)
source: html/6e3e1d3b-454f-510b-6651-0ea4885e3c4e.htm
---
# Autodesk.Revit.DB.FillPattern.#ctor Method

Creates a simple crosshatch fill pattern based on the given name, angle, spacing, FillPatternTarget and FillPatternHostOrientation.

## Syntax (C#)
```csharp
public FillPattern(
	string name,
	FillPatternTarget target,
	FillPatternHostOrientation orientation,
	double angle,
	double spacing1,
	double spacing2
)
```

## Parameters
- **name** (`System.String`) - The name.
- **target** (`Autodesk.Revit.DB.FillPatternTarget`) - The fill pattern target.
- **orientation** (`Autodesk.Revit.DB.FillPatternHostOrientation`) - The fill pattern orientation.
- **angle** (`System.Double`) - The angle.
- **spacing1** (`System.Double`) - The spacing.
- **spacing2** (`System.Double`) - The spacing.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

