---
kind: type
id: T:Autodesk.Revit.DB.MaterialNode
source: html/c70338a6-7f40-e89e-607b-47162df3a5ef.htm
---
# Autodesk.Revit.DB.MaterialNode

This class represents a change of material during a model-exporting process.

## Syntax (C#)
```csharp
public class MaterialNode : RenderNode
```

## Remarks
Output nodes following this node are to be assumed using the material.
 The material remains in effect until another material node is sent to the output.
See also: OnMaterial(MaterialNode) .

