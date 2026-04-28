---
kind: method
id: M:Autodesk.Revit.DB.SketchEditScope.StartWithNewSketch(Autodesk.Revit.DB.ElementId)
source: html/4150d043-a5bf-60ba-b986-11f1dc01eedf.htm
---
# Autodesk.Revit.DB.SketchEditScope.StartWithNewSketch Method

Starts a sketch edit mode for an element which, at this moment, doesn't have a sketch.

## Syntax (C#)
```csharp
public void StartWithNewSketch(
	ElementId elementId
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - The Element without sketch to be edited.

## Remarks
Some surface Revit elements (like some Walls or some Analytical Elements) does not have a valid sketch all the time so in order to edit them, we have to create a valid sketch first.
 The application will need to start a transaction to actually make changes to the element.
 SketchEditScope can only be started when there is no transaction active, thus it does not
 work for commands running in automatic transaction mode.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId elementId already has a sketch defined.
 -or-
 Element does not support sketch editing.
 -or-
 Failed to start the sketch edit mode.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This SketchEditScope is not permitted to start at this moment for one of the following possible reasons:
 The document is in read-only state, or the document is currently modifiable,
 or there already is another edit mode active in the document.
 -or-
 Cannot create sketch.

