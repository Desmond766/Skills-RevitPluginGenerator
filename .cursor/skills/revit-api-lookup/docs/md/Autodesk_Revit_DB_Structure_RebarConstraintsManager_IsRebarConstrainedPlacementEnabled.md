---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarConstraintsManager.IsRebarConstrainedPlacementEnabled
source: html/57d251df-b6a9-6b12-a3c2-22be9245c205.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraintsManager.IsRebarConstrainedPlacementEnabled Property

A static property defining if the 'Rebar Constrained Placement' setting is on or off in current Revit Application Session.

## Syntax (C#)
```csharp
public static bool IsRebarConstrainedPlacementEnabled { get; set; }
```

## Remarks
If user started multiple Revit sessions, and the 'Rebar Constrained Placement' setting might be different in each session.
 Revit.ini file stores the latest setting no matter what the Revit session is. The setting will be written to Revit.ini if user set the value.
 This property enables/disables constraints between standard style rebars.
 This constraint is similar to the standard-to-stirrup constraint in the following way :
 Distance to target cannot be edited.
 The constraint "snaps" the rebars together in a touching position.
 Rebars can be constrained under the following conditions :
 Rebars have standard style. (not stirrups) The segments must be touching. (partially overlapped) If the segments are perfectly overlapped (i.e segments have the same center line) then the constraint will not take place. Only one segment per rebar can be constrained. If one of the segments touches (intersects) more than one segment (or arc), then the constraint will not happen. The segments being constrained are parallel and the bending and segment planes are parallel.

