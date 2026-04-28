---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarHostData.SetCoverType(Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.Structure.RebarCoverType)
source: html/58674efc-3bf7-d999-78c8-3a490bb601f0.htm
---
# Autodesk.Revit.DB.Structure.RebarHostData.SetCoverType Method

Associates the specified CoverType with the specified face of the element.

## Syntax (C#)
```csharp
public void SetCoverType(
	Reference face,
	RebarCoverType coverType
)
```

## Parameters
- **face** (`Autodesk.Revit.DB.Reference`)
- **coverType** (`Autodesk.Revit.DB.Structure.RebarCoverType`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - In this element, face does not have an associated CoverType, because
 it is not exposed.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

