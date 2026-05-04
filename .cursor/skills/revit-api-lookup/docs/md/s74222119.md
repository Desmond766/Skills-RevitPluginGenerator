---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.GetFirstCoreLayerIndex
source: html/db2884a9-bd2a-e7be-eb95-d8dd5e74ee59.htm
---
# Autodesk.Revit.DB.CompoundStructure.GetFirstCoreLayerIndex Method

Gets the index of the first core layer.

## Syntax (C#)
```csharp
public int GetFirstCoreLayerIndex()
```

## Returns
The index of the first core layer.

## Remarks
This is the index on the exterior side. You can change the shell/core layer boundary
 using SetNumberOfShellLayers(ShellLayerType, Int32) .

