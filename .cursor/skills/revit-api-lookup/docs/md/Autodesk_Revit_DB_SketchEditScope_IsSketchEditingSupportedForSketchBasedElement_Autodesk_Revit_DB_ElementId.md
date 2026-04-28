---
kind: method
id: M:Autodesk.Revit.DB.SketchEditScope.IsSketchEditingSupportedForSketchBasedElement(Autodesk.Revit.DB.ElementId)
source: html/4b851561-91b8-291e-ce3d-02dd0467152d.htm
---
# Autodesk.Revit.DB.SketchEditScope.IsSketchEditingSupportedForSketchBasedElement Method

Checks whether the element supports sketch editing.

## Syntax (C#)
```csharp
public bool IsSketchEditingSupportedForSketchBasedElement(
	ElementId elemId
)
```

## Parameters
- **elemId** (`Autodesk.Revit.DB.ElementId`) - The element id to be checked.

## Returns
True if element supports sketch editing, false otherwise.

## Remarks
This method checks if the element supports edit to all its sketches.
 If you want to check if this element supports edit to a particular sketch please use IsSketchEditingSupported(ElementId) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

