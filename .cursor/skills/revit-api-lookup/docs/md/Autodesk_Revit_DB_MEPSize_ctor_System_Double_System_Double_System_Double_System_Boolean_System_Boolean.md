---
kind: method
id: M:Autodesk.Revit.DB.MEPSize.#ctor(System.Double,System.Double,System.Double,System.Boolean,System.Boolean)
source: html/2b62459f-5470-7a37-83ff-5d4b28b68f85.htm
---
# Autodesk.Revit.DB.MEPSize.#ctor Method

Constructs an object that stores the basic size information for MEP duct, pipe, cable tray and conduit.

## Syntax (C#)
```csharp
public MEPSize(
	double nominalDiameter,
	double innerDiameter,
	double outerDiameter,
	bool usedInSizeLists,
	bool usedInSizing
)
```

## Parameters
- **nominalDiameter** (`System.Double`) - Nominal diameter. The value should be a valid, positive Revit length.
- **innerDiameter** (`System.Double`) - Inner diameter. The value should be a valid, positive Revit length.
- **outerDiameter** (`System.Double`) - Outer diameter. The value should be a valid, positive Revit length.
- **usedInSizeLists** (`System.Boolean`) - Whether it is used in size lists.
- **usedInSizing** (`System.Boolean`) - Whether is used in sizing.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for nominalDiameter must be greater than 0 and no more than 30000 feet.
 -or-
 The given value for innerDiameter must be greater than 0 and no more than 30000 feet.
 -or-
 The given value for outerDiameter must be greater than 0 and no more than 30000 feet.

