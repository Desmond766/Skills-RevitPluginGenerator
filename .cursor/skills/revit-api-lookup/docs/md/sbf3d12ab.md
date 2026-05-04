---
kind: method
id: M:Autodesk.Revit.DB.NumberingSchema.GetNumbers(System.String)
source: html/3153106d-9f77-eb5d-20af-cd651e91b640.htm
---
# Autodesk.Revit.DB.NumberingSchema.GetNumbers Method

Returns all numbers currently used in the given numbering sequence

## Syntax (C#)
```csharp
public IList<IntegerRange> GetNumbers(
	string partition
)
```

## Parameters
- **partition** (`System.String`) - Name of the partition that identifies the sequence. The sequence must exist.

## Returns
A collection of integer ranges

## Remarks
Numbers are returned as a collection of ranges, where each range
 is a pair of two integer values, Low and High. As long as there is
 no gap currently in the sequence, there will be only one range.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The sequence partition does not exist in the schema.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

