---
kind: method
id: M:Autodesk.Revit.DB.LinePatternElement.GetLinePattern(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/230a23fa-45d0-d698-2e2d-61d2ecfad0a6.htm
---
# Autodesk.Revit.DB.LinePatternElement.GetLinePattern Method

Gets the LinePattern associated to an element or from a built-in line pattern.

## Syntax (C#)
```csharp
public static LinePattern GetLinePattern(
	Document document,
	ElementId elementId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which to retrieve the LinePattern.
- **elementId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the LinePatternElement or the built-in line pattern id.

## Returns
A copy of LinePattern object. Nothing nullptr a null reference ( Nothing in Visual Basic) if the ElementId doesn't represent a line pattern element
 or built-in line pattern. Nothing nullptr a null reference ( Nothing in Visual Basic) for Solid.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

