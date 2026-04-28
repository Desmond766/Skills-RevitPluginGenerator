---
kind: type
id: T:Autodesk.Revit.DB.ExtrusionAnalyzer
source: html/ba9e3283-6868-8834-e8bf-2ea9e7358930.htm
---
# Autodesk.Revit.DB.ExtrusionAnalyzer

This geometry utility allows you to attempt to "fit" a given piece of geometry into
 the shape of an extrusion.

## Syntax (C#)
```csharp
public class ExtrusionAnalyzer : IDisposable
```

## Remarks
An instance of this class is a single-time use class which should be supplied a
 solid geometry, a plane, and a direction. The utility will calculate a base boundary
 parallel to the input plane which is the outer boundary of the shadow cast by the
 solid onto the input plane and along the extrusion direction. After the extrusion has been calculated, the class permits a second step
 analysis to identify all faces from the original geometry which do not align with the
 faces of the calculated extrusion. This utility works best for geometry which are at least somewhat "extrusion-like",
 for example, the geometry of a wall which may or may not be affected by end joins,
 floor joins, roof joins, openings cut by windows and doors, or other
 modifications.

