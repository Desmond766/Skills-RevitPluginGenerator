---
kind: method
id: M:Autodesk.Revit.DB.Analysis.FieldValues.#ctor(System.Collections.Generic.IList{Autodesk.Revit.DB.Analysis.ValueAtPoint})
source: html/053ac7c0-5297-84bf-7fc3-06af67bbbb3c.htm
---
# Autodesk.Revit.DB.Analysis.FieldValues.#ctor Method

Creates object from an array of domain point values

## Syntax (C#)
```csharp
public FieldValues(
	IList<ValueAtPoint> valueAtPoint
)
```

## Parameters
- **valueAtPoint** (`System.Collections.Generic.IList < ValueAtPoint >`) - Array of values, each corresponding to a domain point

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - valueAtPoint array contains members with different numbers of measurements
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

