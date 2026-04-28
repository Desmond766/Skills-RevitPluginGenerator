---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarHostData.IsFaceExposed(Autodesk.Revit.DB.Reference)
source: html/61392ae4-888e-70a3-2240-9e5e8bc63b81.htm
---
# Autodesk.Revit.DB.Structure.RebarHostData.IsFaceExposed Method

Checks whether the specified face is considered exposed, and
 therefore has an associated CoverType.

## Syntax (C#)
```csharp
public bool IsFaceExposed(
	Reference face
)
```

## Parameters
- **face** (`Autodesk.Revit.DB.Reference`)

## Returns
True if %face% is exposed, false otherwise.

## Remarks
This method replaces the method HasCoverTypeForReference() from
 the 2011 Revit API.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

