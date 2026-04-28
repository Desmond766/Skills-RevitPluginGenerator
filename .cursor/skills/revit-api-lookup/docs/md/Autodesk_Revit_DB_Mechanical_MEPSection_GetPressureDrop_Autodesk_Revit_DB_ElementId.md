---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MEPSection.GetPressureDrop(Autodesk.Revit.DB.ElementId)
source: html/2bc07e50-9324-7854-a6a4-b8f5d43b0862.htm
---
# Autodesk.Revit.DB.Mechanical.MEPSection.GetPressureDrop Method

Gets the pressure drop for the specified element id in this section.

## Syntax (C#)
```csharp
public double GetPressureDrop(
	ElementId elemId
)
```

## Parameters
- **elemId** (`Autodesk.Revit.DB.ElementId`) - The element id which can be duct segment, duct fitting , pipe segment and pipe fitting.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId elemId does not correspond to a valid section member.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

