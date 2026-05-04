---
kind: method
id: M:Autodesk.Revit.DB.Lighting.InitialFluxIntensity.#ctor(System.Double)
source: html/db3110fa-a76f-7070-4d92-fd320d3314b5.htm
---
# Autodesk.Revit.DB.Lighting.InitialFluxIntensity.#ctor Method

Creates an initial flux intensity object with the given document and flux values.

## Syntax (C#)
```csharp
public InitialFluxIntensity(
	double flux
)
```

## Parameters
- **flux** (`System.Double`) - The flux value in lm as a numerical value between 0 and 1e+30.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The flux intensity value is not valid because it is not between 0 and 1e+30.

