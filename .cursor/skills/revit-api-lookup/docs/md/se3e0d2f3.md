---
kind: method
id: M:Autodesk.Revit.DB.IndependentTag.HasTagBehavior
zh: 标记、打标、标签
source: html/fadc39b4-eb80-2e00-f9af-e5752a0bb498.htm
---
# Autodesk.Revit.DB.IndependentTag.HasTagBehavior Method

**中文**: 标记、打标、标签

Checks if the IndependentTag has a tag behavior.

## Syntax (C#)
```csharp
public bool HasTagBehavior()
```

## Remarks
When the IndependentTag object does not have a tag behavior, functions related to references, leaders and orientation will throw an exception.
 In this case, the element may be used for geometry augmentation. [!:Autodesk::Revit::Proxy::DB::IGeometryAugmentationServer] 
 The list of functions that would fail if not in tag mode:
 [M:Autodesk.Revit.DB.IndependentTag.AddReferences(System.Collections.Generic.IList`1{Autodesk.Revit.DB.Reference})] GetLeaderElbow(Reference) GetLeaderEnd(Reference) HasLeader HasLeaderElbow(Reference) IsLeaderVisible(Reference) LeaderEndCondition LeadersPresentationMode MergeElbows [M:Autodesk.Revit.DB.IndependentTag.RemoveReferences(System.Collections.Generic.IList`1{Autodesk.Revit.DB.Reference})] SetIsLeaderVisible(Reference, Boolean) SetLeaderEnd(Reference, XYZ) SetLeaderElbow(Reference, XYZ) TagOrientation TagText

