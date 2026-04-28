---
kind: method
id: M:Autodesk.Revit.DB.Analysis.VectorAtPoint.#ctor(System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ})
source: html/02d307b6-9e0b-692f-1325-346d314b94e8.htm
---
# Autodesk.Revit.DB.Analysis.VectorAtPoint.#ctor Method

Creates object from an array of vectors

## Syntax (C#)
```csharp
public VectorAtPoint(
	IList<XYZ> vectors
)
```

## Parameters
- **vectors** (`System.Collections.Generic.IList < XYZ >`) - Array of vectors, each corresponding to "measurement"

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when supplied vectors contain invalid (infinite or non-number) coordinates
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

