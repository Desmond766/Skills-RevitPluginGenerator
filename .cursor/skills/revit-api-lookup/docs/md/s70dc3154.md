---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShape.GetAllowed(Autodesk.Revit.DB.Structure.RebarBarType)
source: html/20f58bef-6bf7-63c6-d50d-61eb1d74ee4d.htm
---
# Autodesk.Revit.DB.Structure.RebarShape.GetAllowed Method

Check whether a bar type can be used with this RebarShape. Bar types are allowed by default.

## Syntax (C#)
```csharp
public bool GetAllowed(
	RebarBarType barType
)
```

## Parameters
- **barType** (`Autodesk.Revit.DB.Structure.RebarBarType`) - A bar type in the same document as this shape.

## Returns
True if this shape may be combined with this barType.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

