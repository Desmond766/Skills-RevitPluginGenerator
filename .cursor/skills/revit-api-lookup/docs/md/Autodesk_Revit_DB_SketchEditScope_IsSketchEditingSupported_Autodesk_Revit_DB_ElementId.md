---
kind: method
id: M:Autodesk.Revit.DB.SketchEditScope.IsSketchEditingSupported(Autodesk.Revit.DB.ElementId)
source: html/1357d62d-1b59-f552-ec7b-36cda2127e41.htm
---
# Autodesk.Revit.DB.SketchEditScope.IsSketchEditingSupported Method

Checks whether sketch can be edited.

## Syntax (C#)
```csharp
public bool IsSketchEditingSupported(
	ElementId sketchId
)
```

## Parameters
- **sketchId** (`Autodesk.Revit.DB.ElementId`) - The element id of sketch.

## Returns
True if sketch can be edited, false otherwise.

## Remarks
This method checks if this particular sketch can be edited.
 If you want to check if all sketches of an element can be edited please use IsSketchEditingSupportedForSketchBasedElement(ElementId)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

