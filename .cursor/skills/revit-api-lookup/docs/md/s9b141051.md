---
kind: method
id: M:Autodesk.Revit.DB.Frame.#ctor(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
source: html/54dba681-7199-f73f-2908-9bbe54689f6d.htm
---
# Autodesk.Revit.DB.Frame.#ctor Method

Constructor that takes the frame's base point and three basis vectors.

## Syntax (C#)
```csharp
public Frame(
	XYZ origin,
	XYZ vec1,
	XYZ vec2,
	XYZ vec3
)
```

## Parameters
- **origin** (`Autodesk.Revit.DB.XYZ`) - The frame's base point.
- **vec1** (`Autodesk.Revit.DB.XYZ`) - The frame's first basis vector.
- **vec2** (`Autodesk.Revit.DB.XYZ`) - The frame's second basis vector.
- **vec3** (`Autodesk.Revit.DB.XYZ`) - The frame's third basis vector.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

