---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.ConstraintsCanBeEdited
zh: 钢筋、配筋
source: html/37eec9d2-eac9-b7a9-723a-82f1791ee350.htm
---
# Autodesk.Revit.DB.Structure.Rebar.ConstraintsCanBeEdited Method

**中文**: 钢筋、配筋

For ShapeDriven Rebar:
 returns true, if the Rebar element's external constraints are available for editing using the
 RebarConstraintsManager class. It will return false if Rebar is in Group For FreeForm rebar:
 constraints can be edited if there is a valid external server Guid assigned to that Rebar

## Syntax (C#)
```csharp
public bool ConstraintsCanBeEdited()
```

