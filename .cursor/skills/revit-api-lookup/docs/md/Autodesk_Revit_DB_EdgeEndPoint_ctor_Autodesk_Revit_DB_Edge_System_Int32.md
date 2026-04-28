---
kind: method
id: M:Autodesk.Revit.DB.EdgeEndPoint.#ctor(Autodesk.Revit.DB.Edge,System.Int32)
source: html/90e66b0d-9710-07c9-4c78-80cbf722e262.htm
---
# Autodesk.Revit.DB.EdgeEndPoint.#ctor Method

Constructs an instance of EdgeEndPoint.

## Syntax (C#)
```csharp
public EdgeEndPoint(
	Edge edge,
	int index
)
```

## Parameters
- **edge** (`Autodesk.Revit.DB.Edge`) - The Edge.
- **index** (`System.Int32`) - Use 0 for the start point, 1 for the end point of an Edge.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for index is not 0 or 1.

