---
kind: method
id: M:Autodesk.Revit.DB.Lighting.CustomInitialColor.#ctor(System.Double)
source: html/e47b95b5-fa9b-45bb-a82d-18babe8193a4.htm
---
# Autodesk.Revit.DB.Lighting.CustomInitialColor.#ctor Method

Creates a custom initial color set to the given color

## Syntax (C#)
```csharp
public CustomInitialColor(
	double temperature
)
```

## Parameters
- **temperature** (`System.Double`) - The color temperature in Kelvin as a numerical value between 1800 and 20000

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The color temperature is not valid because it is not in the range of 1800 to 20000.

