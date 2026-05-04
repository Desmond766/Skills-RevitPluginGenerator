---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.SetLayoutAsNumberWithSpacing(System.Int32,System.Double)
source: html/6ff04299-3217-c078-5f59-3f058c071bb2.htm
---
# Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.SetLayoutAsNumberWithSpacing Method

Sets the Layout Rule property of rebar set to Number With Spacing.

## Syntax (C#)
```csharp
public void SetLayoutAsNumberWithSpacing(
	int numberOfBars,
	double spacing
)
```

## Parameters
- **numberOfBars** (`System.Int32`) - The number of bars in set.
- **spacing** (`System.Double`) - The spacing of bars in set.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarFreeFormAccessor doesn't contain a valid rebar reference.
 -or-
 This RebarFreeFormAccessor Rebar doesn't contain a valid server GUID.

