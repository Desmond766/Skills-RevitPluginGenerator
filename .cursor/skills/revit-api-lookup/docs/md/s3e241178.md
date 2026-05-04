---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MEPSection.IsMain(Autodesk.Revit.DB.ElementId)
source: html/f34bf304-f7b3-caa1-3fa5-a737284cfd26.htm
---
# Autodesk.Revit.DB.Mechanical.MEPSection.IsMain Method

Check whether the type of fitting in this section is main.

## Syntax (C#)
```csharp
public bool IsMain(
	ElementId fittingId
)
```

## Parameters
- **fittingId** (`Autodesk.Revit.DB.ElementId`) - The element id which can be duct fitting and pipe fitting.

## Returns
True if the type of fitting in this section is main
 False if the type of fitting in this section is branch

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId fittingId does not correspond to a valid section fitting member.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

