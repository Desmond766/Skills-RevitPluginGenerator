---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.GetCustomDistributionPath
source: html/122a818c-2a81-ff20-2435-67b19e20e5af.htm
---
# Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.GetCustomDistributionPath Method

Gets the custom distribution path for free form rebar set.

## Syntax (C#)
```csharp
public IList<Curve> GetCustomDistributionPath()
```

## Returns
Returns an array of curves that represent the distribution path.

## Remarks
For a free form rebar set the distance between two consecutive bars may be different if it is calculated between different points on bars.
 The distribution path is an array of curves with the property that based on these curves the set was calculated to respect the layout rule and number of bars or spacing.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarFreeFormAccessor doesn't contain a valid rebar reference.
 -or-
 This RebarFreeFormAccessor Rebar doesn't contain a valid server GUID.

