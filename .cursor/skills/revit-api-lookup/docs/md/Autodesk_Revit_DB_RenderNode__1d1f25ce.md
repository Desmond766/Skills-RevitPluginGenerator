---
kind: type
id: T:Autodesk.Revit.DB.RenderNode
source: html/9900b69b-7cb7-8555-75ac-4b5f22b5fa7f.htm
---
# Autodesk.Revit.DB.RenderNode

This is the base class of all render nodes in a model-exporting process.

## Syntax (C#)
```csharp
public class RenderNode : IDisposable
```

## Remarks
A node can be both geometric (such as an element, light, etc.) or non-geometric (e.g. material).
 Some types of nodes are container modes, which include other render nodes.

