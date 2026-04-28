---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinitionByArc.#ctor(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Structure.RebarShapeDefinitionByArcType)
source: html/dcbcb0ed-b1ac-499f-fed0-44d8ff69951b.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinitionByArc.#ctor Method

Create a non-spiral shape definition.

## Syntax (C#)
```csharp
public RebarShapeDefinitionByArc(
	Document doc,
	RebarShapeDefinitionByArcType type
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`)
- **type** (`Autodesk.Revit.DB.Structure.RebarShapeDefinitionByArcType`)

## Remarks
Replaces RebarShape.NewDefinitionByArc() from prior versions.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The arc type cannot be set directly
 to Spiral. Instead, call SetArcTypeSpiral() to provide defaults
 for spiral parameters.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

