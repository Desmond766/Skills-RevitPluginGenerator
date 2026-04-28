---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalModelSelector.#ctor(Autodesk.Revit.DB.Curve)
source: html/c49a0fa0-da10-f7c9-c7da-6bbaa8c7dc6b.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalModelSelector.#ctor Method

Creates a selector based on a specific analytical curve.

## Syntax (C#)
```csharp
public AnalyticalModelSelector(
	Curve curve
)
```

## Parameters
- **curve** (`Autodesk.Revit.DB.Curve`) - The curve upon which this selector acts.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input curve points to a helical curve and is not supported for this operation.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

