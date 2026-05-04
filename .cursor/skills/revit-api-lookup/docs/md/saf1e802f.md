---
kind: type
id: T:Autodesk.Revit.DB.LineProperties
source: html/baddd6a0-35a8-c547-2566-ae7846799856.htm
---
# Autodesk.Revit.DB.LineProperties

A structure that has access to the pen properties of lines/curves
 that are currently being drawn/exported via an export context
 during a custom export process.

## Syntax (C#)
```csharp
public class LineProperties : IDisposable
```

## Remarks
For more about using properties of this class refer to the interface
 IModelExportContext and its methods
 which handle geometric objects such as OnCurve(CurveNode) ,
 OnLineSegment(LineSegment) , etc.
 LineProperties are available as a read-only property on the respective output nodes,
 i.e. CurveNode , LineSegment , etc.

