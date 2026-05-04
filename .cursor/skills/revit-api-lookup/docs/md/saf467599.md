---
kind: method
id: M:Autodesk.Revit.DB.NumberingSchema.ChangeNumber(System.String,System.Int32,System.Int32)
source: html/dc93cd7f-dc11-45da-3ed6-c459d1c55c97.htm
---
# Autodesk.Revit.DB.NumberingSchema.ChangeNumber Method

Replaces an existing number with a new one (that does not exist yet).

## Syntax (C#)
```csharp
public IList<ElementId> ChangeNumber(
	string partition,
	int fromNumber,
	int toNumber
)
```

## Parameters
- **partition** (`System.String`) - Name of the partition that identifies the sequence containing the number to be changed.
- **fromNumber** (`System.Int32`) - Number to be changed; there must already be an element with that number in the sequence.
- **toNumber** (`System.Int32`) - Number to change to; no element must have this number yet in the sequence.

## Returns
A collection of elements affected by the change of the number

## Remarks
This method gives the caller the ability to overwrite any number used in a given
 numbering sequence as long as the new number does not exist in the same sequence yet.
 If an attempt is made to replace a number by another that already exists, an exception
 will be thrown. The new number will automatically be applied to all elements that bear the original
 number, thus those elements must be free to be modified. A collection of element Ids
 of all the affected elements is returned by this method. The method is independent of the sequence's current starting number that might have
 been assigned previously, meaning that the new number will be accepted even if it is
 lower than the previously set start number in the sequence.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The sequence partition does not exist in the schema.
 -or-
 The specified sequence does not contain any elements with the given fromNumber.
 -or-
 There already are elements with the given toNumber in the specified sequence.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The value of toNumber must be in the range from 1 to the maximum value for an Integer type
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Either the schema or its document cannot be modified at present.

