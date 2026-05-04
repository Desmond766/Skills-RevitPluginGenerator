---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.GetLastCoreLayerIndex
source: html/4e32008c-8d6a-5368-a4d9-4e3e103bce9d.htm
---
# Autodesk.Revit.DB.CompoundStructure.GetLastCoreLayerIndex Method

Gets the index of the last core layer.

## Syntax (C#)
```csharp
public int GetLastCoreLayerIndex()
```

## Returns
The index of the last core layer.

## Remarks
This is the index on the interior side. You can change the shell/core layer boundary
 using SetNumberOfShellLayers(ShellLayerType, Int32) .

