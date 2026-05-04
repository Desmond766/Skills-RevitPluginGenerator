---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralConnectionHandler.SetDefaultElementOrder
source: html/7b74ec8e-5790-0caa-5045-ef0ff72128fc.htm
---
# Autodesk.Revit.DB.Structure.StructuralConnectionHandler.SetDefaultElementOrder Method

Sorts the connected elements connection according to structural categories, element materials and geometries.
 The steel element is set rather than an element of other material.
 The priorities of the elements are set according structural categories in following order: columns, framings, walls, foundations, floors.
 In case of several Structural Framing elements order is determined by cutting - the cutting element is set as the primary one rather than element being cut.

## Syntax (C#)
```csharp
public void SetDefaultElementOrder()
```

