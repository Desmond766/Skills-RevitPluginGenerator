---
kind: method
id: M:Autodesk.Revit.DB.BRepBuilder.RemovedSomeFaces
source: html/e5cb0e49-8c1a-9bd0-7867-c6a18b2d258a.htm
---
# Autodesk.Revit.DB.BRepBuilder.RemovedSomeFaces Method

Returns 'true' if BRepBuilder removed some problematic faces from the output geometry, 'false' if not.
 If allowRemovalOfProblematicFaces was not called to enable removal of problematic faces, this function
 will return 'false'. Note that if some faces were removed, the output geometry's type will be OpenShell
 regardless of the expected type that was specified when the BRepBuilder was created.

## Syntax (C#)
```csharp
public bool RemovedSomeFaces()
```

## Returns
True if BRepBuilder removed some faces, false if not.

