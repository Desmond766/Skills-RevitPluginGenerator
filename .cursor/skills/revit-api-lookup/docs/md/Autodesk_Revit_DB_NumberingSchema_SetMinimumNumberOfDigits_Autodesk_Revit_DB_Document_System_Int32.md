---
kind: method
id: M:Autodesk.Revit.DB.NumberingSchema.SetMinimumNumberOfDigits(Autodesk.Revit.DB.Document,System.Int32)
source: html/5b78eda1-9ad6-9c9d-bfe4-bdb6752c262f.htm
---
# Autodesk.Revit.DB.NumberingSchema.SetMinimumNumberOfDigits Method

Sets a new value for the minimum number of digits to be used for formating
 the Number parameter of all numbered elements of the given document.

## Syntax (C#)
```csharp
public static void SetMinimumNumberOfDigits(
	Document document,
	int value
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the new value will be in applied.
- **value** (`System.Int32`) - New value for the minimum number of digits.

## Remarks
Valid values range from 1 to 10. Numbers with fewer digits
 than the minimum number will be padded with leading zeros. The value affects all numbering schemas. Thus, once set, numbers for
 Rebar and Reinforcement Fabric will be formatted with the same minimum number of digits. The current value can obtained by invoking the GetMinimumNumberOfDigits(Document) method.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The minimum number of digits must be in range from 1 to 10.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

