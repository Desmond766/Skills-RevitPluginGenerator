---
kind: type
id: T:Autodesk.Revit.DB.CompoundStructure
source: html/dc1a081e-8dab-565f-145d-a429098d353c.htm
---
# Autodesk.Revit.DB.CompoundStructure

Describes the internal structure of a wall, floor, roof or ceiling.

## Syntax (C#)
```csharp
public class CompoundStructure : IDisposable
```

## Remarks
A compound structure consists a collection of ordered layers, proceeding from exterior to interior for a wall, or from top to bottom for a
 floor, roof or ceiling. The properties of these layers determine the
 thickness, material, and function of the overall structure of the associated wall, floor, roof or ceiling. Layers can
 be accessed via the GetLayers () () () method and completely replaced using SetLayers. Layers
 can also be accessed and modified individually using the "layer index", which is a value from in the range [0, LayerCount)
 identifying the layer in the structure. A structure supports the concept of "core layers" and "shell layers". There are two layer indices which identify
 where the boundary between core and shell layers occur in the list of layers. The boundaries between shell and core layers
 are identifiable using
 GetFirstCoreLayerIndex () () () , GetLastCoreLayerIndex () () () , GetCoreBoundaryLayerIndex(ShellLayerType) 
 or GetNumberOfShellLayers(ShellLayerType) . The core layer boundary can be changed with SetNumberOfShellLayers(ShellLayerType, Int32) .
 Compound structures may be vertically compound. If IsVerticallyCompound is false,
 the CompoundStructure describes a series of parallel layers, each with specified width, function, material and other properties.
 If IsVerticallyCompound is true (which should apply only for CompoundStructures assigned to walls) then
 horizontal sections at different elevations may have different layered
 structures. In this case, the structure describes a vertical section via a rectangle
 which is divided into polygonal regions whose sides are all vertical or horizontal segments.
 A map associates each of these regions with the index of a layer in the CompoundStructure which
 determines the properties of that region.

