---
kind: property
id: P:Autodesk.Revit.DB.NumericRevisionSettings.MinimumDigits
source: html/3e9653ff-d2e7-3058-0bbd-6fb6649b81a0.htm
---
# Autodesk.Revit.DB.NumericRevisionSettings.MinimumDigits Property

Controls the minimum number of digits for a revision number.

## Syntax (C#)
```csharp
public int MinimumDigits { get; set; }
```

## Remarks
Use MinimumDigits to force the minimum number of digits for a revision number.
 Zeros will be added to the front of the revision number until the minimum number of digits is satisfied.
 For example, if MinimumDigits is 3, then 9 will be printed as 009 and 10 will be printed as 010.
 If MinimumDigits is 1, then no zeros are added to the front of the revision number.
 The default value for MinimumDigits is 1. Values less than 1 are not allowed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for minimumDigits is not positive.

