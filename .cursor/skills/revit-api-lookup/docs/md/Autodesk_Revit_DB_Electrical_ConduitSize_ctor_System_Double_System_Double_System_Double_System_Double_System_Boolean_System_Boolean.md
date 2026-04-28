---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ConduitSize.#ctor(System.Double,System.Double,System.Double,System.Double,System.Boolean,System.Boolean)
source: html/f5d205f4-b70d-d48a-51de-86d807d06efd.htm
---
# Autodesk.Revit.DB.Electrical.ConduitSize.#ctor Method

Constructs an object that stores the basic size information for conduit.

## Syntax (C#)
```csharp
public ConduitSize(
	double nominalDiameter,
	double innerDiameter,
	double outerDiameter,
	double bendRadius,
	bool usedInSizeLists,
	bool usedInSizing
)
```

## Parameters
- **nominalDiameter** (`System.Double`) - Nominal diameter. The value should be a valid, positive Revit length.
- **innerDiameter** (`System.Double`) - Inner diameter. The value should be a valid, positive Revit length.
- **outerDiameter** (`System.Double`) - Outer diameter. The value should be a valid, positive Revit length.
- **bendRadius** (`System.Double`) - Minimum bend radius. The value should be a valid, positive Revit length.
- **usedInSizeLists** (`System.Boolean`) - Whether it is used in size lists.
- **usedInSizing** (`System.Boolean`) - Whether is used in sizing.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for nominalDiameter must be greater than 0 and no more than 30000 feet.
 -or-
 The given value for innerDiameter must be greater than 0 and no more than 30000 feet.
 -or-
 The given value for outerDiameter must be greater than 0 and no more than 30000 feet.
 -or-
 The given value for bendRadius must be greater than 0 and no more than 30000 feet.

