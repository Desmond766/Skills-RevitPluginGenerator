---
kind: method
id: M:Autodesk.Revit.DB.NumberingSchema.ShiftNumbers(System.String,System.Int32)
source: html/8962e7e3-0860-acd5-c488-d8f93867b1c1.htm
---
# Autodesk.Revit.DB.NumberingSchema.ShiftNumbers Method

Shifts all numbers in the sequence so the starting number has the given value.

## Syntax (C#)
```csharp
public void ShiftNumbers(
	string partition,
	int firstNumber
)
```

## Parameters
- **partition** (`System.String`) - Name of the partition that identifies the sequence. The sequence must exist.
- **firstNumber** (`System.Int32`) - Value for the new first (lowest) number of the sequence.

## Remarks
A shift of all numbers in the sequence will be computed and applied
 so the first (lowest) number in the sequence would have the given value.
 All the other numbers will then be shifted relatively by the same amount. Any existing gaps in the current numbering sequence will be preserved. Shifts that would make the start number less than 1 or bigger than
 MaximumStartingNumber are considered invalid.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The sequence partition does not exist in the schema.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - firstNumber must be in range between 1 and MaximumStartingNumber.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Either the schema or its document cannot be modified at present.

