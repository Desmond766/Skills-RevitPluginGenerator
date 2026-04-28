---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewOpening(Autodesk.Revit.DB.Element,Autodesk.Revit.DB.CurveArray,System.Boolean)
zh: 文档、文件
source: html/8ff3c649-4d5a-67a6-81d7-3d1dca9e9955.htm
---
# Autodesk.Revit.Creation.Document.NewOpening Method

**中文**: 文档、文件

Creates a new opening in a roof, floor and ceiling.

## Syntax (C#)
```csharp
public Opening NewOpening(
	Element hostElement,
	CurveArray profile,
	bool bPerpendicularFace
)
```

## Parameters
- **hostElement** (`Autodesk.Revit.DB.Element`) - Host element of the opening. Can be a roof, floor, or ceiling.
- **profile** (`Autodesk.Revit.DB.CurveArray`) - Profile of the opening.
- **bPerpendicularFace** (`System.Boolean`) - True if the profile is cut perpendicular to the intersecting face of the host. False if the profile is cut vertically.

## Returns
If successful, an Opening object is returned.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the host element does not exist in the given document.

