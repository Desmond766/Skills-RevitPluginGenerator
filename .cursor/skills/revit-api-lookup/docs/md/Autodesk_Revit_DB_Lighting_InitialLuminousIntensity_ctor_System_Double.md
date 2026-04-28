---
kind: method
id: M:Autodesk.Revit.DB.Lighting.InitialLuminousIntensity.#ctor(System.Double)
source: html/baef9352-b5fa-2fc4-2cb3-d67f49e4f08b.htm
---
# Autodesk.Revit.DB.Lighting.InitialLuminousIntensity.#ctor Method

Creates an initial luminous intensity object with the given document and luminosity values.

## Syntax (C#)
```csharp
public InitialLuminousIntensity(
	double luminosity
)
```

## Parameters
- **luminosity** (`System.Double`) - The luminosity value in cd as a numerical value between 0 and 1e+30.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The luminosity value is not valid because it is not between 0 and 1e+30.

