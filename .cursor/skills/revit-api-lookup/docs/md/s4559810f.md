---
kind: method
id: M:Autodesk.Revit.DB.SolidSolidCutUtils.SplitFacesOfCuttingSolid(Autodesk.Revit.DB.Element,Autodesk.Revit.DB.Element,System.Boolean)
source: html/7c6d00a4-616b-0828-27cc-d4f117e5d561.htm
---
# Autodesk.Revit.DB.SolidSolidCutUtils.SplitFacesOfCuttingSolid Method

Causes the faces of the cutting element where it intersects the element it is cutting to be split or unsplit.

## Syntax (C#)
```csharp
public static void SplitFacesOfCuttingSolid(
	Element first,
	Element second,
	bool split
)
```

## Parameters
- **first** (`Autodesk.Revit.DB.Element`) - The solid being cut or the cutting solid
- **second** (`Autodesk.Revit.DB.Element`) - The solid being cut or the cutting solid
- **split** (`System.Boolean`) - True to split the faces of intersection, false to unsplit them.

## Remarks
There must be a cut between the input elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - There is no solid-solid cut between the input elements.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Unable to split or unsplit faces of cutting solid

