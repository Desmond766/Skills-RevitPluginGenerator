---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ConduitSizeSettings.RemoveSize(System.String,System.Double)
source: html/e16228d0-e1a4-d583-aa5f-4338390688d3.htm
---
# Autodesk.Revit.DB.Electrical.ConduitSizeSettings.RemoveSize Method

Erase the existing ConduitSize with this nominal diameter. The conduit standard name determines the location of the size in the size table.

## Syntax (C#)
```csharp
public void RemoveSize(
	string standardName,
	double nominalDiameter
)
```

## Parameters
- **standardName** (`System.String`) - The conduit standard name.
- **nominalDiameter** (`System.Double`) - Nominal diameter.

## Remarks
Does nothing if there is no existing ConduitSize with this nominal diameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for nominalDiameter must be greater than 0 and no more than 30000 feet.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The function is called during iterating the size set.

