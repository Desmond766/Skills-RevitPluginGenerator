---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.GetParameterValueAtIndex(Autodesk.Revit.DB.ElementId,System.Int32)
zh: 钢筋、配筋
source: html/d4d5a126-4e14-8fda-bbb9-2178b7162486.htm
---
# Autodesk.Revit.DB.Structure.Rebar.GetParameterValueAtIndex Method

**中文**: 钢筋、配筋

Get the parameter value for a bar at the specified index.
 The parameter Id.
 The bar index in the rebar distribution. Accepts only values between 0 and NumberOfBarPositions-1.
 The ParameterValue for given parameterId and barPositionIndex.
 Throws exception if barPositionIndex is outside boundaries.

## Syntax (C#)
```csharp
public ParameterValue GetParameterValueAtIndex(
	ElementId paramId,
	int barPositionIndex
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`)
- **barPositionIndex** (`System.Int32`)

## Remarks
If the DistributionType is Uniform then the returned ParameterValue is the same no matter the index.
 If the DistributionType is VaryingLength then the returned ParameterValue is evaluated at the given index.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - barPositionIndex is not in the range [ 0, NumberOfBarPositions-1 ].

