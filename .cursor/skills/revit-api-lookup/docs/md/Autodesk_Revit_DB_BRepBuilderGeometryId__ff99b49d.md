---
kind: type
id: T:Autodesk.Revit.DB.BRepBuilderGeometryId
source: html/f7d0b679-926a-9f1d-8f2a-dda9c2f3fe7a.htm
---
# Autodesk.Revit.DB.BRepBuilderGeometryId

This class is used by the BRepBuilder class to identify objects it creates (faces, edges, etc.).

## Syntax (C#)
```csharp
public class BRepBuilderGeometryId : IDisposable
```

## Remarks
The user should use these ids to organize the calls to BRepBuilder methods (e.g., addLoop() takes a face id as input,
 referring to a face that was previously added by a call to AddFace()). The ids are only valid while the BRepBuilder is in use.

