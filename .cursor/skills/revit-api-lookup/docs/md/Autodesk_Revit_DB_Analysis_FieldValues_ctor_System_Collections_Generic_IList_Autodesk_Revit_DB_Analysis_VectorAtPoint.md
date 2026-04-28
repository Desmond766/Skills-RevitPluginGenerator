---
kind: method
id: M:Autodesk.Revit.DB.Analysis.FieldValues.#ctor(System.Collections.Generic.IList{Autodesk.Revit.DB.Analysis.VectorAtPoint})
source: html/0630f2f8-6f36-2a29-bdfb-2aa7d85caf96.htm
---
# Autodesk.Revit.DB.Analysis.FieldValues.#ctor Method

Creates object from an array of domain point vectors

## Syntax (C#)
```csharp
public FieldValues(
	IList<VectorAtPoint> vectorAtPoint
)
```

## Parameters
- **vectorAtPoint** (`System.Collections.Generic.IList < VectorAtPoint >`) - Array of vectors, each corresponding to a domain point

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Members of vectorAtPoint contain different numbers of measurements
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

