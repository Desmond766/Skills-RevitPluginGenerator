---
kind: method
id: M:Autodesk.Revit.DB.SlabShapeEditor.ModifySubElement(Autodesk.Revit.DB.SlabShapeCrease,System.Double)
source: html/a2d107e1-fc23-5579-0d99-2ce20e41d207.htm
---
# Autodesk.Revit.DB.SlabShapeEditor.ModifySubElement Method

Manipulates the crease on the corresponding slab, roof or floor.

## Syntax (C#)
```csharp
public void ModifySubElement(
	SlabShapeCrease crease,
	double offset
)
```

## Parameters
- **crease** (`Autodesk.Revit.DB.SlabShapeCrease`) - The crease.
- **offset** (`System.Double`) - The new value of the crease offset, which is the average of offsets of its ends.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the crease is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the crease is invalid.

