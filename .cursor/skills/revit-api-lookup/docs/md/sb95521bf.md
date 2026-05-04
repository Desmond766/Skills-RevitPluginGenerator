---
kind: property
id: P:Autodesk.Revit.DB.SunAndShadowSettings.SharesSettings
source: html/8cfd7bb8-754b-e1ee-4eb9-c43f9acdd65b.htm
---
# Autodesk.Revit.DB.SunAndShadowSettings.SharesSettings Property

Identifies whether settings are shared globally.

## Syntax (C#)
```csharp
public bool SharesSettings { get; set; }
```

## Remarks
Identifies whether the per-view SunAndShadowSettings element shares global settings.
 Global settings are a special case that allows multiple views to be associated together
 in order that a change in one view affects that same change in other views. There cannot be
 multiple such groups, and a SunAndShadowSettings element is either a global setting or not.

