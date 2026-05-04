---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.SetLayoutAsMinimumClearSpacing(System.Double)
source: html/9f22ba8b-df0c-31fe-14f4-62e1ee79a04f.htm
---
# Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.SetLayoutAsMinimumClearSpacing Method

Sets the Layout Rule property of rebar set to Minimum Clear Spacing.

## Syntax (C#)
```csharp
public void SetLayoutAsMinimumClearSpacing(
	double spacing
)
```

## Parameters
- **spacing** (`System.Double`) - The maximum spacing of bars in set.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarFreeFormAccessor doesn't contain a valid rebar reference.
 -or-
 This RebarFreeFormAccessor Rebar doesn't contain a valid server GUID.

