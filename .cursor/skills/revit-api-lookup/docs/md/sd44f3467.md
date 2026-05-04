---
kind: method
id: M:Autodesk.Revit.DB.Analysis.ValueAtPoint.#ctor(System.Collections.Generic.IList{System.Double})
source: html/cd1cb171-039b-e444-ac26-8046d3940802.htm
---
# Autodesk.Revit.DB.Analysis.ValueAtPoint.#ctor Method

Creates object from an array of values

## Syntax (C#)
```csharp
public ValueAtPoint(
	IList<double> values
)
```

## Parameters
- **values** (`System.Collections.Generic.IList < Double >`) - Array of values, each corresponding to "measurement"

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when supplied values contain invalid (infinite or non-number) doubles
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

