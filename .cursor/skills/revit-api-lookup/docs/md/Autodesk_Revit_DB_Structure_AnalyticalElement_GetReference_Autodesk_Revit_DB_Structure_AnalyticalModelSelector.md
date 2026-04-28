---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalElement.GetReference(Autodesk.Revit.DB.Structure.AnalyticalModelSelector)
source: html/9804934b-e6dd-3a0f-5994-30307fecca2d.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalElement.GetReference Method

Returns a reference to a given curve within the Analytical Element.

## Syntax (C#)
```csharp
public Reference GetReference(
	AnalyticalModelSelector selector
)
```

## Parameters
- **selector** (`Autodesk.Revit.DB.Structure.AnalyticalModelSelector`) - Specifies where in the Analytical Element the reference lies.

## Returns
Requested reference.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - selector is not valid for this AnalyticalElement.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

