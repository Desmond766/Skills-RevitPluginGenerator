---
kind: method
id: M:Autodesk.Revit.DB.FormatOptions.IsValidAccuracy(System.Double)
source: html/64a12011-e340-8516-2007-9c6dfc35f86e.htm
---
# Autodesk.Revit.DB.FormatOptions.IsValidAccuracy Method

Checks whether an accuracy is valid for the display unit in this FormatOptions.

## Syntax (C#)
```csharp
public bool IsValidAccuracy(
	double accuracy
)
```

## Parameters
- **accuracy** (`System.Double`) - The accuracy to check.

## Returns
True if the accuracy is valid, false otherwise.

## Remarks
See the Accuracy property for details on
 valid accuracy values.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - UseDefault is true in this FormatOptions.

