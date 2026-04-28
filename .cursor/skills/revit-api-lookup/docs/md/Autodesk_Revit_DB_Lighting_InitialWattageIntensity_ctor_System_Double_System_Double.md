---
kind: method
id: M:Autodesk.Revit.DB.Lighting.InitialWattageIntensity.#ctor(System.Double,System.Double)
source: html/dad7bc1c-cc85-32b6-9351-1697e4e7c4ee.htm
---
# Autodesk.Revit.DB.Lighting.InitialWattageIntensity.#ctor Method

Creates an initial wattage intensity object with the given values.

## Syntax (C#)
```csharp
public InitialWattageIntensity(
	double efficacy,
	double wattage
)
```

## Parameters
- **efficacy** (`System.Double`) - The universal unit efficacy value as a numerical value between 0 and 1e+30.
- **wattage** (`System.Double`) - The universal unit wattage value as a numerical value between 0 and 1e+30.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The efficacy value is not valid because it is not between 0 and 1e+30.
 -or-
 The wattage value is not valid because it is not between 0 and 1e+30.

