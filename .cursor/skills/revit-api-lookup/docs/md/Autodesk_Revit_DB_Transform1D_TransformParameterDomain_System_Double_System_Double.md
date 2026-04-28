---
kind: method
id: M:Autodesk.Revit.DB.Transform1D.TransformParameterDomain(System.Double,System.Double)
source: html/fe97e6d2-eea0-26e5-0d32-16281ea95d19.htm
---
# Autodesk.Revit.DB.Transform1D.TransformParameterDomain Method

Performs a transform of the parameter range defined by domain, and ensures that the domain is ordered correctly.

## Syntax (C#)
```csharp
public IList<double> TransformParameterDomain(
	double domainStart,
	double domainEnd
)
```

## Parameters
- **domainStart** (`System.Double`) - The original parameter domain start.
- **domainEnd** (`System.Double`) - The original parameter domain end.

## Remarks
If the domain is empty it is unchanged.

