---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.AreSolidsEqual(Autodesk.Revit.DB.Solid,Autodesk.Revit.DB.Solid,Autodesk.Revit.DB.Transform@)
source: html/03ca1f74-2bd8-a93c-ddf8-377e5a337c6c.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.AreSolidsEqual Method

Determines whether two solids are identical, potentially offset from each other.

## Syntax (C#)
```csharp
public static bool AreSolidsEqual(
	Solid first,
	Solid second,
	out Transform trf
)
```

## Parameters
- **first** (`Autodesk.Revit.DB.Solid`) - The first solid.
- **second** (`Autodesk.Revit.DB.Solid`) - The second solid
- **trf** (`Autodesk.Revit.DB.Transform %`) - The offset transform

## Returns
True if they are identical, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

