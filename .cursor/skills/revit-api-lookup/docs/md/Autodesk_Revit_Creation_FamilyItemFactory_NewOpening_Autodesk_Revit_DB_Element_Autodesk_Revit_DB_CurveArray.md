---
kind: method
id: M:Autodesk.Revit.Creation.FamilyItemFactory.NewOpening(Autodesk.Revit.DB.Element,Autodesk.Revit.DB.CurveArray)
source: html/b869aa8a-0c97-8d20-fee8-82c67849294f.htm
---
# Autodesk.Revit.Creation.FamilyItemFactory.NewOpening Method

Create an opening to cut the wall or ceiling.

## Syntax (C#)
```csharp
public Opening NewOpening(
	Element host,
	CurveArray profile
)
```

## Parameters
- **host** (`Autodesk.Revit.DB.Element`) - Host elements that new opening would lie in. The host can only be a wall or a ceiling.
- **profile** (`Autodesk.Revit.DB.CurveArray`) - The profile of the newly created opening. This may contain more 
than one curve loop. Each loop must be a fully closed curve loop and the loops may not 
intersect. The profiles will be projected into the host plane.

## Returns
If successful, the newly created opening is returned, otherwise an
exception with error information will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument host or profile is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when host isn't a wall or a ceiling.
Thrown when profile doesn't contain any loops.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when opening creation failed.

