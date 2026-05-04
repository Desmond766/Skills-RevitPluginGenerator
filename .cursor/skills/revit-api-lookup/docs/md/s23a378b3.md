---
kind: method
id: M:Autodesk.Revit.DB.RepeatingReferenceSource.GetReference(Autodesk.Revit.DB.RepeaterCoordinates)
source: html/e8d034c9-e440-4aab-7c6d-1ad80a509704.htm
---
# Autodesk.Revit.DB.RepeatingReferenceSource.GetReference Method

Returns an individual repeating reference given by coordinates in the array, or Nothing nullptr a null reference ( Nothing in Visual Basic) if there is no reference at the coordinates (for example if there is a hole in a divided surface.)

## Syntax (C#)
```csharp
public Reference GetReference(
	RepeaterCoordinates coordinates
)
```

## Parameters
- **coordinates** (`Autodesk.Revit.DB.RepeaterCoordinates`) - The coordinates in the array of repeating references.

## Returns
The repeating reference.

## Remarks
The coordinates must be within the bounds of the repeating reference source.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The coordinates are not valid for the repeating reference source. This could be because of a mismatched dimensionality or because the coordinates are outside the bounds of the repeating reference source.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The repeating reference source is no longer valid.

