---
kind: method
id: M:Autodesk.Revit.DB.BRepBuilder.AllowRemovalOfProblematicFaces
source: html/727b6da1-e4d9-8077-c974-e7c1fb8ce34c.htm
---
# Autodesk.Revit.DB.BRepBuilder.AllowRemovalOfProblematicFaces Method

Allow BRepBuilder to remove problematic faces (e.g., due to inaccurate edge geometry). If this option is enabled and
 BRepBuilder removes some faces, the output geometry's type will be OpenShell regardless of the expected type specified
 when the BRepBuilder was created.

## Syntax (C#)
```csharp
public void AllowRemovalOfProblematicFaces()
```

