---
kind: method
id: M:Autodesk.Revit.DB.NumberingSchema.GetMinimumNumberOfDigits(Autodesk.Revit.DB.Document)
source: html/80ac3f63-6383-ba62-380f-0e61b98e8dd7.htm
---
# Autodesk.Revit.DB.NumberingSchema.GetMinimumNumberOfDigits Method

Returns the minimum number of digits to be used for formating
 the Number parameter of all enumerable elements of the given document.

## Syntax (C#)
```csharp
public static int GetMinimumNumberOfDigits(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document this value is going to be applied to.

## Returns
The current number of formatting digits

## Remarks
The number is used by all numbering schemas in the document. The value can be modified by using the SetMinimumNumberOfDigits(Document, Int32) method.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

