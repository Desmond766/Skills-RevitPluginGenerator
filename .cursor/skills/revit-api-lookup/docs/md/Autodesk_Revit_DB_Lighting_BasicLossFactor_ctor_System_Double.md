---
kind: method
id: M:Autodesk.Revit.DB.Lighting.BasicLossFactor.#ctor(System.Double)
source: html/2af06d5c-12f2-90fb-1eab-cf6b1b0e489c.htm
---
# Autodesk.Revit.DB.Lighting.BasicLossFactor.#ctor Method

Creates a basic loss factor object with the given value.

## Syntax (C#)
```csharp
public BasicLossFactor(
	double lossFactorIn
)
```

## Parameters
- **lossFactorIn** (`System.Double`) - The loss factor as a numerical value between 0.0 and 4.0

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The loss factor is not valid because it is not between 0.0 and 4.0.

