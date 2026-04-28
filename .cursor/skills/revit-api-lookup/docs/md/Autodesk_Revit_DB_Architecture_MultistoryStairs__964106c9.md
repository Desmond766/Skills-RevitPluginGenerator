---
kind: type
id: T:Autodesk.Revit.DB.Architecture.MultistoryStairs
source: html/8b07cbff-013c-889f-8807-703e63a91923.htm
---
# Autodesk.Revit.DB.Architecture.MultistoryStairs

Represents a multistory stairs element in Autodesk Revit.

## Syntax (C#)
```csharp
public class MultistoryStairs : Element
```

## Remarks
A multistory stairs element may contain multiple stairs whose extents are governed by base and top levels.
 Use [M:Autodesk.Revit.DB.Architecture.MultistoryStairs.ConnectLevels(System.Collections.Generic.ISet`1{Autodesk.Revit.DB.ElementId})] and [M:Autodesk.Revit.DB.Architecture.MultistoryStairs.DisconnectLevels(System.Collections.Generic.ISet`1{Autodesk.Revit.DB.ElementId})] to add and remove connected levels to a multistory stairs element. This element will contain one or more Stairs elements. These can be obtained via GetAllStairsIds () () () and GetStairsOnLevel(ElementId) .
 Stairs elements are either a reference instance which is copied to each level covered by groups of identical stairs instances which share the same level height,
 or individual Stairs instances which are not connected to a group with the same level height. By default, when adding new levels to the multistory stair,
 new stairs will be added to the group (shown in the Revit user interface with a 'Pin' icon). For groups of duplicate stairs at different levels, the instances can be found as Subelements of the Stairs element (see
 GetSubelements () () () . Stairs in a connected group can be edited together by modifying the associated Stairs instance. For specific floors that need special designs,
 stairs can be separated from a group by unpinning the element, changes made to this Stairs will not affect other any other instance in the element.
 Use Unpin(ElementId) for this. You can add the stairs back into the group via Pin(ElementId) if needed. However, any changes made to the stair will be lost since the stair's properties
 will be overridden by the group specifications.

