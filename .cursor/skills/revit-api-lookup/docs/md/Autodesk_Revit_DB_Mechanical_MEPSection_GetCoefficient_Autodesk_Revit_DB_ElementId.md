---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MEPSection.GetCoefficient(Autodesk.Revit.DB.ElementId)
source: html/446a70e3-cad6-ecb5-2bbe-080fa3977bb4.htm
---
# Autodesk.Revit.DB.Mechanical.MEPSection.GetCoefficient Method

Gets the loss coefficient for the specified element id in this section.

## Syntax (C#)
```csharp
public double GetCoefficient(
	ElementId elemId
)
```

## Parameters
- **elemId** (`Autodesk.Revit.DB.ElementId`) - The element id which can be duct segment, duct fitting , pipe segment and pipe fitting.

## Remarks
For Duct, it is loss coefficient.
 For Pipe, the loss coefficient is equivalent to the friction factor.
 Loss coefficient is a number.
 The unit type is UT_Number.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId elemId does not correspond to a valid section member.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

