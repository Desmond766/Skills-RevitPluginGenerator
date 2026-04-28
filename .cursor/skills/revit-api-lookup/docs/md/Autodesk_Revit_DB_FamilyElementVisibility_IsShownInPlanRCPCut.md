---
kind: property
id: P:Autodesk.Revit.DB.FamilyElementVisibility.IsShownInPlanRCPCut
source: html/4c7a5cb7-7e5e-0336-4da2-6c14354c01a6.htm
---
# Autodesk.Revit.DB.FamilyElementVisibility.IsShownInPlanRCPCut Property

Indicates if the instance is displayed when cut in Plan/RCP (if the category permits).

## Syntax (C#)
```csharp
public bool IsShownInPlanRCPCut { get; set; }
```

## Remarks
controls whether the Model Family Element is shown when a FamilyInstance 
of that Family is cut in a Plan/RCP view, i.e. the cut plane passes through the 
bounding box of the instance. It only has a meaning for categories that are "cut in the symbol". For 
non-cuttable categories it is always false and for ones that are "cuttable in the 
instance" it is the same as the IsShownInTopBottom.

