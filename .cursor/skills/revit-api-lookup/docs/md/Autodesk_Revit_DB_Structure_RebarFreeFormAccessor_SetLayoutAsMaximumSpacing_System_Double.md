---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.SetLayoutAsMaximumSpacing(System.Double)
source: html/45957132-0208-54f9-c191-00ae98333a15.htm
---
# Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.SetLayoutAsMaximumSpacing Method

Sets the Layout Rule property of rebar set to Maximum Spacing.

## Syntax (C#)
```csharp
public void SetLayoutAsMaximumSpacing(
	double spacing
)
```

## Parameters
- **spacing** (`System.Double`) - The maximum spacing of bars in set.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarFreeFormAccessor doesn't contain a valid rebar reference.
 -or-
 This RebarFreeFormAccessor Rebar doesn't contain a valid server GUID.

