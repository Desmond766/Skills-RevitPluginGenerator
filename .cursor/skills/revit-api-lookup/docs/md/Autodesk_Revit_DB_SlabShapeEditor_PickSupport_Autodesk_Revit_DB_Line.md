---
kind: method
id: M:Autodesk.Revit.DB.SlabShapeEditor.PickSupport(Autodesk.Revit.DB.Line)
source: html/ff7dace3-8a34-3760-042d-21d1da8733f1.htm
---
# Autodesk.Revit.DB.SlabShapeEditor.PickSupport Method

Picks an element to support the slab. This method will define split lines and create constant bearing lines for the slab.

## Syntax (C#)
```csharp
public void PickSupport(
	Line gLine
)
```

## Parameters
- **gLine** (`Autodesk.Revit.DB.Line`) - A line from a support element such as a beam.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input line is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input line is invalid.

