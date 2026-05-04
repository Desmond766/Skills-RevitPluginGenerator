---
kind: method
id: M:Autodesk.Revit.DB.NumericRevisionSettings.IsEqual(Autodesk.Revit.DB.NumericRevisionSettings)
source: html/4c375631-2618-34dc-a9e8-849613b08ab7.htm
---
# Autodesk.Revit.DB.NumericRevisionSettings.IsEqual Method

Determines whether a specified NumericRevisionSettings is the same as 'this'.

## Syntax (C#)
```csharp
public bool IsEqual(
	NumericRevisionSettings other
)
```

## Parameters
- **other** (`Autodesk.Revit.DB.NumericRevisionSettings`) - The specified NumericRevisionSettings with which to compare.

## Returns
True, if two NumericRevisionSettings are the same.

## Remarks
The two NumericRevisionSettings are regarded as the same only if they have the same start number,
 prefix and suffix strings.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

