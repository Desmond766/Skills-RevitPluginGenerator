---
kind: method
id: M:Autodesk.Revit.DB.SketchEditScope.Start(Autodesk.Revit.DB.ElementId)
source: html/73819f41-6564-48ce-9f00-25f5b74d41b2.htm
---
# Autodesk.Revit.DB.SketchEditScope.Start Method

Starts a sketch edit mode.

## Syntax (C#)
```csharp
public void Start(
	ElementId sketchId
)
```

## Parameters
- **sketchId** (`Autodesk.Revit.DB.ElementId`) - The Sketch element to be edited.

## Remarks
The application will need to start a transaction to actually make changes to the Sketch element.
 SketchEditScope can only be started when there is no transaction active, thus it does not
 work for commands running in automatic transaction mode.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId sketchId does not represent a Sketch.
 -or-
 Sketch does not support editing.
 -or-
 Failed to start the sketch edit mode.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This SketchEditScope is not permitted to start at this moment for one of the following possible reasons:
 The document is in read-only state, or the document is currently modifiable,
 or there already is another edit mode active in the document.

