---
kind: method
id: M:Autodesk.Revit.DB.Wall.CreateProfileSketch
zh: 墙、墙体
source: html/d582a742-d89d-6edb-90e2-dd16633bd8b8.htm
---
# Autodesk.Revit.DB.Wall.CreateProfileSketch Method

**中文**: 墙、墙体

Creates a new Wall profile Sketch.

## Syntax (C#)
```csharp
public Sketch CreateProfileSketch()
```

## Returns
Created profile Sketch of the Wall.

## Remarks
The loop of the sketch cannot be obtained until regeneration.
 To regenerate the document use Regenerate () () () .
 To edit the Wall profile use [!:Autodesk::Revit::DB::SketchEditScope] .

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Wall does not support profile Sketch as it is not a straight wall; or is tapered;
 or it is an old curtain wall; or it is an infill wall; or it is a replacement curtain panel.
 -or-
 Wall already has a sketch.

