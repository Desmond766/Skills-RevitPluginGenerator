---
kind: method
id: M:Autodesk.Revit.DB.TessellatedShapeBuilder.OpenConnectedFaceSet(System.Boolean)
source: html/186da29a-caa2-99ea-1b2a-722c1656c44a.htm
---
# Autodesk.Revit.DB.TessellatedShapeBuilder.OpenConnectedFaceSet Method

Opens a new connected face set.

## Syntax (C#)
```csharp
public void OpenConnectedFaceSet(
	bool isSolid
)
```

## Parameters
- **isSolid** (`System.Boolean`) - Whether the face set, which is being open, should be build as a solid or as a void.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - A face set is open and a geometry cannot be build until it is closed.

